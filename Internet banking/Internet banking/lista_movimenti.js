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
    

    $("#selIban").on("change", listaTransazioni);

}
function listaTransazioni() {
    sel = $("#selIban").val();
    

    let uriWebService = "api/Transazioni/GetTransazioni/"+sel;
    send_request(uriWebService, "GET", "", tabTransazioni);
}

function tabTransazioni(data) {
    let cl;
    let im;
    let stato;
    $("#tabTransazione").html("");

    $.each(data, function (key, item) {

        if (item.stato == "ES") {
             stato = "<td class='nowrap'>  <span class='status-pill smaller green'></span><span>Completo</span></td>";
            
        }
        else {
            stato = "<td class='nowrap'> <span class='status-pill smaller orange'></span><span>Autorizzato</span></td>";
        }
        if (item.entrata_uscita == "e") {
            im = "<td text-center ><span class='text-success'>+" + item.importo + " €</span></td>";
        }
        else {
            im = "<td text-center><span class='text-danger'>" + item.importo + " €</span></td>";
        }

        cl = $("<tr><td class='text-center'>" + item.data_transazione + "</td> <td class='text-center'>" + item.controparte + "</td>" + stato + "" + im+"</tr>");


        $("#tabTransazione").append(cl);


    });

    let uriWebService = "api/ContiCorrenti/GetSaldo/" + sel;
    send_request(uriWebService, "GET", "", saldo);

    

 


}

function saldo(data) {
    let cl;
    $("#saldo").html("");

    $.each(data, function (key, item) {


        $("#saldo").html("€ "+item.saldo_conto);


    });


   

}