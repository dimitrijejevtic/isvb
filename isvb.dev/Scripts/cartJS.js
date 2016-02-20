    $(".btn").click(function () {
        var id = this.id;
        var input = document.getElementById("qty-" + id);
        var q = input.value;
        return $.ajax({
            type: 'GET',
            url: '../Cart/AddToCart?id=' + id + '&quant=' + q,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                alert(data)
            }
        });
    });