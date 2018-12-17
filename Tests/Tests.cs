using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicReactor;
using Xunit;
using Moq;

namespace Tests
{

    [ExcludeFromCodeCoverage]
    public class Tests
    {
       
        [Theory]
        [InlineData(10, 112, 56)]
        public void GetPressureReadingTest(int minP, int maxP, int p)
        {
            var ps = new PressureSensor();
            var vessel = new Mock<IReactorVessel>();
            ps.SetVessel(vessel.Object);

            vessel.Setup(x => x.MaxPressure).Returns(maxP);
            vessel.Setup(x => x.MinPressure).Returns(minP);
            vessel.Setup(x => x.Pressure).Returns(p);

            Assert.InRange(ps.GetPressureReading(), 0.4508, 0.45099);

        }

    }
}
