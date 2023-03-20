using Microsoft.AspNetCore.Mvc;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpPost]
        [Route("{api}/Create/{playerID}/{tileID}")]
        public async Task<IActionResult> Create(int playerID, int tileID)
        {

            var unit = await _unitService.CreateUnit(playerID, "Ivan", tileID);

            return Ok(unit);
        }

    }
}
