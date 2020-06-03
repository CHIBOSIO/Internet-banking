CREATE TABLE BANCA 
( 	
	id_banca int not null AUTO_INCREMENT,
	nome_banca varchar(30) not null, 
	nazionalita_banca varchar(30) not null,
	PRIMARY KEY(id_banca)
)
CREATE TABLE SERVIZI 
( 	
	id_servizio int not null AUTO_INCREMENT,
	nome_servizio varchar(40) not null, 
	PRIMARY KEY(id_servizio)
	
)
CREATE TABLE CLIENTE 
( 	
	id_cliente int not null AUTO_INCREMENT,
	nome_cliente varchar(30) not null, 
	cognome_cliente varchar(30) not null,
	data_nascita varchar(10),
	comune_nascita varchar(30) not null,
	nazionalita_cliente varchar(30) not null,
	sesso varchar(1) not null,
	indirizzo varchar(30) not null,
	comune_residenza varchar(30) not null,
	comune_residenza varchar(30) not null,
	codice_fiscale_cliente varchar(16) not null,
	carta_identita varchar(16) not null,
	num_telefono varchar(14) not null,
	email varchar(16) not null,
	PRIMARY KEY(id_cliente)
)
CREATE TABLE ACCOUNT 
( 	
	username_cliente varchar(30) not null,
	password_cliente varchar(30) not null, 
	data_attivazione varchar(10),
	primo_accesso varchar(2) not null,
	id_cliente int not null,
	PRIMARY KEY(username_cliente),
	FOREIGN KEY(id_cliente) REFERENCES CLIENTE(id_cliente),
)
CREATE TABLE AMMINISTRATORE 
( 	
	id_amministratore int not null AUTO_INCREMENT,
	username_amministratore int not null identity(50000,1),
	password_amministratore varchar(30) not null, 
	nome_amministratore varchar(30) not null, 
	cognome_amministratore varchar(30) not null,
	PRIMARY KEY(username_cliente)
)
CREATE TABLE CONTO_CORRENTE  
( 	
	IBAN_conto varchar(30) not null ,
	data_apertura varchar(10),
	saldo_conto float not null,
	PRIMARY KEY(IBAN_conto),
	id_cliente int not null,
	FOREIGN KEY(id_cliente) REFERENCES CLIENTE(id_cliente)
	
	
)
CREATE TABLE TIPO_TRANSAZIONE 
( 	
	id_tipo_transazione int not null AUTO_INCREMENT,
	nome varchar(10),
	PRIMARY KEY(id_tipo_transazione)
	
)
CREATE TABLE TRANSAZIONE 
( 	
	id_transazione int not null AUTO_INCREMENT,
	IBAN_mittente varchar(30) not null,
	IBAN_creditore varchar(30) not null,
	data_transazione varchar(10),
	entrata_uscita varchar(2),
	stato varchar(2),
	importo float not null,
	PRIMARY KEY(id_transazione),
	IBAN_conto varchar(30) not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto),	
	id_tipo_transazione int not null,
	FOREIGN KEY(id_tipo_transazione) REFERENCES TIPO_TRANSAZIONE(id_tipo_transazione)
	
)
CREATE TABLE BENIFICIARI 
( 	
	id_benificiario int not null AUTO_INCREMENT,
	nome_cliente varchar(30) not null, 
	cognome_cliente varchar(30) not null,
	IBAN_benificiario varchar(30) not null,
	PRIMARY KEY(id_benificiario),
	id_cliente int not null,
	FOREIGN KEY(id_cliente) REFERENCES CLIENTE(id_cliente)
	
	
	
)
CREATE TABLE TRASFERIMENTO_DENARO 
( 	
	id_trasferimento int not null AUTO_INCREMENT,
	importo float not null,
	data_trasferimento varchar(10),
	IBAN_mittente varchar(30) not null,
	PRIMARY KEY(id_trasferimento),
	IBAN_conto varchar(30) not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto),	
	id_benificiario int not null,
	FOREIGN KEY(id_benificiario) REFERENCES BENIFICIARI(id_benificiario)
	
)


CREATE TABLE CARTE 
( 	
	id_carta int not null AUTO_INCREMENT,
	cvc int not null,
	nr_carta varchar(30) not null, 
	circuito varchar(10),
	data_apertura varchar(10),
	data_scadenza varchar(10),
	saldo float not null,
	massimale float not null,
	importo float not null,
	PRIMARY KEY(id_carta),
	  IBAN_conto int not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto)		
	
	
)
CREATE TABLE RICARICA_TELEFONICA 
( 	
	id_ricarica int not null AUTO_INCREMENT,
	nr_telefono int not null,
	oeratore varchar(30) not null, 
	data_ricarica varchar(10),
	importo float not null,
	PRIMARY KEY(id_ricarica),
    IBAN_conto int not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto)	
)
CREATE TABLE INVESTIMENTI 
( 	
	id_operazione int not null AUTO_INCREMENT,
	quantità int not null,
	titolo varchar(30) not null, 
	data_investimento varchar(10),
	prezzo float not null,
	IBAN_conto int not null,
	PRIMARY KEY(id_operazione)	
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto)
)
CREATE TABLE UTENZE_DOMICILIATE 
( 	
	id_utenza int not null AUTO_INCREMENT,
	data_attivazione varchar(10),
	azienda varchar(30) not null, 	
	IBAN_creditore varchar(30) not null,
	stato varchar(10),
	PRIMARY KEY(id_utenza)		,
	IBAN_conto int not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto)	
)
CREATE TABLE PRESTITO_MUTUO 
( 	
	id_prestito int not null AUTO_INCREMENT,
	importo int not null,
	data_emissione varchar(10),
	tasso int not null,
	mensilità int not null,
	rata int not null,
	tipo_prestito varchar(30) not null, 	
	stato varchar(10),
	importo_restituito int not null,
	PRIMARY KEY(id_prestito),
	id_cliente int not null,
	FOREIGN KEY(id_cliente) REFERENCES CLIENTE(id_cliente)
)
CREATE TABLE ASSEGNI 
( 	
	id_carnet int not null AUTO_INCREMENT
	PRIMARY KEY(id_prestito),
	IBAN_conto int not null,
	FOREIGN KEY(IBAN_conto) REFERENCES CONTO_CORRENTE(IBAN_conto)		
)