using System;

namespace VenronX_Gauges
{
    public class Tachometer
    {
        public Tachometer()
        {
        }
        public Tachometer(int rpm)
        {
            Rpm = rpm;
        }
        public int Rpm { get; set; }
        //Without user input
        private int tachMin = 0;
        private int tachMax = 7000;
        private int tachRedline = 5500;
        public Tuple<int, int, int> TachometerMinMaxRedline
        {
            get
            {
                return Tuple.Create(tachMin, tachMax, tachRedline);
            }
        }
        //User input
        public int TachMin { get; set; }
        public int TachMax { get; set; }
        public int TachRedline { get; set; }
        public Tuple<int, int, int> TachometerMinMaxRedlineUserSet
        {
            get
            {
                return Tuple.Create(TachMin, TachMax, TachRedline);
            }
        }
        public void TestRpmAgainstRedline()
        {
            if(Rpm >= tachRedline)
            {
                throw new DoNotExceedRedline(Rpm);
            } 
        }
    }
    public class DoNotExceedRedline : Exception
    {
        public DoNotExceedRedline(int redlineVal)
            : base(String.Format("Do not exceed the suggested rpm"))
        {
        }
    }
}
