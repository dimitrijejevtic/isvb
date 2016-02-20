function getVisitorsCount() {
    $.ajax({
        type: 'GET',
        url: 'DashboardAPI/CountVisitors',
        contentType: 'application/json',
        dataType:'json',
        success:function(data){
            $(".visitors").text(data)
        }
    });
};