//configurise se context
//console.log("starting map generation")
//const height = 900
//const width = 1600
//var canvas = document.createElement("canvas");
//canvas.classList.add('hasTileMenu');
//canvas.width = width
//canvas.height = height
//var context = canvas.getContext("2d");
//const div = document.getElementById("Map");
//div.appendChild(canvas)

//context.clearRect(0, 0, width, height);
//context.lineWidth = 1.5;
//context.font = "18px sans-serif";
//context.textAlign = "center";
//context.textBaseline = "middle";


// inicijalizacija promenljivih

let delaunay
let voronoi

class Map {

    constructor() {
       
    }

    DrawBoard() {
        const height = 900
        const width = 1600
        var canvas = document.querySelector(".hasTileMenu")
        if (!canvas)
            return 0;
        canvas.addEventListener("click", event => {
            window.eventClicekd = event
        });
        var context = canvas.getContext("2d");
        context.clearRect(0, 0, width, height);
        context.lineWidth = 1.5;
        context.font = "18px sans-serif";
        context.textAlign = "center";
        context.textBaseline = "middle";
        

    const particles = Game.map.allTiles.map(tile => [tile.positionX, tile.positionY]);
    console.log(Game)
    //const particlesRandom = Array.from({ length: 50 }, () => [Math.random() * width, Math.random() * height]);
    delaunay = d3.Delaunay.from(particles);
    voronoi = delaunay.voronoi([0.5, 0.5, width - 0.5, height - 0.5]);
  
    context.clearRect(0, 0, width, height);
    //renderuje base mapu
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();

        voronoi.renderCell(i, context);
        context.fillStyle = TexturePatter;
        context.strokeStyle = "#000"
        context.stroke();
        context.fill();
    }


    //renderuje ko ownuje koju teritoriju
    context.globalAlpha = 0.65;
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();
        context.globalAlpha = 0.5;
        voronoi.renderCell(i, context);
        if (Game.map.allTiles[i].owner == null) {
            context.fillStyle = "#000000";
        }
        else if (Game.map.allTiles[i].owner != null) {
            context.fillStyle = Game.map.allTiles[i].owner.color;
        }

        context.stroke();
        context.fill();
    }
    context.globalAlpha = 1;
    //dodaje stroke teritorijama mora da bude posle teritorije
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();
        voronoi.renderCell(i, context);
        context.stroke();
    }
    //renderuje resurse i units
    for (let i = 0; i < particles.length; i++) {
        context.fillStyle = "#000";
        const polygon = voronoi.cellPolygon(i);
        const centroid = d3.polygonCentroid(polygon);
        var SoldierCount = 0;
        var TankCount = 0;
        var SoldierImg;
        var TankImg;
        Game.map.allTiles[i].units.forEach(unit => {
            if (unit.type.includes("Soldier")) {
                SoldierImg = unit.type;
                SoldierCount++;
            }
            if (unit.type.includes("Tank")) {
                TankImg = unit.type;
                TankCount++;
            }
        })
        if (Game.map.allTiles[i].units.length != 0)
        {
            if (SoldierCount != 0) {
                context.drawImage(images[SoldierImg], centroid[0], centroid[1], -35 - SoldierCount * 2, -35 - SoldierCount * 2);
                context.fillText("  x" + SoldierCount, centroid[0] - 40 - SoldierCount * 2, centroid[1] - 17 - SoldierCount * 2);
            }
            if (TankCount != 0) {
                context.drawImage(images[TankImg], centroid[0], centroid[1], -60 - TankCount * 2, +35 + TankCount * 2);
                context.fillText("  x" + TankCount, centroid[0] - 80 - TankCount * 2, centroid[1] + 17 + TankCount * 2);
            }

        }

        if (Game.map.allTiles[i].units)
            context.drawImage(gold, centroid[0], centroid[1], 20, 20);
        //FFD700
        context.fillStyle = '#000000';
        context.fillText("  +" + Game.map.allTiles[i].gold, centroid[0] + 35, centroid[1] + 5);
        }
        context.fillStyle = '#000000';
        console.log("end of drawBoard")
}

    AddUnit(x, y, type) {
        const cell = delaunay.find(x, y);
        console.log(MyAccount)
        console.log(Game.map.allTiles[cell])
        fetch($("#CreateUnitURL").val() + "/" + MyAccount.player.id + "/" + Game.map.allTiles[cell].id + "/" + type, {
            method: "POST"
        })
            .then((response) => response.json())
            .then((data) => {
                page.updateOtherGamePlayers()
            });
    }
    }
const mapObject = new Map()
const gold = new Image();
const AmericanSolider = new Image();
const RussianSolider = new Image();
const ChiniseSolider = new Image();
const AmericanTank = new Image();
const RussianTank = new Image();
const ChiniseTank = new Image();
const images = {
    "A-Soldier": AmericanSolider,
    "R-Soldier": RussianSolider,
    "C-Soldier": ChiniseSolider,
    "A-Tank": AmericanTank,
    "R-Tank": RussianTank,
    "C-Tank": ChiniseTank,
};
var TexturePatter

async function createPatternsV2() {
    try {
        const goldPromise = new Promise(resolve => {
            gold.src = "/res/map/gold.png";
            gold.onload = () => resolve();
        });

        const AmericanSoliderPromise = new Promise(resolve => {
            AmericanSolider.src = "/res/Units/AmericanSolider.png";
            AmericanSolider.onload = () => resolve();
        });
        const RussianSoliderPromise = new Promise(resolve => {
            RussianSolider.src = "/res/Units/RussianSolider.png";
            RussianSolider.onload = () => resolve();
        });
        const ChiniseSoliderPromise = new Promise(resolve => {
            ChiniseSolider.src = "/res/Units/ChiniseSolider.png";
            ChiniseSolider.onload = () => resolve();
        });
        const AmericanTankPromise = new Promise(resolve => {
            AmericanTank.src = "/res/Units/AmericanTank.png";
            AmericanTank.onload = () => resolve();
        });
        const RussianTankPromise = new Promise(resolve => {
            RussianTank.src = "/res/Units/RussianTank.png";
            RussianTank.onload = () => resolve();
        });
        const ChiniseTankPromise = new Promise(resolve => {
            ChiniseTank.src = "/res/Units/ChiniseTank.png";
            ChiniseTank.onload = () => resolve();
        });


        const backgroundPromise = new Promise(resolve => {
            const background = new Image();
            background.src = "/res/map/texture_grass.png";
            background.onload = () => {
                var canvas = document.createElement("canvas");
                canvas.width = 900
                canvas.height = 1600
                var context = canvas.getContext("2d");
                TexturePatter = context.createPattern(background, "repeat");
                resolve();
            };
        });

        await Promise.all([goldPromise, AmericanSoliderPromise, RussianSoliderPromise, ChiniseSoliderPromise, AmericanTankPromise,
            ,RussianTankPromise, ChiniseTankPromise, backgroundPromise]);

    } catch (error) {
        console.error(error);
    }
}



createPatternsV2().then(() => mapObject.DrawBoard());

window.mapObject = mapObject;

export { mapObject, Map }
//export default Map

