namespace VenronX_Gauges
{
    //"flow meter" to measure current flow of electricity to the battery
    public class Ammeter
    {
        //0 min
        //We will say 30 max
        public int MaxAmps { get; set; }
        public int MinAmps { get; set; } = 0;
    }
}
