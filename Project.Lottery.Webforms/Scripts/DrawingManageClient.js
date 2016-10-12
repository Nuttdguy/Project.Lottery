/// <reference path="jquery-3.1.1.min.js" />

var _serviceUrl = "http://localhost:64999/Game/";


$(document).ready(function (e) {

    ////  LOAD GAME-LIST  ||==\\
    //onChange_drpDownGameName();
    $('.js_LotteryList tr').remove();
});



/*=========================================
            TABLE OF CONTENTS 
==========================================*/


/*========================================
            AJAX REQUESTS  
==========================================*/




/*========================================
            CLICK & BIND EVENTS 
==========================================*/



/*========================================
            DATA CONVERSION
==========================================*/





/*======================================
  [END] === TABLE OF CONTENTS 
========================================*/




/*****  [0].  AJAX |  ON-CHANGE  | DROP-DOWN GAME-NAME  *****/
/***************************************************/

function onChange_drpDownGameName() {

    var id = $('#js_drpDownGameName').val();

    $.ajax({
        type: "GET",
        url: _serviceUrl + "Drawing/List/" + id,
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (data) {
        console.log([data]);

        /******  CLEAR THE PRESENT RESULT SET  ******/
        $('.js_LotteryList').children().remove();

        var listItem = $('.js_LotteryList');

        for (var i = 0; i < data.length; i++) {
            drawId = data[i].LotteryDrawingId;

            edit_btn = '<td><button type="submit" id="' + drawId + '" class="js_EditButton" onclick="js_EditOnClick()"> Edit </button>';
            del_btn = '<button type="submit" id="' + drawId + '" class="js_DeleteButton" onclick="js_DeleteOnClick()"> Delete </button></td>';

            td_DrawId = '<td class="js_ListDrawingId" id="' + drawId + '" >' + drawId + '</td>';
            td_Jackpot = '<td class="js_ListJackpot" id="' + drawId + '" >' + data[i].Jackpot + '</td>';
            td_CashOption = '<td class="js_ListCashOption" id="' + drawId + '" >' + calcCashOption(data[i].Jackpot) + '</td>';
            td_DrawingDate = '<td class="js_ListDrawingDate" id="' + drawId + '" >' + data[i].DrawDates + '</td>';

            listItem.append('<tr id="' + data[i].LotteryDrawingId + '">' + edit_btn + del_btn + td_DrawId + td_Jackpot + td_CashOption + td_DrawingDate + '</tr>');
        }


    }).fail(function (data) {
        console.log("failed");

    }).always(function () {
        console.log("success");

    });

}


/*****  [1].  AJAX |  ONCLICK  | ADD NEW-GAME  *****/
/***************************************************/

function js_SaveItemButton_Click() {

    var lottoId = $('#js_drpDownGameName').val();
    var drawId = $('#js_txtDrawingId').val();
    var jackpot = $('#js_txtJackpot').val();
    var cashOption = $('#js_txtCashOption').val();
    var drawDateOfDrawing = $('#js_txtDrawingDate').val();

    var saveObject = {
        "LotteryId": lottoId,
        "LotteryDrawingId": drawId,
        "Jackpot": jackpot,
        "DrawDates": drawDateOfDrawing
    }

    var jsonIt = JSON.stringify(saveObject);
    console.log(jsonIt);

    $.ajax({
        type: "PUT",
        url: _serviceUrl + "Drawing/",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: jsonIt

    }).done(function (data) {
        console.log([data] + " success!");

    }).fail(function (data) {
        console.log(JSON.stringify(data) + " fail!");

    }).always(function () {

    })

}


/*****  [2].  AJAX |  ONCLICK  | DELETE GAME  *****/
/***************************************************/

function js_DeleteOnClick() {

    $(this).on('click', function (event) {
        var drawId = event.target.id;

        $.ajax({
            type: "DELETE",
            url: _serviceUrl + "Drawing/" + drawId,
            contentType: "application/json; charset=utf-8",
            dataType: "json"

        }).done(function (data) {
            console.log([data] + " success!");

        }).fail(function (data) {
            console.log(JSON.stringify(data) + " FAIL!!");

        }).always(function () {

        })
    })

}


/*****  [100].  EDIT-BUTTON  |  ONCLICK |  APPEND SELECTED DATA INTO FORM  *****/
/*****************************************************************/

function js_EditOnClick() {

    $(this).one('click', function (event) {

        startNode = $('.js_EditButton');

        var trId = event.target.id;
        var tdCol = $(startNode).parent().parent().children();

        var colId = $(tdCol[0]).attr("id");
        for (var i = 0; i < tdCol.length; i++) {
            colId = $(tdCol[i]).attr("id");

            //console.log([data])
            if (colId === trId) {
                //==||  CHECK THE CURRENT INDEX VALUE OF TDCOL ARRAY  ||==\\
                var data = $(tdCol[i]).attr('class');
                var tempName = $(tdCol[i]).html();
                if (data == "js_ListDrawingId") {
                    $('#js_txtDrawingId').val(tempName);
                    //alert(i + tempName);
                }
                else if (data == "js_ListJackpot") {
                    var status = $(tdCol[i]).html();
                    $('#js_txtJackpot').val(status);

                    //alert(i + status);
                }
                else if (data == "js_ListCashOption") {
                    var status = $(tdCol[i]).html();
                    $('#js_txtCashOption').val(status);

                    //alert(i + status);
                }
                else if (data == "js_ListDrawingDate") {
                    var status = $(tdCol[i]).html();
                    $('#js_txtDrawingDate').val(status);

                    //console.log(status);
                    //alert(i + status);
                }
                //console.log(data + "  |  " + tempName);
            }
        }

        event.preventDefault();
    });
}





/*****  [500].  CALCULATE CASH OPTION VALUE || AMOUNT  *****/
/***************************************************/

function calcCashOption(jackpotAmount) {
    return (jackpotAmount * .4).toFixed();
}
