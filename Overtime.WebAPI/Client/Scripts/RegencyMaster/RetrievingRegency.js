$(document).ready(function () {
    LoadIndexRegency();
    LoadProvinceCombo();
    LoadhideAlert();

    $('#table').DataTable({
        "ajax": LoadIndexRegency()
    });
    ClearScreen();
});

function LoadIndexRegency() {
    $.ajax({
        url: "http://localhost:65228/api/Regency",
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.Name + '</td>';                
                html += '<td>' + val.Provinces.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ');">Edit</a> ';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        }
    });
}

function LoadProvinceCombo() {   
    $.ajax({
        url: 'http://localhost:65228/api/Province',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var province = $('#Provinces');
            $.each(result, function (i, Province) {
                $("<option></option>").val(Province.Id).text(Province.Name).appendTo(province);
            });
        }
    });
}

function Save() {
    var regency = new Object();
    regency.Name = $('#Name').val();    
    regency.Provinces = $('#Provinces').val();
    $.ajax({
        url: 'http://localhost:65228/api/Regency',
        type: 'POST',
        dataType: 'json',
        data: regency,
        success: function (response) {
            swal({
                title: "Saved!",
                text: "That data has been soft delete!",
                type: "success"
            },
            function () {
                window.location.href = '/Regencies/Index/';
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
            url: "http://localhost:65228/api/Regency/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Regencies/Index/';
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
        url: 'http://localhost:65228/api/Regency/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);            
            $('#Provinces').val(result.Provinces.Id);

            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {
    var regency = new Object();
    regency.Id = $('#Id').val();
    regency.Name = $('#Name').val();    
    regency.Provinces = $('#Provinces').val();
    $.ajax({
        url: 'http://localhost:65228/api/Regency/' + regency.Id,
        type: 'PUT',
        data: regency,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Regencies/Index/';
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
    if ($('#Provinces').val() == "Choose Province" || ($('Provinces').val() == 0) || ($('Provinces').val() == "")) {
        isAllValid = false;
        $('#Provinces').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Provinces').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Save();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');    
    $('#Provinces').siblings('span.error').css('visibility', 'hidden');
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
    if ($('#Provinces').val() == "Choose Province" || ($('Provinces').val() == " ")) {
        isAllValid = false;
        $('#Provinces').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Provinces').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        Edit();
    }
}

function LoadhideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');    
    $('#Provinces').siblings('span.error').css('visibility', 'hidden').val("Choose Province");
    $('#Provinces').val("Choose Province");
}


