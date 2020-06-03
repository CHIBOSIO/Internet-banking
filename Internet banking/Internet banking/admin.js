"use strict";
let user;
let pwd;
let nome;
let idAd;
let cl;

$(document).ready(function () {
    // ////alert("ciao");
    user = sessionStorage.getItem("usernameAd");
    pwd = sessionStorage.getItem("passwordAd");
    nome = sessionStorage.getItem("nomeAd");
    idAd = sessionStorage.getItem("id");
    $("#nome").html(nome);
    
    let uriWebService = "api/Cliente/GetAllClienti";
    send_request(uriWebService, "GET", "", TabClienti);

    $("#btnLogout").on("click", logout);
});
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}

function TabClienti(data) {
    let cl;
    $("#tabClienti").html("");

    $.each(data, function (key, item) {
        if(item.attivo=="no")
             cl = $("<tr><td class='text-center'>"+item.id_cliente+"</td> <td class='text-center'>"+item.nome_cliente+ " "+item.cognome_cliente+" </td><td class='text-center'>"+item.data_nascita+"</td> <td class='text-center'>"+item.codice_fiscale_cliente+"</td> <td class='text-center'><button id='btnAttiva"+item.id_cliente + "' class='btn btn-primary' onclick='attiva(" +item.id_cliente +")'>Attiva</button></td ></tr>");
        else
            cl = $("<tr><td class='text-center'>" + item.id_cliente + "</td> <td class='text-center'>" + item.nome_cliente + " " + item.cognome_cliente + " </td><td class='text-center'>" + item.data_nascita + "</td> <td class='text-center'>" + item.codice_fiscale_cliente + "</td> <td class='text-center'></td ></tr>");


        $("#tabClienti").append(cl);


    });


}
function attiva(idCliente) {
    
    cl = parseInt(idCliente);
    let pwd = generatePassword();
    let today = oggi();
    let par = "{password_cliente:'" + pwd + "',data_attivazione:'" + today + "',primo_accesso:'si', id_cliente:" + cl + ",id_amministratore:1}";
    let uriWebService = "api/Account/insertAccount";
    send_request(uriWebService, "POST", par, inserimento);
    


}

function generatePassword() {
    let length = 8,
        charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
        retVal = "";
    for (let i = 0, n = charset.length; i < length; ++i) {
        retVal += charset.charAt(Math.floor(Math.random() * n));
    }
    return retVal;
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
    let uriWebService = "api/Account/inviaEmail/" + cl;
    send_request(uriWebService, "GET", "", inviata);
    let uriWebService2 = "api/Account/updateAccount/" + cl;
    send_request(uriWebService2, "GET", "", modificato);
}

function modificato(data) {
    //alert(data);
    let uriWebService = "api/Cliente/GetAllClienti";
    send_request(uriWebService, "GET", "", TabClienti);
   
}
function inviata(data) {
    //alert("mail inviata");
  

}




