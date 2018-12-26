using System.Drawing.Text;

namespace AtomicReactor
{
    public delegate void NotifyTimerEvent(double reactorPressure, double pressureSensorReading, 
        double projSensorReading);

    public delegate void NotifyValveActuation();
    
    /// <summary>
    /// PressureController  keeps track of the rising pressure
    /// and keep it within optimum value using Valve and Pressure Sensor
    /// </summary>
    public interface IPressureController
    {
       event NotifyTimerEvent NotifyTimerEvent;
       event NotifyValveActuation NotifyValveAction;
        double OptimumPressureLoad { get; }
        void StartProcess();
       void StopProcess();
    }
}