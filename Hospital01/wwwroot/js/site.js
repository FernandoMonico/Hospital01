// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function DataTableEs() {
    $('.index-table').DataTable({
        "language": {
            "url": "../../lib/datatables-1.11.2/DataTables-1.11.2/json/es_es.json"
        }
    });
}