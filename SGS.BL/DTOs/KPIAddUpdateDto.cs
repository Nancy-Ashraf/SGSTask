using System.ComponentModel.DataAnnotations;

namespace SGS.BL;

public class KPIAddUpdateDto
{
    public int KpiDepNo { get; set; }

    public string Kpidescription { get; set; }

    public bool MeasurementUnit { get; set; }

    [Range(0, 100)]
    public int TargetedValue { get; set; }
}
