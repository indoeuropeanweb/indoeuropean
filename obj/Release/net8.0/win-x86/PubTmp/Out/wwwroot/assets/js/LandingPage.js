
var generatedOTP;
var Fname;
var Lname; 
var CountryCodeid;
var PhoneNo;
var WhatsappNo;
var Emailid;
var Country1;
var PrefferedBranchID; 
var Levelid;
var TermsAccept;
var Address1Citytext;
var Intakeid;
var EnquirySourceCategoryID;
var EnquirySourceID;
var EnqStageid;
var Isstatusid;
var EnqDate;
var Dob;
var PrefferedCallBackTime;
var HighestQualifcation;
var branchid;
var LandingPageUrl;
var phoneRegex;
var PhonenoOTPStatus='0';

function btnclick() {
    Fname = $("#txtFName_1").val() || '';
    Lname = $('#txtLName').val() || '';
    CountryCodeid = $("#ddlCountryCodeid_1").val() || '67';
    PhoneNo = $("#txtPhone_1").val() || '';
    WhatsappNo = '';
    Emailid = $("#txtEmail_1").val() || '';
    Country1 = $("#ddlDestinationCodeid_1").val();
    if (Country1 === 'Select' || Country1 === null || Country1 === undefined) {
        Country1 = '';
    }
    PrefferedBranchID = $("#ddlBranchCodeId_1").val();
    if (PrefferedBranchID === 'Select' || PrefferedBranchID === null || PrefferedBranchID === undefined) {
        PrefferedBranchID = '';
    }
    Levelid = $("#ddlCourseCodeId_1").val();
    if (Levelid === 'Select' || Levelid === null || Levelid === undefined) {
        Levelid = '';
    }
    TermsAccept = $("#terms_accept").is(':checked');
    Address1Citytext = $("#txtCity_1").val();
    Intakeid = '';
    EnquirySourceCategoryID = window.EnquirySourceCategoryID;
    EnquirySourceID = window.EnquirySourceID;
    EnqStageid = window.EnqStageid;
    Isstatusid = '1';
    EnqDate = '';
    Dob = '';
    PrefferedCallBackTime = $("#ddlPreferredCallBackTime_1").val();
    if (PrefferedCallBackTime === 'Select' || PrefferedCallBackTime === null || PrefferedCallBackTime === undefined) {
        PrefferedCallBackTime = '';
    }
    HighestQualifcation = $("#ddlHighestQualifcation_1").val();
    if (HighestQualifcation === 'Select' || HighestQualifcation === null || HighestQualifcation === undefined) {
        HighestQualifcation = '';
    }
    branchid = window.branchid;
    LandingPageUrl = window.location.href;
    phoneRegex = /^\d{10}$/;


    if (!Fname) {
        alert("Please enter your first name.");
        return false;
    }


    if (!Emailid) {
        alert("Please enter your email address.");
        return false;
    }



    if (!CountryCodeid) {
        alert("Please select your country code.");
        return false;
    }

    if (!PhoneNo) {
        alert("Please enter your phone number.");
        return false;
    }
    if (CountryCodeid !== 67 && PhoneNo.length !== 10) {
        alert("Please enter a valid 10-digit phone number.");
        return false;
    }



    if (!Address1Citytext) {
        alert("Please enter your city.");
        return false;
    }


    if (Country1 === "Select" || Country1 === "") {
        alert("Please select a valid study destination.");
        return false;
    }


    //if (PrefferedBranchID === "Select" || PrefferedBranchID === "") {
    //    alert("Please select a preferred branch.");
    //    return false;
    //}


    if (Levelid === "Select" || Levelid === "") {
        alert("Please select a  Course.");
        return false;
    }



    Create_Lead();

}

function formValidation() {
    Fname = $("#txtFName").val() || '';
    Lname = $('#txtLName').val() || '';
    CountryCodeid = $("#ddlCountryCodeid").val() || '';
    PhoneNo = $("#txtPhone").val() || '';
    WhatsappNo = '';
    Emailid = $("#txtEmail").val() || '';
    Country1 = $("#ddlDestinationCodeid").val();
    if (Country1 === 'Select' || Country1 === null || Country1 === undefined) {
        Country1 = '';
    }
    PrefferedBranchID = $("#ddlBranchCodeId").val();
    if (PrefferedBranchID === 'Select' || PrefferedBranchID === null || PrefferedBranchID === undefined) {
        PrefferedBranchID = '';
    }
    Levelid = $("#ddlCourseCodeId").val();
    if (Levelid === 'Select' || Levelid === null || Levelid === undefined) {
        Levelid = '';
    }
     TermsAccept = $("#terms_accept").is(':checked');
     Address1Citytext = $("#txtCity").val();
     Intakeid = '';
     EnquirySourceCategoryID = window.EnquirySourceCategoryID;
     EnquirySourceID = window.EnquirySourceID;
     EnqStageid = window.EnqStageid;
     Isstatusid = '1';
     EnqDate = '';
     Dob = '';
    PrefferedCallBackTime = $("#ddlPreferredCallBackTime").val();
    if (PrefferedCallBackTime === 'Select' || PrefferedCallBackTime === null || PrefferedCallBackTime === undefined) {
        PrefferedCallBackTime = '';
    }
    HighestQualifcation = $("#ddlHighestQualifcation").val();
    if (HighestQualifcation === 'Select' || HighestQualifcation === null || HighestQualifcation === undefined) {
        HighestQualifcation = '';
    }
     branchid = window.branchid;
     LandingPageUrl = window.location.href;
     phoneRegex = /^\d{10}$/;

  
        if (!Fname) {
            alert("Please enter your first name.");
            return false;
        }
    
  
        if (!Emailid) {
            alert("Please enter your email address.");
            return false;
        }
    
   

        if (!CountryCodeid) {
            alert("Please select your country code.");
            return false;
        }

        if (!PhoneNo) {
            alert("Please enter your phone number.");
            return false;
        }
        if (CountryCodeid !== 67 && PhoneNo.length !== 10) {
            alert("Please enter a valid 10-digit phone number.");
            return false;
        }
  

   
        if (!Address1Citytext) {
            alert("Please enter your city.");
            return false;
        }
    
    
        //if (Country1 === "Select" || Country1 === "") {
        //    alert("Please select a valid study destination.");
        //    return false;
        //}
   
   
        //if (PrefferedBranchID === "Select" || PrefferedBranchID === "") {
        //    alert("Please select a preferred branch.");
        //    return false;
        //}
  
  
        //if (Levelid === "Select" || Levelid === "") {
        //    alert("Please select a  Course.");
        //    return false;
        //}
    
   
       
    Create_Lead();

}
function Create_Lead() {
//API For CRM
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/OnlineLead',
        //url: 'http://testcrm.indoeuropean.in/WebService/Lead.asmx/OnlineLead',
        type: 'GET',
        dataType: 'json',
        data: {
            Fname: Fname,
            Lname: Lname,
            CountryCodeid: CountryCodeid,
            PhoneNo: PhoneNo,
            WhatsappNo: WhatsappNo,
            Emailid: Emailid,
            EnquirySourceCategoryID: EnquirySourceCategoryID,
            EnquirySourceID: EnquirySourceID,
            EnqStageid: EnqStageid,
            branchid: branchid,
            Country1: Country1,
            Levelid: Levelid,
            Intakeid: Intakeid,
            Address1Citytext: Address1Citytext,
            Isstatusid: Isstatusid,
            EnqDate: EnqDate,
            Dob: Dob,
            PrefferedCallBackTime: PrefferedCallBackTime,
            HighestQualifcation: HighestQualifcation,
            PrefferedBranchID: PrefferedBranchID,
            LandingPageUrl: LandingPageUrl,
            PhonenoOTPStatus: PhonenoOTPStatus
        },
        success: function () {
            window.location.href = "/home/thankyou";
        },
        error: function () {
            alert("Query Submission Failed!");
        }
    });

    //API End
}

//function validateCaptcha() {
//    const userAnswer = document.getElementById('user-captcha').value;
//    const correctAnswer = document.getElementById('captcha-answer').value;
//    $('#errorCaptcha').css({
//        'display': 'none',
//        'color': 'red'
//    });

//    if (parseInt(userAnswer) === parseInt(correctAnswer)) {
//        return true;
//    } else {
//        $('#errorCaptcha').css({
//            'display': 'block',
//            'color': 'red'
//        }).text("CAPTCHA validation failed. Please try again.");
//        generateCaptcha();
//        return false;
//    }
//}

function formFieldsControl() {
    // Function to show or hide a div based on its boolean value;
    function toggleDiv(divId, show) {
        if (show) {
            $('#' + divId).show();
        } else {
            $('#' + divId).hide();
        }
    }

    // Toggle each div based on its corresponding boolean value;
    toggleDiv('divFname', window.divFname);
    toggleDiv('divLname', window.divLname);
    toggleDiv('divEmail', window.divEmail);
    toggleDiv('divCountryCodeId', window.divCountryCodeId);
    toggleDiv('divCity', window.divCity);
    toggleDiv('divDestinationCodeid', window.divDestinationCodeid);
    toggleDiv('divBranchCodeId', window.divBranchCodeId);
    toggleDiv('divCourseCodeId', window.divCourseCodeId);
    toggleDiv('divterms_accept', window.divterms_accept);
    toggleDiv('divCaptcha', window.divCaptcha);

}


//API Fill dropdown
$(document).ready(function () {
    console.log('callfunction');
    formFieldsControl();
    $('#errorCaptcha').css({
        'display': 'none'
    });
    getCountryCode();
    GetHeighestQualification();
    getDestinationCode();
    getBranch();
    getCourse();
    GetPreferredCallBackTime();
});
//--------CountryCode---------------//
function getCountryCode() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetCountryCode',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindDropdown(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}

function bindDropdown(data) {
    var dropdown = $('#ddlCountryCodeid');
    dropdown.empty();
    dropdown.append('<option value="Select">Select Country</option>');

    //var dropdown_1 = $('#ddlCountryCodeid_1');
    //dropdown_1.empty();
    //dropdown_1.append('<option value="Select">Select Country</option>');

    $.each(data, function (key, entry) {
        var option = $('<option></option>').attr('value', entry.ID).text(entry.Code);
        if (entry.Code.includes("India")) {
            option.attr('selected', 'selected');
        }
        dropdown.append(option);
      /*  dropdown_1.append(option);*/
    });
}
//end------


//--------------Destination--------------
function getDestinationCode() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetCountry',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindDestinationDropdown(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}
function bindDestinationDropdown(data) {
    var dropdown = $('#ddlDestinationCodeid');
    dropdown.empty();
    dropdown.append('<option value="Select">Select Destination</option>');

    var dropdown_1 = $('#ddlDestinationCodeid_1');
    dropdown_1.empty();
    dropdown_1.append('<option value="Select">Select Destination</option>');
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.COUNTRYID).text(entry.COUNTRYNAME));
        dropdown_1.append($('<option></option>').attr('value', entry.COUNTRYID).text(entry.COUNTRYNAME));
    });
}
//----end---//

// Get Branch
function getBranch() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetBranch',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindBranchDropdown(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}
function bindBranchDropdown(data) {
    var dropdown = $('#ddlBranchCodeId');
    dropdown.empty();
    dropdown.append('<option value="Select">Select Branch</option>');

    var dropdown_1 = $('#ddlBranchCodeId_1');
    dropdown_1.empty();
    dropdown_1.append('<option value="Select">Select Branch</option>');
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.BRANCHID).text(entry.BRANCHNAME));
        dropdown_1.append($('<option></option>').attr('value', entry.BRANCHID).text(entry.BRANCHNAME));
    });
}

//End //

//Get Course--------------
function getCourse() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetLevel',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindCourseDropdown(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}
function bindCourseDropdown(data) {
    var dropdown = $('#ddlCourseCodeId');
    dropdown.empty();
    dropdown.append('<option value="Select">Select Course</option>');

    var dropdown_1 = $('#ddlCourseCodeId_1');
    dropdown_1.empty();
    dropdown_1.append('<option value="Select">Select Course</option>');

    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.QUALLEVELID).text(entry.QUALDESC));
        dropdown_1.append($('<option></option>').attr('value', entry.QUALLEVELID).text(entry.QUALDESC));
    });
}

//Height Qualification

function GetHeighestQualification() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetHighestQualification',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindHeighestQualification(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}
function bindHeighestQualification(data) {
    var dropdown = $('#ddlHighestQualifcation');
    dropdown.empty();
    dropdown.append('<option value="Select"> Highest Qualification </option>');

    var dropdown_1 = $('#ddlHighestQualifcation_1');
    dropdown_1.empty();
    dropdown_1.append('<option value="Select"> Highest Qualification </option>');
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.ID).text(entry.QUALIFICATION));
        dropdown_1.append($('<option></option>').attr('value', entry.ID).text(entry.QUALIFICATION));
    });
}

//Best Time To Call
function GetPreferredCallBackTime() {
    $.ajax({
        url: 'https://crm.indoeuropean.in/WebService/Lead.asmx/GetPreferredCallBackTime',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            bindPreferredCallBackTime(res.data);
        },
        error: function () {
            alert("Data not found");
        }
    });
}
function bindPreferredCallBackTime(data) {
    var dropdown = $('#ddlPreferredCallBackTime');
    dropdown.empty();
    dropdown.append('<option value="Select"> Best Time to Call </option>');

    var dropdown_1 = $('#ddlPreferredCallBackTime_1');
    dropdown_1.empty();
    dropdown_1.append('<option value="Select"> Best Time to Call </option>');
    $.each(data, function (key, entry) {
        dropdown.append($('<option></option>').attr('value', entry.ID).text(entry.CALL_BACK_TIME));
        dropdown_1.append($('<option></option>').attr('value', entry.ID).text(entry.CALL_BACK_TIME));
    });
}
//end


