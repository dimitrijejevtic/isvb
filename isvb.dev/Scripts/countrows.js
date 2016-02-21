var interval = 5000;  // 1000 = 1 second, 3000 = 3 seconds
function doAjax() {
    $.ajax({
        type: 'POST',
        url: '../Cart/CountRows',
        success: function (data) {
            $(".myCart").text(data);
        },
        complete: function (data) {

            setTimeout(doAjax, interval);
        }
    });
}
setTimeout(doAjax, interval);