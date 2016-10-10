function ValidateForm() {
    var txtDateArray = document.getElementsByClassName("txtDrawingDate");
    var txtJackpotArray = document.getElementsByClassName("txtJackpot");
    var validateDateField;
    var validateJackpotField;
    

    if (txtJackpotArray.length >= 1) {
        validateJackpotField = txtJackpotArray.item(0);

        if (validateJackpotField.value.trim() <= 0) {
            alert("Jackpot is required");
            validateJackpotField.focus();
            return false;
        }
    }

    if (txtDateArray.length >= 1) {
        validateDateField = txtDateArray.item(0);

        if (validateDateField.value.trim().length <= 0) {
            alert("Date is required.");
            validateDateField.focus();
            return false;
        }
    }

}