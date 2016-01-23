function getVisitorsCount() {
    $.ajax({
        type: 'GET',
        url: 'API/CountVisitors',
        dataType: 'json',
        contentType: 'application/json',
        success:function(data){
            alert(data)
        }
    });
};