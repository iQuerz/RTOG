using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models.Modals;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    [Route("[controller]")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        [Route("getAddUnitsModal")]
        public async Task<IActionResult> getAddUnitsModal(int playerID)
        {
            var model = new AddUnitsModalModel()
            {
                Units = new()//piksi: units koje player moze da napravi
            };

            return PartialView("Views/Game/_AddUnitsModal.cshtml", model);
        }

        [HttpGet]
        [Route("getUpgradeUnitsModal")]
        public async Task<IActionResult> getUpgradeUnitsModal(int tileID)
        {
            var model = new UpgradeUnitsModalModel()
            {
                Upgrades = new()//piksi: svi available upgrades za units na tile
            };

            return PartialView("Views/Game/_UpgradeUnitsModal.cshtml", model);
        }

        [HttpGet]
        [Route("getUnitsSelectModal")]
        public async Task<IActionResult> getUnitsSelectModal(int tileID, int upgradeID)
        {

            var model = new UnitsSelectModalModel()
            {
                Units = new()//piksi: svi available units za selection unutar tile.
                             //ukoliko je upgradeID != 0, svi available units za taj upgrade na tom tile 
            };

            return PartialView("Views/Game/_UnitsSelectModal.cshtml", model);
        }

        [HttpPost]
        [Route("{api}/Create/{playerID}/{tileID}/{type}")]
        //@Url.Action("Create", "Unit") == {api}/Create note za mene da ne zaboravim zanemari
        public async Task<IActionResult> Create(int playerID, int tileID, string type)
        {

            var unit = await _unitService.CreateUnit(playerID, "Ivan", tileID,type);

            return Ok(unit);
        }

    }
}
