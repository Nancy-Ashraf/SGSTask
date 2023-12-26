using System.ComponentModel.DataAnnotations;

namespace SGS.BL;

public class KPIUpdateDto
{
   
    public string PropertyName {  get; set; }
    
    public int DataEntityId { get; set; }

    
    public string NewValue { get; set; }
}
