using System.IO;
using System.Windows.Forms;
using Epam.Task06.BackUpSystem;

namespace Epam.Task05.BackupSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string backup = @"C:\BackupSystem\Backup";
            string tracking = @"C:\BackupSystem\Tracking";

            textBox1.Text = backup;
            textBox2.Text = tracking;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            dateTimePicker2.Format = DateTimePickerFormat.Time;

            if (!Directory.Exists(tracking))
            {
                Directory.CreateDirectory(tracking);
            }

            BackUpSystem backUpSystem = new BackUpSystem(tracking, backup, ".txt", true);
        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }
    }
}
