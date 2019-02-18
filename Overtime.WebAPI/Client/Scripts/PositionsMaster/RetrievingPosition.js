$(document).ready(function () {
    LoadIndexPosition();
    LoadhideAlert();
    $('#table').DataTable({
        "ajax": LoadIndexPosition()
    })
    ClearScreen();
})

function Save() {
    var position = new Object();
    position.name = $('#Name').val();
    $.ajax({
        url: 'http://localhost:65228/api/Position/',
        type: 'POST',
        dataType: 'json',
        data: position,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been soft delete!",
                type: "success"
            },
            function () {
                window.location.href = '/Positions/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
};

function Edit() {
    var position = new Object();
    position.id = $('#Id').val();
    position.name = $('#Name').val();
    $.ajax({
        url: "http://localhost:65228/api/Position/" + $('#Id').val(),
        data: position,
        type: "PUT",
        dataType: "json",
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Positions/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "http://localhost:65228/api/Position/" + Id,
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function LoadIndexPosition() {
    $.ajax({
        type: "GET",
        url: "http://localhost:65228/api/Position/",
        async: false,
        datatype: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash-o" onclick="return Delete(' + val.Id + ')"></a> </td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:65228/api/Position/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Positions/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#myModal').on('hidden.bs.modal', function () {
        $(this).find("input,textarea,select").val('').end();
        $('#Update').hide();
        $('#Save').show();
    });
}

function ValidationSave() {
    var isAllValid = true;
    if ($('#Name').val() == "" || ($('Name').val() == " ")) {
        isAllValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Save();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
}


function ValidationEdit() {
    var isAllValid = true;
    if ($('#Name').val() == "" || ($('Name').val() == " ")) {
        isAllValid = false;
        $('#Name').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Name').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Edit();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
}
