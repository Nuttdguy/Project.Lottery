/// <reference path="jquery-3.1.1.min.js" />

var _serviceNavUrl = "http://localhost:64999/Game";


$(document).ready(function (e) {

    //==||  CONTENT-NAV GAME-NAME DROPDOWN  ||==\\
    getDropDownGameNames();

})




//==||  DROP-DOWN GAME NAME NAVIGATION ||==\\
function getDropDownGameNames() {

    $.ajax({
        type: "GET",
        url: _serviceNavUrl + "/Detail/List/",
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (data) {
        var dropDown = $("#js_drpDownGameName");

        for (var i = 0; i < data.length; i++) {
            dropDown.append($('<option></option>').val(data[i].LotteryId).html(data[i].LotteryName));
        }

    }).fail(function (data) {

    }).always(function () {

    })
}



////==||  ON-SELECT : LOAD CONTENT  ||==\\

//function onChange_drpDownGameName() {

//    _selectedLotteryId =  $('#js_drpDownGameName').val();

//}


