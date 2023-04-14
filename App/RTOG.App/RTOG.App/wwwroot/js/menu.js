
// mora da se import na cshtml skripta iz "/lib/bootstrap-menu/BootstrapMenu.min.js"
// mora da se linkuje css stylesheet href "/css/dropdown.css"
//const addUnit = require('./Map');
// ovo pravi context menu nad elementima sa klasom .hasTileMenu koji se pojavljuje ispod misa

//import { mapObject } from './Map.js';

/*var eventClicekd;*/

//korisimo da uzimamo lokaciju prvobitnog klika a ne drugog klika na menu
//var tileMenus = document.querySelector('.hasTileMenu');
//console.log(tileMenus)
//tileMenus.addEventListener("click", event => {
//        console.log("Test")
//        eventClicekd = event
//    });


//var mapDiv = document.querySelector('#Map');
//console.log(mapDiv)
//mapDiv.addEventListener("click", event => {
//    console.log("clicked")
//    })

//const MapObject = new Map();
var menu = new BootstrapMenu('.hasTileMenu', {
    menuEvent: 'click',
    actions: [
        {
            name: 'Add new unit',
            iconClass: 'iconoir-add-circle',
            onClick: function () {
                console.log(window.eventClicekd)
                console.log(window.eventClicekd.offsetX, window.eventClicekd.offsetY)
                window.mapObject.AddUnit(window.eventClicekd.offsetX, window.eventClicekd.offsetY)
                //alert("hi");
            }
        },
        {
            name: 'Upgrade unit(s)',
            iconClass: 'iconoir-arrow-up-circle',
            onClick: function () {
                // run when the action is clicked
            }
        },
        {
            name: 'Fortify tile',
            iconClass: 'iconoir-historic-shield',
            onClick: function () {
                // run when the action is clicked
            }
        },
        {
            name: 'Attack/Move',
            iconClass: 'iconoir-move-up',
            onClick: function () {
                // run when the action is clicked
            }
        },
        {
            name: 'Exit',
            iconClass: 'iconoir-cancel'
        }]
});

