
$("#LoginBtn").click(function () {
    debugger;
    var name = $("#nameText").val();
    var password = $("#passText").val();
    
    $.ajax({
        type: "GET",
        url: "https://localhost:44351/Axity/api/GetUser?name=" + name + "&password=" + password ,

        beforeSend: function (request) {
            request.setRequestHeader("Content-Type", "application/json");
        },
        success: function (data) {
            debugger;
            console.log(data);
            var isError = data.HasError;
            var msg = data.responseMsg;
            if (isError === true) {
                //var toast = new iqwerty.toast.Toast();
                console.log(data);

                alert(msg);
                //toast.setText('Error: ' + msg).Show();
            }
            else {
                window.location.href = "https://localhost:44308/Test/GetProducts";
            }
        }

    });
});
