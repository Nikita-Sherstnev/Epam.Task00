using System;
using System.IO;

namespace Epam.Task05.BackupSystem
{
    public class BackupSystem
    {
        private readonly FileSystemWatcher fileWatcher;
        private readonly string trackingDirectory;
        private readonly string backupDirectory;
        private readonly string loggerFullpath;
        private readonly string filter;
        private StreamWriter logger = null;
        private int filesCount = 0;

        public BackupSystem(string trackingDirectory, string backupDirectory, string filter, bool isTracking)
        {
            this.trackingDirectory = trackingDirectory;
            this.backupDirectory = backupDirectory;
            this.filter = filter;
            loggerFullpath = Path.Combine(backupDirectory, "logger.txt");

            if (!Directory.Exists(backupDirectory) || !File.Exists(loggerFullpath))
            {
                Directory.CreateDirectory(backupDirectory);
                string[] filesInBackup = Directory.GetFiles(backupDirectory);
                foreach (var file in filesInBackup)
                {
                    File.Delete(file);
                }

                File.Create(loggerFullpath).Close();

                string[] allTrackingFiles = Directory.GetFiles(trackingDirectory, "*" + filter, SearchOption.AllDirectories);
                Save("Created", allTrackingFiles);
            }
            else
            {
                var files = Directory.GetFiles(this.backupDirectory, "Backup*" + filter, SearchOption.AllDirectories);
                filesCount = files.Length;
            }

            fileWatcher = new FileSystemWatcher(trackingDirectory);
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.Changed += FileSystemWatcherOnChanged;
            fileWatcher.Created += FileSystemWatcherOnCreated;
            fileWatcher.Deleted += FileSystemWatcherOnCreated;
            fileWatcher.Renamed += FileSystemWatcherOnRenamed;
            fileWatcher.Error += FileSystemWatcherOnError;
            fileWatcher.EnableRaisingEvents = isTracking;
        }

        void Recovery(StreamReader reader, string action)
        {
            string restoringFile;
            string renamedFile;
            string backupFile;
            string deletedFile;

            switch (action)
            {
                case "Created":
                    {
                        restoringFile = reader.ReadLine();
                        backupFile = reader.ReadLine();
                        Directory.CreateDirectory(Path.GetDirectoryName(restoringFile));
                        File.Copy(backupFile, restoringFile, true);
                        break;
                    }

                case "Changed":
                    {
                        restoringFile = reader.ReadLine();
                        backupFile = reader.ReadLine();
                        Directory.CreateDirectory(Path.GetDirectoryName(restoringFile));
                        File.Copy(backupFile, restoringFile, true);
                        break;
                    }

                case "Deleted":
                    {
                        deletedFile = reader.ReadLine();
                        File.Delete(reader.ReadLine());
                        break;
                    }

                case "Renamed":
                    {
                        restoringFile = reader.ReadLine();
                        renamedFile = reader.ReadLine();
                        File.Move(renamedFile, restoringFile);
                        break;
                    }

                default: break;
            }
        }

        public void RestoreTo(DateTime restorationTime)
        {
            if (fileWatcher.EnableRaisingEvents == true)
            {
                return;
            }

            StreamReader loggerReader = null;
            DateTime currentLoggerTime;
            string[] allFiles = Directory.GetFiles(trackingDirectory, "*" + filter, SearchOption.AllDirectories);
            foreach (var file in allFiles)
            {
                File.Delete(file);
            }

            using (loggerReader = new StreamReader(loggerFullpath))
            {
                bool result = DateTime.TryParse(loggerReader.ReadLine(), out currentLoggerTime);
                if (!result)
                {
                    throw new Exception("Parsing Error");
                }

                if (restorationTime < currentLoggerTime)
                {
                    restorationTime = currentLoggerTime;
                }

                while (restorationTime >= currentLoggerTime)
                {
                    string action = loggerReader.ReadLine();
                    Recovery(loggerReader, action);
                    if (loggerReader.Peek() < 0)
                    {
                        break;
                    }

                    currentLoggerTime = DateTime.Parse(loggerReader.ReadLine());
                }

                Console.WriteLine("Restoring is complete");
            }
        }

        private void Save(string fileEvent, params string[] trackingFilesFullpath)
        {
            using (logger = new StreamWriter(loggerFullpath, true))
            {
                var time = DateTime.Now.ToString();
                foreach (var trackingFileFullpath in trackingFilesFullpath)
                {
                    string backup_filename = Path.Combine(backupDirectory, "Backup" + filesCount.ToString() + ".txt");
                    string backup_file_fullpath = Path.Combine(backupDirectory, backup_filename);
                    File.Copy(trackingFileFullpath, backup_file_fullpath);

                    logger.WriteLine(time);
                    logger.WriteLine(fileEvent);
                    logger.WriteLine(trackingFileFullpath);
                    logger.WriteLine(backup_file_fullpath);

                    filesCount++;
                }
            }
        }

        private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.FullPath} was created");
            var tracking_file_fullpath = e.FullPath;
            Save("Created", tracking_file_fullpath);
        }

        private void FileSystemWatcherOnRenamed(object sender, RenamedEventArgs e)
        {
            var fileInfo = new FileInfo(e.OldFullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.OldFullPath} was renamed to {e.FullPath}");
            var time = DateTime.Now.ToString();
            using (logger = new StreamWriter(loggerFullpath, true))
            {
                logger.WriteLine(time);
                logger.WriteLine("Renamed");
                logger.WriteLine(e.FullPath);
                logger.WriteLine(e.OldFullPath);
            }
        }

        private void FileSystemWatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File:{e.FullPath} was changed");
            Save("Changed", e.FullPath);
        }

        private void FileSystemWatcherOnDeleted(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.FullPath);
            if (!File.Exists(e.FullPath) || fileInfo.Extension != filter)
            {
                return;
            }

            Console.WriteLine($"File: {e.FullPath} was deleted");

            using (logger = new StreamWriter(loggerFullpath, true))
            {
                logger.WriteLine(DateTime.Now.ToString());
                logger.WriteLine("Deleted");
                logger.WriteLine(e.FullPath);
            }
        }

        private void FileSystemWatcherOnError(object source, ErrorEventArgs e)
        {
            Console.WriteLine("The FileSystemWatcher was detected an error");
        }
    }
}
