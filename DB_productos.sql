	IF DB_ID('DB_productos') IS NULL
	BEGIN
	    CREATE DATABASE DB_productos;
	END
	GO
	
	USE DB_productos;
	GO
	
	CREATE TABLE dbo.Categoria (
	    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	    Nombre NVARCHAR(100) NOT NULL,
	    Descripcion NVARCHAR(500) NOT NULL,
	    Activo BIT NOT NULL DEFAULT 1,
	    FechaCreacion DATETIME2 NOT NULL DEFAULT SYSDATETIME()
	);
	GO;
	
	CREATE TABLE dbo.__EFMigrationsHistory (
	    MigrationId NVARCHAR(150) NOT NULL PRIMARY KEY,
	    ProductVersion NVARCHAR(32) NOT NULL
	);
	GO;
	
	CREATE TABLE dbo.Producto (
	    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	    Nombre NVARCHAR(200) NOT NULL,
	    Descripcion NVARCHAR(500) NOT NULL,
	    Precio DECIMAL(18,2) NOT NULL,
	    Stock INT NOT NULL DEFAULT 0,
	    CategoriaId INT NOT NULL,
	    Imagen NVARCHAR(500) NULL,
	    Activo BIT NOT NULL DEFAULT 1,
	    FechaCreacion DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (CategoriaId)
	        REFERENCES dbo.Categoria(Id)
	        ON DELETE CASCADE
	);
	GO;