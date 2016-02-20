    $(".btn").click(function () {
        var id = this.id;
        var input = document.getElementById("qty-" + id);
        var q = input.value;
        $.ajax({
            type: 'GET',
            url: '../Cart/AddToCart?id=' + id + '&quant=' + q,
            contentType: 'application/json',
            success: function (data) {
                var info = $(".alert-info");
                info.text(data);
                info.css("display", "block");
            }           
        });
        
     });