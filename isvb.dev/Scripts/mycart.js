    $(".update").click(function () {
        var id = this.id;
        var input = document.getElementById("qty-" + id);
        var q = input.value;
        updateFunction(id, q);
    });

function updateFunction(id, q) {
    $.ajax({
        type: 'POST',
        url: 'UpdateItem?id=' + id + '&quant=' + q,
        contentType: 'application/json'

    });
}
    $(".delete").click(function () {
        var id = this.id;
        deleteFunction(id);
    });

function deleteFunction(id) {
    $.ajax({
        type: 'GET',
        url: 'DeleteItem?id=' + id,
        contentType: 'application/json'

    });
}