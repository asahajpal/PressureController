using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicReactor
{
    delegate void Notify(double reactorPressure);

    /// <summary>
    /// FissionChamber contains Reactor Vessel, it is process responsible for Pressure Increase
    /// in the ReactorVessel (which need to be controlled)
    /// </summary>
    interface IFissionChamber
    {
        event Notify NotifyPressureIncrease;
        void StartProcess();
        void StopProcess();
        IReactorVessel Vessel { get; set; }
    }
}
