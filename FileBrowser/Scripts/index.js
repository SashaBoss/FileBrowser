$(document).ready(function () {
    $('.not-impl').on('click', function () {
        toastr.info("Not implemented");
    });

    function callback(data) {
        var
            fileTable = document.getElementById('fileTable');

        var settings = {
            data: data,
            colHeaders: ['Name', 'Modified', 'Size, Kb'],
            contextMenu: ['remove_row']
        };

        var table = new Handsontable(fileTable, settings);
    }

    $.get('http://localhost:53384/api/files', callback);
});