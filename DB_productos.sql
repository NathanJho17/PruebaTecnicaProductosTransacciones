-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- DB_productos.dbo.Categoria definition

-- Drop table

-- DROP TABLE DB_productos.dbo.Categoria;

CREATE TABLE DB_productos.dbo.Categoria (
	Id int IDENTITY(1,1) NOT NULL,
	Nombre nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descripcion nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Activo bit NOT NULL,
	FechaCreacion datetime2 NOT NULL,
	CONSTRAINT PK_Categoria PRIMARY KEY (Id)
);


-- DB_productos.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE DB_productos.dbo.[__EFMigrationsHistory];

CREATE TABLE DB_productos.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- DB_productos.dbo.Producto definition

-- Drop table

-- DROP TABLE DB_productos.dbo.Producto;

CREATE TABLE DB_productos.dbo.Producto (
	Id int IDENTITY(1,1) NOT NULL,
	Nombre nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Descripcion nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Precio decimal(18,2) NOT NULL,
	Stock int NOT NULL,
	CategoriaId int NOT NULL,
	Imagen nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Activo bit NOT NULL,
	FechaCreacion datetime2 NOT NULL,
	CONSTRAINT PK_Producto PRIMARY KEY (Id),
	CONSTRAINT FK_Producto_Categoria_CategoriaId FOREIGN KEY (CategoriaId) REFERENCES DB_productos.dbo.Categoria(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_Producto_CategoriaId ON dbo.Producto (  CategoriaId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;