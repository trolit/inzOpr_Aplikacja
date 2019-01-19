CREATE TABLE [dbo].[Zgloszenia] (
    [idOferty]               INT          IDENTITY (1, 1) NOT NULL,
    [imie_nazwisko]          VARCHAR (80) NOT NULL,
    [firma]                  VARCHAR (80) DEFAULT ('nie podano') NULL,
    [nr_telefonu]            VARCHAR (30) NOT NULL,
    [mail]                   VARCHAR (50) NOT NULL,
    [m_zamieszkania]         VARCHAR (50) NOT NULL,
    [nazwa_imprezy]          VARCHAR (50) NOT NULL,
    [rodzaj_tresc]           VARCHAR (50) NOT NULL,
    [miejsce_realizacji]     VARCHAR (50) DEFAULT ('nie podano') NULL,
    [czas_trwania]           VARCHAR (50) NOT NULL,
    [cyklicznosc]            VARCHAR (50) NOT NULL,
    [charakter_uczestnictwa] VARCHAR (50) NOT NULL,
    [forma_organizacyjna]    VARCHAR (50) NOT NULL,
    [cele]                   VARCHAR (50) NOT NULL,
	[termin_odbycia]		 VARCHAR (50) DEFAULT ('nie podano') NULL,
    [ceny_bilet]             VARCHAR (50) DEFAULT ('nie podano') NULL,
    [dod_uslugi]             VARCHAR (50) DEFAULT ('nie podano') NULL,
    [stanZgloszenia]         VARCHAR (50) DEFAULT ('rozpatrywany') NULL,
    PRIMARY KEY CLUSTERED ([idOferty] ASC)
);



