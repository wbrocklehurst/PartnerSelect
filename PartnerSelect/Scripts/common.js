
// Redirect to custom error page
function DisplayError(page, message) {
    alert(message);
    var href = location.href.substring(0, location.href.lastIndexOf("/"));
    var nextUrl = href + "/Error.aspx?Url=" + page + "&Message=" + message;
    window.open(nextUrl, '_self');
}

// Format json date times in "DD-MM-YYYY HH:MM"
function FormatJsonDateTime(dateTime) {
    var jsonDate = new Date(dateTime);
    var formatted = ("0" + jsonDate.getDate()).slice(-2) + "/" + ("0" + (jsonDate.getMonth() + 1)).slice(-2) + "/" + jsonDate.getFullYear() +
                    " " + jsonDate.getHours() + ":" + ('0' + jsonDate.getMinutes()).slice(-2);
    return formatted;
}

// Format date in "DD/MM/YYYY"
function FormatDate(date) {
    var jsonDate = new Date(date);
    var formatted = ("0" + jsonDate.getDate()).slice(-2) + "/" + ("0" + (jsonDate.getMonth() + 1)).slice(-2) + "/" + jsonDate.getFullYear();
    return formatted;
}

function FormatTrueFalseToYesNo(value)
{
    var valueConverted;

    switch (value) {
        case true:
            valueConverted = "Yes";
            break;
        case false:
            valueConverted = "No";
            break;
        default:
            valueConverted = "N/A";
    }
    return valueConverted;
}

//function FormatGender(sex) {
//    alert(sex);
//    switch (sex) {
//        case "M":
//            return "Male";
//            break;
//        case "F":
//            return "Female";
//            break;
//        default:
//            return sex;
//    }
//}