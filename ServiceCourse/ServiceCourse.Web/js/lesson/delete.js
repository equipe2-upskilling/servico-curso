function deleteCourse(lessonId) {
    // Chamar a API ou fazer a chamada AJAX para deletar o curso
    $.ajax({
        url: '/Lesson/Delete/' + lessonId,
        type: 'POST',
        success: function (result) {
            if (result.success) {
                console.log('Curso deletado com sucesso!');

                $('#deleteConfirmationModal').modal('hide');

                window.location.reload();
            }
        },
        error: function (xhr, status, error) {
            console.error('Erro na exclusão do curso: ' + result.errorMessage);
        }
    });
}

// Evento quando o botão "Confirmar Exclusão" no modal for clicado
$('#confirmDeleteButton').on('click', function () {
    var lessonId = $(this).data('lesson-id');
    deleteCourse(lessonId);
});

// Evento para abrir o modal de confirmação e definir o ID do curso no botão

$('.delete-link').on('click', function () {
    var lessonId = $(this).data('lesson-id'); // Obtem o ID do curso do atributo "data-course-id"
    $('#confirmDeleteButton').data('lesson-id', lessonId); // Define o ID do curso no botão de confirmação
    $('#deleteConfirmationModal').modal('show'); // Abre o modal de confirmação
});

$('.modal-header button.close').on('click', function () {
    $('#deleteConfirmationModal').modal('hide');
});

function updateImagePreview() {
    debugger;
    var imageUrl = $('#Image').val();
    $('#imgPreview').attr('src', imageUrl);
}

$(document).ready(function () {
    $('#Image').on('input', function () {
        debugger;
        updateImagePreview();
    });
});