// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function confirmAndDelete(studentId) {
    if (confirm('Are you sure you want to delete this student?')) {
        $.ajax({
            url: '/Student/DeleteStudent/' + studentId,
            type: 'DELETE',
            success: function (result) {
                window.location.reload();
            },
            error: function (error) {
                console.error('Error deleting student:', error);
            }
        });
    }
}