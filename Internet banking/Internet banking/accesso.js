$(document).ready(function () {
    //  ////alert("ciao");
    $("#btnAccediAcc").on("click", logAccount);
    $("#btnAccediAmm").on("click", logAdmin);

  

});

function logout() {
    sessionStorage.clear();
    window.location = "index.html";
}


function logAccount() {

    let user = parseInt($("#userAcc").val());
    let pwd = $("#pwdAcc").val();
    let par = "{username_cliente:" + user + ",password_cliente:'" + pwd + "'}";
    let uriWebService = "api/Account/accessoAccount";//stringa del webapi
    send_request(uriWebService, "POST", par, loginAc);
}
function logAdmin() {

    let user = $("#userAmm").val();
    let pwd = $("#pwdAmm").val();
    let par = "{username_amministratore:'" + user + "',password_amministratore:'" + pwd + "'}";
    let uriWebService = "api/Admin/accessoAdmin";//stringa del webapi
    send_request(uriWebService, "POST", par, loginAd);
}

function loginAc(data) {

    if (data == "Error: Not Found")
        //alert("credenziali errate");
    else {
        $.each(data, function (key, item) {
            sessionStorage.setItem("usernameAcc", item.username_cliente);
            sessionStorage.setItem("passwordAcc", item.password_cliente);
            sessionStorage.setItem("idAcc", item.id_cliente);
        });
        
           window.location = "apps_bank.html";
    }
}
function loginAd(data) {

    if (data == "Error: Not Found")
        //alert("credenziali errate");
    else {
        $.each(data, function (key, item) {
            sessionStorage.setItem("usernameAd", item.username_amministratore);
            sessionStorage.setItem("passwordAd", item.password_amministratore);
            sessionStorage.setItem("idAd", item.id_amministratore);

        });
        window.location = "admin.html";
    }
}

