using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicReactor
{
    class ReactorVessel : IReactorVessel
    {
        public ReactorVessel()
        {
            Pressure = MinPressure = 10;
            MaxPressure = 112;
        }

        public double Pressure { get; set; }
        public double MinPressure { get; set; }
        public double MaxPressure { get; set; }

        public void DecreasePressure(double pDelta)
        {
            if (Pressure > MinPressure)
                Pressure = Pressure - pDelta;
        }

        public void IncreasePressure(double pDelta)
        {  
            if(Pressure < MaxPressure)
            Pressure = Pressure + pDelta;
        }
    }
}
