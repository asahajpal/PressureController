using System;
using System.Timers;

namespace AtomicReactor
{
    class FissionChamber : IFissionChamber
    {
        public event Notify NotifyPressureIncrease;
        private System.Timers.Timer timer;
        private double pressureIncreaseRate;

        public FissionChamber(IReactorVessel vessel)
        {
            timer = new System.Timers.Timer(1000); //  1 sec timer
            pressureIncreaseRate = 0.03;  // pressure increase rate = 3%/s (given)
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            Vessel = vessel;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var pDelta = pressureIncreaseRate * Vessel.Pressure;
            Vessel.IncreasePressure(pDelta);
            if (NotifyPressureIncrease != null)
                NotifyPressureIncrease(Vessel.Pressure);
        }

        public IReactorVessel Vessel { get; set; }

        public void StartProcess()
        {
            timer.Enabled = true;
        }

        public void StopProcess()
        {
            timer.Enabled = false;
        }
    }
}