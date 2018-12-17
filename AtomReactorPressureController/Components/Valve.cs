namespace AtomicReactor
{
    public class Valve : IValve
    {
        private IReactorVessel vessel;

        public void SetVessel(IReactorVessel device)
        {
            vessel = device;
        }

        public void Activate(double pDelta)
        {
            // open valve
            vessel.DecreasePressure(pDelta);
            //close valve
        }
    }
}