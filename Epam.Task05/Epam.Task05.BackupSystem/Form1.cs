using System;
using System.IO;
using System.Windows.Forms;

namespace Epam.Task05.BackupSystem
{
    public partial class Form1 : Form
    {
        public string backup = @"C:\BackupSystem\Backup";
        public string tracking = @"C:\BackupSystem\Tracking";
        protected DateTime restoreTime;

        public Form1()
        {
            InitializeComponent();

            button1.Visible = false;
            textBox1.Text = backup;
            textBox2.Text = tracking;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            dateTimePicker2.Format = DateTimePickerFormat.Time;

            if (!Directory.Exists(tracking))
            {
                Directory.CreateDirectory(tracking);
            }
        }

        private void radioButton1CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                MessageBox.Show("The tracking was started");
            }

            BackupSystem backupSystem = new BackupSystem(this.tracking, this.backup, ".txt", true);
        }

        private void radioButton2CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void button1Click(object sender, EventArgs e)
        {
            this.restoreTime = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;
            BackupSystem backupSystem = new BackupSystem(this.tracking, this.backup, ".txt", false);
            backupSystem.RestoreTo(this.restoreTime);
        }
    }
}
