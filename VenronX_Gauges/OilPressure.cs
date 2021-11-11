using System;

namespace VenronX_Gauges
{
    public class OilPressure
    {
        //measured in psi
        //10-15 psi at idle, 30 - 40 psi at drive (on avg)
        public int Pressure
        {
            get
            {
                if (Pressure >= Max)
                {
                    throw new OilPressureAtMaxException(Pressure);
                }
                return Pressure;
            }
            set
            {
                Pressure = value;
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }
        //public void WarnsEngineToShutDown()
        //{
        //    if (Pressure >= Max)
        //    {
        //        throw new OilPressureAtMaxException(Pressure);
        //    }
        //}
    }
    public class OilPressureAtMaxException : Exception
    {
        public OilPressureAtMaxException()
        {
        }
        public OilPressureAtMaxException(int pressure)
            : base(String.Format("Engine Software will shut down, oil pressure too hight:" + pressure + "psi."))
        {
        }
    }
}
