/// <reference path="jquery-3.1.1.min.js" />

var _serviceUrl = "http://localhost:64999/Game/";



$(document).ready(function (e) {

    //  LOAD GAME-LIST  ||==\\
    GetLotteryGames();

});



/*=========================================
            TABLE OF CONTENTS 
==========================================*/


/*========================================
            AJAX REQUESTS  
==========================================*/

//== [0]. GetLotteryGames()
//== [2]. SaveGameNameButton_Click()
//== [4]. js_DeleteOnClick();


/*========================================
            CLICK & BIND EVENTS 
==========================================*/

//== [100]. js_EditOnClick()




/*========================================
            DATA CONVERSION
==========================================*/

//== [500]. changeBoolOutputDisplayText()



/*===========    END TOC   ===================*/





/*****  [0]  GET THE LIST OF ALL GAMES  *****/
function GetLotteryGames() {

    $.ajax({
        type: "GET",
        url: _serviceUrl + "Detail/List/",
        contentType: "application/json; charset=utf-8",
        dataType: "json"

    }).done(function (data) {
        var listItem = $('.js_LotteryList');

        for (var i = 0; i < data.length; i++) {
            lotteryId = data[i].LotteryId;

            edit_btn = '<td><button type="submit" id="'+lotteryId+'" class="js_EditButton" onclick="js_EditOnClick()"> Edit </button>';
            del_btn = '<button type="submit" id="'+lotteryId + '" class="js_DeleteButton" onclick="js_DeleteOnClick()"> Delete </button></td>';
            td_LotteryId = '<td class="js_LotteryId" id="'+lotteryId+'" >' + lotteryId + '</td>';
            td_LotteryGameName = '<td class="js_LotteryName" id="'+lotteryId+'" >' + data[i].LotteryName + '</td>';
            td_HasSpecialBall = '<td class="js_HasSpecialBall" id="'+lotteryId+'" >' + changeBoolOutputDisplayText(data[i].HasSpecialBall) + '</td>';
            td_HasRegularBall = '<td class="js_HasRegularBall" id="'+lotteryId+'" >' + changeBoolOutputDisplayText(data[i].HasRegularBall) + '</td>';
            td_NumberOfBalls = '<td class="js_NumberOfBalls" id="'+lotteryId+'" >' + data[i].NumberOfBalls + '</td>';

            listItem.append('<tr id="' + data[i].LotteryId + '">' + edit_btn + del_btn + td_LotteryId + td_LotteryGameName + td_HasSpecialBall + td_HasRegularBall + td_NumberOfBalls + '</tr>');
        }

    }).fail(function (data) {

    }).always(function () {

    });

}


/*****  [2] SAVE-BUTTON || CLICK-EVENT  *****/
function SaveGameName_OnClick() {
    
    var lotteryName = $('#js_txtLotteryName').val();
    var specialBall = $('#js_txtHasSpecialBall').prop('checked');
    var regularBall = $('#js_txtHasRegularBall').prop('checked');
    var numberOfBall = $('#js_txtNumberOfBalls').val();
    var lotteryObject = {
        "LotteryName": lotteryName,
        "HasSpecialBall": specialBall,
        "HasRegularBall": regularBall,
        "NumberOfBalls": numberOfBall
    }

    var jsonLottery = JSON.stringify(lotteryObject);

    $.ajax({
        type: "PUT",
        url: _serviceUrl + 'Detail/',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: jsonLottery

    }).done(function (data) {
        console.log(data);

    }).fail(function (data) {
        console.log(data + 'failed');

    }).always(function () {
        console.log('always');
    })
    
}


/*****  [4] DELETE-BUTTON || AJAX CLICK-EVENT  *****/
function js_DeleteOnClick() {

    $(this).click(function (event) {
        var id = event.target.id;

        $.ajax({
            type: "DELETE",
            url: _serviceUrl + "Detail/" + id,
            contentType: "application/json; charset=utf-8",
            dataType: "json",

        }).done(function (data) {
            console.log(data + "success");

        }).fail(function (data) {
            console.log(data + "fail");

        }).always(function () {
            console.log("always");

        });

    })
}


/*****  [100] EDIT-BUTTON || CLICK-EVENT || APPEND SELECTED DATA INTO FORM  *****/
function js_EditOnClick() {

    $(this).on('click', function (event) {

        startNode = $('.js_EditButton');

        var trId = event.target.id;
        var tdCol = $(startNode).parent().parent().children();

        var colId = $(tdCol[0]).attr("id");
        for (var i = 0; i < tdCol.length; i++) {
            colId = $(tdCol[i]).attr("id");

            //console.log(colId + " || " + trId + " == i =" + i)
            if (colId === trId) {
                //==||  CHECK THE CURRENT INDEX VALUE OF TDCOL ARRAY  ||==\\
                var data = $(tdCol[i]).attr('class');
                var tempName = $(tdCol[i]).html();
                if (data == "js_LotteryName") {
                    $('#js_txtLotteryName').val(tempName);
                    //alert(i + tempName);
                }
                else if (data == "js_HasSpecialBall") {
                    var status = $(tdCol[i]).html();
                    if (status.toLowerCase() == "yes") {
                        $('#js_txtHasSpecialBall').prop('checked', true);
                    } else {
                        $('#js_txtHasSpecialBall').prop('checked', false);
                    }
                    //alert(i + status);
                }
                else if (data == "js_HasRegularBall") {
                    var status = $(tdCol[i]).html();
                    if (status.toLowerCase() == "yes") {
                        $('#js_txtHasRegularBall').prop('checked', true);
                    } else {
                        $('#js_txtHasRegularBall').prop('checked', false);
                    }
                    //alert(i + status);
                }
                else if (data == "js_NumberOfBalls") {
                    var status = $(tdCol[i]).html();
                    $('#js_txtNumberOfBalls').val(status);
                    //alert(i + status);
                }
                console.log(data + "  |  " + tempName);
            }
        }

        event.preventDefault();
    });
}


/*****  [500] CHANGE OUTPUT OF BOOL VALUE  *****/
function changeBoolOutputDisplayText(boolToChange) {

    if (boolToChange) {
        return "Yes";
    } else {
        return "No";
    }
}



