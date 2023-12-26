using SGS.DAL;
using SGS.DAL.Scaffold;
using System.Net.NetworkInformation;

namespace SGS.BL;

public class KPIManager : IKPIManager
{
    private IKPIRepository _KPIRepo;

    public KPIManager(IKPIRepository KPIRepo)
    {
        _KPIRepo = KPIRepo;
    }



    public async Task DeleteKPI(int id)
    {
       await _KPIRepo.DeleteKPI(id);
    }

    public async Task<IEnumerable<KPIReadDto>> GetKPIs()
    {
        var kpis =await _KPIRepo.GetKPIs();
        var kpisDto= kpis.Select(k => new KPIReadDto()
        {
            KpiNo = k.Kpidnum,
            Kpidescription = k.Kpidescription,
            MeasurementUnit = k.MeasurementUnit,
            TargetedValue = k.TargetedValue
        }
        ) ;
        return kpisDto;

    }

    public async Task<IEnumerable<KPIReadDto>> SearchKPI(int? DepId)
    {
        var kpis=await _KPIRepo.SearchKPI(DepId);
        if(kpis == null)
        {
            return null;
        }

        var kpisDto = kpis.Select(k => new KPIReadDto()
        {
            KpiNo = k.Kpidnum,
            KpiDepNo = k.DepNo,
            Kpidescription = k.Kpidescription,
            MeasurementUnit = k.MeasurementUnit,
            TargetedValue = k.TargetedValue
        }
        );
        return kpisDto;

    }

    public async Task UpdateKPI(KPIUpdateDto kpi)
    {
        await _KPIRepo.UpdateKPI(kpi.DataEntityId,kpi.PropertyName,kpi.NewValue);
    }
    public async Task AddKPI(KPIAddUpdateDto KPI)
    {
        if (KPI.TargetedValue > 100)
        {
            throw new ArgumentException("TargetedValue cannot be more than 100%.");
        }
        var newkpi = new Tblkpi()
        {
            DepNo = KPI.KpiDepNo,
            Kpidescription = KPI.Kpidescription,
            MeasurementUnit = KPI.MeasurementUnit,
            TargetedValue = KPI.TargetedValue

        };
        await _KPIRepo.AddKPI(newkpi);
    }
}
