namespace SGS.BL;

public class KPIReadDto
{
    
    public int KpiNo { get; set; }
    public int KpiDepNo { get; set; }
    public string Kpidescription { get; set; } = null!;

    public bool MeasurementUnit { get; set; }

    public int TargetedValue { get; set; }
}
