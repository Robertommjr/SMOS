var url = "http://fcarvalho-001-site4.etempurl.com/api";
var getBalancas = [];

$(document).ready(function () {
    obterTodasAsBalancas();

});

function obterTodasAsBalancas() {
    waitingDialog.show('Obtendo balanças cadastradas no sistema.');
    $.ajax({
        url: url + "/balanca",
        dataType: "json",
        method: "GET",
        success: function (data) {
            getBalancas = data;
            $("#slcEditarBalancas").empty();
            $.each(data, function (index, key) {
                $('#slcEditarBalancas').append($('<option>').text(key.NomeBalanca).attr('value', key.BalancaId));
            });
        },
        error: function (response) {
            waitingDialog.hide();
            alert(response.d);
        },
        complete: function () {
            atualizarFrmEdicao();
            waitingDialog.hide();
        }
    })
};

function atualizarFrmEdicao() {
    var balancaId = $("#slcEditarBalancas option:selected").val();
    $.each(getBalancas, function (index, key) {
        if (key.BalancaId.toString() === balancaId) {
            $("#inputNomeBaia").val(key.NomeBalanca);
            $("#inputDescricaoBaia").val(key.descricaoBalanca);
            $("#inputPesoBaia").val(key.pesoAtual);
        }
    });
};

$("#slcEditarBalancas").on('change', function (e) {
    atualizarFrmEdicao();
});

$("#frmEdicaoBalanca").submit(function (e) {
    var balancaId = $("#slcEditarBalancas option:selected").val();
    waitingDialog.show('Editando dados da balança.');
    var dataStr = JSON.stringify($("#frmEdicaoBalanca").serializeArray());
    var dataObj = JSON.parse(dataStr);
    var balanca = {};
    balanca.BalancaId = dataObj[0].value;
    balanca.NomeBalanca = dataObj[1].value;
    balanca.descricaoBalanca = dataObj[2].value;
    balanca.pesoAtual = dataObj[3];
    console.log(balanca);
});