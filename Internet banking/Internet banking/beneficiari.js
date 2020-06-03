"use strict";
let user;
let pwd;
let nome;
let idCl;

$(document).ready(function () {
    // ////alert("ciao");
   
    idCl = sessionStorage.getItem("idAcc");
    
    let uriWebService = "api/Benificiari/GetAllBeneficiari/"+idCl;
    send_request(uriWebService, "GET", "", tabBeneficiari);
    $("#btnInserisci").on("click", inserisci);
    $("#btnLogout").on("click", logout);

});
function tabBeneficiari(data) {
    let cl;
    $("#tabBeneficiari").html("");

    $.each(data, function (key, item) {
        cl = $("<tr><td class='text-center'>" + item.nome_cliente + " " + item.cognome_cliente + "</td> <td class='text-center'>" + item.IBAN_benificiario + " </td><td class='text-center'>" + item.indirizzo + "</td> <td class='text-center'>" + item.citta + "</td></tr>");


        $("#tabBeneficiari").append(cl);


    });


}

function inserisci() {

    let nome = $("#txtNomeb").val();
    let cognome = $("#txtCognomeb").val();
    let iban = $("#txtIBAN").val();
    let indirizzo = $("#txtIndirizzo").val();
    let citta = $("#txtCitta").val();

    let par = "{nome_cliente:'" + nome + "',cognome_cliente:'" + cognome + "', IBAN_benificiario:'" + iban + "', indirizzo:'" + indirizzo + "', citta:'" + citta + "', id_cliente:" + idCl + ", id_banca:1}";
    let uriWebService = "api/Benificiari/insertBeneficiario";
    send_request(uriWebService, "POST", par, inserimento);


}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function inserimento(data) {
    //alert(data);
    let uriWebService = "api/Benificiari/GetAllBeneficiari/" + idCl;
    send_request(uriWebService, "GET", "", tabBeneficiari);
    $("#txtNomeb").val("");
    $("#txtCognomeb").val("");
    $("#txtIBAN").val("");
    zo = $("#txtIndirizzo").val("");
    $("#txtCitta").val("");
}