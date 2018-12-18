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
        private readonly double optimumPressureLoad = 0.56;   // optimum pressure load (given)
        private readonly double pressureDecreaseRate = 0.06;  // pressure decrease rate is 6 %/s (given)
        private IFissionChamber fissionChamber;

        public event NotifyViews NotifyViews;
        public event NotifyValveActuation NotifyValveAction;

        private IReactorVessel Vessel { get; }

        public PressureController()
        {
            Vessel = new ReactorVessel();
            fissionChamber = new FissionChamber(Vessel);           
            fissionChamber.NotifyPressureIncrease += OnPressureIncreaseEvent;
            pSensor = new PressureSensor();
            pSensor.SetVessel(Vessel);
            valve = new Valve();            
            valve.SetVessel(Vessel);
        }

        private void OnPressureIncreaseEvent(double vesselPressure)
        {
            if (NotifyViews != null)
                NotifyViews(vesselPressure, pSensor.GetPressureReading());
            MonitorPressureAndValveActuator(pSensor.GetPressureReading());
        }

        public void StartProcess()
        {
            fissionChamber.StartProcess();
        }

        public void StopProcess()
        {
            fissionChamber.StopProcess();
        }

        public void MonitorPressureAndValveActuator(double pf)
        {
            // if pressure factor exceeds optimum pressure load
            if (pf > optimumPressureLoad)
            {
                var pDelta = pressureDecreaseRate * Vessel.Pressure;
                if (NotifyValveAction != null)
                    NotifyValveAction();
                valve.Activate(pDelta);
            }
        }
    }
}
