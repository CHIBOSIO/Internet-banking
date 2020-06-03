"use strict";
let user;
let pwd;
let nome;
let idCl;
let sel;
let pr;
let selI;
let importoOp;
let idCarta;
let saldoC2;
let saldoC;
$(document).ready(function () {
    // ////alert("ciao");
   
    idCl = sessionStorage.getItem("idAcc");

    let uriWebService = "api/Carte/GetCarte/" + idCl;
    send_request(uriWebService, "GET", "", tabCarte);
    $("#btnConferma").on("click", inserisci);
    $("#btnLogout").on("click", logout);
});

function tabCarte(data) {
    let cl;
    let stato;
    $("#tabCarte").html("");

    $.each(data, function (key, item) {

        cl = $("<div class='column mx - auto'><div id='carta - " + item.id_carta + "' class='card d - inline - block' style='width: 22rem;'></div><img class='card - img - top img - fluid' src='html_admin/dist/img/card" + item.id_carta + "B.png'><h5 class='card - title text - center mt - 2'>" + item.nr_carta + "</h5><h5 class='card - body text - center pt - 2 pb - 2 text-success'>" + item.saldo + "€</h5><button id='btnRicarica" + item.id_carta + "' class='btn btn-primary card - body text - center pt - 2 pb - 2' onclick='getId(" + item.id_carta + ")' data-target='#ricaricaCarta' data-toggle='modal'>Ricarica Carta</button></div>'");

        $("#tabCarte").append(cl);


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


function getId(id) {
    idCarta = id;
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

function inserisci(data) {
    //alert("ok");
    selI = $("#selIban").val();
    let today = oggi();
    importoOp = $("#txtImporto").val();
    importoOp = "-" + importoOp;
    importoOp = parseFloat(importoOp);
    let ope = "ricarica carta";
   
    let par = "{IBAN_mittente:'" + selI + "', IBAN_creditore:'" + selI + "', controparte:'" + ope + "', data_transazione:'" + today + "', entrata_uscita:'u', importo:" + importoOp + ", stato:'sospeso', id_tipo_transazione:4}";
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
    //alert("ok");
    let saldoTra = saldoC + importoOp;
    saldoTra = parseFloat(saldoTra);
    let uriWebService = "api/ContiCorrenti/updateConto/" + saldoTra + "/" + selI;
    send_request(uriWebService, "GET", "", modificatoConto);






}




function modificatoConto(data) {
    //alert("ok");
    let uriWebService = "api/Carte/GetCarta/" + idCarta;
    send_request(uriWebService, "GET", "", modificaSaldoCarta);

}

function modificaSaldoCarta(data) {



    $.each(data, function (key, item) {


        saldoC2 = item.saldo;


    });
    //alert("ok");
    let saldoTra = saldoC2 - importoOp;
    saldoTra = parseFloat(saldoTra);
    let uriWebService = "api/Carte/updateCarta/" + saldoTra + "/" + idCarta;
    send_request(uriWebService, "GET", "", modificato);






}
function modificato(data) {
    //alert("ok");
    let uriWebService = "api/Carte/GetCarte/" + idCl;
    send_request(uriWebService, "GET", "", tabCarte);
    $("#txtImporto").val("");



}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}



