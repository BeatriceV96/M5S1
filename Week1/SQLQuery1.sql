CREATE TABLE Clienti (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    TipoCliente NVARCHAR(50),
    CodiceFiscale NVARCHAR(16),
    PartitaIVA NVARCHAR(11)
);

CREATE TABLE Spedizioni (
    Id INT PRIMARY KEY IDENTITY,
    ClienteId INT,
    NumeroIdentificativo NVARCHAR(50),
    DataSpedizione DATETIME,
    Peso DECIMAL(10, 2),
    CittaDestinataria NVARCHAR(100),
    IndirizzoDestinatario NVARCHAR(200),
    NominativoDestinatario NVARCHAR(100),
    Costo DECIMAL(10, 2),
    DataConsegnaPrevista DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Clienti(Id)
);

CREATE TABLE AggiornamentiSpedizioni (
    Id INT PRIMARY KEY IDENTITY,
    SpedizioneId INT,
    Stato NVARCHAR(50),
    Luogo NVARCHAR(100),
    Descrizione NVARCHAR(500),
    DataOraAggiornamento DATETIME,
    FOREIGN KEY (SpedizioneId) REFERENCES Spedizioni(Id)
);