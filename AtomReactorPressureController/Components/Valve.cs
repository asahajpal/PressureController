using System.Threading;

namespace AtomicReactor
{
    public class Valve : IValve
    {
        private IReactorVessel vessel;
        private IPressureController _pc;
        private double _pressureDecreaseRate = 0.06; // given value
        public event NotifyValveAction NotifyValveAction;
        private double _currentPr;
        private bool ValveOpened { get; set; }

        public Valve(IPressureController pc)
        {
            _pc = pc;
            _pc.NotifyTimerEvent += Activate;
        }

        public void SetVessel(IReactorVessel device)
        {
            vessel = device;
        }

        private void DecreasePressure()
        {
            OpenValve();
           if(ValveOpened)
                vessel.DecreasePressure(_pressureDecreaseRate * _currentPr);
            CloseValve();
        }

        public void OpenValve()
        { 
            if (!ValveOpened)
            {
                // open valve takes 2 sec
                Thread.Sleep(2000);
                ValveOpened = true;
            }
        }

        public void CloseValve()
        {
            if (ValveOpened)
            {
                // close valve takes 2 sec 
                Thread.Sleep(2000);
                ValveOpened = false;
            }
        }

        public void Activate(double pr, double pf, double projPf)
        {
            if (projPf > _pc.OptimumPressureLoad)
            {
                NotifyValveAction();
                _currentPr = pr;
                var thread = new Thread(new ThreadStart(DecreasePressure));
               thread.Start();
            }
        }
    }
}