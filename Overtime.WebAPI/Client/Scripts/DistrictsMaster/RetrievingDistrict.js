$(document).ready(function () {
    LoadIndexDistrict();
    LoadRegencyCombo();
    LoadhideAlert();

    $('#table').DataTable({
        "ajax": LoadIndexDistrict()
    });
    ClearScreen();
});

function LoadIndexDistrict() {
    $.ajax({
        url: "http://localhost:65228/api/District",
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Regencies.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ');"></a> ';
                html += ' | <a href="#" class="fa fa-trash-o" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        }
    });
}

function LoadRegencyCombo() {
    $.ajax({
        url: 'http://localhost:65228/api/Regency',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var regency = $('#Regencies');
            $.each(result, function (i, Regency) {
                $("<option></option>").val(Regency.Id).text(Regency.Name).appendTo(regency);
            });
        }
    });
}

function Save() {
    var district = new Object();
    district.Name = $('#Name').val();
    district.Regencies = $('#Regencies').val();
    $.ajax({
        url: 'http://localhost:65228/api/District',
        type: 'POST',
        dataType: 'json',
        data: district,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been soft delete!",
                type: "success"
            },
            function () {
                window.location.href = '/Districts/Index/';
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
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
            url: "http://localhost:65228/api/District/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Districts/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function GetById(Id) {
    $.ajax({
        url: 'http://localhost:65228/api/District/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Regencies').val(result.Regencies.Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var district = new Object();
    district.Id = $('#Id').val();
    district.Name = $('#Name').val();
    district.Regencies = $('#Regencies').val();
    $.ajax({
        url: 'http://localhost:65228/api/District/' + district.Id,
        type: 'PUT',
        data: district,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Districts/Index/';
                $('#Id').val('');
                $('#Name').val('');
            });
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
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
    if ($('#Regencies').val() == "Choose Regencies" || ($('Regencies').val() == 0) || ($('Regencies').val() == "")) {
        isAllValid = false;
        $('#Regencies').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Regencies').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Save();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Regencies').siblings('span.error').css('visibility', 'hidden');
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
    if ($('#Regencies').val() == "Choose Regency" || ($('Regencies').val() == " ")) {
        isAllValid = false;
        $('#Regencies').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Regencies').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Edit();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Regencies').siblings('span.error').css('visibility', 'hidden').val("Choose Regency");
    $('#Regencies').val("Choose Regency");
}
