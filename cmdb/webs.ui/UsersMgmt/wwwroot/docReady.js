var editor; // use a global for the submit and return data rendering in the examples

$(document).ready(function () {
    editor = new $.fn.dataTable.Editor({
        ajax: {
            url: "@Url.Action("CustomServerSideSearchAction2", "Test")",
            type: "POST"
        },
        table: "#SearchResultTable",
        fields: [{
            "label": "First name:",
            "name": "firstname"
        },
        {
            "label": "Last name:",
            "name": "lastname"
        }
        ]
    });

    $('#example').DataTable({
        dom: "<'row'<'col-xs-4'B><'col-xs-4'l><'col-xs-4'f>>" + "<'row'<'col-xs-12'tr>>" + "<'row'<'col-xs-5'i><'col-xs-7'p>>",
        proccessing: true,
        serverSide: true,
        ajax: {
            url: "@Url.Action("CustomServerSideSearchAction", "Test")",
            type: "POST"
        },
        language: {
            search: "",
            searchPlaceholder: "Rechercher..."
        },
        columns: [
            { "data": "firstname" },
            { "data": "lastname" }
        ],
        select: true,
        buttons: [
            { extend: "create", editor: editor },
            { extend: "edit", editor: editor },
            { extend: "remove", editor: editor }
        ]
    });
});