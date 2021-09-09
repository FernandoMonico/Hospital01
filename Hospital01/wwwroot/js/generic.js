function ConfirmSave(title = "¿Seguro/a que desea guardar este registro?", text = "Este proceso es irreversible") {
    return Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, guardar',
        cancelButtonText: 'Cancelar'
    });
}

function ConfirmDelete(title = "¿Seguro/a que desea eliminar este registro?", text = "Este proceso es irreversible") {
    return Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, eliminar',
        cancelButtonText: 'Cancelar'
    });
}