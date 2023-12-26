using SGS.DAL.Scaffold;

namespace SGS.DAL;

public interface IKPIRepository
{
    public Task<IEnumerable<Tblkpi>> GetKPIs();
    public Task<IEnumerable<Tblkpi>> SearchKPI(int? DepId);
    public Task AddKPI(Tblkpi KPI);
    public Task UpdateKPI(int entityId,string propertyName,string value);
    public Task DeleteKPI(int id);

}
