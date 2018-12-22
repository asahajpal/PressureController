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
            // open valve takes 2 sec 
            vessel.DecreasePressure(pDelta);
            //close valve takes 2 sec
        }
    }
}