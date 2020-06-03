"use strict";
let user;
let pwd;
let nome;
let idCl;

$(document).ready(function () {
    // ////alert("ciao");
   
    idCl = sessionStorage.getItem("idAcc");

    let uriWebService = "api/Assegni/GetAssegni/" + idCl;
    send_request(uriWebService, "GET", "", tabAssegni);
    $("#btnLogout").on("click", logout);
    
    $("#btnConferma").on("click", inserisci);

});
function tabAssegni(data) {
    let cl;
    $("#tabAssegni").html("");

    $.each(data, function (key, item) {
       
        
        cl = $("<tr><td class='text-center'>" + item.id_carnet + "</td> <td class='text-center'>" + item.IBAN_conto + " </td><td class='text-center'>" + item.data_emissione + "</td></tr>");


        $("#tabAssegni").append(cl);


    });

    let uriWebService = "api/ContiCorrenti/GetIban/" + idCl;
    send_request(uriWebService, "GET", "", comboIban);


}
function comboIban(data) {
    let cl;
    $("#selIban").html("<option>Seleziona Iban</option>");
    $.each(data, function (key, item) {
       
        
        cl = $("<option value=" + item.IBAN_conto + ">" + item.IBAN_conto +"</option>");


        $("#selIban").append(cl);


    });




}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function inserisci() {
    let sel = $("#selIban").val();
    let sel2 = parseInt($("#numero").val());
    let today = oggi();

    let par = "{IBAN_conto:'" + sel + "', data_emissione:'" + today + "'}";
    let uriWebService = "api/Assegni/insertAssegno";
    send_request(uriWebService, "POST", par, inserimento);

    if (sel2 == 2) {
        let par2 = "{IBAN_conto:'" + sel + "', data_emissione:'" + today + "'}";
        let uriWebService2 = "api/Assegni/insertAssegno";
        send_request(uriWebService2, "POST", par2, inserimento);
    }

    

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
    let uriWebService = "api/Assegni/GetAssegni/" + idCl;
    send_request(uriWebService, "GET", "", tabAssegni);
}
