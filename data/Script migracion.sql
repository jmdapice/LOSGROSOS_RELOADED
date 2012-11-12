USE [GD2C2012]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'LOSGROSOS_RELOADED')	
EXEC sys.sp_executesql N'CREATE SCHEMA [LOSGROSOS_RELOADED] AUTHORIZATION [gd]'

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Carga') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Carga;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.GiftCard') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.GiftCard;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.CiudadesPreferidas') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.CiudadesPreferidas;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.CuponComprado') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.CuponComprado;

iF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Clientes') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Clientes;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.CuponCiudad') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.CuponCiudad;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Cupon') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Cupon;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Factura') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Factura;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Proveedor') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Proveedor;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Usuario') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Usuario;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.PermisoPorRol') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.PermisoPorRol;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Rol') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Rol;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Permiso') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Permiso;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.TipoPago') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.TipoPago;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Rubro') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Rubro;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Ciudad') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Ciudad;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.Parametrizacion') 
				AND type in (N'U')) 
DROP TABLE LOSGROSOS_RELOADED.Parametrizacion;

 /************************************************************************************/
 /*                             CREACION TABLA CIUDAD                                */
 /************************************************************************************/
 
 /*Crear tabla ciudad*/
 CREATE TABLE [LOSGROSOS_RELOADED].[Ciudad](
	idCiudad numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	nombre nvarchar(255) NOT NULL UNIQUE,
	) 

 
 /************************************************************************************/
 /*                             CREACION TABLA TIPOPAGO                              */
 /************************************************************************************/
 
 CREATE TABLE [LOSGROSOS_RELOADED].[TipoPago](
	idTipoPago numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	nombre nvarchar(255) NOT NULL UNIQUE,
	) 
 
 

 /************************************************************************************/
 /*                             CREACION TABLA RUBRO                                 */
 /************************************************************************************/
 
 CREATE TABLE [LOSGROSOS_RELOADED].[Rubro](
	idRubro numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(100) NOT NULL UNIQUE,
	)
	
 

 /************************************************************************************/
 /*                             CREACION TABLA ROL                                   */
 /************************************************************************************/

 CREATE TABLE [LOSGROSOS_RELOADED].[Rol](
	idRol        numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	descripcion  nvarchar(100) NOT NULL,
	inhabilitado char default '0' check (inhabilitado = '0' OR inhabilitado = '1'),
	)

 /************************************************************************************/
 /*                             CREACION TABLA USUARIO                               */
 /************************************************************************************/

 CREATE TABLE [LOSGROSOS_RELOADED].[Usuario](
	idUsuario        numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	nombreUsuario    nvarchar(100) NOT NULL,
	contrasena       char(64) NOT NULL,
	intentosFallidos numeric(1,0) default 0 NOT NULL,
	inhabilitado     char default '0' check (inhabilitado = '0' OR inhabilitado = '1'),
	idRol            numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Rol(idRol),
	)

 /************************************************************************************/
 /*                             CREACION TABLA CLIENTE                               */
 /************************************************************************************/
 
 CREATE TABLE [LOSGROSOS_RELOADED].[Clientes](
	idCli numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	nombre nvarchar(255) NOT NULL,
	apellido nvarchar(255) NOT NULL,
	dni numeric(18,0) NOT NULL UNIQUE,
	direccion nvarchar(255),
	tel numeric(18,0) NOT NULL UNIQUE,
	mail nvarchar(255) NOT NULL,
	fechaNac datetime,
	idCiudad numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Ciudad(idCiudad),
	codPostal numeric(10,0),
	saldo numeric(18,2) default 0,
	idUsuario numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Usuario(idUsuario),
	inhabilitado char default '0' check (inhabilitado = '0' OR inhabilitado = '1')	
	)
	

 /************************************************************************************/
 /*                             CREACION TABLA PERMISO                               */
 /************************************************************************************/
 CREATE TABLE [LOSGROSOS_RELOADED].[Permiso](
	idPermiso numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(100) NOT NULL,	
	)

 /************************************************************************************/
 /*                             CREACION TABLA PERMISOPORROL                         */
 /************************************************************************************/
 
  CREATE TABLE [LOSGROSOS_RELOADED].[PermisoPorRol](
    idRol numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Rol(idRol) NOT NULL,
	idPermiso numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Permiso(idPermiso) NOT NULL,
	)

	ALTER TABLE [LOSGROSOS_RELOADED].[PermisoPorRol] 
	ADD CONSTRAINT pk_permisoPorRol PRIMARY KEY
	( idPermiso, idRol )
	GO

 /************************************************************************************/
 /*                             CREACION TABLA PROVEEDOR                             */
 /************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[Proveedor](
	idProveedor		numeric(18,0) IDENTITY(1,1) PRIMARY KEY ,
	razonSocial		nvarchar(100) UNIQUE,
	domicilio		nvarchar(100),	
	idCiudad		numeric(18,0)   FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Ciudad(idCiudad), 
	tel				numeric(18,0),	
	cuit			nvarchar(20)	UNIQUE,
	idRubro			numeric(18,0)	FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Rubro(idRubro),
	mail			nvarchar(255),
	codPostal		numeric(10,0),
	nombContacto	nvarchar(255),
	idUsuario		numeric(18,0)   FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Usuario(idUsuario),
	inhabilitado	char check (inhabilitado = '0' OR inhabilitado = '1') default '0',
	)

 /************************************************************************************/
 /*                             CREACION TABLA CARGA		                         */
 /************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[Carga](	
	idCarga	numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	idCli	numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Clientes(idCli),
	monto	numeric(18,2)	,
	fecha	datetime	,
	idTipoPago	numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.TipoPago(idTipoPago),
	numeroTarj	numeric(18,0) , 
	fechaVencTarj	datetime,
	nombreTitularTarj	nvarchar(255),
	)



 /************************************************************************************/
 /*                             CREACION TABLA GIFTCARD		                         */
 /************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[GiftCard](	
	idGiftCard	numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	idCliOrigen	numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Clientes(idCli),
	idCliDestino numeric(18,0) FOREIGN KEY REFERENCES LOSGROSOS_RELOADED.Clientes(idCli),
	fecha	datetime,
	monto	numeric(18,2) default 0,
	)
	
 /************************************************************************************/
 /*                             CREACION TABLA CIUDADESPREFERIDAS                    */
 /************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[CiudadesPreferidas](	
	idCiudad numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Ciudad](idCiudad) NOT NULL,
	idCli numeric(18,0)	FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Clientes](idCli) NOT NULL,
	)
	
	ALTER TABLE [LOSGROSOS_RELOADED].[CiudadesPreferidas] 
		ADD CONSTRAINT pk_ciudadesPreferidas PRIMARY KEY
		( idCiudad, idCli )
	GO

	
 /************************************************************************************/
 /*                             CREACION TABLA CUPON                                 */
 /************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[Cupon](	
	codigoCupon	nvarchar(50) PRIMARY KEY,
	precio numeric(18,2),	
	precioFicticio numeric(18,2),	
	descripcion	nvarchar(255),	
	idProveedor	numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Proveedor](idProveedor),
	cantMaxima numeric(18,0) default 1,
	fechaPubli datetime,	
	fechaVencOferta	datetime,	
	stock numeric(18,0) default 0,
	fechaVencCanje datetime,
	publicado char check (publicado = '0' OR publicado = '1') default '0',
	)
	
/************************************************************************************/
/*                             CREACION TABLA CUPONCIUDAD                           */
/************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[CuponCiudad](	
	idCiudad	numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Ciudad](idCiudad) NOT NULL,
	codigoCupon	nvarchar(50) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Cupon](codigoCupon) NOT NULL,
	)
	
	ALTER TABLE [LOSGROSOS_RELOADED].[CuponCiudad] 
		ADD CONSTRAINT pk_cuponCiudad PRIMARY KEY
		( idCiudad, codigoCupon )
	GO
	
/************************************************************************************/
/*                             CREACION TABLA FACTURA                               */
/************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[Factura](	
	idFactura	numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	facturaNro	numeric(18,0),	
	fechaFact	datetime,	
	idProveedor	numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Proveedor](idProveedor) NOT NULL,
	importe     numeric(18,2) DEFAULT 0,	
	)
/************************************************************************************/
/*                             CREACION TABLA CUPONCOMPRADO                         */
/************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[CuponComprado](	
	idCompra numeric(18,0) IDENTITY(1,1) PRIMARY KEY,
	codigoCupon	nvarchar(50) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Cupon](codigoCupon) NOT NULL,
	idCli	numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Clientes](idCli),
	fechaCompra	datetime,	
	fechaCanje	datetime,	
	fechaDevolucion	datetime,	
	idFactura	numeric(18,0) FOREIGN KEY REFERENCES [LOSGROSOS_RELOADED].[Factura](idFactura),
	motivoDevol	nvarchar(255),
	)	

/************************************************************************************/
/*                             CREACION TABLA PARAMETRIZACION                       */
/************************************************************************************/

  CREATE TABLE [LOSGROSOS_RELOADED].[Parametrizacion] (
	codigo nvarchar(20) PRIMARY KEY,
	valor nvarchar(100) NOT NULL,
  )	  

----------------------FIN CREACION DE TABLAS----------------------------------
GO
----------------------COMIENZA CREACIÓN TRIGGERS --------------------------------
/************************************************************************************/
/*       TRIGGER QUE ACTUALIZA EL SALDO DEL CLIENTE POR CADA CARGA RECIBIDA         */
/************************************************************************************/
CREATE TRIGGER LOSGROSOS_RELOADED.tr_Carga_ActualizarSaldo ON LOSGROSOS_RELOADED.Carga
	
	AFTER INSERT
		
	AS
			
	BEGIN
		
	UPDATE LOSGROSOS_RELOADED.Clientes
		SET saldo = saldo + b.montoTotal
		FROM  (select idCli,SUM(monto) as montoTotal from inserted 
		 group by idCli) b
		WHERE LOSGROSOS_RELOADED.Clientes.idCli = b.idCli
	
	END
GO

/************************************************************************************/
/*       TRIGGER QUE ACTUALIZA EL SALDO DEL CLIENTE POR CADA GIFTCARD               */
/************************************************************************************/

CREATE TRIGGER LOSGROSOS_RELOADED.tr_GiftCard_ActualizarSaldo ON LOSGROSOS_RELOADED.GiftCard
	
	AFTER INSERT
		
	AS
			
	BEGIN
	
	UPDATE LOSGROSOS_RELOADED.Clientes
		SET saldo = saldo - b.montoTotal
		FROM  (select idCliOrigen,SUM(monto) as montoTotal from inserted 
		 group by idCliOrigen) b
		WHERE LOSGROSOS_RELOADED.Clientes.idCli = b.idCliOrigen
		
	UPDATE LOSGROSOS_RELOADED.Clientes
		SET saldo = saldo + b.montoTotal
		FROM  (select idCliDestino,SUM(monto) as montoTotal from inserted 
		 group by idCliDestino) b
		WHERE LOSGROSOS_RELOADED.Clientes.idCli = b.idCliDestino
	
	END
GO

/************************************************************************************/
/*       TRIGGER QUE INHABILITA AL USUARIO EN CASO DE 3 O MAS INTENTOS FALLIDOS     */
/************************************************************************************/
CREATE TRIGGER LOSGROSOS_RELOADED.tr_inhabilitarUsuario ON LOSGROSOS_RELOADED.Usuario
	
	AFTER UPDATE
		
	AS
			
	BEGIN	
	
	UPDATE LOSGROSOS_RELOADED.Usuario
		SET inhabilitado = '1', intentosFallidos = 3
		WHERE intentosFallidos > 2 
		  AND idUsuario IN (select idUsuario from inserted )
	END
GO


/************************************************************************************/
/*       TRIGGER QUE QUITA UN ROL CUANDO SE DA DE BAJA                              */
/************************************************************************************/

CREATE TRIGGER LOSGROSOS_RELOADED.tr_sacarRol ON LOSGROSOS_RELOADED.Rol
	
	AFTER UPDATE
		
	AS
			
	BEGIN	
	
	UPDATE LOSGROSOS_RELOADED.Usuario
		SET idRol = NULL
		WHERE idRol IN (select idRol from inserted where inhabilitado = '1' ) 
	END
GO

/************************************************************************************/
/*       TRIGGER PARA CUPONES                                                       */
/************************************************************************************/

CREATE TRIGGER LOSGROSOS_RELOADED.tr_Cupon_actualizarSaldo ON LOSGROSOS_RELOADED.CuponComprado

	AFTER INSERT
	
	AS
	
	BEGIN
	
	UPDATE LOSGROSOS_RELOADED.Clientes
		SET saldo = saldo - b.montoTotal
		FROM  (select a.idCli ,SUM(cupon.precio) as montoTotal 
		       from inserted a, LOSGROSOS_RELOADED.Cupon cupon
		       where cupon.codigoCupon = a.codigoCupon 
		       group by a.idCli) b
		WHERE LOSGROSOS_RELOADED.Clientes.idCli = b.idCli
		
	END

GO

CREATE TRIGGER LOSGROSOS_RELOADED.tr_Cupon_devolverSaldo ON LOSGROSOS_RELOADED.CuponComprado

	AFTER UPDATE
	
	AS
	
	BEGIN
	
	IF (UPDATE(fechaDevolucion))
	UPDATE LOSGROSOS_RELOADED.Clientes
		SET saldo = saldo + b.montoTotal
		FROM  (select a.idCli ,SUM(cupon.precio) as montoTotal 
		       from inserted a, LOSGROSOS_RELOADED.Cupon cupon
		       where cupon.codigoCupon = a.codigoCupon 
		       group by a.idCli) b
		WHERE LOSGROSOS_RELOADED.Clientes.idCli = b.idCli
		
	END

GO

----------------------FIN CREACIÓN TRAIGGERS --------------------------------

----------------------COMIENZA MIGRADO DE DATOS--------------------------------
/************************************************************************************/
/*                             CARGA TABLA CIUDAD                                   */
/************************************************************************************/

/*Cargo las ciudades de los clientes*/
INSERT INTO LOSGROSOS_RELOADED.Ciudad (nombre) Select distinct Cli_Ciudad
                                              from gd_esquema.Maestra
                                              order by Cli_Ciudad

/*Cargo las ciudades de los proveedores que no estan ya cargadas*/
INSERT INTO LOSGROSOS_RELOADED.Ciudad (nombre) select distinct a.Provee_Ciudad
												from gd_esquema.Maestra a
												where not exists (select 1 from gd_esquema.Maestra b 
																   where b.Cli_Ciudad = a.Provee_Ciudad)
												 and a.Provee_Ciudad is not null
												 	 
/************************************************************************************/
/*                             CARGA TABLA TIPOPAGO                                 */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.TipoPago (nombre) select distinct Tipo_Pago_Desc
												 from gd_esquema.Maestra
												 where Tipo_Pago_Desc is not null
												 order by Tipo_Pago_Desc
											 
/************************************************************************************/
/*                             CARGA TABLA RUBRO                                    */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.Rubro (descripcion) 	select distinct Provee_Rubro
													from gd_esquema.Maestra
													where Provee_Rubro is not null
													order by Provee_Rubro

/************************************************************************************/
/*                             CARGA TABLA ROL                                      */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.Rol (descripcion) values ('Cliente')
INSERT INTO LOSGROSOS_RELOADED.Rol (descripcion) values ('Proveedor')
INSERT INTO LOSGROSOS_RELOADED.Rol (descripcion) values ('Administrador General')
INSERT INTO LOSGROSOS_RELOADED.Rol (descripcion) values ('Administrativo')

/************************************************************************************/
/*                             CARGA TABLA PERMISO                                  */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.Permiso(descripcion)
values ('Abm Rol'), ('Abm Cliente'),
('Abm Proveedor'), ('Carga'), ('Giftcard'),
('Comprar cupon'), ('Devolucion cupon'), ('Historial de compra de cupones'),
('Crear cupon'), ('Registro Consumo de cupon'), ('Publicar cupon'),
('Facturacion'), ('Listado Estadistico'),('Gestionar usuarios');

/************************************************************************************/
/*                             CARGA TABLA PERMISOPORROL                            */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.PermisoPorRol(idRol, idPermiso)
VALUES (1, 6),(1, 7),(1, 8),(1, 5), 
(2, 9), (2, 10), 
(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),(3,9),(3,10),(3,11),(3,12),(3,13),(3,14),
(4, 2),(4, 3),(1, 4),(4,11),(4, 12),(4,14);

/************************************************************************************/
/*                             CARGA TABLA USUARIO                                  */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.Usuario (nombreUsuario,contrasena,idRol)
	SELECT DISTINCT a.Cli_Dni, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',
					b.idRol
	FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Rol b
	WHERE b.descripcion = 'Cliente'

INSERT INTO LOSGROSOS_RELOADED.Usuario (nombreUsuario,contrasena,idRol)
	SELECT DISTINCT a.Provee_CUIT, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',
					b.idRol
	FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Rol b
	WHERE b.descripcion = 'Proveedor'
	  AND a.Provee_CUIT is not null

INSERT INTO LOSGROSOS_RELOADED.Usuario (nombreUsuario,contrasena,idRol)
       values ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 3)
       
/************************************************************************************/
/*                             CARGA TABLA CLIENTES                                 */
/************************************************************************************/  

INSERT INTO LOSGROSOS_RELOADED.Clientes (nombre,apellido,dni,direccion,tel,mail,fechaNac,idCiudad,idUsuario)
	SELECT DISTINCT a.Cli_Nombre,a.Cli_Apellido,a.Cli_Dni,a.Cli_Direccion,a.Cli_Telefono,a.Cli_Mail,
					a.Cli_Fecha_Nac,b.idCiudad,c.idUsuario
	FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Ciudad b,LOSGROSOS_RELOADED.Usuario c
	WHERE a.Cli_Ciudad = b.nombre
	  AND CAST(a.Cli_Dni AS VARCHAR) = c.nombreUsuario     

/************************************************************************************/
/*                             CARGA TABLA CARGA                                    */
/************************************************************************************/  
	  
INSERT INTO LOSGROSOS_RELOADED.Carga (idCli,monto,fecha,idTipoPago)
	SELECT b.idCli, a.Carga_Credito, a.Carga_Fecha, c.idTipoPago
	FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Clientes b, LOSGROSOS_RELOADED.TipoPago c
	WHERE a.Carga_Credito is not null
	  and b.dni = a.Cli_Dni
	  and c.nombre = a.Tipo_Pago_Desc
	  
/************************************************************************************/
/*                             CARGA TABLA GIFTCARD                                 */
/************************************************************************************/  
	  
INSERT INTO LOSGROSOS_RELOADED.GiftCard (idCliOrigen,idCliDestino,fecha,monto)
	SELECT b.idCli, c.idCli, a.GiftCard_Fecha,a.GiftCard_Monto
	FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Clientes b, LOSGROSOS_RELOADED.Clientes c
	WHERE a.Cli_Dni = b.dni
	  and a.Cli_Dest_Dni = c.dni	
	    	  
/************************************************************************************/
/*                             CARGA TABLA PROVEEDOR                                */
/************************************************************************************/ 
 
INSERT INTO LOSGROSOS_RELOADED.Proveedor (razonSocial,domicilio,idCiudad,tel,cuit,idRubro,idUsuario)
SELECT DISTINCT a.Provee_RS,a.Provee_Dom,b.idCiudad,a.Provee_Telefono,a.Provee_CUIT,c.idRubro,d.idUsuario
FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Ciudad b, LOSGROSOS_RELOADED.Rubro c, LOSGROSOS_RELOADED.Usuario d
WHERE a.Provee_Ciudad = b.nombre
  AND a.Provee_Rubro = c.descripcion
  AND a.Provee_CUIT = d.nombreUsuario
  
/************************************************************************************/
/*                             CARGA TABLA CUPON                                    */
/************************************************************************************/ 

INSERT INTO LOSGROSOS_RELOADED.Cupon(codigoCupon,precio,precioFicticio,descripcion,idProveedor,cantMaxima,
                                     fechaPubli,fechaVencOferta,stock,publicado)
SELECT DISTINCT a.Groupon_Codigo,a.Groupon_Precio,a.Groupon_Precio_Ficticio,a.Groupon_Descripcion,b.idProveedor,5,
       a.Groupon_Fecha, a.Groupon_Fecha_Venc,a.Groupon_Cantidad, '1'
FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Proveedor b
WHERE a.Provee_CUIT = b.cuit 


/************************************************************************************/
/*                             CARGA TABLA FACTURA                                  */
/************************************************************************************/ 

-- Puse ese 0.5 para facturar por algo... La idea es q en el aplicativo
-- ese 0.5 sea un valor que el administrador elija
INSERT INTO LOSGROSOS_RELOADED.Factura (facturaNro,fechaFact,idProveedor,importe)
SELECT a.Factura_Nro, a.Factura_Fecha, b.idProveedor,
       SUM(a.Groupon_Precio * 0.5) as importe         
FROM gd_esquema.Maestra a, LOSGROSOS_RELOADED.Proveedor b
WHERE a.Factura_Nro IS NOT NULL
  AND a.Provee_CUIT = b.cuit
GROUP BY a.Factura_Nro, a.Factura_Fecha, b.idProveedor
ORDER BY a.Factura_Nro

/************************************************************************************/
/*                             CARGA TABLA CUPONCOMPRADO                            */ 
/************************************************************************************/ 

INSERT INTO LOSGROSOS_RELOADED.CuponComprado
SELECT a.Groupon_Codigo,b.idCli, a.Groupon_Fecha_Compra,a.Groupon_Entregado_Fecha,
		a.Groupon_Devolucion_Fecha,a.Factura_Nro, ''
FROM gd_esquema.Maestra a
INNER JOIN LOSGROSOS_RELOADED.Clientes b on a.Cli_Dni=b.dni
WHERE a.Groupon_Codigo is not null
AND a.Groupon_Entregado_Fecha is null
AND a.Groupon_Devolucion_Fecha is null
AND a.Factura_Nro is null;  

UPDATE LOSGROSOS_RELOADED.CuponComprado
SET LOSGROSOS_RELOADED.CuponComprado.fechaCanje = a.Groupon_Entregado_Fecha
FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b
WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
AND a.Cli_Dni = b.dni
AND a.Groupon_Entregado_Fecha is not null;


UPDATE LOSGROSOS_RELOADED.CuponComprado
SET LOSGROSOS_RELOADED.CuponComprado.fechaDevolucion = a.Groupon_Devolucion_Fecha
FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b
WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
AND a.Cli_Dni = b.dni
AND a.Groupon_Devolucion_Fecha is not null;


UPDATE LOSGROSOS_RELOADED.CuponComprado
SET LOSGROSOS_RELOADED.CuponComprado.idFactura = c.idFactura
FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b, LOSGROSOS_RELOADED.Factura c
WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
AND a.Cli_Dni = b.dni
AND a.Factura_Nro = c.facturaNro
AND a.Factura_Nro is not null;

/************************************************************************************/
/*                             CARGA TABLA CIUDADESPREFERIDAS                       */
/************************************************************************************/

--Seteamos para los clientes migrados su ciudad de pretenencia como preferida

INSERT INTO LOSGROSOS_RELOADED.CiudadesPreferidas (idCli,idCiudad)
SELECT idCli,idCiudad
FROM LOSGROSOS_RELOADED.Clientes

/************************************************************************************/
/*                             CARGA TABLA CUPONCIUDAD                              */
/************************************************************************************/

--Seteamos para los cupones migrados todas las ciudades como disponibles

INSERT INTO LOSGROSOS_RELOADED.CuponCiudad (codigoCupon,idCiudad)
SELECT a.codigoCupon,b.idCiudad
FROM LOSGROSOS_RELOADED.Cupon a, LOSGROSOS_RELOADED.Ciudad b

GO

/************************************************************************************/
/*                             CARGA TABLA PARAMETRIZACIONES                        */
/************************************************************************************/

INSERT INTO LOSGROSOS_RELOADED.Parametrizacion(codigo,valor)
VALUES ('giftcard_min', '20'),
       ('giftcard_max', '100'),
       ('factura_porcen', '0.5')

---------------------------FIN MIGRADO DE DATOS--------------------------------------

----------------------COMIENZA CREACIÓN TRIGGERS SEGUNDA PARTE -----------------------

/************************************************************************************/
/*       TRIGGER PARA CUPONES                                                       */
/************************************************************************************/
GO
CREATE TRIGGER LOSGROSOS_RELOADED.tr_actualizarStockCupon ON LOSGROSOS_RELOADED.CuponComprado

	AFTER INSERT
	
	AS
	
	BEGIN

		UPDATE LOSGROSOS_RELOADED.Cupon 
		SET LOSGROSOS_RELOADED.Cupon.stock = LOSGROSOS_RELOADED.Cupon.stock - 1
		FROM inserted 
		WHERE LOSGROSOS_RELOADED.Cupon.codigoCupon = inserted.codigoCupon
		
		
	
	END

GO



----------------------FIN CREACIÓN TRIGGERS SEGUNDA PARTE----------------------------

--------------------------------COMIENZO PROCEDURES----------------------------------

/************************************************************************************/
/*                             CREAR STORES PROCEDURES                              */
/************************************************************************************/

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_Alta_Proveedor') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_Alta_Proveedor;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_Modificar_Proveedor') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_Modificar_Proveedor;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_HabilitacionProveedor') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_HabilitacionProveedor;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_Alta_Cliente') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_Alta_Cliente;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_Modificar_Cliente') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_Modificar_Cliente;


IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_HabilitacionCliente') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_HabilitacionCliente;


IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.P_Insertar_Carga') 
				AND type in (N'P')) 
DROP PROCEDURE LOSGROSOS_RELOADED.P_Insertar_Carga;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.F_idCiudad') 
				AND type in (N'FN')) 
DROP FUNCTION LOSGROSOS_RELOADED.F_idCiudad;

IF  EXISTS (SELECT * 
			FROM sys.objects 
			WHERE object_id = OBJECT_ID(N'LOSGROSOS_RELOADED.F_idUsuario') 
				AND type in (N'FN')) 
DROP FUNCTION LOSGROSOS_RELOADED.F_idUsuario;

GO

CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_Alta_Proveedor]
	@razonSocial nvarchar(100) = null,
	@domicilio nvarchar(100) = null,
	@idCiudad numeric(18,0) = null,
	@tel numeric(18,0) = null,
	@cuit nvarchar(20) = null,
	@idRubro numeric(18,0) = null,
	@mail nvarchar(255) = null,
	@codPostal numeric(18,0) = null,
	@nombContacto nvarchar(255) = null,
	@idUsuario numeric(18,0) = null
	
AS
BEGIN
		
	insert into LOSGROSOS_RELOADED.Proveedor
	(razonSocial, domicilio, idCiudad, tel,
	 cuit, idRubro, mail, codPostal, nombContacto,
	 idUsuario)
	values
	(@razonSocial, @domicilio, @idCiudad, @tel,
	 @cuit, @idRubro, @mail, @codPostal, @nombContacto,
	 @idUsuario)
	
	
END
go

CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_Modificar_Proveedor]
	@idProveedor numeric(18,0),
	@razonSocial nvarchar(100) = null,
	@domicilio nvarchar(100) = null,
	@idCiudad numeric(18,0) = null,
	@tel numeric(18,0) = null,
	@cuit nvarchar(20) = null,
	@idRubro numeric(18,0) = null,
	@mail nvarchar(255) = null,
	@codPostal numeric(18,0) = null,
	@nombContacto nvarchar(255) = null
	
AS
BEGIN

	update LOSGROSOS_RELOADED.Proveedor
		set	razonSocial = @razonSocial,
			domicilio = @domicilio,
			idCiudad = @idCiudad,
			tel = @tel,
			cuit = @cuit,
			idRubro = @idRubro,
			mail = @mail,
			codPostal = @codPostal,
			nombContacto = @nombContacto
		where idProveedor = @idProveedor
	
	
END
go

CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_HabilitacionProveedor]
	@idProveedor numeric(18,0),
	@inhabilitado char(1)
AS
BEGIN
	update LOSGROSOS_RELOADED.Proveedor
	set	inhabilitado = @inhabilitado
	where idProveedor = @idProveedor
END
go


/************************************************************************************/
/*                                STORED PROCEDURES CLIENTE                         */
/************************************************************************************/

CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_Alta_Cliente]
	@nombre nvarchar(255) = null,
	@apellido nvarchar(255) = null,
	@dni numeric(18,0) = null,
	@direccion nvarchar(255) = null,
	@tel numeric(18,0) = null,
	@mail nvarchar(255) = null,
	@fechaNac datetime = null,
	@idCiudad numeric(18,0) = null,
	@codPostal numeric(10,0) = null,
	@saldo numeric(18,2) = null,
	@idUsuario numeric(18,0) = null
	
AS
BEGIN
		
	insert into LOSGROSOS_RELOADED.Clientes
	(nombre, apellido, dni, direccion, tel, mail,
	 fechaNac, idCiudad, codPostal, saldo, idUsuario)
	values
	(@nombre, @apellido, @dni, @direccion, @tel, @mail,
	 @fechaNac, @idCiudad, @codPostal, @saldo, @idUsuario)
	
	
END
GO


CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_Modificar_Cliente]
	@idCli numeric(18,0) = null,
	@nombre nvarchar(255) = null,
	@apellido nvarchar(255) = null,
	@dni numeric(18,0) = null,
	@direccion nvarchar(255) = null,
	@tel numeric(18,0) = null,
	@mail nvarchar(255) = null,
	@fechaNac datetime = null,
	@idCiudad numeric(18,0) = null,
	@codPostal numeric(10,0) = null
	
	
AS
BEGIN

	update LOSGROSOS_RELOADED.Clientes
		set	nombre = @nombre,
			apellido = @apellido,
			dni = @dni,
			direccion = @direccion,
			tel = @tel,
			mail = @mail,
			fechaNac = @fechaNac,
			idCiudad = @idCiudad,
			codPostal = @codPostal
			
		where idCli = @idCli
	
	
END
GO


CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_HabilitacionCliente]
	@idCli numeric(18,0),
	@inhabilitado char(1)
AS
BEGIN
	update LOSGROSOS_RELOADED.Clientes
	set	inhabilitado = @inhabilitado
	where idCli = @idCli
END
GO



CREATE PROCEDURE [LOSGROSOS_RELOADED].[P_Insertar_Carga]
	@nombreUsuario nvarchar(100),
	@monto numeric(18,0),
	@fecha datetime,
	@idTipoPago numeric(18,0),
	@numeroTarj numeric(18,0) = null,
	@fechaVenc datetime = null,
	@nombreTitularTarj nvarchar(255) = null

AS
BEGIN

	DECLARE @idCli numeric(18,0);
	DECLARE @idUsuario numeric(18,0);

	SET @idUsuario = (SELECT DISTINCT idUsuario FROM LOSGROSOS_RELOADED.Usuario WHERE nombreUsuario = @nombreUsuario)

	SET @idCli = 
	(SELECT DISTINCT idCli 
	FROM LOSGROSOS_RELOADED.Clientes
	WHERE idUsuario = @idUsuario
	)
	  
	INSERT INTO LOSGROSOS_RELOADED.Carga
	(idCli, monto, fecha, idTipoPago, numeroTarj, 
	 fechaVencTarj, nombreTitularTarj)
	 VALUES (@idCli, @monto,@fecha,@idTipoPago,@numeroTarj,
	 @fechaVenc, @nombreTitularTarj);

END
GO

----------------------------------FIN PROCEDURES-------------------------------------


--------------------------------COMIENZO FUNCIONES-----------------------------------

/************************************************************************************/
/*                               FUNCION DEVUELVE ID_CIUDAD                         */
/************************************************************************************/

CREATE FUNCTION [LOSGROSOS_RELOADED].[F_idCiudad] 
(	
   @nombre nvarchar(255) = null
)
RETURNS numeric(18,0)
BEGIN
DECLARE 
 @idCiudad numeric(18,0);

	SET @idCiudad = 
	(SELECT idCiudad 
	FROM LOSGROSOS_RELOADED.Ciudad
	WHERE nombre = @nombre)
	
RETURN @idCiudad

END

GO

CREATE FUNCTION [LOSGROSOS_RELOADED].[F_idUsuario] 
(	
   @nombreUsuario nvarchar(100)
)
RETURNS numeric(18,0)
BEGIN
DECLARE 
@idUser numeric(18,0);


	SET @idUser = 
	(SELECT idUsuario  
	FROM LOSGROSOS_RELOADED.Usuario
	WHERE nombreUsuario = @nombreUsuario)

RETURN @idUser

END
