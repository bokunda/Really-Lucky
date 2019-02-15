var selectedNumbers = [];

function loadGames()
{
    $.get("api/games", function (data, status) {
        var html = "";
        for (var i = 0; i < data.length; i++) {
            html += "<div class=\"gameImg\"><img src=\"" + data[i].imgSrc + "\" class=\"img-games\" onclick=\"displayGameText(" + data[i].gameId + ")\"></div>";
        }

        document.getElementById("gameImages").innerHTML = html;
    });
}

function generateLucky6() {
    // instead 48 create const file and use it.
    var html = "<div class=\"lucky6-div\"";
    for (var i = 0; i < 48; i++) {
        if (i % 16 == 0) html += "<br><br>";
        html += "<div class=\"lucky6-ball\"  onclick=\"addNumberForTicket(" + (i+1) + ")\" ><span class=\"lucky6-num\">" + (i + 1) + "</span></div>";
    }
    html += "</div>";
    document.getElementById("gamePlayground").innerHTML = html;
}

function displayGameText(gameId)
{
    $.get("api/games/" + gameId, function(data, status) {
        document.getElementById("gameTitle").innerHTML = data.name;
        document.getElementById("gameDescription").innerHTML = data.description;

        generateLucky6();
    });
}

function addNumberForTicket(number) {
    // use constant instead 5
    if (selectedNumbers.length < 6) {
        if (selectedNumbers.includes(number) == false) {
            selectedNumbers.push(number);
            document.getElementById("ticketNumbers").innerText = selectedNumbers;
            if (selectedNumbers.length == 6) {
                document.getElementById("submitTicket").innerHTML = "<button onclick=\"submitTicket()\" type=\"button\" class=\"btn btn-warning\" style=\"display: inline-block;\">Submit</button>";
            }
        }
    }
    else {
        alert("Ticket must have 6 numbers!");
    }
}

function updateStatistics() {
    $.get("api/tickets/getStatistics", function (data, status) {
        var html = "<h5 class=\"uppercase\">Statistics:</h5>";
        html += "<h6 class=\"uppercase\">Total tickets: " + data.tickets + "</h6>";
        html += "<h6 class=\"uppercase\">Winners: " + data.winners + "</h6>";
        document.getElementById("forOutput").innerHTML += html;
    });
}

function submitTicket() {
    var obj = {
        "GameId": "1",
        "LuckySixBalls": [
        ]
    }

    // use constant insetad 6
    for (var i = 0; i < 6; i++) {
        obj.LuckySixBalls.push({ "Number": selectedNumbers[i], "Color": "1", "RoundId": "1" });
    }
    obj = JSON.stringify(obj);
    
    $.ajax({
        type: "POST",
        url: "api/tickets/add",
        data: obj,
        success: function (data) {
            var ticketNumber = data;
            $.get("api/tickets/draw/1", function (data, status) {
                var good = 0;
                var html = "<h3 class=\"uppercase d-inline\">Drawed numbers: </h3>";
                // use constant instead 20
                console.log(data);
                for (var i = 0; i < 20; i++) {
                    if (selectedNumbers.includes(data.luckySixBalls[i].number)) {
                        html += "<h4 id=\"ticketNumbers\" class=\"d-inline text-danger\">" + data.luckySixBalls[i].number + " </h4>";
                        good++;
                    }
                    else {
                        html += "<h4 id=\"ticketNumbers\" class=\"d-inline\">" + data.luckySixBalls[i].number + " </h4>";
                    }
                }
                
                if (good == 6) {
                    html += "<br><h4 class=\"uppercase text-info\">You won!</h4>";
                    var st = { "Id": ticketNumber, "Status": "2" };
                    st = JSON.stringify(st);
                    $.ajax({
                        type: "POST",
                        url: "api/tickets/setstatus",
                        data: st,
                        success: function () {
                            console.log("Status updated.");
                            updateStatistics();
                        },
                        contentType: 'application/json'
                    });                    
                } else {
                    html += "<br><h4 class=\"uppercase text-danger\">You lose!</h4>";
                    var st = { "Id": ticketNumber, "Status": "1" };
                    st = JSON.stringify(st);
                    $.ajax({
                        type: "POST",
                        url: "api/tickets/setstatus",
                        data: st,
                        success: function () {
                            console.log("Status updated.");
                            updateStatistics();
                        },
                        contentType: 'application/json'
                    });
                }

                document.getElementById("forOutput").innerHTML = html;
            });
        },
        contentType: 'application/json'
    });

    
}