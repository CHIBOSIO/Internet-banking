"use strict";
let user;
let pwd;
let nome;
let idCl;
let sel;

$(document).ready(function () {
    // ////alert("ciao");
   
    idCl = sessionStorage.getItem("idAcc");

    let uriWebService = "api/ContiCorrenti/GetIban/" + idCl;
    send_request(uriWebService, "GET", "", comboIban);
    $("#btnLogout").on("click", logout);





});
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function comboIban(data) {
    let cl;
    $("#selIban").html("<option>Seleziona Iban</option>");

    $.each(data, function (key, item) {


        cl = $("<option value=" + item.IBAN_conto + ">" + item.IBAN_conto + "</option>");


        $("#selIban").append(cl);


    });


    $("#selIban").on("change", listaUte);

}
function listaUte() {
    sel = $("#selIban").val();


    let uriWebService = "api/Utenze/GetUtenze/" + sel;
    send_request(uriWebService, "GET", "", tabUtenze);
}

function tabUtenze(data) {
    let cl;
    let im;
    let stato;
    $("#tabUtenze").html("");

    $.each(data, function (key, item) {

        if (item.stato == "AT") {
            stato = "<td class='nowrap'>  <span class='status-pill smaller green'></span><span>ATTIVO</span></td>";

        }
        else {
            stato = "<td class='nowrap'> <span class='status-pill smaller red'></span><span>SOSPESO</span></td>";
        }

        cl = $("<tr><td class='text-center'>" + item.data_attivazione + "</td> <td class='text-center'>" + item.IBAN_creditore + "</td> <td class='text-center'>" + item.azienda + "</td>" + stato + "</tr>");


        $("#tabUtenze").append(cl);


    });







}