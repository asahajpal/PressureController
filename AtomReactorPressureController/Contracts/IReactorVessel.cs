namespace AtomicReactor
{
    /// <summary>
    /// ReactorVessel is that component which is subjected to pressure rise due to process in
    /// Fission Chamber. ReactorVessel has prescribed Pressure limits (min and max).
    /// </summary>
    public interface IReactorVessel
    {
        double MaxPressure { get; set; }
        double MinPressure { get; set; }
        void IncreasePressure(double pressureDelta);
        void DecreasePressure(double pressureDelta);
        double Pressure { get; }
    }
}
