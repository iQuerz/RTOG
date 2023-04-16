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
        private readonly IUpgradeService _upgradeService;
        
        public UnitController(IUnitService unitService, IUpgradeService upgradeService)
        {
            _unitService = unitService;
            _upgradeService = upgradeService;
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
                Units = units
            };

            return PartialView("Views/Game/_AddUnitsModal.cshtml", model);
        }

        [HttpGet]
        [Route("getUpgradeUnitsModal")]
        public async Task<IActionResult> getUpgradeUnitsModal(int tileID)
        {
            var upgrades = _upgradeService.GetUpgradeOptions();
            var model = new UpgradeUnitsModalModel()
            {
                tileID= tileID,
                Upgrades = upgrades
            };

            return PartialView("Views/Game/_UpgradeUnitsModal.cshtml", model);
        }

        [HttpGet]
        [Route("getUnitsSelectModal")]
        public async Task<IActionResult> getUnitsSelectModal(int tileID, int upgradeID)
        {

            List<Unit> units = await _unitService.GetUnits(tileID);
            string upgradeName = _upgradeService.GetUpgradeName(upgradeID);
            if(upgradeID != 0)
            {
                for (int i = units.Count - 1; i >= 0; i--)
                {
                    if (units[i].Upgrades == null)
                        continue;
                    if (units[i].Upgrades.Any(up => up.Name == upgradeName))
                    {
                        units.RemoveAt(i);
                    }
                }
            }
            var model = new UnitsSelectModalModel()
            {
                tileID= tileID,
                upgradeID = upgradeID,
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

        [HttpPatch]
        [Route("UpgradeUnits/{upgradeID}")]
        public async Task<IActionResult> UpgradeUnits(int upgradeID, [FromBody] List<int> unitIDs)
        {
            await _upgradeService.UpgradeUnits(upgradeID, unitIDs);
            //piksi: ovde treba da se upgrade-uju svi poslati units
            Console.WriteLine("After upgrade");
            return Ok();
        }

        [HttpPatch]
        [Route("MoveUnits")]
        public async Task<IActionResult> MoveUnits(int tileID, [FromBody] List<int> unitIDs)
        {
            //piksi: ovde treba da se pomere svi poslati units na tile

            return Ok();
        }
    }
}
