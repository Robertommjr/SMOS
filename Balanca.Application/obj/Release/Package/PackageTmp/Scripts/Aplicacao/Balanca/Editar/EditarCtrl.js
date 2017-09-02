var url = "http://fcarvalho-001-site4.etempurl.com/api";
var getBalancas = [];

$(document).ready(function () {
    obterTodasAsBalancas();

});

function obterTodasAsBalancas() {
    waitingDialog.show('Obtendo balanças cadastradas no sistema.');
    obterBalancas();
    waitingDialog.hide();
};

function obterBalancas() {
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
            alert(response.d);
            waitingDialog.hide();
        },
        complete: function () {
            atualizarFrmEdicao();
        }
    })
}

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

$("#frmEdicaoBalanca").on('submit', function (e) {
    e.preventDefault();  
    var balancaId = $("#slcEditarBalancas option:selected").val();
    waitingDialog.show('Editando dados da balança.');
    var dataStr = JSON.stringify($("#frmEdicaoBalanca").serializeArray());
    var dataObj = JSON.parse(dataStr);
    var balanca = {};
    balanca.BalancaId = balancaId;
    balanca.NomeBalanca = dataObj[0].value;
    balanca.descricaoBalanca = dataObj[1].value;
    balanca.pesoAtual = dataObj[2].value;
    $.ajax({
        url: url + "/balanca/" + balancaId,
        dataType: "json",
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        method: "PUT",
        data: balanca,
        success: function (response) {
            waitingDialog.hide();
            obterBalancas();
            $('#frmEdicaoBalanca').trigger("reset");
        },
        failure: function (response) {
            console.log(response.d);
        }
    });
    
});