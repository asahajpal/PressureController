using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicReactor
{
    /// <summary>
    /// FissionChamber contains Reactor Vessel, it is process responsible for Pressure Increase
    /// in the ReactorVessel (which need to be controlled)
    /// </summary>
    interface IFissionChamber
    {
        void StartProcess();
        void StopProcess();
        IReactorVessel Vessel { get; set; }
    }
}
