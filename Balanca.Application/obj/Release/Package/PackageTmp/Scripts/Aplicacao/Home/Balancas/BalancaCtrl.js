
var url = "http://fcarvalho-001-site4.etempurl.com/api";
var arrayBalancas = [], arrayPeso = [];
var totalPoints = 100;
var dataSet = [];

var realtime = "on";
var updateInterval = 5000;

$(document).ready(function () {
    obterTodasAsBalancas();
    $('.slider').slider();

});

function obterTodasAsBalancas() {
    waitingDialog.show('Obtendo balanças cadastradas no sistema.');
    $.ajax({
        url: url + "/balanca",
        dataType: "json",
        method: "GET",
        success: function (response) {
            arrayBalancas = response;
            if (response.length === 3) {
                $("#nmBalancaA").text(response[0].NomeBalanca);
                $("#nmBalancaB").text(response[1].NomeBalanca);
                $("#nmBalancaC").text(response[2].NomeBalanca);
                $("#dsBalancaA").text(response[0].descricaoBalanca);
                $("#dsBalancaB").text(response[1].descricaoBalanca);
                $("#dsBalancaC").text(response[2].descricaoBalanca);
                $("#nmConfigBalancaA").text(response[0].NomeBalanca);
                $("#nmConfigBalancaB").text(response[1].NomeBalanca);
                $("#nmConfigBalancaC").text(response[2].NomeBalanca);
                for (var i = 0; i < response.length; ++i) {
                    dataSet = [
                        {
                            "label": response[i].NomeBalanca,
                            "data": response[i].pesoAtual
                        }
                    ]
                }
            }
        },
        error: function (response) {
            waitingDialog.hide();
            alert(response.d);
        },
        complete: function () {
            obterTodosOsPesos();
            waitingDialog.hide();
        }
    })
};

function obterTodosOsPesos() {
    dataSet = [];
    $.ajax({
        url: url + "/balanca",
        dataType: "json",
        method: "GET",
        async: false,
        success: function (response) {
            arrayBalancas = response;
            if (response.length === 3) {
                for (var i = 0; i < response.length; ++i) {
                    dataSet.push(
                        {
                            "label": response[i].NomeBalanca,
                            "data": response[i].pesoAtual
                        }
                    )
                }
            }
        },
        error: function (response) {
            alert(response);
        },
        complete: function (response)
        {
            checarAlarme();
            setTimeout(obterTodosOsPesos, 5000);
        }
    });
};

var smoothie = new SmoothieChart({ maxValueScale: 1.50, scaleSmoothing: 0.350, responsive: true, maxValue: 10, minValue: 0 });



smoothie.streamTo(document.getElementById("mycanvas"), 1000);


// Data
var line1 = new TimeSeries();
var line2 = new TimeSeries();
var line3 = new TimeSeries();


smoothie.addTimeSeries(line1, { strokeStyle: 'rgb(0, 166, 9)', fillStyle: 'rgba(0, 166, 90, 0.4)', lineWidth: 3 });

smoothie.addTimeSeries(line2, { strokeStyle: 'rgb(243, 156, 18)', fillStyle: 'rgba(243, 156, 18, 0.4)', lineWidth: 3 });

smoothie.addTimeSeries(line3, { strokeStyle: 'rgb(0, 192, 239)', fillStyle: 'rgba(0, 192, 239, 0.3)', lineWidth: 3 });

// Add a random value to each line every second

setInterval(function () {
    line1.append(new Date().getTime(), dataSet[0].data);
    line2.append(new Date().getTime(), dataSet[1].data);
    line3.append(new Date().getTime(), dataSet[2].data);
}, 1000);

// Add to SmoothieChart
smoothie.addTimeSeries(line1);
smoothie.addTimeSeries(line2);
smoothie.addTimeSeries(line3);



function checarAlarme()
{
    var getDataA = $("#pesoBalancaA").val().split(",");
    if (dataSet[0].data < getDataA[0] || dataSet[0].data > parseFloat(getDataA[1])) {
        $("#dispararErro").click();
    };

    var getDataB = $("#pesoBalancaB").val().split(",");
    if (dataSet[1].data < getDataB[0] || dataSet[1].data > parseFloat(getDataB[1])) {
        $("#dispararErro").click();
    }

    var getDataC = $("#pesoBalancaC").val().split(",");
    if (dataSet[2].data < getDataC[0] || dataSet[2].data > parseFloat(getDataC[1])) {
        $("#dispararErro").click();
    }

    //$("#pesoBalancaA").on('change', function () {
       
    //    console.log(getData);
    //});

    //$("#pesoBalancaB").on('change', function () {
       
    //    console.log($("#pesoBalancaB").val());
    //});

    //$("#pesoBalancaC").on('change', function () {
        
    //    console.log($("#pesoBalancaC").val());
    //});
}