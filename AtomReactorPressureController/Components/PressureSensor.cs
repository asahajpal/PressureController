using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AtomicReactor
{
    public class PressureSensor : IPressureSensor
    {

        private IReactorVessel vessel;

        private bool Active { get; set; }
        private double minValue { get; set; }
        private double maxValue { get; set; }
        private double pressureFactor;

        public PressureSensor()
        {
            Active = false;
        }
       
        public void SetVessel(IReactorVessel vessel)
        {
            this.vessel = vessel;
            Active = true;
        }

        public double GetPressureReading()
        {
            if (Active)
            {
                minValue = vessel.MinPressure;
                maxValue = vessel.MaxPressure;
                pressureFactor = (vessel.Pressure - minValue) / (maxValue - minValue);
                return pressureFactor;
            }

            return -1;
        }
    }
}
