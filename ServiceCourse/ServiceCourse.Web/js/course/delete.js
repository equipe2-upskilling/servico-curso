//$(".delete-link").click(function (event) {
//    event.preventDefault();

//    let deleteUrl = $(this).data("delete-url");

//    $.ajax({
//        url: deleteUrl,
//        type: "POST",
//        success: function (data) {
//            $('#deleteConfirmationModal').modal('show');
//            //window.location.reload(); // Recarrega a página
//        },
//        error: function (xhr, status, error) {
//            console.error("Erro na exclusão: " + error);
//        }
//    });
//});
//$('#deleteConfirmationModal').on('hidden.bs.modal', function (e) {
//    // Recarregar a página após o fechamento do modal
//    window.location.reload();
//});
//$(document).ready(function () {
//    $("#createCourseForm").submit(function (event) {
//        event.preventDefault();
//        debugger;
//         let formData = $(this).serialize();;

//        $.ajax({
//            type: 'POST',
//            data: formData,
//            success: function (data) {
//                console.log('Curso criado com sucesso!');
//                location.href;

//            },
//            error: function (xhr, status, error) {
//                console.error('Erro na criação do curso: ' + error);
//            }
//        });
//    });
//});

function deleteCourse(courseId) {
    // Chamar a API ou fazer a chamada AJAX para deletar o curso
    $.ajax({
        url: '/Course/Delete/' + courseId,
        type: 'POST',
        success: function (data) {
            // Chamada AJAX bem-sucedida
            console.log('Curso deletado com sucesso!');

            // Fechar o modal após a exclusão
            $('#deleteConfirmationModal').modal('hide');

            // Recarregar a página após o fechamento do modal (opcional)
             window.location.reload();
        },
        error: function (xhr, status, error) {
            // Tratar erros, se necessário
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
    var courseId = $(this).data('course-id');
    $('#confirmDeleteButton').data('course-id', courseId);
    $('#deleteConfirmationModal').modal('show');
});

$('.modal-header button.close').on('click', function () {
    $('#deleteConfirmationModal').modal('hide');
});