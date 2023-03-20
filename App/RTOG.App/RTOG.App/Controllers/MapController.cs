using Microsoft.AspNetCore.Mvc;
using RTOG.Business.Infrastructure.Helper;
using RTOG.Business.Interfaces;
using RTOG.Business.Services;
using RTOG.Data.Models;

namespace RTOG.App.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapService _MapService;

        public MapController(IMapService mapService)
        {
            _MapService = mapService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //controler sluzi samo za nase generisanje sandbox mapi nece se actualy korisit u aplikaciji 
        //dev only controller
        [HttpPost]
        [Route("{api}/GenerateMap/{Name}")]
        public async Task<IActionResult> GenerateMapPreset([FromBody]List<Point> points, string name)
        {
            var generatedMap = await _MapService.GenerateMapPreset(points); //, name);
            return Ok(generatedMap);
        }
        [HttpPost]
        [Route("{api}/GenerateMapFromPreset/{mapID}/{playerCount}")]
        public async Task<IActionResult> GenerateMapFromPreset(int mapID, int playerCount)
        {
            var generatedMap = await _MapService.GenerateMapFromPreset(mapID, playerCount);
            return Ok(generatedMap);
        }
        [HttpGet]
        [Route("{api}/GetMap/{mapID}")]
        public async Task<IActionResult> GetMap(int mapID)
        {
            var map = await _MapService.Get(mapID);
            return Ok(map);
        }
        [HttpGet]
        [Route("{api}/GetAllMaps")]
        public async Task<IActionResult> GetAllMaps()
        {
            var map = await _MapService.GetAllMapPresets();
            return Ok(map);
        }
    }
}
