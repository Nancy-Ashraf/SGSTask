using SGS.DAL.Scaffold;

namespace SGS.BL;

public interface IKPIManager
{
    public Task<IEnumerable<KPIReadDto>> GetKPIs();
    public Task<IEnumerable<KPIReadDto>> SearchKPI(int? DepId);
    public Task AddKPI(KPIAddUpdateDto KPI);
    public Task UpdateKPI(KPIUpdateDto KPI);
    public Task DeleteKPI(int id);
}
