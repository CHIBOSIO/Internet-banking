"use strict";
let user;
let pwd;
let nome;
let idCl;
let sel;
let importoOp;
let selI
let saldoC;

$(document).ready(function () {
    // ////alert("ciao");
    user = sessionStorage.getItem("usernameAcc");
    pwd = sessionStorage.getItem("passwordAcc");
    idCl = sessionStorage.getItem("idAcc");
    let uriWebService = "api/ContiCorrenti/GetIban/" + idCl;
    send_request(uriWebService, "GET", "", comboIban);

    $("#btnConferma").on("click", inserisci);
    $("#btnLogout").on("click", logout);

    $("#succ").hide();
    $("#fail").hide();

});
function comboIban(data) {
    let cl;
    $("#selIban").html("<option>Seleziona Iban</option>");

    $.each(data, function (key, item) {


        cl = $("<option value=" + item.IBAN_conto + ">" + item.IBAN_conto + "</option>");


        $("#selIban").append(cl);


    });

    let uriWebService = "api/Benificiari/GetAllBeneficiari/" + idCl;
    send_request(uriWebService, "GET", "", selBene);


}
function selBene(data) {
    let cl;
    $("#selBen").html("");

    $.each(data, function (key, item) {


        cl = $("<option value=" + item.id_benificiario + ">" + item.nome_cliente + " " + item.cognome_cliente+"</option>");


        $("#selBen").append(cl);


    });

    $("#selBen").on("change", datiBen);

}
function datiBen() {
    let b = parseInt($("#selBen").val());
    let uriWebService = "api/Benificiari/GetBeneficiari/" + b;
    send_request(uriWebService, "GET", "", campiBene);

}
function campiBene(data) {
    let cl;
 

    $.each(data, function (key, item) {


        $("#txtIBAN").val(item.IBAN_benificiario);
        $("#txtCitta").val(item.citta); 7
        nome = item.nome_cliente + " " + item.cognome_cliente;


        


    });


}

function inserisci() {
    let sel = $("#selIban").val();
    let bene = $("#selBen").val();
    let IBAN = $("#txtIBAN").val();
    let causale = $("#txtCausale").val();
    let today = oggi();
    let importo = parseFloat($("#txtImporto").val());
    let par = "{importo:" + importo + ", data_trasferimento:'" + today + "', IBAN_conto:'" + sel + "', causale:'" + causale + "', id_benificiario:" + bene + ", IBAN_destinatario:'" + IBAN + "'}";
    let uriWebService = "api/Trasferimento/insertTrasferimento";
    send_request(uriWebService, "POST", par, inserimento);


}
function oggi() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = dd + '/' + mm + '/' + yyyy;
    let og = today.toString();
    return og;
}

function inserimento(data) {
    //alert(data);

    let IBAN = $("#txtIBAN").val();
    selI = $("#selIban").val();
    let today = oggi();
    importoOp = $("#txtImporto").val();
    importoOp = "-" + importoOp;
    importoOp = parseFloat(importoOp);
 
    let par = "{IBAN_mittente:'" + selI + "', IBAN_creditore:'" + IBAN + "', controparte:'" + nome + "', data_transazione:'" + today + "', entrata_uscita:'u', importo:" + importoOp + ", stato:'sospeso', id_tipo_transazione:2}";
    let uriWebService = "api/Transazioni/insertTransazioni";
    send_request(uriWebService, "POST", par, inserimentoTra);

}
function inserimentoTra(data) {
    //alert("ok");

    let uriWebService = "api/ContiCorrenti/GetSaldo/" + selI;
    send_request(uriWebService, "GET", "", saldo);



}

function saldo(data) {




    $.each(data, function (key, item) {


        saldoC = item.saldo_conto;


    });
    if (saldoC > importoOp) {
        let saldoTra = saldoC + importoOp;
        saldoTra = parseFloat(saldoTra);
        let uriWebService = "api/ContiCorrenti/updateConto/" + saldoTra + "/" + selI;
        send_request(uriWebService, "GET", "", modificato);
    }
    else {
    
        $("#fail").show();
    }





}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}


function modificato(data) {
    //alert("ok");
    $("#succ").show();

     $("#selIban").val("");
 
   $("#txtIBAN").val("");
    $("#txtCausale").val();
   
    $("#txtImporto").val("");

}
