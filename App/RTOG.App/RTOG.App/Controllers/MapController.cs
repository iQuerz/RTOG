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
        [Route("{api}/GenerateMap")]
        public async Task<IActionResult> CreateGuest([FromBody]List<Point> points)
        {
            var generatedMap = await _MapService.GenerateMap(points, 3);
            return Ok(generatedMap);
        }
        [HttpGet]
        [Route("{api}/GetMap/{mapID}")]
        public async Task<IActionResult> GetMap(int mapID)
        {
            var map = await _MapService.Get(mapID);
            return Ok(map);
        }
    }
}
