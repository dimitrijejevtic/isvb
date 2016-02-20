    $(".btn").click(function () {
        var id = this.id;
        var input = document.getElementById("qty-" + id);
        var q = input.value;
        var dat;
        $.ajax({
            type: 'GET',
            url: '../Cart/AddToCart?id=' + id + '&quant=' + q,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                dat=data;
            }           
        });
        var info = $(".alert-info");
        info.text("Product added");
        info.css("display", "block");
     });