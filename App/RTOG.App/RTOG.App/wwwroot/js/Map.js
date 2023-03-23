//configurise se context
const height = 900
const width = 1600
var canvas = document.createElement("canvas");
canvas.classList.add('hasTileMenu');
canvas.width = width
canvas.height = height
var context = canvas.getContext("2d");
const div = document.getElementById("Map");
div.appendChild(canvas)
context.clearRect(0, 0, width, height);
context.lineWidth = 1.5;
context.font = "18px sans-serif";
context.textAlign = "center";
context.textBaseline = "middle";


// inicijalizacija promenljivih
const gold = new Image();
const solider = new Image();
var TexturePatter
let delaunay
let voronoi

async function createPatternsV2() {
    try {
        const goldPromise = new Promise(resolve => {
            gold.src = "https://cdn-icons-png.flaticon.com/512/199/199541.png";
            gold.onload = () => resolve();
        });

        const soliderPromise = new Promise(resolve => {
            solider.src = "https://www.freepnglogos.com/uploads/soldier-png/soldier-battlefield-graphic-pack-0.png";
            solider.onload = () => resolve();
        });

        const backgroundPromise = new Promise(resolve => {
            const background = new Image();
            background.src = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/65614919-0734-4dc8-9460-7034fd979346/dbg8qqd-0fb0aced-d05c-4df6-a7c6-b8e04c184ac5.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzY1NjE0OTE5LTA3MzQtNGRjOC05NDYwLTcwMzRmZDk3OTM0NlwvZGJnOHFxZC0wZmIwYWNlZC1kMDVjLTRkZjYtYTdjNi1iOGUwNGMxODRhYzUucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.9IQbxC3HC3uuJLf8V9Ridq005b2_-4zFg6Cb9rJ2tbw";
            background.onload = () => {
                TexturePatter = context.createPattern(background, "repeat");
                resolve();
            };
        });

        await Promise.all([goldPromise, soliderPromise, backgroundPromise]);
        
    } catch (error) {
        console.error(error);
    }
}

await createPatternsV2().then(() => DrawBoard());

//loaduje slike 
//async function createPatterns() {
//    try {

//        gold.src = "https://cdn-icons-png.flaticon.com/512/199/199541.png";
//        gold.onload = function () {
//        }  

//        solider.src = "https://www.freepnglogos.com/uploads/soldier-png/soldier-battlefield-graphic-pack-0.png";
//        solider.onload = function () {
//        }  


//        const image = new Image();
//        image.src = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/65614919-0734-4dc8-9460-7034fd979346/dbg8qqd-0fb0aced-d05c-4df6-a7c6-b8e04c184ac5.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzY1NjE0OTE5LTA3MzQtNGRjOC05NDYwLTcwMzRmZDk3OTM0NlwvZGJnOHFxZC0wZmIwYWNlZC1kMDVjLTRkZjYtYTdjNi1iOGUwNGMxODRhYzUucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.9IQbxC3HC3uuJLf8V9Ridq005b2_-4zFg6Cb9rJ2tbw";
//        image.onload = function () {
//            TexturePatter = context.createPattern(image, "repeat");
//            DrawBoard();
//        }  
//    } catch(error)
//    {
//        console.error(error);
//    }
//}

//await createPatterns().then(() =>
//    DrawBoard()
//    )

console.log(Game)
console.log(solider)
console.log(gold)
//renderuje board
function DrawBoard() {
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
    //renderuje resurse
    for (let i = 0; i < particles.length; i++) {
        context.fillStyle = "#000";
        const polygon = voronoi.cellPolygon(i);
        const centroid = d3.polygonCentroid(polygon);
        var distance = 0;
        Game.map.allTiles[i].units.forEach(unit => {
            context.drawImage(solider, centroid[0], centroid[1], -20, -20 + distance);
            distance += 20;
        })
        if (Game.map.allTiles[i].units )
        context.drawImage(gold, centroid[0], centroid[1], 20, 20);
        context.fillText("  +" + Game.map.allTiles[i].gold, centroid[0] + 35, centroid[1] + 5);
    }
}
export class Map {

    constructor() { }

        AddUnit(x, y) {
        const cell = delaunay.find(x, y);
        console.log(MyAccount)
        console.log(Game.map.allTiles[cell])
            //mora menjam url ovde da ne bude static
            fetch("https://localhost:7281/Unit/Create/" + MyAccount.player.id + "/" + Game.map.allTiles[cell].id, {
                method: "POST"
                })
                .then((response) => response.json())
                .then((data) => console.log(data));

            DrawBoard();
    }
}

export default Map;
//simulacija igre za sada
//canvas.addEventListener("click", event => {
//    const x = event.offsetX, y = event.offsetY;
//    console.log(event.offsetX, event.offsetY)
//    const cell = delaunay.find(x, y);
//    if (cell !== undefined) {
//        Game.map.allTiles[cell].owner = Game.players[0];
//    }
//    DrawBoard()
//});

//canvas.addEventListener("contextmenu", event => {
//    event.preventDefault();
//    const x = event.offsetX, y = event.offsetY;
//    const cell = delaunay.find(x, y);
//    if (cell !== undefined) {
//        Game.map.allTiles[cell].owner = Game.players[1];
//    }
//    DrawBoard()
//});