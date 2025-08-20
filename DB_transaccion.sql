IF DB_ID('DB_transaccion') IS NULL
BEGIN
    CREATE DATABASE DB_transaccion;
END
GO

USE DB_transaccion;
GO

IF OBJECT_ID('dbo.Transaccion', 'U') IS NOT NULL
    DROP TABLE dbo.Transaccion;

IF OBJECT_ID('dbo.__EFMigrationsHistory', 'U') IS NOT NULL
    DROP TABLE dbo.__EFMigrationsHistory;
GO

CREATE TABLE dbo.Transaccion (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Tipo NVARCHAR(100) NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Detalle NVARCHAR(500) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    NombreProducto NVARCHAR(200) NULL,
    StockProducto INT NOT NULL DEFAULT 0
);
GO

CREATE TABLE dbo.__EFMigrationsHistory (
    MigrationId NVARCHAR(150) NOT NULL PRIMARY KEY,
    ProductVersion NVARCHAR(32) NOT NULL
);
GO
