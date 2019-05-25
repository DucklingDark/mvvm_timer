using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace Timer.Model
{
    struct Lap
    {
        public int number;
        public string lapTime;
    }

    class TimerModel : INotifyPropertyChanged
    {
        private string time;
        private ObservableCollection<Lap> laps;
        private DispatcherTimer dt;
        private long elapsedTime;

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public ObservableCollection<Lap> Laps
        {
            get { return laps; }
            set
            {
                laps = value;
                OnPropertyChanged("Laps");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimerModel()
        {
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += Timer_Tick;
            dt.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime += 1000;
            TimeSpan t = TimeSpan.FromMilliseconds(elapsedTime);
            Time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                 t.Hours, t.Minutes,
                                 t.Seconds);
        }
    }
}
