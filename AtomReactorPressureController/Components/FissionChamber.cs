using System;
using System.Timers;

namespace AtomicReactor
{
    class FissionChamber : IFissionChamber
    {
        private IPressureController _pc;
        private readonly double _pressureIncreaseRate;
        private bool timerEventAdded;

        public FissionChamber(IReactorVessel vessel, IPressureController pc)
        {
            _pc = pc;
            _pc.NotifyTimerEvent += IncreasePressure;
            _pressureIncreaseRate = 0.03;  // pressure increase rate = 3%/s (given)
            timerEventAdded = true;
            Vessel = vessel;
        }

        private void IncreasePressure(double pressure, double prReading, double projPf )
        {
            var pDelta = _pressureIncreaseRate * Vessel.Pressure;

            Vessel.IncreasePressure(pDelta);
        }

        public IReactorVessel Vessel { get; set; }

        public void StartProcess()
        {
            if (!timerEventAdded)
            {
                _pc.NotifyTimerEvent += IncreasePressure;
                timerEventAdded = true;
            }
        }

        public void StopProcess()
        {
            if(timerEventAdded)
            {
                _pc.NotifyTimerEvent -= IncreasePressure;
                timerEventAdded = false;
            }
        }
    }
}