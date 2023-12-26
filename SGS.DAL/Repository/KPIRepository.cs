using Microsoft.EntityFrameworkCore;
using Dapper;
using SGS.DAL.Scaffold;
using System.Data;

namespace SGS.DAL;

public class KPIRepository:IKPIRepository
{
    private ConfigDbContext _context;

    public KPIRepository(ConfigDbContext context)
    {
        _context=context;

    }

    public async Task AddKPI(Tblkpi KPI)
    {
        var procedureName = "InsertKPI";
        var parameters = new DynamicParameters();
        parameters.Add("description", KPI.Kpidescription, DbType.String, ParameterDirection.Input);
        parameters.Add("DepNo", KPI.DepNo, DbType.Int32, ParameterDirection.Input);
        parameters.Add("MeasurementUnit", KPI.MeasurementUnit, DbType.Boolean, ParameterDirection.Input);
        parameters.Add("targetedVal", KPI.TargetedValue, DbType.Int32, ParameterDirection.Input);
        using (var connection = _context.CreateConnection())
        {
            await connection.QueryFirstOrDefaultAsync<Tblkpi>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task DeleteKPI(int id)
    {
        var procedureName = "DeleteKPI";
        var parameters = new DynamicParameters();
        parameters.Add("KPID", id, DbType.Int32, ParameterDirection.Input);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(procedureName, parameters, null, null, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Tblkpi>> GetKPIs()
    {
        using (var connection = _context.CreateConnection())
        {
            var KPIs = await connection.QueryAsync<Tblkpi>("GetAllKPIs");
            return KPIs;
        }
    }

    public async Task<IEnumerable<Tblkpi>> SearchKPI(int? DepId)
    {
        var procedureName = "SearchKPI";
        var parameters = new DynamicParameters();
        parameters.Add("DepartmentId", DepId, DbType.Int32, ParameterDirection.Input);
        using (var connection = _context.CreateConnection())
        {
            var kpi = await connection.QueryAsync<Tblkpi>(procedureName, parameters);
            return kpi;

        }
    }

    public async Task UpdateKPI(int entityId, string propertyName, string value)
    {

        var procedureName = "UpdateKPI";
        var parameters = new DynamicParameters();
        parameters.Add("KPID", entityId, DbType.Int32, ParameterDirection.Input);
        parameters.Add("PropertyName", propertyName, DbType.String, ParameterDirection.Input);
        parameters.Add("NewValue", value, DbType.String, ParameterDirection.Input);

        using (var connection = _context.CreateConnection())
        {
            await connection.QueryFirstOrDefaultAsync<Tblkpi>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
        }

    }
}
