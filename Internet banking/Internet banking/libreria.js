function send_request(url, method, parameters, callback) {
    ////alert(parameters);
	$.ajax({
		url: url, //default: currentPage
		type: method,
		//contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		//dataType: "text",   //usiamo un dato di tipo testo perchè al momento del parsing possiamo debuggarlo visualizzandolo
        //contentType: 'application/x-www-form-urlencoded',
        contentType: 'application/json',//passare paramentri
        dataType: 'json',//ricevere parametri 
		data: parameters,
		timeout : 5000000,
		success: callback,
		error : function(jqXHR, test_status, str_error){
			//console.log("No connection to " + link);
			//console.log("Test_status: " + test_status);
			//alert("Error: " + str_error);
		}
	});
}