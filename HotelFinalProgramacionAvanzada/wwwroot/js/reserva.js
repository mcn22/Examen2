var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblReservas').DataTable({
        "ajax": {
            "url": "/Reserva/Listar"
        },
        "columns": [
            { "data": "reservaId", "width": "5%" },
            { "data": "usuario.nombre", "width": "15%" },
            { "data": "habitacion.hotel.nombre", "width": "15%" },
            {
                "data": "reservaId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a onclick="ShowPopup('/Reserva/Upsert/?id=${data}','Actualizar Reserva')" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/Reserva/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
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
