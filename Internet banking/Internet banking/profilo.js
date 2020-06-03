"use strict";
let user;
let pwd;
let nome;
let idCl;

$(document).ready(function () {
    // ////alert("ciao");
   
    idCl = sessionStorage.getItem("idAcc");

    let uriWebService = "api/Cliente/GetCliente/" + idCl;
    send_request(uriWebService, "GET", "", datiAcc);
    $("#btnConferma").on("click", update);
    $("#btnLogout").on("click", logout);
    $("#succ").hide();

});
function datiAcc(data) {
    
    $.each(data, function (key, item) {
    
        $("#txtNome").val(item.nome_cliente);
        $("#txtcognome").val(item.cognome_cliente);
        $("#txtData").val(item.data_nascita);
        $("#txtComuneN").val(item.comune_nascita);
        $("#txtNaz").val(item.nazionalita_cliente);
        $("#txtSesso").val(item.sesso);
        $("#txtCF").val(item.codice_fiscale_cliente);
        $("#txtCI").val(item.carta_identita);
        $("#txtIndirizzo").val(item.indirizzo);
        $("#txtComuneR").val(item.comune_residenza);
        $("#txtEmail").val(item.email);
        $("#txtTel").val(item.num_telefono);
        

    });


}
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function update() {

    // ////alert("pasato 2");  
 
    let Naz=$("#txtNaz").val();
    let Sesso=$("#txtSesso").val();
    let CI=$("#txtCI").val();
    let Indirizzo=$("#txtIndirizzo").val();
    let ComuneR=$("#txtComuneR").val();
    let Email=$("#txtEmail").val();
    let Tel=$("#txtTel").val();
   
    let par = "{id_cliente:" + idCl + ",nazionalita_cliente:'" + Naz + "',sesso:'" + Sesso + "', carta_identita:'" + CI + "', indirizzo:'" + Indirizzo + "', comune_residenza:'" + ComuneR + "', num_telefono:'" + Tel + "', email:'" + Email + "'}";
    let uriWebService = "api/Cliente/updateCliente";
    send_request(uriWebService, "POST", par, modificato);



}

function modificato(data) {
    //alert(data);
    $("#succ").show();


}