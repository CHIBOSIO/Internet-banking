"use strict";
let user;
let pwd;
let nome;
let idCl;

$(document).ready(function () {
    // ////alert("ciao");
    user = sessionStorage.getItem("usernameAcc");
    idCl = sessionStorage.getItem("idAcc");

  
    $("#btnConferma").on("click", update);
    $("#btnLogout").on("click", logout);
    $("#succ").hide();
    $("#fail").hide();

});
function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}
function update(data) {

    let pwd = $("#vecchia").val();
    let par = "{username_cliente:" + user + ",password_cliente:'" + pwd + "'}";
    let uriWebService = "api/Account/accessoAccount";//stringa del webapi
    send_request(uriWebService, "POST", par, loginAc);
}
function loginAc(data) {

    if (data == "")
        $("#fail").show();
    else {
        let nuova = $("#nuova").val();

        let par = "{id_cliente:" + idCl + ",password_cliente:'" + nuova + "'}";
        let uriWebService = "api/Account/updatePassword";
        send_request(uriWebService, "POST", par, modificato);

      
    }
}
function modificato(data) {
    //alert(data);
    $("#succ").show();
}