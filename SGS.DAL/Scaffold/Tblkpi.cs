using System;
using System.Collections.Generic;

namespace SGS.DAL.Scaffold;

public partial class Tblkpi
{
    public int Kpidnum { get; set; }

    public string Kpidescription { get; set; } = null!;

    public int DepNo { get; set; }

    public bool MeasurementUnit { get; set; }

    public int TargetedValue { get; set; }
}
