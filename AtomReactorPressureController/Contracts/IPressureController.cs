using System.Drawing.Text;

namespace AtomicReactor
{
    public delegate void NotifyViews(double reactorPressure, double pressureSensorReading);

    public delegate void NotifyValveActuation();
    
    /// <summary>
    /// PressureController  keeps track of the rising pressure
    /// and keep it within optimum value using Valve and Pressure Sensor
    /// </summary>
    public interface IPressureController
    {
       event NotifyViews NotifyViews;
       event NotifyValveActuation NotifyValveAction;
       void StartProcess();
       void StopProcess();
       void MonitorPressureAndValveActuator(double s);
    }
}