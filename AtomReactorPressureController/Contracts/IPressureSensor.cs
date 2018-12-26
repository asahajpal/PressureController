using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicReactor
{
    /// <summary>
    /// Pressure Sensor senses pressure of Reactor Vessel and converts it into
    /// PressureLoadFactor (0.0 - 1.0 ) 
    /// </summary>
    public interface IPressureSensor
    {
        void SetVessel(IReactorVessel vessel);
        double GetPressureReading();
        double GetProjectedPressureReading();
    }
}
