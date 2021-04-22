var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblEstadosReserva').DataTable({
        "ajax": {
            "url": "/EstadoReserva/Listar"
        },
        "columns": [
            { "data": "nombreEstado", "width": "20%" },
            {
                "data": "estadoReservaId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a onclick="ShowPopup('/EstadoReserva/Upsert/?id=${data}','Actualizar estado reserva')" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/EstadoReserva/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
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
