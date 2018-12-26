using System.Windows.Forms;

namespace AtomicReactor
{
    /// <summary>
    /// Valve is used by PressureController for decreasing the pressure in ReactorVessel when it
    /// crosses optimum limit 
    /// </summary>
    ///
    
    public delegate void NotifyValveAction();
    /// 
    public interface IValve
    {
        event NotifyValveAction NotifyValveAction;
        void Activate(double pr, double pf, double projPf);
        void OpenValve();
        void CloseValve();
        void SetVessel(IReactorVessel device);
    }
}