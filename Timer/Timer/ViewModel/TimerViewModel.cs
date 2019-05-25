using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.ViewModel
{
    class TimerViewModel
    {
        public Model.TimerModel Timer { get; set; }

        public TimerViewModel()
        {
            Timer = new Model.TimerModel();
        }
    }
}
