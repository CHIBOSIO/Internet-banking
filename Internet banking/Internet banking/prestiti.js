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

    let uriWebService = "api/Prestito/GetPrestiti/" + idCl;
    send_request(uriWebService, "GET", "",tabPrestiti);

    $("#btnLogout").on("click", logout);



});
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function tabPrestiti(data) {
    let cl;
    let stato;
    $("#tabPrestiti").html("");

    $.each(data, function (key, item) {

        if (item.stato == "attivo") {
            stato = "<td class='nowrap'>  <span class='status-pill smaller green'></span><span>ATTIVO</span></td>";

        }
        else {
            stato = "<td class='nowrap'> <span class='status-pill smaller red'></span><span>SOSPESO</span></td>";
        }

        cl = $("<tr onclick='info(" + item.id_prestito + ")'  data-target='#infoPrestiti' data-toggle='modal'><td class='text-center'>" + item.tipo_prestito + "</td> <td class='text-center'>" + item.importo + "€</td> <td class='text-center'>" + item.mensilita + "</td> <td class='text-center'>" + item.rata + "€</td>"+stato+"</tr>");


        $("#tabPrestiti").append(cl);


    });
}
function info(idPrestito) {

    pr = parseInt(idPrestito);
    let uriWebService = "api/Prestito/GetPrestito/" + pr;
    send_request(uriWebService, "GET", "", infoPrestiti);


}

function infoPrestiti(data) {

    $.each(data, function (key, item) {

        $("#txtImporto").val(item.importo);
        $("#txtFinanz").val(item.tipo_prestito);
        $("#txtMen").val(item.mensilita);
        $("#txtImportoMen").val(item.rata);
        $("#txtDataE").val(item.data_emissione);
        $("#txtDataT").val(item.data_termine);
        $("#txtTasso").val(item.tasso+"%");
        $("#txtVersamento").val(item.importo_restituito);
    

    });


}