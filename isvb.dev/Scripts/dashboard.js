
function getVisitorsCount() {
   $.ajax({
        type: 'GET',
        url: '../DashboardAPI/CountVisitors',
        dataType: 'json',
        contentType:'application/json',
        success:function(data){
            $("#visitors").text(data)
        }
    });
};
