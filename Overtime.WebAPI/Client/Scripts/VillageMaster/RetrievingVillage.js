$(document).ready(function () {
    LoadIndexVillage();
    LoadDistrictCombo();
    LoadhideAlert();

    $('#table').DataTable({
        "ajax": LoadIndexVillage()
    });
    ClearScreen();
});

function LoadIndexVillage() {
    $.ajax({
        url: "http://localhost:65228/api/Village",
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Districts.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ');"></a> ';
                html += ' | <a href="#" class="fa fa-trash-o" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        }
    });
}

function LoadDistrictCombo() {
    $.ajax({
        url: 'http://localhost:65228/api/District',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var district = $('#Districts');
            $.each(result, function (i, District) {
                $("<option></option>").val(District.Id).text(District.Name).appendTo(district);
            });
        }
    });
}

function Save() {
    var village = new Object();
    village.Name = $('#Name').val();
    village.Districts = $('#Districts').val();
    $.ajax({
        url: 'http://localhost:65228/api/Village',
        type: 'POST',
        dataType: 'json',
        data: village,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been soft delete!",
                type: "success"
            },
            function () {
                window.location.href = '/Villages/Index/';
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
            url: "http://localhost:65228/api/Village/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Villages/Index/';
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
        url: 'http://localhost:65228/api/Village/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Districts').val(result.Districts.Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var village = new Object();
    village.Id = $('#Id').val();
    village.Name = $('#Name').val();
    village.Districts = $('#Districts').val();
    $.ajax({
        url: 'http://localhost:65228/api/Village/' + village.Id,
        type: 'PUT',
        data: village,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Villages/Index/';
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
    if ($('#Districts').val() == "Choose Districts" || ($('Districts').val() == 0) || ($('Districts').val() == "")) {
        isAllValid = false;
        $('#Districts').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Districts').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Save();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Districts').siblings('span.error').css('visibility', 'hidden');
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
    if ($('#Districts').val() == "Choose District" || ($('Districts').val() == " ")) {
        isAllValid = false;
        $('#Districts').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Districts').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Edit();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Districts').siblings('span.error').css('visibility', 'hidden').val("Choose Districts");
    $('#Districts').val("Choose District");
}
