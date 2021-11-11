using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VenronX_Gauges;

namespace VenronX_Tests
{
    [TestClass]
    public class GaugeTests
    {
        Speedometer _speedometer;
        Tachometer _tachometer;
        [TestInitialize]
        public void TestInitialize()
        {
            _speedometer = new Speedometer();
            _tachometer = new Tachometer();
        }

        //SPEEDOMETER TESTS
        [TestMethod]
        public void TestGettingMinMaxSpeedometerShouldPass()
        {
            Assert.AreEqual(_speedometer.SpeedometerSetMinMax().Item1, 2);
            Assert.AreEqual(_speedometer.SpeedometerSetMinMax().Item2, 250);
            Assert.AreNotEqual(_speedometer.SpeedometerSetMinMax(), new Tuple<int, int>(250, 20));
        }
        [TestMethod]
        public void TestUserSettingMinMaxSpeedometerShouldPass()
        {
            _speedometer.UserSetMin = 20;
            _speedometer.UserSetMax = 300;
            var minMax = _speedometer.SpeedometerMinMax;
            Assert.AreEqual(_speedometer.UserSetMin, 20);
            Assert.AreEqual(_speedometer.UserSetMax, 300);
            Assert.AreEqual(minMax.Item1, 20);
            Assert.AreEqual(minMax.Item2, 300);
        }

        //TACHOMETER TESTS

        //test getting all three values, min/max/redline (redline is a "do not exceed" value)
        [TestMethod]
        public void GettingAllValuesNoUserInput()
        {
            //pre set values of 0-min, 7000-max, 5500-redline
            var allValues = _tachometer.TachometerMinMaxRedline;
            Assert.AreEqual(allValues, new Tuple<int, int, int>(0, 7000, 5500));
        }
        //test getting exception
        [TestMethod]
        [ExpectedException(typeof(DoNotExceedRedline), "Do not exceed the suggested rpm")]
        public void GetExceptionWhenRPMReachesRedline()
        {
            _tachometer.Rpm = 6000;
            _tachometer.TestRpmAgainstRedline();
        }
    }
}
