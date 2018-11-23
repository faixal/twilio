// Write your JavaScript code.
function sendSms() {
    var number = $("#sms-to-number").val();
    var body = $("#sms-body").val();

    var server = { Number: number, Body: body };

    $.ajax({
        url: "api/Sms/SendSms",
        type: "POST",
        data: server,
        success: function (data) {
            $("#response").html(JSON.stringify(data, null, 2));
        },
        error: function (p1, p2, p3) {

        }
    });
}

function makeCall() {
    var number = $("#call-to-number").val();    
    var server = { Number: number};

    $.ajax({
        url: "api/Phone/MakeCall",
        type: "POST",
        data: server,
        success: function (data) {
            $("#response").html(JSON.stringify(data, null, 2));
        },
        error: function (p1, p2, p3) {

        }
    });
}

function receiveCall() {
    $.ajax({
        url: "api/Phone/ReceiveCall",
        type: "POST",
        success: function (data) {
            $("#response").html(JSON.stringify(data, null, 2));
        },
        error: function (p1, p2, p3) {

        }
    });
}