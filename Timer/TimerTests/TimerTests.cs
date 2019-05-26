using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timer;
using Timer.Model;

namespace TimerTests
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        public void Test_No_Laps()
        {
            TimerModel timer = new TimerModel();

            Assert.AreEqual(0, timer.Laps.Count);
        }

        [TestMethod]
        public void Test_One_Lap()
        {
            TimerModel timer = new TimerModel();
            timer.AddLap();

            Assert.AreEqual(1, timer.Laps.Count);
        }

        [TestMethod]
        public void Test_Five_Laps()
        {
            TimerModel timer = new TimerModel();

            for (int i = 0; i < 5; i++)
                timer.AddLap();

            Assert.AreEqual(5, timer.Laps.Count);
        }

        [TestMethod]
        public void Test_Third_Lap_Number()
        {
            TimerModel timer = new TimerModel();

            for (int i = 0; i < 5; i++)
                timer.AddLap();

            Assert.AreEqual(3, timer.Laps[2].LapNumber);
        }

        [TestMethod]
        public void Test_No_Laps_After_Reset()
        {
            TimerModel timer = new TimerModel();

            for (int i = 0; i < 5; i++)
                timer.AddLap();

            timer.TimerReset();
            Assert.AreEqual(0, timer.Laps.Count);
        }
    }
}
