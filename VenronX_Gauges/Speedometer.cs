using System;

namespace VenronX_Gauges
{
    public class Speedometer
    {
        public int Speed { get; set; }
        //Without user input
        //Speedometer Min/Max
        //First time using Tuple (tuples are used to harness a data structure without having to create a new type (i.e. another class specifically for SpeedometerMin/Max

        //delcaring private variables to hold values not set by the user
        private int _speedometerMin = 0;
        private int _speedometerMax = 250;
        public Tuple<int, int> SpeedometerSetMinMax()
        {
            return Tuple.Create(_speedometerMin, _speedometerMax);
        }

        //With user input
        //private int _userSetMin;
        //private int _userSetMax;
        public int UserSetMin { get; set; }
        public int UserSetMax { get; set; }
        public Tuple<int, int> SpeedometerMinMax
        {
            get
            {
                return Tuple.Create(UserSetMin, UserSetMax);
            }
        }

    }
}
