console.log("starting map generation")
var canvas = document.createElement("canvas");
canvas.classList.add('hasTileMenu');
canvas.width = 1600
canvas.height = 900
var map = document.getElementById("Map");
if (map) {
    map.appendChild(canvas);
} else {
    console.log("Element with ID 'Map' not found yet!");
}


//dva puta se ulazi u ovo not sure why prvi put Map jos uvek ne postoj pa baci error drugi put radi sve kako treba