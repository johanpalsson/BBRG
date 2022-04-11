

$(document).ready(function () {
    var counter = 2;
    $(function () {

        $('#add').click(function () {
            $('<tr id="regionRow_' + counter + '">'
                + '<td>'
                + '<select type="text" value="RegionId" name="Region" id="Region_'+ counter+'" class="form-control Region" " >'
                + $(".Region").html()
                + '</select>'
                + '</td>'
                + '<td>'
                + '<button data-region-id= id="deleteRegion" type="button" class="btn btnDeleteRegion btn-link btn-xs btn" btn-xs>remove</button>'
                + '</td>'
                + '</tr>').appendTo('#regionTable');
            counter++;
            return false;
        });
    });
});

