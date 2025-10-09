var EnquirySourceCategoryID = 2, EnquirySourceID = 4, EnqStageid = 1, branchid = 21, divFname = !0, divLname = !0, divEmail = !0, divCountryCodeId = !0, divCity = !0, divDestinationCodeid = !0, divBranchCodeId = !0, divCourseCodeId = !0, divterms_accept = !0, divCaptcha = !0;

$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget);
    var recipient = button.data('whatever');
    var modal = $(this);
    modal.find('.modal-title').text('New message to ' + recipient);
    modal.find('.modal-body input').val(recipient);
});

function myFunction() {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
}

window.dataLayer = window.dataLayer || []; 0
function gtag() { dataLayer.push(arguments); }
gtag('js', new Date());
gtag('config', 'G-V436130YDY');