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

//const goldGlobal = new Image();
//const soliderGlobal = new Image();
//var TexturePatter

//async function createPatternsV2() {
//    try {
//        const goldPromise = new Promise(resolve => {
//            gold.src = "https://cdn-icons-png.flaticon.com/512/199/199541.png";
//            gold.onload = () => resolve();
//        });

//        const soliderPromise = new Promise(resolve => {
//            solider.src = "/res/Units/Unit2.png";
//            solider.onload = () => resolve();
//        });

//        const backgroundPromise = new Promise(resolve => {
//            const background = new Image();
//            background.src = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/65614919-0734-4dc8-9460-7034fd979346/dbg8qqd-0fb0aced-d05c-4df6-a7c6-b8e04c184ac5.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzY1NjE0OTE5LTA3MzQtNGRjOC05NDYwLTcwMzRmZDk3OTM0NlwvZGJnOHFxZC0wZmIwYWNlZC1kMDVjLTRkZjYtYTdjNi1iOGUwNGMxODRhYzUucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.9IQbxC3HC3uuJLf8V9Ridq005b2_-4zFg6Cb9rJ2tbw";
//            background.onload = () => {
//                var canvas1 = document.querySelector(".hasTileMenu")
//                console.log(canvas1)
//                if (canvas1) {
//                    var context = canvas1.getContext("2d");
//                    TexturePatter = context.createPattern(background, "repeat");
//                }
//                resolve();
//            };
//        });

//        await Promise.all([goldPromise, soliderPromise, backgroundPromise]);

//    } catch (error) {
//        console.error(error);
//    }
//}

//createPatternsV2().then(() => {
//    window.goldGlobal = goldGlobal;
//    window.soliderGlobal = soliderGlobal;
//    window.TexturePatterGlobal = TexturePatterGlobal;
//    cosnole.log("Assets loaded")
//});
//dva puta se ulazi u ovo not sure why prvi put Map jos uvek ne postoj pa baci error drugi put radi sve kako treba