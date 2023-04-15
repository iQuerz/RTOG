
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
window.activeAction = 0;
var menu = new BootstrapMenu('.hasTileMenu', {
    menuEvent: 'click',
    actions: [
        {
            name: 'Add new unit',
            iconClass: 'iconoir-add-circle',
            onClick: function () {
                page.showAddUnitsModal();
                window.activeAction = 1;
                var tileId = window.mapObject.ReturnTileID(window.eventClicekd.offsetX, window.eventClicekd.offsetY);
                page.showAddUnitsModal(tileId)
                //window.mapObject.AddUnit(window.eventClicekd.offsetX, window.eventClicekd.offsetY,"Soldier")
                //windows.selectedTileID = window.mapObject.Return
            }
        },
        {
            name: 'Upgrade unit(s)',
            iconClass: 'iconoir-arrow-up-circle',
            onClick: function () {
                window.activeAction = 2;
                //cisto radi testiranja ovo zove trenunto
                window.mapObject.AddUnit(window.eventClicekd.offsetX, window.eventClicekd.offsetY, "Tank")
                // run when the action is clicked
            }
        },
        {
            name: 'Fortify tile',
            iconClass: 'iconoir-historic-shield',
            onClick: function () {
                window.activeAction = 3;
                var tileId = window.mapObject.ReturnTileID(window.eventClicekd.offsetX, window.eventClicekd.offsetY);
                console.log(tileId);
                // run when the action is clicked
            }
        },
        {
            name: 'Attack/Move',
            iconClass: 'iconoir-move-up',
            onClick: function () {
                window.activeAction = 4;
                // run when the action is clicked
            }
        },
        {
            name: 'Exit',
            iconClass: 'iconoir-cancel'
        }]
});

