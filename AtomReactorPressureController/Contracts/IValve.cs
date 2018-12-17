namespace AtomicReactor
{
    /// <summary>
    /// Valve is used by PressureController for decreasing the pressure in ReactorVessel when it
    /// crosses optimum limit 
    /// </summary>
    public interface IValve
    {
        void Activate(double pDelta);

        void SetVessel(IReactorVessel device);
    }
}