function deleteCourse(courseId) {
    // Chamar a API ou fazer a chamada AJAX para deletar o curso
    $.ajax({
        url: '/Course/Delete/' + courseId,
        type: 'POST',
        success: function (data) {
            // Chamada AJAX bem-sucedida
            console.log('Curso deletado com sucesso!');

            $('#deleteConfirmationModal').modal('hide');

             window.location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Erro na exclusão do curso: ' + error);
        }
    });
}

// Evento quando o botão "Confirmar Exclusão" no modal for clicado
$('#confirmDeleteButton').on('click', function () {
    var courseId = $(this).data('course-id');
    deleteCourse(courseId);
});

// Evento para abrir o modal de confirmação e definir o ID do curso no botão

$('.delete-link').on('click', function () {
    var courseId = $(this).data('course-id'); // Obtem o ID do curso do atributo "data-course-id"
    $('#confirmDeleteButton').data('course-id', courseId); // Define o ID do curso no botão de confirmação
    $('#deleteConfirmationModal').modal('show'); // Abre o modal de confirmação
});

$('.modal-header button.close').on('click', function () {
    $('#deleteConfirmationModal').modal('hide');
});