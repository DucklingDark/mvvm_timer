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
    class Lap : INotifyPropertyChanged
    {
        private int lapNumber;
        private string fullTime;
        private string lapTime;

        public int LapNumber
        {
            get { return lapNumber; }
            set
            {
                lapNumber = value;
                OnPropertyChanged("LapNumber");
            }
        }

        public string FullTime
        {
            get { return fullTime; }
            set
            {
                fullTime = value;
                OnPropertyChanged("FullTime");
            }
        }

        public string LapTime
        {
            get { return lapTime; }
            set
            {
                lapTime = value;
                OnPropertyChanged("LapTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class TimerModel : INotifyPropertyChanged
    {
        private string time;
        private ObservableCollection<Lap> laps;
        private DispatcherTimer dt;
        private long elapsedTime;
        private long lastTime;

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimerModel()
        {
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Tick += Timer_Tick;
            dt.Start();
            Laps = new ObservableCollection<Lap>();
            lastTime = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime += 1000;
            TimeSpan t = TimeSpan.FromMilliseconds(elapsedTime);
            Time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                 t.Hours, t.Minutes, t.Seconds);
        }

        public void AddLap()
        {
            string tempFullTime = "Общее время: " + Time;
            TimeSpan tempT = TimeSpan.FromMilliseconds(elapsedTime - lastTime);
            lastTime = elapsedTime;
            string tempLapTime = "Время круга: ";
            tempLapTime += string.Format("{0:D2}:{1:D2}:{2:D2}",
                                          tempT.Hours, tempT.Minutes, tempT.Seconds);
            Laps.Add(new Lap { LapNumber = Laps.Count + 1, LapTime = tempLapTime, FullTime = tempFullTime});
        }
    }
}
