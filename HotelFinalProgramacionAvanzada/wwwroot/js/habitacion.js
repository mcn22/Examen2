var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblHabitaciones').DataTable({
        "ajax": {
            "url": "/Habitacion/Listar"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            { "data": "tipoHabitacion.nombre", "width": "15%" },
            { "data": "hotel.nombre", "width": "15%" },
            {
                "data": "habitacionId",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a onclick="ShowPopup('/Habitacion/Upsert/?id=${data}','Actualizar Habitacion')" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Borrar("/Habitacion/Borrar/?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
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
