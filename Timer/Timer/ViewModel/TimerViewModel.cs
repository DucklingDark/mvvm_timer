using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Timer.Model;

namespace Timer.ViewModel
{
    class TimerViewModel
    {
        public TimerModel Timer { get; set; }

        public TimerViewModel()
        {
            Timer = new TimerModel();
        }

        public ICommand AddLap
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Timer.AddLap();
                });
            }
        }
    }
}
