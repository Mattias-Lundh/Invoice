// sending and receiving file
$("#invoceUpload").on('submit', function (e) {
    
    e.preventDefault();
    let file = document.querySelector("#file").files;
    if (!file[0] || !IsPdf(file[0].name)) {
        alert("please select a pdf file");
    } else {
        SendFile(file[0]);
    }
    
    })

function IsPdf(fileName)
{
    let ext = fileName.substring(fileName.lastIndexOf('.') + 1);
    if (ext == "pdf") {
        return true;
    }
    return false;
}

function SendFile(file) {
    var fd = new FormData();
    fd.append('file', file);

    $.ajax({
        url: 'https://invoicepresentationapi.azurewebsites.net/api/invoice',
        data: fd,
        processData: false,
        contentType: false,
        type: 'POST',
        success: function (data) {
            LoadPdfData(JSON.parse(data));
        }
    });
}

// Knockout 
function PdfViewModel(data) {
    this.address = ko.observable(data.Address);
    this.avi = ko.observable(data.Avi);
    this.amountDue = ko.observable(data.AmountDue);
}

function LoadPdfData(data) {
    ko.applyBindings(new PdfViewModel(data))
}