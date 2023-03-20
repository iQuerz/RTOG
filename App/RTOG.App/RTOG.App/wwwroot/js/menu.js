
// mora da se import na cshtml skripta iz "/lib/bootstrap-menu/BootstrapMenu.min.js"
// mora da se linkuje css stylesheet href "/css/dropdown.css"
//const addUnit = require('./Map');
// ovo pravi context menu nad elementima sa klasom .hasTileMenu koji se pojavljuje ispod misa

import { AddUnit } from './Map.js';

var eventClicekd;

//korisimo da uzimamo lokaciju prvobitnog klika a ne drugog klika na menu
const tileMenus = document.querySelector('.hasTileMenu');
console.log(tileMenus)
tileMenus.addEventListener("click", event => {
    eventClicekd = event
});

var menu = new BootstrapMenu('.hasTileMenu', {
    menuEvent: 'click',
    actions: [
        {
            name: 'Add new unit',
            iconClass: 'iconoir-add-circle',
            onClick: function () {
                //console.log(eventClicekd.offsetX, eventClicekd.offsetY)
                AddUnit(eventClicekd.offsetX, eventClicekd.offsetY)
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


