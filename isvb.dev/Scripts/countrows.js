var interval = 30000;  // 1000 = 1 second, 3000 = 3 seconds
function doAjax() {
    $.ajax({
        type: 'POST',
        url: 'CountRows',
        dataType: 'json',
        success: function (data) {
            $('#hidden').val(data);
        },
        complete: function (data) {

            setTimeout(doAjax, interval);
        }
    });
}
setTimeout(doAjax, interval);