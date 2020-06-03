"use strict";
let user;
let pwd;
let nome;
let idCl;
let sel;
let pr;

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


    $("#selIban").on("change", listaInve);

}
function listaInve() {
    sel = $("#selIban").val();
    let uriWebService = "api/Investimenti/GetInvestimento/" + sel;
    send_request(uriWebService, "GET", "", tabInve);
}

function tabInve(data) {
    let cl;
    let im;
    let stato;
    $("#tabInvestimenti").html("");

    $.each(data, function (key, item) {

       

        cl = $("<tr><td class='text-center'>" + item.titolo + "</td> <td class='text-center'>" + item.quantita + "</td> <td class='text-center'>" + item.data_investimento + "</td><td class='text-center'>" + item.prezzo + "€</td></tr>");


        $("#tabInvestimenti").append(cl);


    });







}
