
$(document).ready(function ()
{
    $(".active").removeClass("active");
    $(".homeNav").addClass("active");
    getBalance();
    getInventory();
    feedBillEvents();

    $("#change").on("click", getChange);
});

let yourBalance = 0;

function feedBillEvents() {
    $("#1bill").on("click", function (e) {
        sendMoney(1);
    });
    $("#5bill").on("click", function (e) {
        sendMoney(5);
    });
    $("#10bill").on("click", function (e) {
        sendMoney(10);
    });
}

function getChange() {
    if (yourBalance > 0) {
        $.ajax({
            url: vndrServerUrl + "api/change",
            type: "POST"
        }).done(function (response) {
            $("#feedBackStatus").text(response.status.status);

            let message = "Your change: ";

            if (response.change.dollars > 0) {
                message += `Dollars: ${response.change.dollars} `;
            }

            if (response.change.quarters > 0) {
                message += `Quarters: ${response.change.quarters} `;
            }

            if (response.change.dimes > 0) {
                message += `Dimes: ${response.change.dimes} `;
            }

            if (response.change.nickels > 0) {
                message += `Nickels: ${response.change.nickels} `;
            }

            if (response.change.pennies > 0) {
                message += `Pennies: ${response.change.pennies} `;
            }

            $("#feedBackImage").removeClass();
            $("#feedBackImage").addClass("fas far fa-coins fa-5x text-center card-img-top debug");
            $("#feedBackMessage").text(message);

            getBalance();
            getInventory();
        });
    }
    else {
        $("#feedBackStatus").text("Woops");
        $("#feedBackImage").removeClass();
        $("#feedBackImage").addClass("fas far fa-coins fa-5x text-center card-img-top debug");
        $("#feedBackMessage").text("You had no money");
    }        
}

function sendMoney(amt) {    
    $.ajax({
        url: vndrServerUrl + "api/feedmoney",
        type: "POST",
        data: {
            amount: amt
        }
    }).done(function (response) {
        getBalance();
        feedMessage(amt, response.status);
        getInventory();
    });
}

function getInventory() {
    $.ajax({
        url: vndrServerUrl + "api/inventory",
        type: "GET",
        dataType: "json"
    }).done(function (data) {
        $("#itemContainer").empty();

        let rowDiv = {};
        for (let colIdx = 0; colIdx < data.length; colIdx++) {
            rowDiv = $("<div>");

            for (let rowIdx = 0; rowIdx < data[colIdx].length; rowIdx++) {                
                let item = data[colIdx][rowIdx];
                let key = item.inventory.key;
                let row = item.inventory.row.toString();
                let col = item.inventory.column.toString();

                //Create objects to hold new item
                let card = $("<div>").addClass("card");
                let title = $("<h5>").addClass("card-title");
                let header = $("<h5>").addClass("card-header");
                let image = $("<img>").addClass("card-img-top ");
                let price = $("<div>").addClass("card-footer");
                let itemSoldOut = $("<p>").addClass("card-text text-center align-middle cardss");

                title.text(item.product.name);
                header.text(item.product.name);
                card.append(header);
                
                //Add attributes
                price.text(`$${item.product.price.toFixed(2)}`);
                if (item.inventory.qty > 0) {
                    image.attr("src", item.product.image);
                    image.addClass("itemImage");
                    card.append(image);
                }
                else {
                    itemSoldOut.text("Sold Out");
                    card.append(itemSoldOut);
                }

                card.attr("id", key);
                card.css({ "grid-row": row });
                card.data("Row", row);
                card.data("Col", col);

                card.append(price);

                //Events
                if (item.inventory.qty === 0) {
                    card.addClass("cantClick");
                    card.on("click", soldOut);
                }
                else if (item.product.price > yourBalance) {
                    card.addClass("cantClick");
                    card.on("click", notEnough);
                }
                else {
                    card.on("click", purchaseProduct);
                    card.on("click", function () {                     
                    });
                }
                card.addClass("vendingItem");
                rowDiv.append(card);
            }

            $("#itemContainer").append(rowDiv);
        }
    });
}

function notEnough(e) {
    updateStatus("fa-times-circle", "Not enough money", "Error");
    for (var x = 1; x <= 3; x++) {
        $(this).animate({ "left": "+=20px" }, 50).animate({ "left": "-=20px" }, 50).animate({ "left": "-=20px" }, 50).animate({ "left": "+=20px" }, 50)
    }
}

function soldOut(e) {
    updateStatus("fa-times-circle", "Item is sold out", "Error");
    for (var x = 1; x <= 3; x++) {
        $(this).animate({ "left": "+=20px" }, 50).animate({ "left": "-=20px" }, 50).animate({ "left": "-=20px" }, 50).animate({ "left": "+=20px" }, 50)
    }
}

function purchaseProduct() {
    let prodCol = $(this).data("Col");
    let prodRow = $(this).data("Row");

    $.ajax({
        url: vndrServerUrl + "api/purchase",
        type: "POST",
        dataType: "json",
        data: {
            row: prodRow,
            col: prodCol
        }
    }).done(function (data) {
        console.log(data);
        getBalance();
        let image = "fa-thumbs-up";
        if (data.status === "Error") {
            image = "fa-times-circle";
        }
        updateStatus(image, data.message, data.status);
        getInventory();
    });
}

function feedMessage(amount, status) {
    updateStatus("fa-money-bill-wave", `$${amount} added to balance`, status);
}

function updateStatus(image, message, status) {
    $("#feedBackImage").removeClass();
    $("#feedBackImage").addClass(`fas far ${image} fa-5x text-center card-img-top debug`);
    $("#feedBackMessage").text(message);
    $("#feedBackStatus").text(status);
}

function getBalance() {
    $.ajax({
        url: vndrServerUrl + "api/balance",
        type: "GET",
        dataType: "json"
    }).done(function (data)
    {
        yourBalance = data;
        let balance = formatter.format(data);
        $("#balance").text(balance);
    });
}

const formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
    minimumFractionDigits: 2
});