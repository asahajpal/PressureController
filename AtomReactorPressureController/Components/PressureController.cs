using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AtomicReactor
{
    public class PressureController : IPressureController
    {
        private IPressureSensor pSensor;
        private IValve valve;
        private System.Timers.Timer timer;

        //private readonly double _pressureDecreaseRate = 0.06;  // pressure decrease rate is 6 %/s (given)
        private IFissionChamber fissionChamber;

        public event NotifyTimerEvent NotifyTimerEvent;
        public event NotifyValveActuation NotifyValveAction;

        private IReactorVessel Vessel { get; }

        public double OptimumPressureLoad { get; } = 0.56;

        public PressureController()
        {
            timer = new System.Timers.Timer(1000); //  1 sec timer
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            
            Vessel = new ReactorVessel();
            fissionChamber = new FissionChamber(Vessel, this);
            
            pSensor = new PressureSensor();
            pSensor.SetVessel(Vessel);
            valve = new Valve(this);            
            valve.SetVessel(Vessel);
            valve.NotifyValveAction += OnValveActivation;
        }

        private void OnValveActivation()
        {
            if (NotifyValveAction != null)
                NotifyValveAction();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var prReading = pSensor.GetPressureReading();
            var projPf = pSensor.GetProjectedPressureReading();
            var pr = Vessel.Pressure;
            if (NotifyTimerEvent != null)
                NotifyTimerEvent(pr, prReading, projPf);
        }

        public void StartProcess()
        {
            timer.Start();
        }

        public void StopProcess()
        {
            timer.Stop();
        }
    }
}
