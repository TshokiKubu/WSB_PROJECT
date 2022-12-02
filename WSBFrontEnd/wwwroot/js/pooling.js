$(document).ready(function (e) {

    
    $('#add-supplier').click(function () {
        $('#modal-add-supplier').modal('toggle');
    });

    $.ajax({
        type: "GET",
        url: "/Home/GetExchangeRate",
        data: "{}",
        success: function (data) {
            $("#currencyDropDownList").html("");

            var currencyDropDown = '<option value="-1">-- Select currency Type --</option>';
            for (var i = 0; i < data.length; i++) {
                currencyDropDown += '<option value="' + data[i].value + '">' + data[i].name + '</option>';
            }
            $("#currencyDropDownList").html(currencyDropDown);
        }
    });
});

refreshCovertionRate();
function refreshCovertionRate(a) {
    update(a);
    function update(b) {
        console.log(b);
        c = setTimeout(update, 15000, b)
    }
}