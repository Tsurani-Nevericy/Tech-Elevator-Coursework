function filterOperation(data, selection) {
    let result = [];

    for (let i = 0; i < data.length; i++) {
        if (selection == "all" || data[i].operationType == selection) {
            result.push(data[i]);
        }
    }

    return result;
}

function filterUsers(data, selection) {
    let result = [];

    for (let i = 0; i < data.length; i++) {
        if (selection == "all" || data[i].userId == selection) {
            result.push(data[i]);
        }
    }

    return result;
}

function filterProducts(data, selection) {
    let result = [];

    for (let i = 0; i < data.length; i++) {
        if (selection == "all" || data[i].productId == selection) {
            result.push(data[i]);
        }
    }

    return result;
}

function buildLogTable(data) {

    for (let i = 0; i < data.length; i++) {

        let logBlock = $("<div>").addClass("row");
        logBlock.append($("<div>").addClass("col-sm-1"));

        let date = $("<div>").html(data[i].timeStampStr).addClass("col-3");
        let transaction = $("<div>").addClass("col-4");
        if (data[i].operationType == 1) {
            transaction.html("FEED MONEY");
        }
        else if (data[i].operationType == 2) {
            transaction.html("GIVE CHANGE");
        }
        else {
            transaction.html("PURCHASE: " + data[i].productName);
        }
        let price = $("<div>").html("$" + data[i].price.toFixed(2)).addClass("col-2");

        logBlock.append(date);
        logBlock.append(transaction);
        logBlock.append(price);
        logBlock.append($("<div>").addClass("col-sm-1"));

        $("#logBox").append(logBlock);
    }
}

function updateLogData() {
    $.ajax({
        url: vndrServerUrl + "api/log",
        type: "GET",
        dataType: "json",
    }).done(function (data) {

        data = filterOperation(data, $("#operations").val());
        data = filterUsers(data, $("#users").val());
        data = filterProducts(data, $("#products").val());
        buildLogTable(data);
    });
}

$(document).ready(function () {

    updateLogData();

    $(".active").removeClass("active");
    $(".logNav").addClass("active");

    $("#operations").change(function () {
        $(".headerRow").nextAll("div").remove();
        updateLogData();        
    });

    $("#users").change(function () {
        $(".headerRow").nextAll("div").remove();
        updateLogData();
    });

    $("#products").change(function () {
        $(".headerRow").nextAll("div").remove();
        updateLogData();
    });
    
});