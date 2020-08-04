using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Alarm_clock
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        readonly SoundPlayer soundPlayer = new SoundPlayer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            MessageBox.Show("Your timer is started","Starting...");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                try
                {
                    soundPlayer.SoundLocation = "Alarm Clock Sound.wav";
                    soundPlayer.PlayLooping();
                }
                catch
                {
                    MessageBox.Show("Timer is finished!!");
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            soundPlayer.Stop();
            MessageBox.Show("Your timer is stopped", "Stopping...");
        }
    }
}
