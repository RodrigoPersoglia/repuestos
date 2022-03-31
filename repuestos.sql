-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         5.6.26 - MySQL Community Server (GPL)
-- SO del servidor:              Win32
-- HeidiSQL Versión:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para repuestos
CREATE DATABASE IF NOT EXISTS `repuestos` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `repuestos`;

-- Volcando estructura para procedimiento repuestos.AgregarArticulo
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarArticulo`(
	IN `p1` VARCHAR(45),
	IN `p2` VARCHAR(45),
	IN `p3` VARCHAR(45),
	IN `p4` VARCHAR(60),
	IN `p5` DECIMAL(15,2),
	IN `p6` INT,
	IN `p7` INT,
	IN `p8` INT,
	IN `p9` VARCHAR(150),
	IN `p10` INT,
	IN `p11` INT,
	IN `p12` INT,
	IN `p13` INT,
	IN `p14` VARCHAR(50)


,
	IN `p15` DATE,
	IN `p16` VARCHAR(50)
)
INSERT INTO articulo (codigo,codigoProveedor,numeroPieza,descripcion,precio, stockMin,stockMax,StockActual,observaciones,Marca_ID,Rubro_ID,Lado_ID,Proveedor_ID,Ubicacion,creacion,usuario) 
VALUES (p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16)//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarCompatibilidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarCompatibilidad`(
	IN `p1` VARCHAR(50),
	IN `p2` int

)
BEGIN
START TRANSACTION;
insert into compatibilidad (Articulo_ID,Modelo_ID)
values ((select id
from articulo a	where a.codigo = p1),
p2);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.agregarDetalleFactura
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarDetalleFactura`(
	IN `p1` varchar(50),
	IN `p2` varchar(100),
	IN `p3` int,
	IN `p4` decimal(15,2)



)
BEGIN
START TRANSACTION;
insert into detallefactura (codigo,descripcion,cantidad,precio,factura_ID,articulo_ID)
values(p1,p2,p3,p4,
(select f.ID
from factura f
order by f.id desc
limit 1
),
(select a.ID
from articulo a
where a.codigo = p1
limit 1)
);


UPDATE articulo a2
SET
a2.stockActual= a2.stockActual -p3
where a2.codigo = p1;

COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.agregarDetallePresupuesto
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `agregarDetallePresupuesto`(
	IN `p1` varchar(50),
	IN `p2` varchar(100),
	IN `p3` int,
	IN `p4` decimal(15,2)




)
BEGIN
START TRANSACTION;
insert into detallepresupuesto (codigo,descripcion,cantidad,precio,presupuesto_ID,articulo_ID)
values(p1,p2,p3,p4,
(select f.ID
from presupuesto f
order by f.id desc
limit 1
),
(select a.ID
from articulo a
where a.codigo = p1
limit 1)
);


UPDATE articulo a2
SET
a2.stockActual= a2.stockActual -p3
where a2.codigo = p1;

COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarEquivalencia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarEquivalencia`(
	IN `p1` VARCHAR(50),
	IN `p2` int

)
BEGIN
START TRANSACTION;
insert into equivalencia (Articulo_ID,Equivalencia_ID)
values ((select id
from articulo a	where a.codigo = p1),
p2);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarFactura
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarFactura`(
	IN `p1` datetime,
	IN `p2` decimal(15,2),
	IN `p3` decimal(15,2),
	IN `p4` decimal(15,2),
	IN `p5` int,
	IN `p6` varchar(60),
	IN `p7` varchar(45),
	IN `p8` varchar(45),
	IN `p9` varchar(10),
	IN `p10` varchar(45)




,
	IN `p11` INT


)
BEGIN
START TRANSACTION;
insert into factura (numero,fechaHora,subTotal,financiacion,total,cliente_ID,cliente,direccion,localidad,cp,usuario,medioPagoID)
values(
(
select 1+ifnull(
(select f.numero
from factura f
order by f.ID desc
limit 1),0)
),
p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11);
commit;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarLocalidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarLocalidad`(p1 varchar(60), p2 int)
insert into Localidad (nombre,provincia_ID)
values (p1,p2)//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarMatriz
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarMatriz`(
	IN `p1` int,
	IN `p2` int ,
	IN `p3` DECIMAL(5,3),
	IN `p4` int,
	IN `p5` int


)
BEGIN
insert into matriz( ejemplar,cantidadSalidas,pesoActual,Articulo_ID,cliente_ID,kgAcumulados)
values (p1,p2,p3,p4,p5,0);
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarMovimientoStock
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarMovimientoStock`(
	IN `p1` date,
	IN `p2` int,
	IN `p3` int,
	IN `p4` varchar(60),
	IN `p5` varchar(200)
,
	IN `p6` INT

)
begin
start transaction;
insert into movimientostock (fecha,articuloID,tipoMovimientoID,usuario,observaciones,cantidad)
values(p1,p2,p3,p4,p5,p6);

 IF     
 			  p3 = 1 THEN  
 			  
				update articulo a
				set
				a.stockActual = a.stockActual + p6
				where a.ID = p2
				
				;
 	 ELSEIF p3 = 2  THEN 
	  			update articulo a
				set
				a.stockActual = a.stockActual - p6
				where a.ID = p2
				;
    END IF;


commit;
end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarPresupuesto
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarPresupuesto`(
	IN `p1` datetime,
	IN `p2` decimal(15,2),
	IN `p3` decimal(15,2),
	IN `p4` decimal(15,2),
	IN `p5` int,
	IN `p6` varchar(60),
	IN `p7` varchar(45),
	IN `p8` varchar(45),
	IN `p9` varchar(10),
	IN `p10` varchar(45)




,
	IN `p11` INT


)
BEGIN
START TRANSACTION;
insert into presupuesto (numero,fechaHora,subTotal,financiacion,total,cliente_ID,cliente,direccion,localidad,cp,usuario,medioPagoID)
values(
(
select 1+ifnull(
(select f.numero
from presupuesto f
order by f.ID desc
limit 1),0)
),
p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11);
commit;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.AgregarUsuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarUsuario`(
	IN `p1` varchar(20),
	IN `p2` varchar(20),
	IN `p3` INT,
	IN `p4` INT,
	IN `p5` INT,
	IN `p6` INT,
	IN `p7` INT,
	IN `p8` INT


,
	IN `p9` INT
,
	IN `p10` INT,
	IN `p11` INT,
	IN `p12` INT,
	IN `p13` INT,
	IN `p14` INT,
	IN `p15` INT,
	IN `p16` INT,
	IN `p17` INT,
	IN `p18` INT,
	IN `p19` INT,
	IN `p20` INT

)
BEGIN
Insert into Usuario (
usuario,
clave,
verCliente,
VerArchivo,
verArticulos,
verPedidos,
verMatrices,
verUsuarios,
verReportes,
altaArticulos,
bajaArticulos,
modificaArticulos,
altaClientes,
modificaClientes,
altaPedidos,
modificaPedidos,
detallePedidos,
altaMatrices,
modificaMatrices,
nitruradoMatrices
)
values(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,p20);
END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.articulo
CREATE TABLE IF NOT EXISTS `articulo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(45) NOT NULL,
  `codigoProveedor` varchar(45) NOT NULL,
  `numeroPieza` varchar(45) NOT NULL,
  `descripcion` varchar(60) NOT NULL,
  `precio` decimal(15,2) NOT NULL,
  `stockMin` int(11) NOT NULL,
  `stockMax` int(11) NOT NULL,
  `stockActual` int(11) NOT NULL,
  `observaciones` varchar(300) NOT NULL,
  `Marca_ID` int(11) NOT NULL,
  `Rubro_ID` int(11) NOT NULL,
  `Lado_ID` int(11) NOT NULL,
  `Proveedor_ID` int(11) NOT NULL,
  `Ubicacion` varchar(50) NOT NULL DEFAULT '',
  `creacion` date NOT NULL,
  `usuario` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `Aleacion_ID` (`Marca_ID`),
  KEY `Clasificacion_ID` (`Lado_ID`),
  KEY `Cliente_ID` (`Proveedor_ID`),
  KEY `Temple_ID` (`Rubro_ID`),
  FULLTEXT KEY `codigo` (`codigo`,`codigoProveedor`,`numeroPieza`,`descripcion`,`observaciones`),
  CONSTRAINT `articulo_ibfk_1` FOREIGN KEY (`Marca_ID`) REFERENCES `marca` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `articulo_ibfk_2` FOREIGN KEY (`Lado_ID`) REFERENCES `lado` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `articulo_ibfk_3` FOREIGN KEY (`Proveedor_ID`) REFERENCES `proveedor` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `articulo_ibfk_4` FOREIGN KEY (`Rubro_ID`) REFERENCES `rubro` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1748 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.articulo: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `articulo` DISABLE KEYS */;
REPLACE INTO `articulo` (`ID`, `codigo`, `codigoProveedor`, `numeroPieza`, `descripcion`, `precio`, `stockMin`, `stockMax`, `stockActual`, `observaciones`, `Marca_ID`, `Rubro_ID`, `Lado_ID`, `Proveedor_ID`, `Ubicacion`, `creacion`, `usuario`) VALUES
	(1747, 'SC', 'SC', 'SC', 'Escribir Descripcion y precio', 1.00, 1, 1, 0, '', 7, 10, 32, 832, '', '2022-03-31', 'Administrador');
/*!40000 ALTER TABLE `articulo` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.BuscarArticulo
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarArticulo`(
	IN `busqueda` VARCHAR(60)








)
SELECT *
FROM articulo a
inner join proveedor ct on a.Proveedor_ID = ct.ID
inner join marca m on a.Marca_ID = m.ID
WHERE a.descripcion like concat('%',busqueda, '%') 
or a.codigo like concat('%',busqueda, '%')
or a.codigoProveedor like concat('%',busqueda, '%')
or a.numeroPieza like concat('%',busqueda, '%')
or ct.Alias like concat('%',busqueda, '%')
or a.observaciones like concat('%',busqueda, '%')//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.BuscarArticuloEspecifica
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarArticuloEspecifica`(
	IN `busqueda` varchar(40)










)
SELECT *, MATCH (a.descripcion,a.codigo,a.codigoProveedor,a.numeroPieza,a.observaciones) AGAINST (busqueda) as score
FROM articulo a
inner join proveedor ct on a.Proveedor_ID = ct.ID
inner join marca m on a.Marca_ID = m.ID
WHERE 
MATCH (a.descripcion,a.codigo,a.codigoProveedor,a.numeroPieza,a.observaciones) AGAINST (busqueda)
order by score desc//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.BuscarArticuloID
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarArticuloID`(
	IN `busqueda` varchar(40)






)
SELECT *
FROM articulo a
inner join proveedor ct on a.Proveedor_ID = ct.ID
inner join marca m on a.Marca_ID = m.ID
WHERE a.ID = busqueda//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.BuscarClientePorFactura
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarClientePorFactura`(
	IN `p1` int
)
select c.ID,c.numero,c.Alias,c.razonSocial,c.telefono1,c.telefono2,d.CalleNumero,l.nombre
from factura f inner join cliente c on f.cliente_ID = c.id
inner join direccion d on c.Direccion_ID = d.ID
inner join localidad l on d.Localidad_ID = l.id
where f.numero = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.BuscarModelo
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarModelo`(
	IN `busqueda` varchar(100)
)
select m.ID,m.descripcion,m.`año`,m.Marca_ID,ma.descripcion
from modelo m 
inner join marcavehiculo ma on m.Marca_ID = ma.ID 
where ma.descripcion like concat('%',busqueda, '%')
or m.descripcion like concat('%',busqueda, '%')//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.BuscarModeloID
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscarModeloID`(busqueda int)
select m.ID,m.descripcion,m.`año`,m.Marca_ID,ma.descripcion
from modelo m 
inner join marcavehiculo ma on m.Marca_ID = ma.ID 
where m.ID= busqueda//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.CambioPreciosImporte
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CambioPreciosImporte`(
	IN `p0` INT,
	IN `p1` DECIMAL(10,3)
,
	IN `p2` INT



)
begin
 IF     
 			  p0 = 0 and p2 = 0 THEN  
				update articulo a
				set
				a.precio = a.precio + p1
				;
 	 ELSEIF p0 = 0 and p2 > 0 THEN 
	  				update articulo a
				set
				a.precio = a.precio + p1
				where a.Proveedor_ID = p2
				;
	 ELSEIF p0 > 0 and p2 = 0 THEN 
	 				update articulo a
				set
				a.precio = a.precio + p1
				where a.Rubro_ID = p0
				;
    ELSEIF p0 > 0 and p2 > 0 THEN 
	 				update articulo a
				set
				a.precio = a.precio + p1
				where a.Rubro_ID = p0 and a.Proveedor_ID = p2
				;
    END IF;

end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.CambioPreciosPorcentaje
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CambioPreciosPorcentaje`(
	IN `p0` INT,
	IN `p1` DECIMAL(10,3)
,
	IN `p2` INT


)
begin
 IF     
 			  p0 = 0 and p2 = 0 THEN  
				update articulo a
				set
				a.precio = a.precio * p1
				;
 	 ELSEIF p0 = 0 and p2 > 0 THEN 
	  				update articulo a
				set
				a.precio = a.precio * p1
				where a.Proveedor_ID = p2
				;
	 ELSEIF p0 > 0 and p2 = 0 THEN 
	 				update articulo a
				set
				a.precio = a.precio * p1
				where a.Rubro_ID = p0
				;
    ELSEIF p0 > 0 and p2 > 0 THEN 
	 				update articulo a
				set
				a.precio = a.precio * p1
				where a.Rubro_ID = p0 and a.Proveedor_ID = p2
				;
    END IF;

end//
DELIMITER ;

-- Volcando estructura para tabla repuestos.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(10) NOT NULL,
  `Alias` varchar(45) NOT NULL,
  `razonSocial` varchar(45) DEFAULT NULL,
  `cuit` int(11) DEFAULT NULL,
  `telefono1` varchar(45) DEFAULT NULL,
  `telefono2` varchar(45) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  `Direccion_ID` int(11) NOT NULL,
  `Dir_Ent_ID` int(11) NOT NULL,
  `TipoDoc_ID` int(11) NOT NULL,
  `Iva_ID` int(11) NOT NULL,
  `Bonificacion` decimal(4,2) NOT NULL,
  `Recargo` decimal(4,2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UNICO` (`numero`),
  KEY `fk_Cliente_Direccion1_idx` (`Direccion_ID`),
  KEY `FK_cliente_direccion` (`Dir_Ent_ID`),
  KEY `FK_cliente_iva` (`Iva_ID`),
  KEY `FK_cliente_tipodocumento` (`TipoDoc_ID`),
  CONSTRAINT `FK_cliente_direccion` FOREIGN KEY (`Dir_Ent_ID`) REFERENCES `direccion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_cliente_iva` FOREIGN KEY (`Iva_ID`) REFERENCES `iva` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_cliente_tipodocumento` FOREIGN KEY (`TipoDoc_ID`) REFERENCES `tipodocumento` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cliente_Direccion1` FOREIGN KEY (`Direccion_ID`) REFERENCES `direccion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.cliente: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
REPLACE INTO `cliente` (`ID`, `numero`, `Alias`, `razonSocial`, `cuit`, `telefono1`, `telefono2`, `email`, `Direccion_ID`, `Dir_Ent_ID`, `TipoDoc_ID`, `Iva_ID`, `Bonificacion`, `Recargo`) VALUES
	(5, 1, 'CONSUMIDOR FINAL', 'CONSUMIDOR FINAL', 1, ' ', ' ', NULL, 137, 138, 3, 4, 0.00, 0.00),
	(6, 2, '.EXE SOLUCIONES INFORMATICAS', '.EXE SOLUCIONES INFORMATICAS', 1, '11-4170-9324', '(011) 4355-7120', NULL, 139, 140, 3, 4, 0.00, 0.00);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.compatibilidad
CREATE TABLE IF NOT EXISTS `compatibilidad` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Articulo_ID` int(11) NOT NULL,
  `Modelo_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK__articulo` (`Articulo_ID`),
  KEY `FK__modelo` (`Modelo_ID`),
  CONSTRAINT `FK__articulo` FOREIGN KEY (`Articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK__modelo` FOREIGN KEY (`Modelo_ID`) REFERENCES `modelo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.compatibilidad: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `compatibilidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `compatibilidad` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.CrearCliente
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CrearCliente`(
	IN `p1` int,
	IN `p2` varchar(100),
	IN `p3` varchar(100),
	IN `p4` int,
	IN `p5` varchar(100),
	IN `p6` varchar(100),
	IN `p7` int,
	IN `p8` int,
	IN `p9` int,
	IN `p10` int

,
	IN `p11` DECIMAL(4,2),
	IN `p12` DECIMAL(4,2)
)
BEGIN
START TRANSACTION;
insert into cliente
(numero,alias,razonSocial,cuit,telefono1,telefono2,Direccion_ID,Dir_Ent_ID,TipoDoc_ID,IVA_iD,Bonificacion,Recargo)
values
(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.CrearProveedor
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `CrearProveedor`(
	IN `p1` int,
	IN `p2` varchar(100),
	IN `p3` varchar(100),
	IN `p4` int,
	IN `p5` varchar(100),
	IN `p6` varchar(100),
	IN `p7` int,
	IN `p8` int,
	IN `p9` int,
	IN `p10` int

)
BEGIN
START TRANSACTION;
insert into proveedor
(numero,alias,razonSocial,cuit,telefono1,telefono2,Direccion_ID,Dir_Ent_ID,TipoDoc_ID,IVA_iD)
values
(p1,p2,p3,p4,p5,p6,p7,p8,p9,p10);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.detallefactura
CREATE TABLE IF NOT EXISTS `detallefactura` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(50) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(15,2) NOT NULL,
  `factura_ID` int(11) NOT NULL,
  `articulo_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK__factura` (`factura_ID`),
  KEY `FK_detalleFactura_articulo` (`articulo_ID`),
  CONSTRAINT `FK__factura` FOREIGN KEY (`factura_ID`) REFERENCES `factura` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_detalleFactura_articulo` FOREIGN KEY (`articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.detallefactura: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `detallefactura` DISABLE KEYS */;
/*!40000 ALTER TABLE `detallefactura` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.detallepresupuesto
CREATE TABLE IF NOT EXISTS `detallepresupuesto` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(50) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(15,2) NOT NULL,
  `presupuesto_ID` int(11) NOT NULL,
  `articulo_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK__factura` (`presupuesto_ID`),
  KEY `FK_detalleFactura_articulo` (`articulo_ID`),
  CONSTRAINT `detallepresupuesto_ibfk_1` FOREIGN KEY (`presupuesto_ID`) REFERENCES `presupuesto` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `detallepresupuesto_ibfk_2` FOREIGN KEY (`articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Volcando datos para la tabla repuestos.detallepresupuesto: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `detallepresupuesto` DISABLE KEYS */;
/*!40000 ALTER TABLE `detallepresupuesto` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.direccion
CREATE TABLE IF NOT EXISTS `direccion` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CalleNumero` varchar(45) NOT NULL,
  `Localidad_ID` int(11) NOT NULL,
  `CodigoPostal` varchar(10) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Direccion_Localidad1_idx` (`Localidad_ID`),
  CONSTRAINT `fk_Direccion_Localidad1` FOREIGN KEY (`Localidad_ID`) REFERENCES `localidad` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.direccion: ~20 rows (aproximadamente)
/*!40000 ALTER TABLE `direccion` DISABLE KEYS */;
REPLACE INTO `direccion` (`ID`, `CalleNumero`, `Localidad_ID`, `CodigoPostal`) VALUES
	(121, 'Felipe Amoedo 3002', 16, '1887'),
	(122, 'Felipe Amoedo 3002', 16, '1887'),
	(123, ' ', 30, '  '),
	(124, ' ', 30, '  '),
	(125, ' ', 3, ' '),
	(126, ' ', 3, ' '),
	(127, ' ', 3, ' '),
	(128, ' ', 3, ' '),
	(129, 'Tomas Edison 1800', 3, '1888'),
	(130, 'Tomas Edison 1800', 3, '1888'),
	(131, 'Barzi 719', 3, '1888'),
	(132, 'Barzi 719', 3, '1888'),
	(133, 'Felipe Amoedo 3002', 16, '1878'),
	(134, 'Felipe Amoedo 3002', 16, '1878'),
	(135, 'Manuel R. Trelles 2419', 30, '1416'),
	(136, 'Manuel R. Trelles 2419', 30, '1416'),
	(137, 'Gral Perón 2036', 3, '1888'),
	(138, 'Gral Perón 2036', 3, '1888'),
	(139, 'Barzi y Serrano', 3, '1888'),
	(140, 'Barzi y Serrano', 3, '1888');
/*!40000 ALTER TABLE `direccion` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.EliminarLocalidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarLocalidad`(
	IN `p0` INT
)
BEGIN
delete from Localidad 
where id = p0
;END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.eliminarUsuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarUsuario`(
	IN `p0` int
)
BEGIN
delete from usuario
where ID = p0;
END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.equivalencia
CREATE TABLE IF NOT EXISTS `equivalencia` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Articulo_ID` int(11) NOT NULL,
  `Equivalencia_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Índice 4` (`Articulo_ID`,`Equivalencia_ID`),
  KEY `FK_Equivalencia_articulo_2` (`Equivalencia_ID`),
  KEY `Articulo_ID_Equivalencia_ID` (`Articulo_ID`),
  CONSTRAINT `FK_Equivalencia_articulo` FOREIGN KEY (`Articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Equivalencia_articulo_2` FOREIGN KEY (`Equivalencia_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.equivalencia: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `equivalencia` DISABLE KEYS */;
/*!40000 ALTER TABLE `equivalencia` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.factura
CREATE TABLE IF NOT EXISTS `factura` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `numero` int(10) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `subTotal` decimal(15,2) NOT NULL,
  `financiacion` decimal(15,2) NOT NULL,
  `total` decimal(15,2) NOT NULL,
  `cliente_ID` int(10) NOT NULL,
  `cliente` varchar(60) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `localidad` varchar(45) NOT NULL,
  `cp` varchar(10) NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `medioPagoID` int(11) NOT NULL,
  `activa` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `FK__cliente` (`cliente_ID`),
  KEY `FK_factura_mediodepago` (`medioPagoID`),
  CONSTRAINT `FK__cliente` FOREIGN KEY (`cliente_ID`) REFERENCES `cliente` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_factura_mediodepago` FOREIGN KEY (`medioPagoID`) REFERENCES `mediodepago` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.factura: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.guardarDireccion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `guardarDireccion`(
	IN `p1` varchar(100),
	IN `p2` int
,
	IN `p3` VARCHAR(10)
)
BEGIN
insert into direccion (CalleNumero,Localidad_ID,codigoPostal)
values (p1,p2,p3)
;END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.HeidiSQL_temproutine_1
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `HeidiSQL_temproutine_1`(
	IN `p1` int,
	IN `p2` INT,
	IN `p3` DECIMAL(7,4),
	IN `p4` int  ,
	IN `p5` int

,
	IN `p6` INT
)
update matriz m
SET
cantidadSalidas = p2,
pesoActual =  p3,
Cliente_ID = p4,
EstadoMatriz_ID =  p5,
kgAcumulados =  p6//
DELIMITER ;

-- Volcando estructura para tabla repuestos.iva
CREATE TABLE IF NOT EXISTS `iva` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.iva: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `iva` DISABLE KEYS */;
REPLACE INTO `iva` (`ID`, `descripcion`) VALUES
	(1, 'Responsable Inscripto'),
	(2, 'Monotributo'),
	(3, 'Exento'),
	(4, 'Consumidor Final'),
	(5, 'Exportación');
/*!40000 ALTER TABLE `iva` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.lado
CREATE TABLE IF NOT EXISTS `lado` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `descripcion` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.lado: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `lado` DISABLE KEYS */;
REPLACE INTO `lado` (`ID`, `descripcion`, `precio`) VALUES
	(30, 'Derecho (Acomp.)', 0.00),
	(31, 'Izquierdo (Cond,)', 0.00),
	(32, 'Pieza única', 0.00),
	(33, 'Izq - Der (Cond, - Acomp.)', 0.00);
/*!40000 ALTER TABLE `lado` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.licencia
CREATE TABLE IF NOT EXISTS `licencia` (
  `Expira` date NOT NULL,
  `Valida` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.licencia: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `licencia` DISABLE KEYS */;
REPLACE INTO `licencia` (`Expira`, `Valida`) VALUES
	('2022-05-31', 1);
/*!40000 ALTER TABLE `licencia` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.limpiarComprobantes
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `limpiarComprobantes`()
BEGIN
START TRANSACTION;

delete from detallefactura;
delete from detallepresupuesto;
delete from factura;
delete from presupuesto;

COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.LimpiarDatos
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `LimpiarDatos`()
begin
start transaction;
delete from equivalencia;
delete from compatibilidad;
delete from movimientostock;
delete from articulo;
delete from proveedor;
delete from marca;
delete from rubro;
delete from mediodepago;
delete from modelo;
delete from marcavehiculo;
call limpiarComprobantes();
delete from cliente;
commit;
end//
DELIMITER ;

-- Volcando estructura para tabla repuestos.localidad
CREATE TABLE IF NOT EXISTS `localidad` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `Provincia_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Localidad_Provincia_idx` (`Provincia_ID`),
  CONSTRAINT `fk_Localidad_Provincia` FOREIGN KEY (`Provincia_ID`) REFERENCES `provincia` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.localidad: ~29 rows (aproximadamente)
/*!40000 ALTER TABLE `localidad` DISABLE KEYS */;
REPLACE INTO `localidad` (`ID`, `nombre`, `Provincia_ID`) VALUES
	(1, '9 de Abril', 1),
	(2, 'Munro', 1),
	(3, 'Florencio Varela', 1),
	(8, 'La Plata', 1),
	(9, 'Lomas del  Mirador', 1),
	(10, 'Temperley', 1),
	(11, 'Malvinas Argentinas', 6),
	(12, 'Ringuelet', 1),
	(13, 'Lomas de Zamora', 1),
	(14, 'Glew', 1),
	(15, 'Wilde', 1),
	(16, 'Quilmes', 1),
	(18, 'Carlos Paz', 6),
	(19, 'Santa Rosa Calamuchita', 6),
	(20, 'San Justo', 1),
	(21, 'Rufino', 21),
	(23, 'Jose C. Paz', 1),
	(24, 'Tapiales', 1),
	(25, 'Caseros', 1),
	(26, 'San Fernando', 1),
	(27, 'Lobos', 1),
	(28, 'Gral. San Martin', 21),
	(30, 'CABA', 2),
	(31, 'San Miguel', 1),
	(32, 'San Martin', 1),
	(33, 'Moron', 1),
	(34, 'LANUS OESTE', 1),
	(35, 'Luis Guillon', 1),
	(36, 'Chascomus', 1);
/*!40000 ALTER TABLE `localidad` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.marca
CREATE TABLE IF NOT EXISTS `marca` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.marca: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
REPLACE INTO `marca` (`ID`, `descripcion`) VALUES
	(7, 'Corven'),
	(8, 'Luk'),
	(9, 'Valeo'),
	(10, 'Skf'),
	(11, 'Nakata');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.marcavehiculo
CREATE TABLE IF NOT EXISTS `marcavehiculo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.marcavehiculo: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `marcavehiculo` DISABLE KEYS */;
REPLACE INTO `marcavehiculo` (`ID`, `descripcion`) VALUES
	(81, 'Ford'),
	(82, 'Volkswagen'),
	(83, 'Chevrolet');
/*!40000 ALTER TABLE `marcavehiculo` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.mediodepago
CREATE TABLE IF NOT EXISTS `mediodepago` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `recargo` decimal(15,3) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero` (`numero`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.mediodepago: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `mediodepago` DISABLE KEYS */;
REPLACE INTO `mediodepago` (`ID`, `numero`, `descripcion`, `recargo`) VALUES
	(8, 1, 'Efectivo', 0.000),
	(9, 2, 'QR', 3.000),
	(10, 3, 'Tarjeta (3 cuotas)', 3.000),
	(11, 4, 'Tarjeta (6 cuotas)', 6.000),
	(13, 5, 'Tarjeta (12 cuotas)', 10.000);
/*!40000 ALTER TABLE `mediodepago` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.modCli1
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `modCli1`(
	IN `p0` int(11),
	IN `p1` int (10),
	IN `p2` varchar (45),
	IN `p3` varchar (45),
	IN `p4` int(11),
	IN `p5` varchar (45),
	IN `p6` varchar (45),
	IN `p7` int (11),
	IN `p8` int(11)
,
	IN `p9` DECIMAL(15,3),
	IN `p10` DECIMAL(15,3)
)
BEGIN
UPDATE cliente c
SET  
numero = p1,
Alias = p2,
razonSocial = p3,
cuit = p4,
telefono1 =  p5,
telefono2 =  p6,
tipoDoc_ID = p7,
Iva_ID = p8,
bonificacion = p9,
recargo = p10
where c.ID = p0;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModCli2
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModCli2`(
	IN `p0` int(11),
	IN `p9` varchar(45),
	IN `p10` int(11),
	IN `p11` varchar(10)

)
BEGIN
UPDATE direccion d
inner join cliente c
SET  
calleNumero =  p9,
Localidad_ID = p10,
codigoPostal =  p11
where  c.ID = p0 and  d.ID =  c.Direccion_ID
;

END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModCli3
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModCli3`(
	IN `p0` int(11),
	IN `p12` varchar(45),
	IN `p13` int(11),
	IN `p14` varchar(10)


)
BEGIN
UPDATE direccion d
inner join cliente c
SET  
calleNumero =  p12,
Localidad_ID = p13,
codigoPostal =  p14
where  c.ID = p0 and  d.ID =  c.Dir_Ent_ID
;

END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.modelo
CREATE TABLE IF NOT EXISTS `modelo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) NOT NULL,
  `año` int(11) NOT NULL,
  `Marca_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `descripcion` (`descripcion`,`año`),
  KEY `FK__marcavehiculo` (`Marca_ID`),
  CONSTRAINT `FK__marcavehiculo` FOREIGN KEY (`Marca_ID`) REFERENCES `marcavehiculo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=970 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.modelo: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `modelo` DISABLE KEYS */;
REPLACE INTO `modelo` (`ID`, `descripcion`, `año`, `Marca_ID`) VALUES
	(961, 'Cruze', 2019, 83),
	(962, 'Cruze', 2020, 83),
	(963, 'Cruze', 2021, 83),
	(964, 'Fiesta Kinetic', 2015, 81),
	(965, 'Fiesta Kinetic', 2017, 81),
	(966, 'Fiesta Kinetic', 2016, 81),
	(967, 'Gol Trend', 2014, 82),
	(968, 'Gol Trend', 2015, 82),
	(969, 'Gol Trend', 2016, 82);
/*!40000 ALTER TABLE `modelo` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.ModificarArticulo
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarArticulo`(
	IN `p1` VARCHAR(45),
	IN `p0` INT,
	IN `p2` VARCHAR(45),
	IN `p3` VARCHAR(45),
	IN `p4` VARCHAR(60),
	IN `p5` DECIMAL(15,2),
	IN `p6` INT,
	IN `p7` INT,
	IN `p8` INT,
	IN `p9` VARCHAR(150),
	IN `p10` INT,
	IN `p11` INT,
	IN `p12` INT,
	IN `p13` INT,
	IN `p14` VARCHAR(50)


,
	IN `p15` DATE,
	IN `p16` VARCHAR(50)


)
begin
start transaction;
UPDATE articulo a SET
codigo = p1,
codigoProveedor = p2,
numeroPieza = p3,
descripcion = p4,
precio = p5,
 stockMin = p6,
 stockMax = p7,
 StockActual = p8,
 observaciones = p9,
 Marca_ID = p10,
 Rubro_ID = p11,
 Lado_ID = p12,
 Proveedor_ID = p13,
 Ubicacion = p14,
 creacion = p15,
 usuario  = p16
 where a.ID = p0;
 
delete from equivalencia 
where Articulo_ID = p0;

delete from compatibilidad 
where Articulo_ID = p0;
 
 commit;
 end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarCliente
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarCliente`(
	IN `p0` int(11),
	IN `p1` int (10),
	IN `p2` varchar (45),
	IN `p3` varchar (45),
	IN `p4` int(11),
	IN `p5` varchar (45),
	IN `p6` varchar (45),
	IN `p7` int (11),
	IN `p8` int(11),
	IN `p9` varchar(45),
	IN `p10` int(11),
	IN `p11` varchar(10),
	IN `p12` varchar(45),
	IN `p13` int(11),
	IN `p14` varchar(10)



,
	IN `p15` DECIMAL(15,3),
	IN `p16` DECIMAL(15,3)
)
BEGIN
START TRANSACTION;
call modCli1(p0,p1,p2,p3,p4,p5,p6,p7,p8,p15,p16);
call modCli2(p0,p9,p10,p11);
call modCli3(p0,p12,p13,p14);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.modificarEstado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `modificarEstado`(
	IN `p1` varchar(40),
	IN `p2` int
)
BEGIN
UPDATE pedido p
SET  
Estado_ID  = p2
where p.numero = p1
;END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarLocalidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarLocalidad`(p0 int,p1 varchar(60), p2 int)
update Localidad l
set 
nombre = p1,
provincia_ID = p2
where l.ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarProveedor
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarProveedor`(
	IN `p0` int(11),
	IN `p1` int (10),
	IN `p2` varchar (45),
	IN `p3` varchar (45),
	IN `p4` int(11),
	IN `p5` varchar (45),
	IN `p6` varchar (45),
	IN `p7` int (11),
	IN `p8` int(11),
	IN `p9` varchar(45),
	IN `p10` int(11),
	IN `p11` varchar(10),
	IN `p12` varchar(45),
	IN `p13` int(11),
	IN `p14` varchar(10)




)
BEGIN
START TRANSACTION;
call modPro1(p0,p1,p2,p3,p4,p5,p6,p7,p8);
call modPro2(p0,p9,p10,p11);
call modPro3(p0,p12,p13,p14);
COMMIT;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarPuesto
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarPuesto`(p0 int,p1 varchar(60), p2 varchar(60), p3 varchar(60))
update puesto p
set
descripcion = p1,
maquinista= p2,
encargado = p3
where p.ID = p0//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarUsuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarUsuario`(
	IN `p0` int ,
	IN `p1` varchar(20),
	IN `p2` varchar(20),
	IN `p3` INT,
	IN `p4` INT,
	IN `p5` INT,
	IN `p6` INT,
	IN `p7` INT,
	IN `p8` INT


,
	IN `p9` INT

,
	IN `p10` INT,
	IN `p11` INT,
	IN `p12` INT,
	IN `p13` INT,
	IN `p14` INT,
	IN `p15` INT,
	IN `p16` INT,
	IN `p17` INT,
	IN `p18` INT,
	IN `p19` INT,
	IN `p20` INT
)
BEGIN
update Usuario u
SET
usuario = p1,
clave = p2,
verCliente = p3 ,
VerArchivo = p4,
verArticulos = p5,
u.verPedidos = p6,
verMatrices = p7,
verUsuarios = p8,
verReportes = p9,

altaArticulos = p10,
bajaArticulos = p11,
modificaArticulos = p12,
altaClientes = p13,
modificaClientes = p14,
altaPedidos = p15,
modificaPedidos = p16,
detallePedidos = p17,
altaMatrices = p18,
modificaMatrices = p19,
nitruradoMatrices = p20
where u.ID = p0;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.modPro1
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `modPro1`(
	IN `p0` int(11),
	IN `p1` int (10),
	IN `p2` varchar (45),
	IN `p3` varchar (45),
	IN `p4` int(11),
	IN `p5` varchar (45),
	IN `p6` varchar (45),
	IN `p7` int (11),
	IN `p8` int(11)
)
BEGIN
UPDATE proveedor c
SET  
numero = p1,
Alias = p2,
razonSocial = p3,
cuit = p4,
telefono1 =  p5,
telefono2 =  p6,
tipoDoc_ID = p7,
Iva_ID = p8
where c.ID = p0;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModPro2
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModPro2`(
	IN `p0` int(11),
	IN `p9` varchar(45),
	IN `p10` int(11),
	IN `p11` varchar(10)

)
BEGIN
UPDATE direccion d
inner join proveedor c
SET  
calleNumero =  p9,
Localidad_ID = p10,
codigoPostal =  p11
where  c.ID = p0 and  d.ID =  c.Direccion_ID
;

END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModPro3
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModPro3`(
	IN `p0` int(11),
	IN `p12` varchar(45),
	IN `p13` int(11),
	IN `p14` varchar(10)


)
BEGIN
UPDATE direccion d
inner join proveedor c
SET  
calleNumero =  p12,
Localidad_ID = p13,
codigoPostal =  p14
where  c.ID = p0 and  d.ID =  c.Dir_Ent_ID
;

END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.movimientostock
CREATE TABLE IF NOT EXISTS `movimientostock` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `articuloID` int(11) NOT NULL,
  `tipoMovimientoID` int(11) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `observaciones` varchar(200) NOT NULL,
  `cantidad` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_movimientostock_articulo` (`articuloID`),
  KEY `FK_movimientostock_tipomovimiento` (`tipoMovimientoID`),
  CONSTRAINT `FK_movimientostock_articulo` FOREIGN KEY (`articuloID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_movimientostock_tipomovimiento` FOREIGN KEY (`tipoMovimientoID`) REFERENCES `tipomovimiento` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.movimientostock: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `movimientostock` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimientostock` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.obtenerCliente
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerCliente`(
	IN `p1` VARCHAR(100)




)
begin
select c.ID as IdCliente, c.numero as Numero , c.Alias ,c.razonSocial, c.cuit
,c.telefono1,c.telefono2
,d1.ID as idDireccionFiscal, d1.CalleNumero as direccion, l1.nombre as Localidad, p1.nombre as provincia, d1.CodigoPostal
,d2.ID as idDireccionEntrega, d2.CalleNumero as direccion, l2.nombre as Localidad,p2.nombre as provincia, d2.CodigoPostal
,i.descripcion as IVA, td.descripcion as tipoDocumento, c.Bonificacion , c.Recargo
from cliente c
inner join iva i on c.Iva_ID = i.id
inner join tipodocumento td on c.TipoDoc_ID = td.ID
inner join direccion d1 on c.Direccion_ID = d1.id
inner join localidad l1 on d1.Localidad_ID = l1.ID
inner join provincia p1 on l1.Provincia_ID = p1.id
inner join direccion d2 on c.Dir_Ent_ID = d2.ID
inner join localidad l2 on d2.Localidad_ID = l2.ID
inner join provincia p2 on l2.Provincia_ID = p2.id
where c.ID = p1 
or c.Alias like concat('%',p1,'%') 
or c.razonSocial like concat('%',p1,'%') 
or c.cuit like concat('%',p1,'%')

;end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.obtenerClienteporNumero
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerClienteporNumero`(
	IN `p1` VARCHAR(100)





)
begin
select c.ID as IdCliente, c.numero as Numero , c.Alias ,c.razonSocial, c.cuit
,c.telefono1,c.telefono2
,d1.ID as idDireccionFiscal, d1.CalleNumero as direccion, l1.nombre as Localidad, p1.nombre as provincia, d1.CodigoPostal
,d2.ID as idDireccionEntrega, d2.CalleNumero as direccion, l2.nombre as Localidad,p2.nombre as provincia, d2.CodigoPostal
,i.descripcion as IVA, td.descripcion as tipoDocumento, c.Bonificacion , c.Recargo
from cliente c
inner join iva i on c.Iva_ID = i.id
inner join tipodocumento td on c.TipoDoc_ID = td.ID
inner join direccion d1 on c.Direccion_ID = d1.id
inner join localidad l1 on d1.Localidad_ID = l1.ID
inner join provincia p1 on l1.Provincia_ID = p1.id
inner join direccion d2 on c.Dir_Ent_ID = d2.ID
inner join localidad l2 on d2.Localidad_ID = l2.ID
inner join provincia p2 on l2.Provincia_ID = p2.id
where c.numero = p1 


;end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ObtenerDetalleFactura
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerDetalleFactura`(p1 int)
select * from detallefactura d inner join factura f on d.factura_ID = f.ID where f.numero = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.obtenerProveedor
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProveedor`(
	IN `p1` VARCHAR(100)



)
begin
select c.ID as IdCliente, c.numero as Numero , c.Alias ,c.razonSocial, c.cuit
,c.telefono1,c.telefono2
,d1.ID as idDireccionFiscal, d1.CalleNumero as direccion, l1.nombre as Localidad, p1.nombre as provincia, d1.CodigoPostal
,d2.ID as idDireccionEntrega, d2.CalleNumero as direccion, l2.nombre as Localidad,p2.nombre as provincia, d2.CodigoPostal
,i.descripcion as IVA, td.descripcion as tipoDocumento
from proveedor c
inner join iva i on c.Iva_ID = i.id
inner join tipodocumento td on c.TipoDoc_ID = td.ID
inner join direccion d1 on c.Direccion_ID = d1.id
inner join localidad l1 on d1.Localidad_ID = l1.ID
inner join provincia p1 on l1.Provincia_ID = p1.id
inner join direccion d2 on c.Dir_Ent_ID = d2.ID
inner join localidad l2 on d2.Localidad_ID = l2.ID
inner join provincia p2 on l2.Provincia_ID = p2.id
where c.ID = p1 
or c.Alias like concat('%',p1,'%') 
or c.razonSocial like concat('%',p1,'%') 
or c.cuit like concat('%',p1,'%')

;end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.obtenerRecargoFinanciero
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerRecargoFinanciero`(
	IN `p1` int
)
select recargo
from mediodepago mp
where id = p1
limit 1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.obtenerUsuario
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerUsuario`(
	IN `parametro1` varchar(40)

)
(
SELECT *
FROM usuario u 
where u.usuario = parametro1 limit 1)//
DELIMITER ;

-- Volcando estructura para tabla repuestos.presupuesto
CREATE TABLE IF NOT EXISTS `presupuesto` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `numero` int(10) NOT NULL,
  `fechaHora` datetime NOT NULL,
  `subTotal` decimal(15,2) NOT NULL,
  `financiacion` decimal(15,2) NOT NULL,
  `total` decimal(15,2) NOT NULL,
  `cliente_ID` int(10) NOT NULL,
  `cliente` varchar(60) NOT NULL,
  `direccion` varchar(45) NOT NULL,
  `localidad` varchar(45) NOT NULL,
  `cp` varchar(10) NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `medioPagoID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK__cliente` (`cliente_ID`),
  KEY `FK_factura_mediodepago` (`medioPagoID`),
  CONSTRAINT `presupuesto_ibfk_1` FOREIGN KEY (`cliente_ID`) REFERENCES `cliente` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `presupuesto_ibfk_2` FOREIGN KEY (`medioPagoID`) REFERENCES `mediodepago` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Volcando datos para la tabla repuestos.presupuesto: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `presupuesto` DISABLE KEYS */;
/*!40000 ALTER TABLE `presupuesto` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.proveedor
CREATE TABLE IF NOT EXISTS `proveedor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(10) NOT NULL,
  `Alias` varchar(45) NOT NULL,
  `razonSocial` varchar(45) DEFAULT NULL,
  `cuit` int(11) DEFAULT NULL,
  `telefono1` varchar(45) DEFAULT NULL,
  `telefono2` varchar(45) DEFAULT NULL,
  `email` varchar(70) DEFAULT NULL,
  `Direccion_ID` int(11) NOT NULL,
  `Dir_Ent_ID` int(11) NOT NULL,
  `TipoDoc_ID` int(11) NOT NULL,
  `Iva_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `UNICO` (`numero`),
  KEY `fk_Cliente_Direccion1_idx` (`Direccion_ID`),
  KEY `FK_cliente_direccion` (`Dir_Ent_ID`),
  KEY `FK_cliente_iva` (`Iva_ID`),
  KEY `FK_cliente_tipodocumento` (`TipoDoc_ID`),
  CONSTRAINT `proveedor_ibfk_1` FOREIGN KEY (`Dir_Ent_ID`) REFERENCES `direccion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `proveedor_ibfk_2` FOREIGN KEY (`Iva_ID`) REFERENCES `iva` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `proveedor_ibfk_3` FOREIGN KEY (`TipoDoc_ID`) REFERENCES `tipodocumento` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `proveedor_ibfk_4` FOREIGN KEY (`Direccion_ID`) REFERENCES `direccion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=834 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Volcando datos para la tabla repuestos.proveedor: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
REPLACE INTO `proveedor` (`ID`, `numero`, `Alias`, `razonSocial`, `cuit`, `telefono1`, `telefono2`, `email`, `Direccion_ID`, `Dir_Ent_ID`, `TipoDoc_ID`, `Iva_ID`) VALUES
	(832, 1, 'EL POSITIVO', 'EL POSITIVO', 1, '5274-7445 | 5274-7446', '5274-7447 | 5274-7448 ', NULL, 133, 134, 3, 1),
	(833, 2, 'RODAMET', 'RODAMET', 2, '4016-0000 | 4583-8748', ' 4584-6646 /6127 /7925', NULL, 135, 136, 1, 1);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.provincia
CREATE TABLE IF NOT EXISTS `provincia` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.provincia: ~24 rows (aproximadamente)
/*!40000 ALTER TABLE `provincia` DISABLE KEYS */;
REPLACE INTO `provincia` (`ID`, `nombre`) VALUES
	(1, 'Buenos Aires'),
	(2, 'Ciudad Aut. Bs. As'),
	(3, 'Catamarca'),
	(4, 'Chaco'),
	(5, 'Chubut'),
	(6, 'Córdoba'),
	(7, 'Corrientes'),
	(8, 'Entre Ríos'),
	(9, 'Formosa'),
	(10, 'Jujuy'),
	(11, 'La Pampa'),
	(12, 'La Rioja'),
	(13, 'Mendoza'),
	(14, 'Misiones'),
	(15, 'Neuquén'),
	(16, 'Río Negro'),
	(17, 'Salta'),
	(18, 'San Juan'),
	(19, 'San Luis'),
	(20, 'Santa Cruz'),
	(21, 'Santa Fe'),
	(22, 'Santiago del Estero'),
	(23, 'Tierra del Fuego, Antártida e Islas del Atlán'),
	(24, 'Tucumán');
/*!40000 ALTER TABLE `provincia` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.rubro
CREATE TABLE IF NOT EXISTS `rubro` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.rubro: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `rubro` DISABLE KEYS */;
REPLACE INTO `rubro` (`ID`, `descripcion`) VALUES
	(7, 'Tren Delantero'),
	(8, 'Tren Trasero'),
	(9, 'Frenos'),
	(10, 'Embrague'),
	(11, 'Mecanica Gral.');
/*!40000 ALTER TABLE `rubro` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.tipodocumento
CREATE TABLE IF NOT EXISTS `tipodocumento` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.tipodocumento: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `tipodocumento` DISABLE KEYS */;
REPLACE INTO `tipodocumento` (`ID`, `descripcion`) VALUES
	(1, 'Cuit'),
	(2, 'Cuil'),
	(3, 'DNI'),
	(4, 'Pasaporte');
/*!40000 ALTER TABLE `tipodocumento` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.tipomovimiento
CREATE TABLE IF NOT EXISTS `tipomovimiento` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(60) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.tipomovimiento: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `tipomovimiento` DISABLE KEYS */;
REPLACE INTO `tipomovimiento` (`ID`, `descripcion`) VALUES
	(1, 'Entrada'),
	(2, 'Salida');
/*!40000 ALTER TABLE `tipomovimiento` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.UltimasDirecciones
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `UltimasDirecciones`()
BEGIN
select *
from direccion d
group by d.ID desc limit 2
;END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.unidad
CREATE TABLE IF NOT EXISTS `unidad` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.unidad: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `unidad` DISABLE KEYS */;
REPLACE INTO `unidad` (`ID`, `Descripcion`) VALUES
	(1, 'Kg'),
	(2, 'Tiras');
/*!40000 ALTER TABLE `unidad` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(40) NOT NULL,
  `clave` varchar(40) NOT NULL,
  `verCliente` int(1) NOT NULL,
  `verArchivo` int(1) NOT NULL,
  `verArticulos` int(1) NOT NULL,
  `verPedidos` int(1) NOT NULL,
  `verMatrices` int(1) NOT NULL,
  `verUsuarios` int(1) NOT NULL,
  `verReportes` int(1) NOT NULL,
  `altaArticulos` int(1) NOT NULL,
  `bajaArticulos` int(1) NOT NULL,
  `modificaArticulos` int(1) NOT NULL,
  `altaClientes` int(1) NOT NULL,
  `modificaClientes` int(1) NOT NULL,
  `altaPedidos` int(1) NOT NULL,
  `modificaPedidos` int(1) NOT NULL,
  `detallePedidos` int(1) NOT NULL,
  `altaMatrices` int(1) NOT NULL,
  `modificaMatrices` int(1) NOT NULL,
  `nitruradoMatrices` int(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.usuario: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
REPLACE INTO `usuario` (`ID`, `usuario`, `clave`, `verCliente`, `verArchivo`, `verArticulos`, `verPedidos`, `verMatrices`, `verUsuarios`, `verReportes`, `altaArticulos`, `bajaArticulos`, `modificaArticulos`, `altaClientes`, `modificaClientes`, `altaPedidos`, `modificaPedidos`, `detallePedidos`, `altaMatrices`, `modificaMatrices`, `nitruradoMatrices`) VALUES
	(2, 'Mostrador', 'mostrador', 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0),
	(4, 'Administrador', 'exemac', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
	(5, 'Deposito', 'deposito', 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	(6, 'Gestion', 'gestion', 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.verCompatibilidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verCompatibilidad`(
	IN `p1` int

)
select m.ID,mv.descripcion,m.descripcion,m.`año`
from compatibilidad c
inner join modelo m on c.Modelo_ID = m.ID
inner join marcaVehiculo mv on m.Marca_ID = mv.id
where c.Articulo_ID = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verEquivalencia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verEquivalencia`(
	IN `p1` INT


)
select e.Equivalencia_ID,aa.codigo,aa.descripcion,m.descripcion
from equivalencia e
inner join articulo a on e.Articulo_ID  = a.ID
inner join articulo aa on e.Equivalencia_ID  = aa.ID
inner join marca m on aa.Marca_ID = m.id
where a.ID = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verfacturas
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verfacturas`(
	IN `p0` TINYINT(1),
	IN `p1` DATE,
	IN `p2` DATE
)
begin
if p0!=true and p0!=false 
			then
         select f.fechaHora,f.numero,f.cliente,f.total,mp.descripcion,f.usuario
			from factura f 
			inner join mediodepago mp on f.medioPagoID = mp.id
			-- where f.fechaHora >= p1 and f.fechaHora <= concat(p2,' 23:59:59')
	 ;
  
  else
  select f.fechaHora,f.numero,f.cliente,f.total,mp.descripcion,f.usuario
	from factura f 
	inner join mediodepago mp on f.medioPagoID = mp.id
	where f.fechaHora >= p1 and f.fechaHora <= concat(p2,' 23:59:59')
	and f.activa = p0;
  end if;
end//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verLocalidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verLocalidad`(p1 int)
Select *
from localidad l
where l.Provincia_ID = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verMovimientos
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verMovimientos`(
	IN `p1` DATE,
	IN `p2` DATE

)
select m.fecha,a.codigo,a.descripcion,m.cantidad,t.descripcion,m.Usuario,m.observaciones
from movimientostock m
inner join articulo a on m.articuloID = a.ID
inner join tipomovimiento t on m.tipoMovimientoID = t.id
where m.fecha >=p1 and m.fecha <= p2
order by m.fecha desc//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verStock
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verStock`()
select a.codigo, a.descripcion, a.stockActual, a.stockMin, a.stockMax,(a.stockMin - a.stockActual) as puntoPedido,( a.stockActual - a.stockMax) as sobrestock, a.creacion,a.usuario
from articulo a
order by a.creacion desc//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verUsuarios
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verUsuarios`()
select *
from usuario u//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
