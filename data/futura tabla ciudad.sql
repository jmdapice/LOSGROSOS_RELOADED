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

INSERT INTO LOSGROSOS_RELOADED.Cupon(codigoCupon,precio,precioFicticio,descripcion,idProveedor,
                                     fechaPubli,fechaVencOferta,stock)
SELECT DISTINCT a.Groupon_Codigo,a.Groupon_Precio,a.Groupon_Precio_Ficticio,a.Groupon_Descripcion,b.idProveedor,
       a.Groupon_Fecha, a.Groupon_Fecha_Venc,a.Groupon_Cantidad
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

--INSERT INTO LOSGROSOS_RELOADED.CuponComprado
--SELECT a.Groupon_Codigo,b.idCli, a.Groupon_Fecha_Compra,a.Groupon_Entregado_Fecha,
--		a.Groupon_Devolucion_Fecha,a.Factura_Nro, ''
--FROM gd_esquema.Maestra a
--INNER JOIN LOSGROSOS_RELOADED.Clientes b on a.Cli_Dni=b.dni
--WHERE a.Groupon_Codigo is not null
--AND a.Groupon_Entregado_Fecha is null
--AND a.Groupon_Devolucion_Fecha is null
--AND a.Factura_Nro is null;  

--UPDATE LOSGROSOS_RELOADED.CuponComprado
--SET LOSGROSOS_RELOADED.CuponComprado.fechaCanje = a.Groupon_Entregado_Fecha
--FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b
--WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
--AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
--AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
--AND a.Cli_Dni = b.dni
--AND a.Groupon_Entregado_Fecha is not null;


--UPDATE LOSGROSOS_RELOADED.CuponComprado
--SET LOSGROSOS_RELOADED.CuponComprado.fechaDevolucion = a.Groupon_Devolucion_Fecha
--FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b
--WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
--AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
--AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
--AND a.Cli_Dni = b.dni
--AND a.Groupon_Devolucion_Fecha is not null;


--UPDATE LOSGROSOS_RELOADED.CuponComprado
--SET LOSGROSOS_RELOADED.CuponComprado.idFactura = c.idFactura
--FROM gd_esquema.Maestra a , LOSGROSOS_RELOADED.Clientes b, LOSGROSOS_RELOADED.Factura c
--WHERE LOSGROSOS_RELOADED.CuponComprado.idCli = b.idCli
--AND LOSGROSOS_RELOADED.CuponComprado.codigoCupon = a.Groupon_Codigo 
--AND LOSGROSOS_RELOADED.CuponComprado.fechaCompra = a.Groupon_Fecha_Compra
--AND a.Cli_Dni = b.dni
--AND a.Factura_Nro = c.facturaNro
--AND a.Factura_Nro is not null;

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