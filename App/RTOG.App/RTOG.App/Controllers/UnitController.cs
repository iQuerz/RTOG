using Microsoft.AspNetCore.Mvc;
using RTOG.App.Models.Modals;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using System.Numerics;
using System.Reflection;

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
        public async Task<IActionResult> getAddUnitsModal(int playerID, int tileID)
        {

            List<string> units = await _unitService.GetUnitsOptions(playerID);
            var model = new AddUnitsModalModel()
            {
                playerID= playerID,
                tileID = tileID,
                Units = units//piksi: units koje player moze da napravi
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
            List<Unit> units = await _unitService.GetUnits(tileID);
            if(upgradeID != 0)
            {
                for (int i = units.Count - 1; i >= 0; i--)
                {
                    if (units[i].Upgrades.Any(up => up.ID == upgradeID))
                    {
                        units.RemoveAt(i);
                    }
                }
            }
            var model = new UnitsSelectModalModel()
            {
                tileID= tileID,
                Units = units//piksi: svi available units za selection unutar tile.
                             //ukoliko je upgradeID != 0, svi available units za taj upgrade na tom tile 
            };

            return PartialView("Views/Game/_UnitsSelectModal.cshtml", model);
        }

        [HttpPost]
        [Route("Create/{playerID}/{tileID}")]
        public async Task<IActionResult> Create(int playerID, int tileID, [FromBody] List<string> units)
        {

            var unit = await _unitService.CreateUnit(playerID, "Ivan", tileID, units);

            return Ok(unit);
        }
        [HttpGet]
        [Route("Get/{tileID}")]
        public async Task<IActionResult> Get(int tileID)
        {

            var unit = await _unitService.GetUnits(tileID);

            return Ok(unit);
        }

    }
}
