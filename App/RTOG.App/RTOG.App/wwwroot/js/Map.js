const height = 900
const width = 1600

console.log(Map);



var canvas = document.createElement("canvas");
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

const gold = new Image();
var TexturePatter
console.log(TexturePatter);
async function createPatterns() {
    try {

        gold.src = "https://cdn-icons-png.flaticon.com/512/199/199541.png";
        gold.onload = function () {
        }  


        const image = new Image();
        image.src = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/65614919-0734-4dc8-9460-7034fd979346/dbg8qqd-0fb0aced-d05c-4df6-a7c6-b8e04c184ac5.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzY1NjE0OTE5LTA3MzQtNGRjOC05NDYwLTcwMzRmZDk3OTM0NlwvZGJnOHFxZC0wZmIwYWNlZC1kMDVjLTRkZjYtYTdjNi1iOGUwNGMxODRhYzUucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.9IQbxC3HC3uuJLf8V9Ridq005b2_-4zFg6Cb9rJ2tbw";
        image.onload = function () {
            TexturePatter = context.createPattern(image, "repeat");
            DrawBoard();
        }  
    } catch(error)
    {
        console.error(error);
    }
}

createPatterns()
let delaunay
let voronoi
function DrawBoard() {
    const particles = Map.allTiles.map(tile => [tile.positionX, tile.positionY]);
    //const particlesRandom = Array.from({ length: 50 }, () => [Math.random() * width, Math.random() * height]);
    delaunay = d3.Delaunay.from(particles);
    voronoi = delaunay.voronoi([0.5, 0.5, width - 0.5, height - 0.5]);
    context.clearRect(0, 0, width, height);
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();

        voronoi.renderCell(i, context);
        context.fillStyle = TexturePatter;
        context.strokeStyle = "#000"
        context.stroke();
        context.fill();
    }

    context.globalAlpha = 0.5;
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();
        context.globalAlpha = 0.5;
        voronoi.renderCell(i, context);
        if (Map.allTiles[i].owner == null)
        {
            context.fillStyle = "#000000";
        }
        else if (Map.allTiles[i].owner == 1)
        {
            context.fillStyle = "#eb5954";
        } else if (Map.allTiles[i].owner == 2)
        {
            context.fillStyle = "#77eb54";
        }
        context.stroke();
        context.fill();
    }
    context.globalAlpha = 1;
    for (let i = 0; i < particles.length; i++) {
        context.beginPath();
        voronoi.renderCell(i, context);
        context.stroke();
    }
    for (let i = 0; i < particles.length; i++) {
        context.fillStyle = "#000";
        const polygon = voronoi.cellPolygon(i);
        const centroid = d3.polygonCentroid(polygon);
        context.drawImage(gold, centroid[0], centroid[1], 20, 20);
        context.fillText("  +" + Map.allTiles[i].gold, centroid[0] + 35, centroid[1] + 5);
    }
}
document.getElementById("my-button").addEventListener("click", DrawBoard);



canvas.addEventListener("click", event => {
    const x = event.offsetX, y = event.offsetY;
    const cell = delaunay.find(x, y);
    if (cell !== undefined) {
        Map.allTiles[cell].owner = 1;
    }
    DrawBoard()
});

canvas.addEventListener("contextmenu", event => {
    event.preventDefault();
    const x = event.offsetX, y = event.offsetY;
    const cell = delaunay.find(x, y);
    if (cell !== undefined) {
        Map.allTiles[cell].owner = 2;
    }
    DrawBoard()
});