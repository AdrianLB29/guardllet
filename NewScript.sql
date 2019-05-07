CREATE DATABASE GUARDLLET 
GO

USE GUARDLLET
GO

-------------------------------
-------------------------------
---- CREACION DE TABLAS -------
-------------------------------
-------------------------------

CREATE TABLE SEMESTRES(
	ID_SEMESTRE INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(100),
)

CREATE TABLE MATERIAS(
	ID_MATERIA INT IDENTITY(1,1) PRIMARY KEY,
	ID_SEMESTRE INT,
	NOMBRE VARCHAR(100)
)

CREATE TABLE ESCUELAS(
	ID_ESCUELA INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(100)
)

CREATE TABLE DATOS_ESCOLARES(
	ID_DATOS_ESCOLARES INT IDENTITY(1,1) PRIMARY KEY,
	ID_ESCUELA INT,
	BOLETA VARCHAR(10) UNIQUE,
	GRUPO VARCHAR(6),
	EDAD VARCHAR(2)
	
	CONSTRAINT fk_ESC FOREIGN KEY (ID_ESCUELA) REFERENCES ESCUELAS(ID_ESCUELA),
)

CREATE TABLE DATOS_GENERALES(
	ID_DATOS_GENERALES INT IDENTITY(1,1) PRIMARY KEY,
	ID_DATOS_ESCOLARES INT NULL,
	NOMBRES VARCHAR(100),
	APELLIDO_P VARCHAR(50),
	APELLIDO_M VARCHAR(50),
	CELULAR VARCHAR(10) UNIQUE,
	FOTO IMAGE,
	
	CONSTRAINT fk_DAT_ESC FOREIGN KEY (ID_DATOS_ESCOLARES) REFERENCES DATOS_ESCOLARES(ID_DATOS_ESCOLARES),
)

CREATE TABLE MONEDERO(
	ID_MONEDERO INT IDENTITY(1,1) PRIMARY KEY,
	CODIGO VARCHAR(20) UNIQUE,
	IMAGEN_CODIGO IMAGE,
	SALDO INT,
)

CREATE TABLE USUARIO(
	ID_USUARIO INT IDENTITY(1,1) PRIMARY KEY,
	ID_DATOS_GENERALES INT NULL,
	ID_MONEDERO INT NULL,
	CORREO VARCHAR(100) UNIQUE,
	CONTRASEÑA VARCHAR(MAX),
	TIPO_USUARIO INT,
	ESTADO INT,
	
	CONSTRAINT fk_DAT_GEN FOREIGN KEY (ID_DATOS_GENERALES) REFERENCES DATOS_GENERALES(ID_DATOS_GENERALES),
	CONSTRAINT fk_MON FOREIGN KEY (ID_MONEDERO) REFERENCES MONEDERO(ID_MONEDERO),
)

CREATE TABLE PRODUCTO(
	ID_PRODUCTO INT IDENTITY(1,1) PRIMARY KEY,
	NOMBRE VARCHAR(100),
	CODIGO VARCHAR(10),
	PRECIO INT,
	IMAGEN IMAGE,
)

CREATE TABLE MOVIMIENTO_CV(
	ID_MOVIMIENTO_CV INT IDENTITY(1,1) PRIMARY KEY,
	ID_PRODUCTO INT,
	ID_MONEDERO INT NULL,
	ESTADO INT,
	FECHA DATETIME,
	NUMERO_AUTORIZACION VARCHAR(50) NULL,
	MENSAJE VARCHAR(500),
	
	CONSTRAINT fk_PRO FOREIGN KEY (ID_PRODUCTO) REFERENCES PRODUCTO(ID_PRODUCTO),
	CONSTRAINT fk_MON_MOV_CV FOREIGN KEY (ID_MONEDERO) REFERENCES MONEDERO(ID_MONEDERO),
)

CREATE TABLE MOVIMIENTO_R(
	ID_MOVIMIENTO_R INT IDENTITY(1,1) PRIMARY KEY,
	ID_ADMINISTRADOR INT,
	ID_MONEDERO INT NULL,
	MONTO INT,
	FECHA DATETIME,
	NUMERO_AUTORIZACION VARCHAR(50) NULL,
	ESTADO INT,
	MENSAJE VARCHAR(500),
	
	CONSTRAINT fk_ADM FOREIGN KEY (ID_ADMINISTRADOR) REFERENCES USUARIO(ID_USUARIO),
	CONSTRAINT fk_MON_MOV_R FOREIGN KEY (ID_MONEDERO) REFERENCES MONEDERO(ID_MONEDERO),
)

ALTER TABLE [dbo].[MOVIMIENTO_R] ADD  CONSTRAINT [DF_tb_MOVIMIENTO_R_fecha]  DEFAULT (getdate()) FOR [FECHA]

CREATE TABLE COMPROBANTE(
	ID_COMPROBANTE INT IDENTITY(1,1) PRIMARY KEY,
	ID_MONEDERO INT,
	FECHA DATETIME,
	NOMBRE_ARTICULO VARCHAR(100),
	PRECIO INT,
	TIPO INT,
	MATERIAS VARCHAR(100) NULL,
	NUMERO_AUTORIZACION VARCHAR(50),

	CONSTRAINT fk_MON_COM FOREIGN KEY (ID_MONEDERO) REFERENCES MONEDERO(ID_MONEDERO),
)
GO

------------------------------------
------------------------------------
-----CREACION DE PROCEDIMIENTOS ----
------------------------------------
------------------------------------


---PROCEDIMIENTO PARA REGISTRAR-----
--------- USUARIO ------------------

CREATE PROCEDURE [dbo].[RegistroUsuario]

@CORREO VARCHAR(100),
@CONTRASEÑA VARCHAR(MAX),
@TIPO_USUARIO INT,
@ESTADO INT,
@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into USUARIO
(
	CORREO,
	CONTRASEÑA,
	TIPO_USUARIO,
	ESTADO
)

Values

(
	
	@CORREO,
	ENCRYPTBYPASSPHRASE('password', @CONTRASEÑA),
	@TIPO_USUARIO,
	@ESTADO
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_USUARIO FROM USUARIO WHERE CORREO = @CORREO
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA VINCULAR--------
---------DATOS USUARIO----------------

CREATE PROCEDURE  [dbo].[VincularDatosUsuario]

@ID_USUARIO INT,
@ID_DATOS_GENERALES INT,
@ESTADO INT,
@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
UPDATE USUARIO

SET
 
 ID_DATOS_GENERALES = @ID_DATOS_GENERALES,
 ESTADO = @ESTADO
 
WHERE ID_USUARIO = @ID_USUARIO

SET @ID_REGISTRO = @ID_USUARIO 

RETURN(@ID_REGISTRO)

END

--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA VINCULAR--------
---------DATOS ESCOLARES--------------

CREATE PROCEDURE  [dbo].[VincularDatosEscolares]

@ID_DATOS_GENERALES INT,
@ID_DATOS_ESCOLARES INT,

@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
UPDATE DATOS_GENERALES

SET
 
	ID_DATOS_ESCOLARES = @ID_DATOS_ESCOLARES
 
WHERE ID_DATOS_GENERALES = @ID_DATOS_GENERALES

SET @ID_REGISTRO = @ID_DATOS_GENERALES 

RETURN(@ID_REGISTRO)

END

--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

----PROCEDIMIENTO DE LOGIN------
--------------------------------


CREATE PROCEDURE  [dbo].[LoginUsuario]
    
	@CORREO VARCHAR(100), 
	@CONTRASEÑA VARCHAR(300),
	@RESULTADO BIT OUTPUT

AS

	DECLARE @CONTRASEÑA_CODIFICADA AS VARCHAR(300)
	DECLARE @CONTRASEÑA_DECODIFICADA AS VARCHAR(300)

BEGIN

SELECT @CONTRASEÑA_CODIFICADA = CONTRASEÑA FROM USUARIO WHERE CORREO = @CORREO
SET @CONTRASEÑA_DECODIFICADA = DECRYPTBYPASSPHRASE('password', @CONTRASEÑA_CODIFICADA)

END

BEGIN

IF @CONTRASEÑA_DECODIFICADA = @CONTRASEÑA
    SET @RESULTADO = 1
ELSE
	SET @RESULTADO = 0

RETURN(@RESULTADO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA REGISTRAR------
----------DATOS GENERALES------------

CREATE PROCEDURE [dbo].[RegistroDatosGenerales]

@NOMBRES VARCHAR(100),
@APELLIDO_P VARCHAR(50),
@APELLIDO_M	VARCHAR(50),
@CELULAR VARCHAR(10),
@FOTO IMAGE,
@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into DATOS_GENERALES
(
    NOMBRES,
	APELLIDO_P,
	APELLIDO_M,
	CELULAR,
	FOTO
)

Values

(
	@NOMBRES,
	@APELLIDO_P,
	@APELLIDO_M,
	@CELULAR,
	@FOTO
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_DATOS_GENERALES FROM DATOS_GENERALES WHERE CELULAR = @CELULAR
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA REGISTRAR------
----------DATOS ESCOLARES------------

CREATE PROCEDURE [dbo].[RegistroDatosEscolares]

@ID_ESCUELA INT,
@BOLETA VARCHAR(10),
@GRUPO	VARCHAR(6),
@EDAD VARCHAR(2),
@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into DATOS_ESCOLARES
(
    ID_ESCUELA,
	BOLETA,
	GRUPO,
	EDAD
)

Values

(
	@ID_ESCUELA,
	@BOLETA,
	@GRUPO,
	@EDAD
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_DATOS_ESCOLARES FROM DATOS_ESCOLARES WHERE BOLETA = @BOLETA
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA REGISTRAR------
-------------MONEDERO----------------

CREATE PROCEDURE [dbo].[RegistroMonedero]

@CODIGO VARCHAR(20),
@IMAGEN_CODIGO IMAGE,
@SALDO INT,

@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into MONEDERO
(
    CODIGO,
	IMAGEN_CODIGO,
	SALDO
)

Values

(
	@CODIGO,
	@IMAGEN_CODIGO,
	@SALDO
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_MONEDERO FROM MONEDERO WHERE CODIGO = @CODIGO
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA VINCULAR-------
-------------MONEDERO----------------

CREATE PROCEDURE [dbo].[VincularMonedero]

@ID_USUARIO INT,
@ID_MONEDERO INT,

@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
UPDATE USUARIO

SET
 
  ID_MONEDERO = @ID_MONEDERO

WHERE ID_USUARIO = @ID_USUARIO

SET @ID_REGISTRO = @ID_USUARIO 

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

---PROCEDIMIENTO PARA ACTUALIZAR--------
--------- SALDO MONEDERO ---------------

CREATE PROCEDURE  [dbo].[ActualizarSaldo]

@ID_MONEDERO INT,
@NUEVO_SALDO INT

AS

BEGIN
    
UPDATE MONEDERO

SET
 
	SALDO = @NUEVO_SALDO
 
WHERE ID_MONEDERO = @ID_MONEDERO

END

--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO

------PROCEDIMIENTO PARA REGISTRAR--------
-------------MOVIMIENTO CV----------------

CREATE PROCEDURE [dbo].[RegistroMovimientoCV]

@ID_PRODUCTO INT,
@ID_MONEDERO INT,
@ESTADO INT,
@FECHA DATETIME,
@NUMERO_AUTORIZACION VARCHAR(50),
@MENSAJE VARCHAR(500),

@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into MOVIMIENTO_CV
(
    ID_PRODUCTO,
	ID_MONEDERO,
	ESTADO,
	FECHA,
	NUMERO_AUTORIZACION,
	MENSAJE
)

Values

(
	@ID_PRODUCTO,
	@ID_MONEDERO,
	@ESTADO,
	@FECHA,
	@NUMERO_AUTORIZACION,
	@MENSAJE
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_MOVIMIENTO_CV FROM MOVIMIENTO_CV WHERE NUMERO_AUTORIZACION = @NUMERO_AUTORIZACION
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO


------PROCEDIMIENTO PARA REGISTRAR--------
------------- COMPROBANTE ----------------

CREATE PROCEDURE [dbo].[RegistroComprobante]

@ID_MONEDERO INT,
@FECHA DATETIME,
@NOMBRE_ARTICULO VARCHAR(100),
@NUMERO_AUTORIZACION INT,
@PRECIO INT,
@MATERIAS VARCHAR(100),
@TIPO INT,

@ID_REGISTRO INT OUTPUT

AS

BEGIN
    
Insert Into COMPROBANTE
(
	ID_MONEDERO,
    FECHA,
	NOMBRE_ARTICULO,
	NUMERO_AUTORIZACION,
	PRECIO,
    MATERIAS,
	TIPO
)

Values

(
	@ID_MONEDERO,
	@FECHA,
	@NOMBRE_ARTICULO,
	@NUMERO_AUTORIZACION,
	@PRECIO,
	@MATERIAS,
	@TIPO
)

END

BEGIN

DECLARE @ID AS INT 

SELECT @ID = ID_COMPROBANTE FROM COMPROBANTE WHERE NUMERO_AUTORIZACION = @NUMERO_AUTORIZACION
SET @ID_REGISTRO = @ID

RETURN(@ID_REGISTRO)

END
--------------------------------------------------------------
--------------------------------------------------------------
--------------------------------------------------------------
GO


----------------------------------
---INSERCION DE DATOS ESTATICOS---
----------------------------------

INSERT INTO ESCUELAS(NOMBRE)
VALUES ('Cecyt 13 "Ricardo Flores Magon"')

INSERT INTO PRODUCTO(NOMBRE,PRECIO,CODIGO)
VALUES('Examen a titulo de suficiencia',10,'SERVETS01') 

INSERT INTO PRODUCTO(NOMBRE,PRECIO,CODIGO)
VALUES('Reposicion de credencial',62,'SERVRCD01')

INSERT INTO PRODUCTO(NOMBRE,CODIGO)
VALUES('Deuda en biblioteca','SERVFEB01')

INSERT INTO PRODUCTO(NOMBRE,CODIGO)
VALUES('Examen a titulo de suficiencia','SERVETS01')

----------------------------------
------------SEMESTRES-------------
----------------------------------

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('PRIMER SEMESTRE')

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('SEGUNDO SEMESTRE')

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('TERCER SEMESTRE')

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('CUARTO SEMESTRE')

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('QUINTO SEMESTRE')

INSERT INTO SEMESTRES(NOMBRE)
VALUES ('SEXTO SEMESTRE')


----------------------------------
-----MATERIAS PRIMER SEMESTRE-----
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ALGEBRA', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COMPUTACION BASICA I', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('EXPRESION ORAL Y ESCRITA I', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES I', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('FILOSOFIA I', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DESARROLLO PERSONAL', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ORIENTACION JUVENIL Y PROFESIONAL I', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DESARROLLO DE HABILIDADES DEL PENSAMIENTO', 1)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('HISTORIA DE MEXICO CONTEMPORANEO I', 1)

----------------------------------
-----MATERIAS SEGUNDO SEMESTRE-----
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('GEOMETRIA Y TRIGONOMETRIA', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('FILOSOFIA II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COMPUTACION BASICA II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('EXPRESION ORAL Y ESCRITA II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('BIOLOGIA BASICA', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('HISTORIA DE MEXICO CONTEMPORANEO II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ORIENTACION JUVENIL Y PROFESIONAL II', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('TECNICAS DE INVESTIGACION DE CAMPO', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('APRECIACION ARTISTICA', 2)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COMUNICACION Y LIDERAZGO', 2)

----------------------------------
-----MATERIAS TERCER SEMESTRE------
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

----- TRONCO COMUN ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('GEOMETRIA ANALITICA', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('FISICA I', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('QUIMICA I', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES III', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COMUNICACION CIENTIFICA', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CONTABILIDAD I', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ENTORNO SOCIOECONOMICO DE MEXICO', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CALCULOS FINANCIEROS I', 3) 

----- ADMINISTRACION ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ADMINISTRACION', 3) 

----- CONTADURIA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('LEGISLACION FISCAL', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ORGANIZACION CONTABLE', 3) 

----- INFORMATICA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('HERRAMIENTAS DE PROGRAMACION', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ENSAMBLADO Y MANTENIMIENTO DE PCS', 3) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PRINCIPIOS CULINARIOS', 3) 
										      
INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('OPERACION HOTELERA', 3) 

----------------------------------
-----MATERIAS CUARTO SEMESTRE------
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

----- TRONCO COMUN ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CALCULO DIFERENCIAL', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('FISICA II', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('QUIMICA II', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES IV', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DERECHO', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CONTABILIDAD II', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CALCULOS FINANCIEROS II', 4) 

----- ADMINISTRACION ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ADMINISTRACION DE CAPITAL HUMANO', 4) 

----- CONTADURIA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('LEGISLACION FICAL PERSONAS FISICAS', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PAQUETERIA CONTABLE', 4) 

----- INFORMATICA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PROGRAMACION ESTRUCTURADA', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('REALIDAD VIRTUAL', 4) 

----- TURISMO ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COCINA INTERNACIONAL', 4) 
										      
INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('SERVICIOS DE HOSPEDAJE', 4) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES TURISTICO I', 4) 

----------------------------------
-----MATERIAS QUINTO SEMESTRE------
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

----- TRONCO COMUN ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CALCULO INTEGRAL', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('MICROECONOMIA', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES V', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DERECHO MERCANTIL', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CONTABILIDAD III', 5)  

----- ADMINISTRACION ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ADMINISTRACION DE SUELDOS Y SALARIOS', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('SISTEMAS Y METODOS ORGANIZACIONALES', 5)

----- CONTADURIA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('LEGISLACION FISCAL PERSONAS MORALES', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DERECHO LABORAL', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NOCIONES DE FINANZAS Y PRESUPUESTOS', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CONTABILIDADES ESPECIALES', 5) 

----- INFORMATICA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PROGRAMACION ORIENTADA A OBJETOS', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('BASE DE DATOS', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('MODELADO DE SISTEMAS', 5) 

----- TURISMO ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COSTO DE ALIMENTOS Y BEBIDAS', 5) 
										      
INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PATRIMONIO TURISTICO NACIONAL', 5)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('AGENCIA DE VIAJES', 5) 

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('RESTAURANTE Y BAR', 5)  

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES TURISTICO III', 5) 

----------------------------------
-----MATERIAS SEXTO SEMESTRE------
----------------------------------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NULL',0)

----- TRONCO COMUN ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PROBABILIDAD Y ESTADISTICA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('MACROECONOMIA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES VI', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ORIENTACION JUVENIL Y PROFESIONAL IV', 6)

----- ADMINISTRACION ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PAQUETERIA ADMINISTRATIVA', 6)

----- CONTADURIA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('SEGURIDAD SOCIAL', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NOMINAS', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('NOCIONES DE AUDITORIA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DESARROLLO DE PROYECTOS DE INVESTIGACION', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('CONTABILIDAD DE COSTOS', 6)

----- INFORMATICA ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PROGRAMACION AVANZADA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('DESARROLLO WEB Y MULTIMEDIA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('TELEINFORMATICA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('SISTEMAS DE INFORMACION', 6)

----- TURISMO ------

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('PATRIMONIO TURISTICO INTERNACIONAL', 6) 
										      
INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('COMERCIALIZACION TURISTICA', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('SISTEMA DE RESERVACIONES SABRE', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('ORGANIZACION DE EVENTOS', 6)

INSERT INTO MATERIAS(NOMBRE, ID_SEMESTRE)
VALUES ('INGLES TURISTICO III', 6) 

GO
