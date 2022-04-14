

$(document).ready(function () {
    var counter = 1;
    $(function () {

        $('#add').click(function () {
            $('<tr id="regionRow_' + counter + '">'
                + '<td class="form-group">'
                + '<select type="text" name="RegionList[' + counter + '].Id" id="Region" class="form-control Region" " >'
                + $(" .SecType").html()
                + '</select>'
                + '</td>'
                + '<td>'
                + '<button data-region-id= id="deleteRegion" type="button" class="btn btnDeleteRegion btn-link btn-xs btn" btn-xs>remove</button>'
                + '</td>'
                + '</tr>').appendTo('#SecTypeTable');
            counter++;
            return false;
        });
    });
});

$(document).on("click", ".btnDeleteRegion", function () {
    var tableLength = $("table tr").length;
    if (tableLength != 2) {
        $(this).closest("tr").remove()
    }
});
