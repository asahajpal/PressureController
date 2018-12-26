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

        public double GetProjectedPressureReading()
        {
            // projected pressure in next 1 sec
            var pr1 = vessel.Pressure + 0.03 * vessel.Pressure;
            // projected pressure in next 2 sec
            var pr2 = pr1 * 0.03 + pr1;
            var minValue = vessel.MinPressure;
            var maxValue = vessel.MaxPressure;
            var projectedPressureFactor = (pr2 - minValue) / (maxValue - minValue);
            return projectedPressureFactor;
        }

    }
}
