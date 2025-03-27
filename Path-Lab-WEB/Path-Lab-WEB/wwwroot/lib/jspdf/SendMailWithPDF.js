window.jsPDF = window.jspdf.jsPDF;
debugger
var Email = $('#PrimaryEmail').val();
function Send_Email_PDF() {
    var doc = new jsPDF();
    //  var pdfContent;        
    var elementHTML = document.querySelector("#contentToPrint");
    doc.html(elementHTML, {
        callback: function (doc) {
            debugger
            var pdf = doc.output('blob');
            var mail = Email;
            var data = new FormData();
            var data1 = new FormData();
            data.append("data", pdf, "PaySlip.pdf",);
            data1.append("pEmailSendTo", Email);
            var xhr = new XMLHttpRequest();
            xhr.open('post', '/SentPaySlip/SendEmailWithAttachments', true); //Post to api url to save to server
            xhr.send(data, data1);
            //console.log(pdf);
        },
        margin: [2, 2, 2, 2],
        autoPaging: 'text',
        x: 0,
        y: 0,
        width: 206,
        windowWidth: 1000
    });
    //swal("PDF saved!", "This PDF saved successfully", "success");
}

window.onload = function () {
    var chartPromises = chartData.map(function (data) {
        return createChart(data.chartId, data.xValues, data.yValues, data.barColors, data.titleText)
            .then(function (chart) {
                var chartCanvas = chart.canvas;
                var chartImage = chartCanvas.toDataURL('image/png');
                chartCanvas.parentNode.removeChild(chartCanvas);
                var imgElement = document.createElement('img');
                imgElement.src = chartImage;
                imgElement.alt = 'Chart Image';
                imgElement.style.width = '100%';
                imgElement.style.height = '287px';
                imgElement.style.maxWidth = '400px';
                imgElement.style.marginTop = '-55px';
                imgElement.style.display = 'block';
                imgElement.style.boxSizing = 'border-box';
                var chartElement = document.getElementById(data.parenDivId);
                chartElement.appendChild(imgElement);
            });
    });

    Promise.all(chartPromises)
        .then(function () {
            console.log("All charts are rendered.");
        })
        .catch(function (error) {
            console.error("An error occurred:", error);
        });
};

var chartData = [
    {
        chartId: "myChart1",
        parenDivId: "chartElement1",
        xValues: ["Oct", "Dec", "Feb", "Apr", "Jun", "Aug", "Oct"],
        yValues: [11, 9, 10, 12, 10, 14, 11],
        barColors: ["blue", "red", "yellow", "green", "blue", "purple", "brown"],
        titleText: "Usage 1"
    },
    {
        chartId: "myChart2",
        parenDivId: "chartElement2",
        xValues: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul"],
        yValues: [5, 8, 3, 12, 7, 9, 6],
        barColors: ["orange", "green", "red", "blue", "yellow", "purple", "pink"],
        titleText: "Usage 2"
    },
    {
        chartId: "myChart3",
        parenDivId: "chartElement3",
        xValues: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
        yValues: [9, 5, 7, 10, 8, 6, 4],
        barColors: ["red", "green", "blue", "orange", "yellow", "purple", "pink"],
        titleText: "Usage 3"
    }
];
