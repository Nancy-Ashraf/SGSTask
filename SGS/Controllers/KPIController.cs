using Microsoft.AspNetCore.Mvc;
using SGS.BL;


namespace SGS.Controllers
{
    public class KPIController : Controller
    {
        private readonly IKPIManager _kpiManager;

        public KPIController(IKPIManager kPIManager)
        {
            _kpiManager = kPIManager;
        }

        [Route("/")]
        public async Task<IActionResult> GetAllKpis()
        {
            var kpis = (await _kpiManager.GetKPIs()).ToList();
            return View(kpis);
        }

        [Route("/SearchKpi/{DepNo}")]
        public async Task<IActionResult> GetAllKpis(int DepNo)
        {
            var kpis = (await _kpiManager.SearchKPI(DepNo)).ToList();
            return View("GetAllKpis", kpis);
        }

   

        [Route("/UpdateKpi")]
        
        public async Task<IActionResult> UpdateKpi([FromBody]KPIUpdateDto kpiAddDto)
        {
            if (ModelState.IsValid)
            {
                await _kpiManager.UpdateKPI(kpiAddDto);
                return Ok();
            }

            // ModelState is not valid, handle errors
            return BadRequest();
        }

        [Route("/AddKpi")]
        public async Task<IActionResult> AddKpi([FromBody] KPIAddUpdateDto kpiAddDto)
        {
            await _kpiManager.AddKPI(kpiAddDto);

            // Assuming you want to send some data back in the response
            var responseData = new
            {
                Message = "KPI added successfully",
                // Add any other data you want to send back
            };

            return Ok(responseData);
        }

        [Route("/DeleteKpi")]
        public async Task<IActionResult> DeleteKpi(int KpiID)
        {
            await _kpiManager.DeleteKPI(KpiID);

            // Assuming you want to send some data back in the response
            var responseData = new
            {
                Message = "KPI added successfully",
                // Add any other data you want to send back
            };

            return Ok(responseData);
        }

    }
}
