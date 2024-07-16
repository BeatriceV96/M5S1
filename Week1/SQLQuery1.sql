CREATE TABLE Clienti (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    TipoCliente BIT, -- 0 per privato, 1 per azienda
    CodiceFiscale NVARCHAR(16) NULL,
    PartitaIVA NVARCHAR(11) NULL,
    CONSTRAINT CHK_Clienti_CodiceFiscale_PartitaIVA CHECK (
        (TipoCliente = 0 AND CodiceFiscale IS NOT NULL AND PartitaIVA IS NULL) OR
        (TipoCliente = 1 AND PartitaIVA IS NOT NULL AND CodiceFiscale IS NULL)
    )
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
    CONSTRAINT FK_Spedizioni_Clienti FOREIGN KEY (ClienteId) REFERENCES Clienti(Id)
);

CREATE TABLE Stati (
    Id INT PRIMARY KEY IDENTITY,
    Descrizione NVARCHAR(50)
);

CREATE TABLE AggiornamentiSpedizioni (
    Id INT PRIMARY KEY IDENTITY,
    SpedizioneId INT,
    StatoId INT,
    Luogo NVARCHAR(100),
    Descrizione NVARCHAR(500),
    DataOraAggiornamento DATETIME,
    CONSTRAINT FK_AggiornamentiSpedizioni_Spedizioni FOREIGN KEY (SpedizioneId) REFERENCES Spedizioni(Id),
    CONSTRAINT FK_AggiornamentiSpedizioni_Stati FOREIGN KEY (StatoId) REFERENCES Stati(Id)
);
