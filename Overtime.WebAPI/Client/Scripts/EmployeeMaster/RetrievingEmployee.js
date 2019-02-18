$(document).ready(function () {
    LoadIndexEmployee();
    LoadPositionCombo();
    LoadVillageCombo();
    LoadProvinceCombo();
    LoadEmployeeCombo();
    //LoadhideAlert();

    $('#table').DataTable({
        "ajax": LoadIndexEmployee()
    });
    ClearScreen();
});

function LoadIndexEmployee() {
    debugger;
    $.ajax({
        url: "http://localhost:65228/api/Employee",
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.First_Name + '</td>';
                html += '<td>' + val.Last_Name + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Postal_Code + '</td>';
                //html += '<td>' + val.Salary + '</td>';
                html += '<td>' + val.Phone + '</td>';
                html += '<td>' + val.Managers_Id + '</td>';
                html += '<td>' + val.Positions.Name + '</td>';
                html += '<td>' + val.Villages.Name + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ');"></a> ';
                html += ' | <a href="#" class="fa fa-trash-o" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        }
    });
}

function LoadPositionCombo() {
    $.ajax({
        url: 'http://localhost:65228/api/Position',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var position = $('#Positions');
            $.each(result, function (i, Position) {
                $("<option></option>").val(Position.Id).text(Position.Name).appendTo(position);
            });
        }
    });
}



function LoadEmployeeCombo() {
    $.ajax({
        url: 'http://localhost:65228/api/Employee',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var employee = $('#Employees');
            $.each(result, function (i, Employee) {
                $("<option></option>").val(Employee.Id).text(Employee.Name).appendTo(employee);
            });
        }
    });
}

function LoadVillageCombo() {
    $.ajax({
        url: 'http://localhost:65228/api/Village',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var village = $('#Villages');
            $.each(result, function (i, Village) {
                $("<option></option>").val(Village.Id).text(Village.Name).appendTo(village);
            });
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
    debugger;
    var employee = new Object();
    employee.First_Name = $('#First_Name').val();
    employee.Last_Name = $('#Last_Name').val();
    employee.Address = $('#Address').val();
    employee.Provinces = $('#Provinces').val();
    employee.Regencies = $('#Regencies').val();
    employee.Districts = $('#Districts').val();
    employee.Villages = $('#Villages').val();
    employee.Postal_Code = $('#Postal_Code').val();
    employee.Salary = $('#Salary').val();
    employee.Phone = $('#Phone').val();
    employee.Positions = $('#Positions').val();
    employee.Managers = $('#Managers').val();
    employee.Username = $('#Username').val();
    employee.Password = $('#Password').val();
    employee.Question = $('#Question').val();
    employee.Answer = $('#Answer').val();
    $.ajax({
        url: 'http://localhost:65228/api/Employee',
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
                window.location.href = '/Employees/Index/';
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
            url: "http://localhost:65228/api/Employee/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Employees/Index/';
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
        url: 'http://localhost:65228/api/Employee/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#First_Name').val(result.First_Name);
            $('#Last_Name').val(result.Last.Name);
            $('#Address').val(result.Address);
            $('#Postal_Code').val(result.Postal_Code);
            $('#Salary').val(result.Salary);
            $('#Phone').val(result.Phone);
            $('#Positions').val(result.Positions.Id);
            $('#Villages').val(result.Villages.Id);
            $('#Managers').val(result.Managers.Id);            
            $('#myModal').modal('show');
            $('#Save').hide();
            $('#Update').show();
        }
    })
}

function Edit() {    
    var employee = new Object();
    employee.Id = $('#Id').val();
    employee.First_Name = $('#First_Name').val();
    employee.Last_Name = $('#Last_Name').val();
    employee.Address = $('#Address').val();
    employee.Provinces = $('#Provinces').val();
    employee.Regencies = $('#Regencies').val();
    employee.Districts = $('#Districts').val();
    employee.Villages = $('#Villages').val();
    employee.Postal_Code = $('#Postal_Code').val();
    employee.Salary = $('#Salary').val();
    employee.Phone = $('#Phone').val();
    employee.Positions = $('#Positions').val();
    employee.Managers = $('#Managers').val();
    $.ajax({
        url: 'http://localhost:65228/api/Employee/' + employee.Id,
        type: 'PUT',
        data: employee,
        dataType: 'json',
        success: function (response) {
            swal({
                title: "Updated!",
                text: "your data has been updated!",
                type: "success"
            },
            function () {
                window.location.href = '/Employees/Index/';
                $('#Id').val('');
                $('#First_Name').val('');
                $('#Last_Name').val('');
                $('#Address').val('');
                $('#Provinces').val('');
                $('#Regencies').val('');
                $('#Districts').val('');
                $('#Villages').val('');
                $('#Postal_Code').val('');
                $('#Salary').val('');
                $('#Phone').val('');
                $('#Positions').val('');
                $('#Managers').val('');
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
    function ValidationSave() {
        var isAllValid = true;
        if ($('#First_Name').val() == "" || ($('First_Name').val() == " ")) {
            isAllValid = false;
            $('#First_Name').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#First_Name').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Last_Name').val() == "" || ($('Last_Name').val() == " ")) {
            isAllValid = false;
            $('#Last_Name').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Last_Name').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Address').val() == "" || ($('Address').val() == " ")) {
            isAllValid = false;
            $('#Address').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Address').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Provincies').val() == "Choose Provincies" || ($('Provincies').val() == 0) || ($('Provincies').val() == "")) {
            isAllValid = false;
            $('#Provincies').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Provincies').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Regencies').val() == "Choose Regencies" || ($('Regencies').val() == 0) || ($('Regencies').val() == "")) {
            isAllValid = false;
            $('#Regencies').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Regencies').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Districts').val() == "Choose Districts" || ($('Districts').val() == 0) || ($('Districts').val() == "")) {
            isAllValid = false;
            $('#Districts').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Districts').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Villages').val() == "Choose Villages" || ($('Villages').val() == 0) || ($('Villages').val() == "")) {
            isAllValid = false;
            $('#Villages').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Villages').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Postal_Code').val() == "" || ($('Postal_Code').val() == " ")) {
            isAllValid = false;
            $('#Postal_Code').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Postal_Code').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Salary').val() == "" || ($('Salary').val() == " ")) {
            isAllValid = false;
            $('#Salary').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Salary').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Phone').val() == "" || ($('Phone').val() == " ")) {
            isAllValid = false;
            $('#Phone').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Phone').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#Positions').val() == "Choose Positions" || ($('Positions').val() == 0) || ($('Positions').val() == "")) {
            isAllValid = false;
            $('#Positions').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Positions').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Managers').val() == "Choose Managers" || ($('Managers').val() == 0) || ($('Managers').val() == "")) {
            isAllValid = false;
            $('#Managers').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Managers').siblings('span.error').css('visibility', 'hidden');
        }
        if (isAllValid) {
            Save();
        }
    }

    function LoadhideAlert() {
        $('#First_Name').siblings('span.error').css('visibility', 'hidden');
        $('#Last_Name').siblings('span.error').css('visibility', 'hidden');;
        $('#Address').siblings('span.error').css('visibility', 'hidden');
        $('#Provinces').siblings('span.error').css('visibility', 'hidden');
        $('#Regencies').siblings('span.error').css('visibility', 'hidden');
        $('#Districts').siblings('span.error').css('visibility', 'hidden');
        $('#Villages').siblings('span.error').css('visibility', 'hidden');
        $('#Postal_Code').siblings('span.error').css('visibility', 'hidden');
        $('#Salary').siblings('span.error').css('visibility', 'hidden');
        $('#Phone').siblings('span.error').css('visibility', 'hidden');
        $('#Positions').siblings('span.error').css('visibility', 'hidden');
        $('#Managers').siblings('span.error').css('visibility', 'hidden');
    }

    function ValidationEdit() {
        var isAllValid = true;
        if ($('#First_Name').val() == "" || ($('First_Name').val() == " ")) {
            isAllValid = false;
            $('#First_Name').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#First_Name').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Last_Name').val() == "" || ($('Last_Name').val() == " ")) {
            isAllValid = false;
            $('#Last_Name').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Last_Name').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Address').val() == "" || ($('Address').val() == " ")) {
            isAllValid = false;
            $('#Address').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Address').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Provincies').val() == "Choose Provincies" || ($('Provincies').val() == 0) || ($('Provincies').val() == "")) {
            isAllValid = false;
            $('#Provincies').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Provincies').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Regencies').val() == "Choose Regencies" || ($('Regencies').val() == 0) || ($('Regencies').val() == "")) {
            isAllValid = false;
            $('#Regencies').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Regencies').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Districts').val() == "Choose Districts" || ($('Districts').val() == 0) || ($('Districts').val() == "")) {
            isAllValid = false;
            $('#Districts').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Districts').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Villages').val() == "Choose Villages" || ($('Villages').val() == 0) || ($('Villages').val() == "")) {
            isAllValid = false;
            $('#Villages').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Villages').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Postal_Code').val() == "" || ($('Postal_Code').val() == " ")) {
            isAllValid = false;
            $('#Postal_Code').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Postal_Code').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Salary').val() == "" || ($('Salary').val() == " ")) {
            isAllValid = false;
            $('#Salary').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Salary').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Phone').val() == "" || ($('Phone').val() == " ")) {
            isAllValid = false;
            $('#Phone').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Phone').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#Positions').val() == "Choose Positions" || ($('Positions').val() == 0) || ($('Positions').val() == "")) {
            isAllValid = false;
            $('#Positions').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Positions').siblings('span.error').css('visibility', 'hidden');
        }
        if ($('#Managers').val() == "Choose Managers" || ($('Managers').val() == 0) || ($('Managers').val() == "")) {
            isAllValid = false;
            $('#Managers').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Managers').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            Edit();
        }
    }
}







