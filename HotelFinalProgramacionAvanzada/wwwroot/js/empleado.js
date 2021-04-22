var dataTable;

$(document).ready(function () {
    cargarDataTable();
});

function cargarDataTable() {
    dataTable = $("#tblUsuarios").DataTable({
        "ajax": {
            "url": "/Usuario/Listar",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "usuario.nombre", "width": "15%" },
            { "data": "usuario.email", "width": "15%" },
            { "data": "hotel.nombre", "width": "15%" },
            { "data": "usuario.role", "width": "15%" }
        ],
        "language": {
            "lengthMenu": "Desplegando _MENU_ registros por página",
            "zeroRecords": "Lo sentimos, no se han encontrado registros.",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay registros disponibles.",
            "infoFiltered": "(filtrado de _MAX_ registros.)",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Filtrar:",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

//function LockUnlock(id) {
//    $.ajax({
//        "url": '/admin/usuario/lockunlock',
//        "type": "POST",
//        "contentType": "application/json",
//        "data": JSON.stringify(id),
//        "dataType": "json",
//        "success": function (data) {
//            if (data.success) {
//                toastr.success(data.message);
//                dataTable.ajax.reload();
//            }
//            else {
//                toastr.error(data.message);
//            }
//        }
//    });
//}