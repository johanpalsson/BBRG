$(document).on("click", ".btnDeleteSecType", function () {
    var tableLength = $("table tr").length;
    if (tableLength != 2) {
        $(this).closest("tr").remove()
    }
});

$(document).ready(function () {
    var counter = 2;
    $(function () {

        $('#add').click(function () {
            $('<tr id="SecTypeRow_' + counter + '">'
                + '<td class="form-group">'
                + '<select type="text" asp-for="SecTypeId" name="SecType" id="Region_' + counter + '" class="form-control Region" " >'
                + $(".SecType").html()
                + '</select>'
                + '</td>'
                + '<td>'
                + '<button data-secType-id= id="deleteSecType" type="button" class="btn btnDeleteSecType btn-link btn-xs btn" btn-xs>remove</button>'
                + '</td>'
                + '</tr>').appendTo('#SecTypeTable');
            counter++;
            return false;
        });
    });
});
