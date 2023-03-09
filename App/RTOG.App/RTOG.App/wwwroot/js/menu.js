

// mora da se import na cshtml skripta iz "/lib/bootstrap-menu/BootstrapMenu.min.js"
// mora da se linkuje css stylesheet href "/css/dropdown.css"

// ovo pravi context menu nad elementima sa klasom .hasTileMenu koji se pojavljuje ispod misa
var menu = new BootstrapMenu('.hasTileMenu', {
    menuEvent: 'click',
    actions: [
        {
            name: 'Add new unit',
            iconClass: 'iconoir-add-circle',
            onClick: function () {
                alert("hi");
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


