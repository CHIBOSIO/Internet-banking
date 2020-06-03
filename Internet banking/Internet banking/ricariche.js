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
   
    idCl = sessionStorage.getItem("idAcc");

    let uriWebService = "api/Ricariche/GetRicariche/" + idCl;
    send_request(uriWebService, "GET", "", TabRicariche);
    $("#btnConferma").on("click", inserisci);
    $("#btnLogout").on("click", logout);

});





function TabRicariche(data) {
    let cl;
    $("#tabRicariche").html("");

    $.each(data, function (key, item) {
        cl = $("<tr><td class='text-center'>" + item.IBAN_conto + "</td> <td class='text-center'>" + item.data_ricarica + " </td><td class='text-center'>" + item.oeratore + "</td> <td class='text-center'>" + item.nr_telefono + "</td>  <td class='text-center'>" + item.importo + "€</td></tr>");


        $("#tabRicariche").append(cl);

    });
    let uriWebService = "api/ContiCorrenti/GetIban/" + idCl;
    send_request(uriWebService, "GET", "", comboIban);



}

function comboIban(data) {
    let cl;
    $("#selIban").html("<option>Seleziona Iban</option>");

    $.each(data, function (key, item) {


        cl = $("<option value=" + item.IBAN_conto + ">" + item.IBAN_conto + "</option>");


        $("#selIban").append(cl);


    });




}
function inserisci() {
    let sel = $("#selIban").val();
    let num = $("#txtNum").val();
    let today = oggi();
    let importo = parseFloat($("#txtImporto").val());
    let ope = "TIM";
    let ibaO = $("#selOperatore").val();
    let par = "{IBAN_conto:'" + sel + "', data_ricarica:'" + today + "', nr_telefono:'" + num + "', oeratore:'" + ope + "', IBAN_operatore:'" + ibaO + "', importo:" + importo + "}";
    let uriWebService = "api/Ricariche/insertRicarica";
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
    //alert("ok");
     selI = $("#selIban").val();
    let today = oggi();
    importoOp = $("#txtImporto").val();
    importoOp = "-" + importoOp;
    importoOp = parseFloat(importoOp);
    let ope = "TIM";
    let ibaO = $("#selOperatore").val();
    let par = "{IBAN_mittente:'" + selI + "', IBAN_creditore:'" + ibaO + "', controparte:'" + ope + "', data_transazione:'" + today + "', entrata_uscita:'u', importo:" + importoOp + ", stato:'sospeso', id_tipo_transazione:5}";
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


        saldoC=item.saldo_conto;


    });
    //alert("ok");
    let saldoTra = saldoC + importoOp;
    saldoTra = parseFloat(saldoTra);
    let uriWebService = "api/ContiCorrenti/updateConto/" + saldoTra + "/" + selI;
    send_request(uriWebService, "GET", "", modificato);






}

   


function modificato(data) {
    //alert("ok");
    let uriWebService = "api/Ricariche/GetRicariche/" + idCl;
    send_request(uriWebService, "GET", "", TabRicariche);
    $("#txtNum").val("");
    $("#txtImporto").val("");
   
}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}


