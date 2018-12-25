using System;
using System.IO;

namespace Epam.Task06.BackUpSystem
{
    public class BackUpSystem
    {
        private readonly FileSystemWatcher fileWatcher;
        private StreamWriter logger = null;

        public event EventHandler OnDataRestored;

        private readonly string trackingDirectory;
        private readonly string backupDirectory;
        private readonly string loggerFullpath;
        private readonly string filter;
        private int filesCount = 0;

        public BackUpSystem(string trackingDirectory, string backupDirectory, string filter, bool isTracking)
        {
            this.trackingDirectory = trackingDirectory;
            this.backupDirectory = backupDirectory;
            this.filter = filter;
            loggerFullpath = Path.Combine(backupDirectory, "logger.txt");
            if (!Directory.Exists(backupDirectory) || !File.Exists(loggerFullpath))
            {
                Directory.CreateDirectory(backupDirectory);
                string[] files_in_backup = Directory.GetFiles(backupDirectory);
                foreach (var file in files_in_backup)
                {
                    File.Delete(file);
                }

                File.Create(loggerFullpath).Close();

                string[] all_tracking_files = Directory.GetFiles(trackingDirectory, "*" + filter, SearchOption.AllDirectories);
                Save("Created", all_tracking_files);
            }
            else
            {
                var c = Directory.GetFiles(this.backupDirectory, "BackUp*" + filter, SearchOption.AllDirectories);
                filesCount = c.Length;
            }

            fileWatcher = new FileSystemWatcher(trackingDirectory);
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.Changed += FileSystemWatcher_OnChanged;
            fileWatcher.Created += FileSystemWatcher_OnCreated;
            fileWatcher.Deleted += FileSystemWatcher_OnCreated;
            fileWatcher.Renamed += FileSystemWatcher_OnRenamed;
            fileWatcher.Error += FileSystemWatcher_OnError;
            fileWatcher.EnableRaisingEvents = isTracking;
        }

        public void RestoreTo(DateTime restoration_time)
        {
            if (fileWatcher.EnableRaisingEvents == true)
            {
                return;
            }

            StreamReader logger_reader = null;
            DateTime current_logger_time;
            string[] all_files = Directory.GetFiles(trackingDirectory, "*" + filter, SearchOption.AllDirectories);
            foreach (var file in all_files)
            {
                File.Delete(file);
            }

            using (logger_reader = new StreamReader(loggerFullpath))
            {
                bool result = DateTime.TryParse(logger_reader.ReadLine(), out current_logger_time);
                if (!result)
                {
                    throw new Exception("Parsing Error");
                }

                if (restoration_time < current_logger_time)
                {
                    restoration_time = current_logger_time;
                }

                while (restoration_time >= current_logger_time)
                {
                    string action = logger_reader.ReadLine();
                    Recovery(logger_reader, action);
                    if (logger_reader.Peek() < 0)
                    {
                        break;
                    }

                    current_logger_time = DateTime.Parse(logger_reader.ReadLine());
                }

                Console.WriteLine("Restoring has been done");
            }

            void Recovery(StreamReader reader, string action)
            {
                string restoring_file;
                string renamed_file;
                string backup_file;
                string deleted_file;
                switch (action)
                {
                    case "Created":
                        {
                            restoring_file = reader.ReadLine();
                            backup_file = reader.ReadLine();
                            Directory.CreateDirectory(Path.GetDirectoryName(restoring_file));
                            File.Copy(backup_file, restoring_file, true);
                            break;
                        }

                    case "Changed":
                        {
                            restoring_file = reader.ReadLine();
                            backup_file = reader.ReadLine();
                            Directory.CreateDirectory(Path.GetDirectoryName(restoring_file));
                            File.Copy(backup_file, restoring_file, true);
                            break;
                        }

                    case "Deleted":
                        {
                            deleted_file = reader.ReadLine();
                            File.Delete(reader.ReadLine());
                            break;
                        }

                    case "Renamed":
                        {
                            restoring_file = reader.ReadLine();
                            renamed_file = reader.ReadLine();
                            File.Move(renamed_file, restoring_file);
                            break;
                        }

                    default: break;
                }
            }
        }

        private void Save(string file_event, params string[] tracking_files_fullpath)
        {
            using (logger = new StreamWriter(loggerFullpath, true))
            {
                var time = DateTime.Now.ToString();
                foreach (var tracking_file_fullpath in tracking_files_fullpath)
                {
                    string backup_filename = Path.Combine(backupDirectory, "BackUp" + filesCount.ToString() + ".txt");
                    string backup_file_fullpath = Path.Combine(backupDirectory, backup_filename);
                    File.Copy(tracking_file_fullpath, backup_file_fullpath);

                    logger.WriteLine(time);
                    logger.WriteLine(file_event);
                    logger.WriteLine(tracking_file_fullpath);
                    logger.WriteLine(backup_file_fullpath);

                    filesCount++;
                }
            }

            logger.Close();
        }

        private void FileSystemWatcher_OnCreated(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.FullPath} has been created");
            var trackingFileFullpath = e.FullPath;
            Save("Created", trackingFileFullpath);
        }

        private void FileSystemWatcher_OnRenamed(object sender, RenamedEventArgs e)
        {
            var fileInfo = new FileInfo(e.OldFullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.OldFullPath} has been renamed to {e.FullPath}");
            var time = DateTime.Now.ToString();
            using (logger = new StreamWriter(loggerFullpath, true))
            {
                logger.WriteLine(time);
                logger.WriteLine("Renamed");
                logger.WriteLine(e.FullPath);
                logger.WriteLine(e.OldFullPath);
            }

            logger.Close();
        }

        private void FileSystemWatcher_OnChanged(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.FullPath} has been changed");
            Save("Changed", e.FullPath);
        }

        private void FileSystemWatcher_OnDeleted(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File: {e.FullPath} deleted");

            using (logger = new StreamWriter(loggerFullpath, true))
            {
                logger.WriteLine(DateTime.Now.ToString());
                logger.WriteLine("Deleted");
                logger.WriteLine(e.FullPath);
            }

            logger.Close();
        }

        private void FileSystemWatcher_OnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("The FileSystemWatcher has detected an error");

            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                Console.WriteLine("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message);
            }
        }
    }
}
