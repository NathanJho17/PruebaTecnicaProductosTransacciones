-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- DB_transaccion.dbo.Transaccion definition

-- Drop table

-- DROP TABLE DB_transaccion.dbo.Transaccion;

CREATE TABLE DB_transaccion.dbo.Transaccion (
	Id uniqueidentifier NOT NULL,
	Tipo nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductoId int NOT NULL,
	Cantidad int NOT NULL,
	PrecioUnitario decimal(18,2) NOT NULL,
	Detalle nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Activo bit NOT NULL,
	FechaCreacion datetime2 NOT NULL,
	NombreProducto nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	StockProducto int DEFAULT 0 NOT NULL,
	CONSTRAINT PK_Transaccion PRIMARY KEY (Id)
);


-- DB_transaccion.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE DB_transaccion.dbo.[__EFMigrationsHistory];

CREATE TABLE DB_transaccion.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);