using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtomicReactor
{
    /// <summary>
    /// To-Do
    /// Make WrappedVolatileDouble as Immutable type to enforce any likely volatile reads or
    /// concurrent data-read conflicts
    /// </summary>
    public class WrappedVolatileDouble
    {
        public double Data { get; set; }
    }

    class ReactorVessel : IReactorVessel
    {
        private volatile WrappedVolatileDouble _pressure;

        public ReactorVessel()
        {
            _pressure = new WrappedVolatileDouble
            {
                Data = MinPressure = 10
            };
            MaxPressure = 17;
        }

        public double Pressure { get => _pressure.Data;
            private set => _pressure.Data = value; }
        public double MinPressure { get; set; }
        public double MaxPressure { get; set; }

        public void DecreasePressure(double pDelta)
        {
            lock (this)
            {
                while (Pressure <= MinPressure) Monitor.Wait(this);
                Pressure = Pressure - pDelta;
                Monitor.Pulse(this);
            }
        }

        public void IncreasePressure(double pDelta)
        {
            lock (this)
            {
                while (Pressure >= MaxPressure) Monitor.Wait(this);
                Pressure = Pressure + pDelta;
                Monitor.Pulse(this);
            }

        }
    }
}
