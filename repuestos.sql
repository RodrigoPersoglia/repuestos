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

-- Volcando estructura para procedimiento repuestos.AcumuladoDesdeNitrurado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AcumuladoDesdeNitrurado`(
	IN `p1` int
)
select sum(dt.kgs)
from detallefabricacion dt
where dt.Matriz_ID = p1 and dt.fecha > (select n.fecha
from nitrurado n
where n.matriz_ID = p1
group by n.id
-- order by n.fecha desc 
limit 1)//
DELIMITER ;

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

-- Volcando estructura para procedimiento repuestos.AgregarDetalleFabricacion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarDetalleFabricacion`(
	IN `fecha` DATE,
	IN `horaInicio` VARCHAR(5),
	IN `horaFin` VARCHAR(5),
	IN `kgs` decimal(8,1),
	IN `tiras` int,
	IN `largoPerfil` VARCHAR(100),
	IN `pesoMetro` DECIMAL(8,4),
	IN `colada` VARCHAR(45),
	IN `observaciones` VARCHAR(100),
	IN `largoTocho` INT,
	IN `cantidadTochos` INT,
	IN `matriz_ID` INT,
	IN `prensa` INT,
	IN `pedido_ID` INT,
	IN `turno_ID` INT,
	IN `Aleacion_ID` INT




,
	IN `kg_acumulados` INT

,
	IN `p18` INT(1),
	IN `p19` DECIMAL(10,2)



)
BEGIN
START TRANSACTION;
INSERT INTO detalleFabricacion 
(fecha,horaInicio,horaFin, kgs,tiras,largoPerfil,
pesoMetro,colada,observaciones,largoTocho,
cantidadTochos,matriz_ID,puesto_ID,pedido_ID,turno_ID,Aleacion_ID,diamTocho,kgPrensa)
VALUES 
(fecha,horaInicio,horaFin, kgs,tiras,largoPerfil,
pesoMetro,colada,observaciones,largoTocho,
cantidadTochos,matriz_ID,prensa,pedido_ID,turno_ID,Aleacion_ID,p18,p19);

UPDATE matriz m
SET  
pesoActual = pesoMetro ,
kgAcumulados  =  m.KgAcumulados + kg_acumulados,
KgAcumDesdeNit = KgAcumDesdeNit + kg_acumulados
where ID=matriz_ID;

UPDATE articulo 
SET  
Puesto_ID = prensa
where ID = 

(select  p.Articulo_ID
from pedido p
where p.ID = pedido_ID)
;commit


;END//
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

-- Volcando estructura para procedimiento repuestos.AgregarNitrurado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarNitrurado`(
	IN `p1` date,
	IN `p2` int


)
BEGIN
START TRANSACTION;
insert into Nitrurado
(fecha, matriz_ID)
values (p1,p2);

update matriz m
set
KgAcumDesdeNit = 0,
CantidadNitrurados = m.CantidadNitrurados + 1
where ID = p2;



COMMIT;

END//
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

-- Volcando estructura para procedimiento repuestos.AgregarPuesto
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `AgregarPuesto`(p1 varchar(60), p2 varchar(60), p3 varchar(60))
insert into puesto (descripcion,maquinista,encargado)
values ( p1,p2,p3)//
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
) ENGINE=InnoDB AUTO_INCREMENT=1745 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.articulo: ~12 rows (aproximadamente)
/*!40000 ALTER TABLE `articulo` DISABLE KEYS */;
REPLACE INTO `articulo` (`ID`, `codigo`, `codigoProveedor`, `numeroPieza`, `descripcion`, `precio`, `stockMin`, `stockMax`, `stockActual`, `observaciones`, `Marca_ID`, `Rubro_ID`, `Lado_ID`, `Proveedor_ID`, `Ubicacion`, `creacion`, `usuario`) VALUES
	(1733, '10', 'rodrigo persoglia', '10', 'Correa Distribucion 50 cm 40 dientes', 2108.77, 5, 10, 2, 'palio corsa', 3, 6, 32, 830, 'B5', '2022-03-22', 'Rodrigo'),
	(1734, '100', '1000', '100', 'Correa Distribucion 50 cm ', 2948.41, 5, 10, 50, '  ', 6, 6, 32, 831, 'B6', '2022-03-22', 'Rodrigo'),
	(1735, '1000', '1000', '1000', 'kit Distribucion', 3446.47, 3, 10, 42, 'corsa', 1, 6, 32, 830, 'B7', '2022-03-22', 'Rodrigo'),
	(1736, '5050', '5050', '5050', 'prueba', 21859.22, 10, 100, 50, '', 4, 2, 32, 830, '', '2022-03-22', 'Rodrigo'),
	(1737, '989898', '989898', '989898', 'ruleman', 2185.92, 10, 100, 45, 'palio', 2, 4, 32, 831, 'bbb', '2022-03-22', 'Rodrigo'),
	(1738, 'SC', 'SC', 'SC', 'Escribir detalle', 1.45, 1, 1, 49, '', 1, 3, 32, 830, '', '2022-03-22', 'Rodrigo'),
	(1739, 'A12-0138-001', 'A12-0138-001', 'A12-0138-001', 'PARRILLA DERECHA PEUGEOT 206', 2914.78, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-22', 'Rodrigo'),
	(1740, '23032022', '23032022', '23032022', 'prueba del dia', 2623.39, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-22', 'Rodrigo'),
	(1741, '1006', '1006', '1006', 'Paño fijo', 8.97, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-23', 'Rodrigo'),
	(1742, '721450764938', '721450764938', '721450764938', 'toner', 218.59, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-23', 'Rodrigo'),
	(1743, '721450764937', '721450764937', '721450764937', 'toner hp', 218.81, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-23', 'Rodrigo'),
	(1744, '3726860776493', '3726860776493', '3726860776493', 'otro articulo', 179.25, 1, 1, 1, '', 4, 3, 30, 830, '', '2022-03-23', 'Rodrigo');
/*!40000 ALTER TABLE `articulo` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.aumentoPrecios
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `aumentoPrecios`(
	IN `p0` INT,
	IN `p1` DECIMAL(10,3)
)
begin
if p0=0
			then
			update articulo a
			set
			a.precio = a.precio * p1
	 ;
  
  else
			update articulo a
			set
			a.precio = a.precio * p1
			where a.Rubro_ID = p0
			;
  end if;
end//
DELIMITER ;

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

-- Volcando estructura para procedimiento repuestos.cantidadNitturados
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `cantidadNitturados`(p0 int)
select count(*) as cantidad
from nitrurado n
inner join matriz m on n.matriz_ID = m.id
inner join articulo a on m.Articulo_ID = a.id
where m.ID = p0
group by a.ID
limit 1//
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.cliente: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
REPLACE INTO `cliente` (`ID`, `numero`, `Alias`, `razonSocial`, `cuit`, `telefono1`, `telefono2`, `email`, `Direccion_ID`, `Dir_Ent_ID`, `TipoDoc_ID`, `Iva_ID`, `Bonificacion`, `Recargo`) VALUES
	(2, 1, 'CONSUMIDOR FINAL', 'CONSUMIDOR FINAL', 1, ' ', ' ', NULL, 127, 128, 3, 4, 0.00, 0.00),
	(3, 2, 'MR. MAC SOLUCIONES ', 'MR. MAC SOLUCIONES ', 2, '4287-5420', '15-1234-5678', NULL, 129, 130, 3, 4, 0.00, 15.00),
	(4, 3, '.EXE DESARROLLOS INFORMÁTICOS', '.EXE DESARROLLOS INFORMÁTICOS', 2147483647, '4355-7120', '11-4170-9324', NULL, 131, 132, 1, 1, 0.00, 0.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.compatibilidad: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `compatibilidad` DISABLE KEYS */;
REPLACE INTO `compatibilidad` (`ID`, `Articulo_ID`, `Modelo_ID`) VALUES
	(5, 1734, 671),
	(6, 1734, 670),
	(7, 1734, 669),
	(8, 1735, 671),
	(9, 1735, 675),
	(10, 1735, 670),
	(11, 1735, 674);
/*!40000 ALTER TABLE `compatibilidad` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.consultaPedidoDetalle
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `consultaPedidoDetalle`(
	IN `parametro1` varchar(40)

)
BEGIN
select *
from pedidodetalle pd
inner join pedido p on pd.Pedido_ID = p.ID
where p.numero= parametro1;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.consultaPedidos
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `consultaPedidos`(
	IN `parametro1` varchar(40)



)
BEGIN
select p.ID,p.numero,p.fecha,p.kgEstimados,p.OC,p.Observaciones,c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,sum(pd.cantidad) as cantidad,count(*) as detalle, a.codigo as ID_Articulo ,p.Matriz_ID
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
where p.numero = parametro1
group by p.ID 
order by p.numero 
limit 1;
END//
DELIMITER ;

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
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.detallefactura: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `detallefactura` DISABLE KEYS */;
REPLACE INTO `detallefactura` (`ID`, `codigo`, `descripcion`, `cantidad`, `precio`, `factura_ID`, `articulo_ID`) VALUES
	(65, '10', 'Correa Distribucion 50 cm 40 dientes', 4, 1315.50, 55, 1733),
	(66, '100', 'Correa Distribucion 50 cm ', 2, 2115.20, 56, 1734),
	(67, '1000', 'kit Distribucion', 6, 2150.00, 57, 1735),
	(68, 'SC', 'reparacion amortiguador delantero', 1, 8000.00, 58, 1738);
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
) ENGINE=InnoDB AUTO_INCREMENT=133 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.direccion: ~12 rows (aproximadamente)
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
	(132, 'Barzi 719', 3, '1888');
/*!40000 ALTER TABLE `direccion` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.eliminarDetalle
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `eliminarDetalle`(
	IN `parametro1` varchar(40)
)
BEGIN
delete 
from pedidodetalle 
where Pedido_ID = parametro1;
END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.EliminarDetalleFabricacion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarDetalleFabricacion`(
	IN `p0` int(11),
	IN `p1` decimal(8,1),
	IN `p2` int(11)


)
BEGIN
START TRANSACTION;
delete from DetalleFabricacion
where ID= p0;

UPDATE matriz  m
SET  
kgAcumulados  =  m.KgAcumulados - p1,
KgAcumDesdeNit = m.KgAcumDesdeNit - p1
where ID= p2;

COMMIT;

END//
DELIMITER ;

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

-- Volcando estructura para procedimiento repuestos.EliminarPuesto
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EliminarPuesto`(p0 int)
delete from puesto 
where ID = p0//
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

-- Volcando estructura para tabla repuestos.empleado
CREATE TABLE IF NOT EXISTS `empleado` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `legajo` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `legajo_UNIQUE` (`legajo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.empleado: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
REPLACE INTO `empleado` (`ID`, `legajo`, `nombre`, `apellido`) VALUES
	(1, 1, 'Adriano', 'Alcaraz'),
	(2, 2, 'Nestor', 'Burello'),
	(3, 3, 'Carlos', 'Vavallo'),
	(4, 4, 'Diomedez', 'Alcaraz');
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.EnProduccion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `EnProduccion`()
select p.ID,p.numero,p.fecha,
ifnull (p.kgEstimados

-(SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p.id
GROUP BY dt.Pedido_ID
limit 1),p.kgEstimados )as kgPendientes,

c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,

ifnull (
(sum(pd.cantidad) / (select count(*)
from detallefabricacion dp 
inner join pedido pe on dp.Pedido_ID = pe.ID
where pe.numero = p.numero limit 1)),sum(pd.cantidad)) as cantidad,


 a.codigo as codigo, DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) AS proyeccion
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
left join detallefabricacion dt on dt.pedido_id=p.id
where e.ID< 4 and e.ID>1
group by p.ID 
order by  p.numero//
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.equivalencia: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `equivalencia` DISABLE KEYS */;
REPLACE INTO `equivalencia` (`ID`, `Articulo_ID`, `Equivalencia_ID`) VALUES
	(11, 1734, 1733),
	(12, 1735, 1733),
	(13, 1735, 1734);
/*!40000 ALTER TABLE `equivalencia` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.estado
CREATE TABLE IF NOT EXISTS `estado` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.estado: ~8 rows (aproximadamente)
/*!40000 ALTER TABLE `estado` DISABLE KEYS */;
REPLACE INTO `estado` (`ID`, `Descripcion`) VALUES
	(1, 'Aprobación'),
	(2, 'Fabricacion Parcial'),
	(3, 'Producción'),
	(4, 'Tratamiento Superficial'),
	(5, 'Terminado'),
	(6, 'Entregado'),
	(7, 'Baja'),
	(8, 'Excedente');
/*!40000 ALTER TABLE `estado` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.estadomatriz
CREATE TABLE IF NOT EXISTS `estadomatriz` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `estado` varchar(40) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.estadomatriz: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `estadomatriz` DISABLE KEYS */;
REPLACE INTO `estadomatriz` (`ID`, `estado`) VALUES
	(1, 'OK'),
	(2, 'En reparacion'),
	(3, 'Baja');
/*!40000 ALTER TABLE `estadomatriz` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.factura: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
REPLACE INTO `factura` (`ID`, `numero`, `fechaHora`, `subTotal`, `financiacion`, `total`, `cliente_ID`, `cliente`, `direccion`, `localidad`, `cp`, `usuario`, `medioPagoID`, `activa`) VALUES
	(55, 1, '2022-03-22 16:38:20', 5262.00, 0.00, 5262.00, 2, 'CONSUMIDOR FINAL', ' ', 'Florencio Varela', ' ', 'Rodrigo', 1, 1),
	(56, 2, '2022-03-22 16:38:40', 4230.39, 0.00, 4230.39, 3, 'MR. MAC SOLUCIONES ', 'Tomas Edison 1800', 'Florencio Varela', '1888', 'Rodrigo', 1, 0),
	(57, 3, '2022-03-22 16:39:13', 12900.00, 0.00, 12900.00, 4, '.EXE DESARROLLOS INFORMÁTICOS', 'Barzi 719', 'Florencio Varela', '1888', 'Rodrigo', 1, 1),
	(58, 4, '2022-03-23 12:02:21', 8000.00, 0.00, 8000.00, 3, 'MR. MAC SOLUCIONES ', 'Tomas Edison 1800', 'Florencio Varela', '1888', 'Rodrigo', 1, 1);
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

-- Volcando estructura para procedimiento repuestos.KgFabricados
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `KgFabricados`(p1 int)
SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p1
GROUP BY dt.Pedido_ID
limit 1//
DELIMITER ;

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
	(30, 'Derecho', 0.00),
	(31, 'Izquierdo', 0.00),
	(32, 'Pieza única', 0.00),
	(33, 'Izquierdo - Derecho', 0.00);
/*!40000 ALTER TABLE `lado` ENABLE KEYS */;

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

-- Volcando estructura para tabla repuestos.localidad
CREATE TABLE IF NOT EXISTS `localidad` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `Provincia_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_Localidad_Provincia_idx` (`Provincia_ID`),
  CONSTRAINT `fk_Localidad_Provincia` FOREIGN KEY (`Provincia_ID`) REFERENCES `provincia` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.localidad: ~28 rows (aproximadamente)
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
	(35, 'Luis Guillon', 1);
/*!40000 ALTER TABLE `localidad` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.marca
CREATE TABLE IF NOT EXISTS `marca` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.marca: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
REPLACE INTO `marca` (`ID`, `descripcion`) VALUES
	(1, 'VALEO'),
	(2, 'SKF'),
	(3, 'SACH'),
	(4, 'CORVEN'),
	(6, 'LUK');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.marcavehiculo
CREATE TABLE IF NOT EXISTS `marcavehiculo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.marcavehiculo: ~80 rows (aproximadamente)
/*!40000 ALTER TABLE `marcavehiculo` DISABLE KEYS */;
REPLACE INTO `marcavehiculo` (`ID`, `codigo`, `descripcion`) VALUES
	(1, 1, 'Audi'),
	(2, 1, 'Abarth'),
	(3, 2, 'Alfa Romeo'),
	(4, 3, 'Aro'),
	(5, 4, 'Asia'),
	(6, 5, 'Asia Motors'),
	(7, 6, 'Aston Martin'),
	(8, 7, 'Audi'),
	(9, 8, 'Austin'),
	(10, 9, 'Auverland'),
	(11, 10, 'Bentley'),
	(12, 11, 'Bertone'),
	(13, 12, 'Bmw'),
	(14, 13, 'Cadillac'),
	(15, 14, 'Chevrolet'),
	(16, 15, 'Chrysler'),
	(17, 16, 'Citroen'),
	(18, 17, 'Corvette'),
	(19, 18, 'Dacia'),
	(20, 19, 'Daewoo'),
	(21, 20, 'Daf'),
	(22, 21, 'Daihatsu'),
	(23, 22, 'Daimler'),
	(24, 23, 'Dodge'),
	(25, 24, 'Ferrari'),
	(26, 25, 'Fiat'),
	(27, 26, 'Ford'),
	(28, 27, 'Galloper'),
	(29, 28, 'Gmc'),
	(30, 29, 'Honda'),
	(31, 30, 'Hummer'),
	(32, 31, 'Hyundai'),
	(33, 32, 'Infiniti'),
	(34, 33, 'Innocenti'),
	(35, 34, 'Isuzu'),
	(36, 35, 'Iveco'),
	(37, 36, 'Iveco-pegaso'),
	(38, 37, 'Jaguar'),
	(39, 38, 'Jeep'),
	(40, 39, 'Kia'),
	(41, 40, 'Lada'),
	(42, 41, 'Lamborghini'),
	(43, 42, 'Lancia'),
	(44, 43, 'Land-rover'),
	(45, 44, 'Ldv'),
	(46, 45, 'Lexus'),
	(47, 46, 'Lotus'),
	(48, 47, 'Mahindra'),
	(49, 48, 'Maserati'),
	(50, 49, 'Maybach'),
	(51, 50, 'Mazda'),
	(52, 51, 'Mercedes-benz'),
	(53, 52, 'Mg'),
	(54, 53, 'Mini'),
	(55, 54, 'Mitsubishi'),
	(56, 55, 'Morgan'),
	(57, 56, 'Nissan'),
	(58, 57, 'Opel'),
	(59, 58, 'Peugeot'),
	(60, 59, 'Pontiac'),
	(61, 60, 'Porsche'),
	(62, 61, 'Renault'),
	(63, 62, 'Rolls-royce'),
	(64, 63, 'Rover'),
	(65, 64, 'Saab'),
	(66, 65, 'Santana'),
	(67, 66, 'Seat'),
	(68, 67, 'Skoda'),
	(69, 68, 'Smart'),
	(70, 69, 'Ssangyong'),
	(71, 70, 'Subaru'),
	(72, 71, 'Suzuki'),
	(73, 72, 'Talbot'),
	(74, 73, 'Tata'),
	(75, 74, 'Toyota'),
	(76, 75, 'Umm'),
	(77, 76, 'Vaz'),
	(78, 77, 'Volkswagen'),
	(79, 78, 'Volvo'),
	(80, 79, 'Wartburg');
/*!40000 ALTER TABLE `marcavehiculo` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.matriz
CREATE TABLE IF NOT EXISTS `matriz` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ejemplar` int(11) NOT NULL,
  `cantidadSalidas` int(2) NOT NULL,
  `pesoActual` decimal(7,3) DEFAULT NULL,
  `Articulo_ID` int(11) NOT NULL,
  `Cliente_ID` int(11) NOT NULL,
  `EstadoMatriz_ID` int(11) NOT NULL DEFAULT '1',
  `KgAcumulados` int(11) NOT NULL,
  `KgAcumDesdeNit` int(11) NOT NULL,
  `CantidadNitrurados` int(11) NOT NULL,
  `Controlada` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `fk_Matriz_Articulo1_idx` (`Articulo_ID`),
  KEY `fk_Matriz_Cliente1_idx` (`Cliente_ID`),
  KEY `fk_Matriz_Estado` (`EstadoMatriz_ID`),
  CONSTRAINT `fk_Matriz_Articulo1` FOREIGN KEY (`Articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Matriz_Cliente1` FOREIGN KEY (`Cliente_ID`) REFERENCES `cliente` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Matriz_Estado` FOREIGN KEY (`EstadoMatriz_ID`) REFERENCES `estadomatriz` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.matriz: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `matriz` DISABLE KEYS */;
/*!40000 ALTER TABLE `matriz` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.mediodepago
CREATE TABLE IF NOT EXISTS `mediodepago` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `recargo` decimal(15,3) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero` (`numero`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.mediodepago: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `mediodepago` DISABLE KEYS */;
REPLACE INTO `mediodepago` (`ID`, `numero`, `descripcion`, `recargo`) VALUES
	(1, 1, 'Efectivo', 0.000),
	(2, 2, 'Debito', 3.000),
	(3, 3, 'Tarjeta de crédito (1 cuota)', 3.000),
	(4, 4, 'Tarjeta de crédito (hasta 3 cuotas)', 6.000),
	(5, 5, 'Tarjeta de crédito (hasta 6 coutas)', 9.000),
	(6, 6, 'Tarjeta de crédito (ahora 12)', 12.000),
	(7, 7, 'QR mercado Pago', 1.000);
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
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `año` int(11) NOT NULL,
  `Marca_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `codigo` (`codigo`),
  UNIQUE KEY `descripcion` (`descripcion`,`año`),
  KEY `FK__marcavehiculo` (`Marca_ID`),
  CONSTRAINT `FK__marcavehiculo` FOREIGN KEY (`Marca_ID`) REFERENCES `marcavehiculo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=961 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.modelo: ~955 rows (aproximadamente)
/*!40000 ALTER TABLE `modelo` DISABLE KEYS */;
REPLACE INTO `modelo` (`ID`, `codigo`, `descripcion`, `año`, `Marca_ID`) VALUES
	(6, 1, '500', 2000, 2),
	(7, 2, 'Grande Punto', 2000, 2),
	(8, 3, 'Punto Evo', 2000, 2),
	(9, 4, '500c', 2000, 2),
	(10, 5, '695', 2000, 2),
	(11, 6, 'Punto', 2000, 2),
	(12, 7, '155', 2000, 3),
	(13, 8, '156', 2000, 3),
	(14, 9, '159', 2000, 3),
	(15, 10, '164', 2000, 3),
	(16, 11, '145', 2000, 3),
	(17, 12, '147', 2000, 3),
	(18, 13, '146', 2000, 3),
	(19, 14, 'Gtv', 2000, 3),
	(20, 15, 'Spider', 2000, 3),
	(21, 16, '166', 2000, 3),
	(22, 17, 'Gt', 2000, 3),
	(23, 18, 'Crosswagon', 2000, 3),
	(24, 19, 'Brera', 2000, 3),
	(25, 20, '90', 2000, 3),
	(26, 21, '75', 2000, 3),
	(27, 22, '33', 2000, 3),
	(28, 23, 'Giulietta', 2000, 3),
	(29, 24, 'Sprint', 2000, 3),
	(30, 25, 'Mito', 2000, 3),
	(31, 26, 'Expander', 2000, 4),
	(32, 27, '10', 2000, 4),
	(33, 28, '24', 2000, 4),
	(34, 29, 'Dacia', 2000, 4),
	(35, 30, 'Rocsta', 2000, 5),
	(36, 32, 'Db7', 2000, 7),
	(37, 33, 'V8', 2000, 7),
	(38, 34, 'Db9', 2000, 7),
	(39, 35, 'Vanquish', 2000, 7),
	(40, 36, 'V8 Vantage', 2000, 7),
	(41, 37, 'Vantage', 2000, 7),
	(42, 38, 'Dbs', 2000, 7),
	(43, 39, 'Volante', 2000, 7),
	(44, 40, 'Virage', 2000, 7),
	(45, 41, 'Vantage V8', 2000, 7),
	(46, 42, 'Vantage V12', 2000, 7),
	(47, 43, 'Rapide', 2000, 7),
	(48, 44, 'Cygnet', 2000, 7),
	(49, 45, '80', 2000, 8),
	(50, 46, 'A4', 2000, 8),
	(51, 47, 'A6', 2000, 8),
	(52, 48, 'S6', 2000, 8),
	(53, 49, 'Coupe', 2000, 8),
	(54, 50, 'S2', 2000, 8),
	(55, 51, 'Rs2', 2000, 8),
	(56, 52, 'A8', 2000, 8),
	(57, 53, 'Cabriolet', 2000, 8),
	(58, 54, 'S8', 2000, 8),
	(59, 55, 'A3', 2000, 8),
	(60, 56, 'S4', 2000, 8),
	(61, 57, 'Tt', 2000, 8),
	(62, 58, 'S3', 2000, 8),
	(63, 59, 'Allroad Quattro', 2000, 8),
	(64, 60, 'Rs4', 2000, 8),
	(65, 61, 'A2', 2000, 8),
	(66, 62, 'Rs6', 2000, 8),
	(67, 63, 'Q7', 2000, 8),
	(68, 64, 'R8', 2000, 8),
	(69, 65, 'A5', 2000, 8),
	(70, 66, 'S5', 2000, 8),
	(71, 68, '200', 2000, 8),
	(72, 69, '100', 2000, 8),
	(73, 71, 'Tts', 2000, 8),
	(74, 72, 'Q5', 2000, 8),
	(75, 73, 'A4 Allroad Quattro', 2000, 8),
	(76, 74, 'Tt Rs', 2000, 8),
	(77, 75, 'Rs5', 2000, 8),
	(78, 76, 'A1', 2000, 8),
	(79, 77, 'A7', 2000, 8),
	(80, 78, 'Rs3', 2000, 8),
	(81, 79, 'Q3', 2000, 8),
	(82, 80, 'A6 Allroad Quattro', 2000, 8),
	(83, 81, 'S7', 2000, 8),
	(84, 82, 'Sq5', 2000, 8),
	(85, 83, 'Mini', 2000, 9),
	(86, 84, 'Montego', 2000, 9),
	(87, 85, 'Maestro', 2000, 9),
	(88, 86, 'Metro', 2000, 9),
	(89, 87, 'Mini Moke', 2000, 9),
	(90, 88, 'Diesel', 2000, 10),
	(91, 89, 'Brooklands', 2000, 11),
	(92, 90, 'Turbo', 2000, 11),
	(93, 91, 'Continental', 2000, 11),
	(94, 92, 'Azure', 2000, 11),
	(95, 93, 'Arnage', 2000, 11),
	(96, 94, 'Continental Gt', 2000, 11),
	(97, 95, 'Continental Flying Spur', 2000, 11),
	(98, 96, 'Turbo R', 2000, 11),
	(99, 97, 'Mulsanne', 2000, 11),
	(100, 98, 'Eight', 2000, 11),
	(101, 99, 'Continental Gtc', 2000, 11),
	(102, 100, 'Continental Supersports', 2000, 11),
	(103, 101, 'Freeclimber Diesel', 2000, 12),
	(104, 102, 'Serie 3', 2000, 13),
	(105, 103, 'Serie 5', 2000, 13),
	(106, 104, 'Compact', 2000, 13),
	(107, 105, 'Serie 7', 2000, 13),
	(108, 106, 'Serie 8', 2000, 13),
	(109, 107, 'Z3', 2000, 13),
	(110, 108, 'Z4', 2000, 13),
	(111, 109, 'Z8', 2000, 13),
	(112, 110, 'X5', 2000, 13),
	(113, 111, 'Serie 6', 2000, 13),
	(114, 112, 'X3', 2000, 13),
	(115, 113, 'Serie 1', 2000, 13),
	(116, 114, 'Z1', 2000, 13),
	(117, 115, 'X6', 2000, 13),
	(118, 116, 'X1', 2000, 13),
	(119, 117, 'Seville', 2000, 14),
	(120, 118, 'Sts', 2000, 14),
	(121, 119, 'El Dorado', 2000, 14),
	(122, 120, 'Cts', 2000, 14),
	(123, 121, 'Xlr', 2000, 14),
	(124, 122, 'Srx', 2000, 14),
	(125, 123, 'Escalade', 2000, 14),
	(126, 124, 'Bls', 2000, 14),
	(127, 125, 'Corvette', 2000, 15),
	(128, 126, 'Blazer', 2000, 15),
	(129, 127, 'Astro', 2000, 15),
	(130, 128, 'Nubira', 2000, 15),
	(131, 129, 'Evanda', 2000, 15),
	(132, 130, 'Trans Sport', 2000, 15),
	(133, 131, 'Camaro', 2000, 15),
	(134, 132, 'Matiz', 2000, 15),
	(135, 133, 'Alero', 2000, 15),
	(136, 134, 'Tahoe', 2000, 15),
	(137, 135, 'Tacuma', 2000, 15),
	(138, 136, 'Trailblazer', 2000, 15),
	(139, 137, 'Kalos', 2000, 15),
	(140, 138, 'Aveo', 2000, 15),
	(141, 139, 'Lacetti', 2000, 15),
	(142, 140, 'Epica', 2000, 15),
	(143, 141, 'Captiva', 2000, 15),
	(144, 142, 'Hhr', 2000, 15),
	(145, 143, 'Cruze', 2000, 15),
	(146, 144, 'Spark', 2000, 15),
	(147, 145, 'Orlando', 2000, 15),
	(148, 146, 'Volt', 2000, 15),
	(149, 147, 'Malibu', 2000, 15),
	(150, 148, 'Vision', 2000, 16),
	(151, 149, '300m', 2000, 16),
	(152, 150, 'Grand Voyager', 2000, 16),
	(153, 151, 'Viper', 2000, 16),
	(154, 152, 'Neon', 2000, 16),
	(155, 153, 'Voyager', 2000, 16),
	(156, 154, 'Stratus', 2000, 16),
	(157, 155, 'Sebring', 2000, 16),
	(158, 156, 'Sebring 200c', 2000, 16),
	(159, 157, 'New Yorker', 2000, 16),
	(160, 158, 'Pt Cruiser', 2000, 16),
	(161, 159, 'Crossfire', 2000, 16),
	(162, 160, '300c', 2000, 16),
	(163, 161, 'Le Baron', 2000, 16),
	(164, 162, 'Saratoga', 2000, 16),
	(165, 163, 'Xantia', 2000, 17),
	(166, 164, 'Xm', 2000, 17),
	(167, 165, 'Ax', 2000, 17),
	(168, 166, 'Zx', 2000, 17),
	(169, 167, 'Evasion', 2000, 17),
	(170, 168, 'C8', 2000, 17),
	(171, 169, 'Saxo', 2000, 17),
	(172, 170, 'C2', 2000, 17),
	(173, 171, 'Xsara', 2000, 17),
	(174, 172, 'C4', 2000, 17),
	(175, 173, 'Xsara Picasso', 2000, 17),
	(176, 174, 'C5', 2000, 17),
	(177, 175, 'C3', 2000, 17),
	(178, 176, 'C3 Pluriel', 2000, 17),
	(179, 177, 'C1', 2000, 17),
	(180, 178, 'C6', 2000, 17),
	(181, 179, 'Grand C4 Picasso', 2000, 17),
	(182, 180, 'C4 Picasso', 2000, 17),
	(183, 181, 'Ccrosser', 2000, 17),
	(184, 182, 'C15', 2000, 17),
	(185, 183, 'Jumper', 2000, 17),
	(186, 184, 'Jumpy', 2000, 17),
	(187, 185, 'Berlingo', 2000, 17),
	(188, 186, 'Bx', 2000, 17),
	(189, 187, 'C25', 2000, 17),
	(190, 188, 'Cx', 2000, 17),
	(191, 189, 'Gsa', 2000, 17),
	(192, 190, 'Visa', 2000, 17),
	(193, 191, 'Lna', 2000, 17),
	(194, 192, '2cv', 2000, 17),
	(195, 193, 'Nemo', 2000, 17),
	(196, 194, 'C4 Sedan', 2000, 17),
	(197, 195, 'Berlingo First', 2000, 17),
	(198, 196, 'C3 Picasso', 2000, 17),
	(199, 197, 'Ds3', 2000, 17),
	(200, 198, 'Czero', 2000, 17),
	(201, 199, 'Ds4', 2000, 17),
	(202, 200, 'Ds5', 2000, 17),
	(203, 201, 'C4 Aircross', 2000, 17),
	(204, 202, 'Celysee', 2000, 17),
	(205, 204, 'Contac', 2000, 19),
	(206, 205, 'Logan', 2000, 19),
	(207, 206, 'Sandero', 2000, 19),
	(208, 207, 'Duster', 2000, 19),
	(209, 208, 'Lodgy', 2000, 19),
	(210, 209, 'Nexia', 2000, 20),
	(211, 210, 'Aranos', 2000, 20),
	(212, 211, 'Lanos', 2000, 20),
	(213, 214, 'Nubira Compact', 2000, 20),
	(214, 215, 'Leganza', 2000, 20),
	(215, 221, 'Applause', 2000, 22),
	(216, 222, 'Charade', 2000, 22),
	(217, 223, 'Rocky', 2000, 22),
	(218, 224, 'Feroza', 2000, 22),
	(219, 225, 'Terios', 2000, 22),
	(220, 226, 'Sirion', 2000, 22),
	(221, 227, 'Serie Xj', 2000, 23),
	(222, 228, 'Xj', 2000, 23),
	(223, 229, 'Double Six', 2000, 23),
	(224, 230, 'Six', 2000, 23),
	(225, 231, 'Series Iii', 2000, 23),
	(226, 233, 'Caliber', 2000, 24),
	(227, 234, 'Nitro', 2000, 24),
	(228, 235, 'Avenger', 2000, 24),
	(229, 236, 'Journey', 2000, 24),
	(230, 237, 'F355', 2000, 25),
	(231, 238, '360', 2000, 25),
	(232, 239, 'F430', 2000, 25),
	(233, 240, 'F512 M', 2000, 25),
	(234, 241, '550 Maranello', 2000, 25),
	(235, 242, '575m Maranello', 2000, 25),
	(236, 243, '599', 2000, 25),
	(237, 244, '456', 2000, 25),
	(238, 245, '456m', 2000, 25),
	(239, 246, '612', 2000, 25),
	(240, 247, 'F50', 2000, 25),
	(241, 248, 'Enzo', 2000, 25),
	(242, 249, 'Superamerica', 2000, 25),
	(243, 250, '430', 2000, 25),
	(244, 251, '348', 2000, 25),
	(245, 252, 'Testarossa', 2000, 25),
	(246, 253, '512', 2000, 25),
	(247, 254, '355', 2000, 25),
	(248, 255, 'F40', 2000, 25),
	(249, 256, '412', 2000, 25),
	(250, 257, 'Mondial', 2000, 25),
	(251, 258, '328', 2000, 25),
	(252, 259, 'California', 2000, 25),
	(253, 260, '458', 2000, 25),
	(254, 261, 'Ff', 2000, 25),
	(255, 262, 'Croma', 2000, 26),
	(256, 263, 'Cinquecento', 2000, 26),
	(257, 264, 'Seicento', 2000, 26),
	(258, 267, 'Panda', 2000, 26),
	(259, 268, 'Tipo', 2000, 26),
	(260, 270, 'Uno', 2000, 26),
	(261, 271, 'Ulysse', 2000, 26),
	(262, 272, 'Tempra', 2000, 26),
	(263, 273, 'Marea', 2000, 26),
	(264, 274, 'Barchetta', 2000, 26),
	(265, 275, 'Bravo', 2000, 26),
	(266, 276, 'Stilo', 2000, 26),
	(267, 277, 'Brava', 2000, 26),
	(268, 278, 'Palio Weekend', 2000, 26),
	(269, 279, '600', 2000, 26),
	(270, 280, 'Multipla', 2000, 26),
	(271, 281, 'Idea', 2000, 26),
	(272, 282, 'Sedici', 2000, 26),
	(273, 283, 'Linea', 2000, 26),
	(274, 285, 'Fiorino', 2000, 26),
	(275, 286, 'Ducato', 2000, 26),
	(276, 287, 'Doblo Cargo', 2000, 26),
	(277, 288, 'Doblo', 2000, 26),
	(278, 289, 'Strada', 2000, 26),
	(279, 290, 'Regata', 2000, 26),
	(280, 291, 'Talento', 2000, 26),
	(281, 292, 'Argenta', 2000, 26),
	(282, 293, 'Ritmo', 2000, 26),
	(283, 294, 'Punto Classic', 2000, 26),
	(284, 295, 'Qubo', 2000, 26),
	(285, 298, 'Freemont', 2000, 26),
	(286, 299, 'Panda Classic', 2000, 26),
	(287, 300, '500l', 2000, 26),
	(288, 301, 'Maverick', 2000, 27),
	(289, 302, 'Escort', 2000, 27),
	(290, 303, 'Focus', 2000, 27),
	(291, 304, 'Mondeo', 2000, 27),
	(292, 305, 'Scorpio', 2000, 27),
	(293, 306, 'Fiesta', 2000, 27),
	(294, 307, 'Probe', 2000, 27),
	(295, 308, 'Explorer', 2000, 27),
	(296, 309, 'Galaxy', 2000, 27),
	(297, 310, 'Ka', 2000, 27),
	(298, 311, 'Puma', 2000, 27),
	(299, 312, 'Cougar', 2000, 27),
	(300, 313, 'Focus Cmax', 2000, 27),
	(301, 314, 'Fusion', 2000, 27),
	(302, 315, 'Streetka', 2000, 27),
	(303, 316, 'Cmax', 2000, 27),
	(304, 317, 'Smax', 2000, 27),
	(305, 318, 'Transit', 2000, 27),
	(306, 319, 'Courier', 2000, 27),
	(307, 320, 'Ranger', 2000, 27),
	(308, 321, 'Sierra', 2000, 27),
	(309, 322, 'Orion', 2000, 27),
	(310, 323, 'Pick Up', 2000, 27),
	(311, 324, 'Capri', 2000, 27),
	(312, 325, 'Granada', 2000, 27),
	(313, 326, 'Kuga', 2000, 27),
	(314, 327, 'Grand Cmax', 2000, 27),
	(315, 328, 'Bmax', 2000, 27),
	(316, 329, 'Tourneo Custom', 2000, 27),
	(317, 330, 'Exceed', 2000, 28),
	(318, 331, 'Santamo', 2000, 28),
	(319, 332, 'Super Exceed', 2000, 28),
	(320, 333, 'Accord', 2000, 30),
	(321, 334, 'Civic', 2000, 30),
	(322, 335, 'Crx', 2000, 30),
	(323, 336, 'Prelude', 2000, 30),
	(324, 337, 'Nsx', 2000, 30),
	(325, 338, 'Legend', 2000, 30),
	(326, 339, 'Crv', 2000, 30),
	(327, 340, 'Hrv', 2000, 30),
	(328, 341, 'Logo', 2000, 30),
	(329, 342, 'S2000', 2000, 30),
	(330, 343, 'Stream', 2000, 30),
	(331, 344, 'Jazz', 2000, 30),
	(332, 345, 'Frv', 2000, 30),
	(333, 346, 'Concerto', 2000, 30),
	(334, 347, 'Insight', 2000, 30),
	(335, 348, 'Crz', 2000, 30),
	(336, 349, 'H2', 2000, 31),
	(337, 350, 'H3', 2000, 31),
	(338, 351, 'H3t', 2000, 31),
	(339, 352, 'Lantra', 2000, 32),
	(340, 353, 'Sonata', 2000, 32),
	(341, 354, 'Elantra', 2000, 32),
	(342, 355, 'Accent', 2000, 32),
	(343, 356, 'Scoupe', 2000, 32),
	(344, 358, 'Atos', 2000, 32),
	(345, 359, 'H1', 2000, 32),
	(346, 360, 'Atos Prime', 2000, 32),
	(347, 361, 'Xg', 2000, 32),
	(348, 362, 'Trajet', 2000, 32),
	(349, 363, 'Santa Fe', 2000, 32),
	(350, 364, 'Terracan', 2000, 32),
	(351, 365, 'Matrix', 2000, 32),
	(352, 366, 'Getz', 2000, 32),
	(353, 367, 'Tucson', 2000, 32),
	(354, 368, 'I30', 2000, 32),
	(355, 369, 'Pony', 2000, 32),
	(356, 370, 'Grandeur', 2000, 32),
	(357, 371, 'I10', 2000, 32),
	(358, 372, 'I800', 2000, 32),
	(359, 373, 'Sonata Fl', 2000, 32),
	(360, 374, 'Ix55', 2000, 32),
	(361, 375, 'I20', 2000, 32),
	(362, 376, 'Ix35', 2000, 32),
	(363, 377, 'Ix20', 2000, 32),
	(364, 378, 'Genesis', 2000, 32),
	(365, 379, 'I40', 2000, 32),
	(366, 380, 'Veloster', 2000, 32),
	(367, 381, 'G', 2000, 33),
	(368, 382, 'Ex', 2000, 33),
	(369, 383, 'Fx', 2000, 33),
	(370, 384, 'M', 2000, 33),
	(371, 385, 'Elba', 2000, 34),
	(372, 386, 'Minitre', 2000, 34),
	(373, 387, 'Trooper', 2000, 35),
	(374, 389, 'D Max', 2000, 35),
	(375, 390, 'Rodeo', 2000, 35),
	(376, 391, 'Dmax', 2000, 35),
	(377, 392, 'Trroper', 2000, 35),
	(378, 393, 'Daily', 2000, 36),
	(379, 394, 'Massif', 2000, 36),
	(380, 396, 'Duty', 2000, 37),
	(381, 398, 'Serie Xk', 2000, 38),
	(382, 400, 'Stype', 2000, 38),
	(383, 401, 'Xf', 2000, 38),
	(384, 402, 'Xtype', 2000, 38),
	(385, 403, 'Wrangler', 2000, 39),
	(386, 404, 'Cherokee', 2000, 39),
	(387, 405, 'Grand Cherokee', 2000, 39),
	(388, 406, 'Commander', 2000, 39),
	(389, 407, 'Compass', 2000, 39),
	(390, 408, 'Wrangler Unlimited', 2000, 39),
	(391, 409, 'Patriot', 2000, 39),
	(392, 410, 'Sportage', 2000, 40),
	(393, 411, 'Sephia', 2000, 40),
	(394, 412, 'Sephia Ii', 2000, 40),
	(395, 413, 'Pride', 2000, 40),
	(396, 414, 'Clarus', 2000, 40),
	(397, 415, 'Shuma', 2000, 40),
	(398, 416, 'Carnival', 2000, 40),
	(399, 417, 'Joice', 2000, 40),
	(400, 418, 'Magentis', 2000, 40),
	(401, 419, 'Carens', 2000, 40),
	(402, 420, 'Rio', 2000, 40),
	(403, 421, 'Cerato', 2000, 40),
	(404, 422, 'Sorento', 2000, 40),
	(405, 423, 'Opirus', 2000, 40),
	(406, 424, 'Picanto', 2000, 40),
	(407, 425, 'Ceed', 2000, 40),
	(408, 426, 'Ceed Sporty Wagon', 2000, 40),
	(409, 427, 'Proceed', 2000, 40),
	(410, 428, 'K2500 Frontier', 2000, 40),
	(411, 429, 'K2500', 2000, 40),
	(412, 430, 'Soul', 2000, 40),
	(413, 431, 'Venga', 2000, 40),
	(414, 432, 'Optima', 2000, 40),
	(415, 433, 'Ceed Sportswagon', 2000, 40),
	(416, 434, 'Samara', 2000, 41),
	(417, 435, 'Niva', 2000, 41),
	(418, 436, 'Sagona', 2000, 41),
	(419, 437, 'Stawra 2110', 2000, 41),
	(420, 438, '214', 2000, 41),
	(421, 439, 'Kalina', 2000, 41),
	(422, 440, 'Serie 2100', 2000, 41),
	(423, 441, 'Priora', 2000, 41),
	(424, 442, 'Gallardo', 2000, 42),
	(425, 443, 'Murcielago', 2000, 42),
	(426, 444, 'Aventador', 2000, 42),
	(427, 445, 'Delta', 2000, 43),
	(428, 446, 'K', 2000, 43),
	(429, 447, 'Y10', 2000, 43),
	(430, 448, 'Dedra', 2000, 43),
	(431, 449, 'Lybra', 2000, 43),
	(432, 450, 'Z', 2000, 43),
	(433, 451, 'Y', 2000, 43),
	(434, 452, 'Ypsilon', 2000, 43),
	(435, 453, 'Thesis', 2000, 43),
	(436, 454, 'Phedra', 2000, 43),
	(437, 455, 'Musa', 2000, 43),
	(438, 456, 'Thema', 2000, 43),
	(439, 457, 'Zeta', 2000, 43),
	(440, 458, 'Kappa', 2000, 43),
	(441, 459, 'Trevi', 2000, 43),
	(442, 460, 'Prisma', 2000, 43),
	(443, 461, 'A112', 2000, 43),
	(444, 462, 'Ypsilon Elefantino', 2000, 43),
	(445, 464, 'Range Rover', 2000, 44),
	(446, 465, 'Defender', 2000, 44),
	(447, 466, 'Discovery', 2000, 44),
	(448, 467, 'Freelander', 2000, 44),
	(449, 468, 'Range Rover Sport', 2000, 44),
	(450, 469, 'Discovery 4', 2000, 44),
	(451, 470, 'Range Rover Evoque', 2000, 44),
	(452, 471, 'Maxus', 2000, 45),
	(453, 472, 'Ls400', 2000, 46),
	(454, 473, 'Ls430', 2000, 46),
	(455, 474, 'Gs300', 2000, 46),
	(456, 475, 'Is200', 2000, 46),
	(457, 476, 'Rx300', 2000, 46),
	(458, 477, 'Gs430', 2000, 46),
	(459, 478, 'Gs460', 2000, 46),
	(460, 479, 'Sc430', 2000, 46),
	(461, 480, 'Is300', 2000, 46),
	(462, 481, 'Is250', 2000, 46),
	(463, 482, 'Rx400h', 2000, 46),
	(464, 483, 'Is220d', 2000, 46),
	(465, 484, 'Rx350', 2000, 46),
	(466, 485, 'Gs450h', 2000, 46),
	(467, 486, 'Ls460', 2000, 46),
	(468, 487, 'Ls600h', 2000, 46),
	(469, 488, 'Ls', 2000, 46),
	(470, 489, 'Gs', 2000, 46),
	(471, 490, 'Is', 2000, 46),
	(472, 491, 'Sc', 2000, 46),
	(473, 492, 'Rx', 2000, 46),
	(474, 493, 'Ct', 2000, 46),
	(475, 494, 'Elise', 2000, 47),
	(476, 495, 'Exige', 2000, 47),
	(477, 496, 'Bolero Pickup', 2000, 48),
	(478, 497, 'Goa Pickup', 2000, 48),
	(479, 498, 'Goa', 2000, 48),
	(480, 499, 'Cj', 2000, 48),
	(481, 500, 'Pikup', 2000, 48),
	(482, 501, 'Thar', 2000, 48),
	(483, 502, 'Ghibli', 2000, 49),
	(484, 503, 'Shamal', 2000, 49),
	(485, 504, 'Quattroporte', 2000, 49),
	(486, 505, '3200 Gt', 2000, 49),
	(487, 507, 'Spyder', 2000, 49),
	(488, 508, 'Gransport', 2000, 49),
	(489, 509, 'Granturismo', 2000, 49),
	(490, 511, 'Biturbo', 2000, 49),
	(491, 512, '228', 2000, 49),
	(492, 513, '224', 2000, 49),
	(493, 514, 'Grancabrio', 2000, 49),
	(494, 515, 'Maybach', 2000, 50),
	(495, 516, 'Xedos 6', 2000, 51),
	(496, 517, '626', 2000, 51),
	(497, 518, '121', 2000, 51),
	(498, 519, 'Xedos 9', 2000, 51),
	(499, 520, '323', 2000, 51),
	(500, 521, 'Mx3', 2000, 51),
	(501, 522, 'Rx7', 2000, 51),
	(502, 523, 'Mx5', 2000, 51),
	(503, 524, 'Mazda3', 2000, 51),
	(504, 525, 'Mpv', 2000, 51),
	(505, 526, 'Demio', 2000, 51),
	(506, 527, 'Premacy', 2000, 51),
	(507, 528, 'Tribute', 2000, 51),
	(508, 529, 'Mazda6', 2000, 51),
	(509, 530, 'Mazda2', 2000, 51),
	(510, 531, 'Rx8', 2000, 51),
	(511, 532, 'Mazda5', 2000, 51),
	(512, 533, 'Cx7', 2000, 51),
	(513, 534, 'Serie B', 2000, 51),
	(514, 535, 'B2500', 2000, 51),
	(515, 536, 'Bt50', 2000, 51),
	(516, 537, 'Mx6', 2000, 51),
	(517, 538, '929', 2000, 51),
	(518, 539, 'Cx5', 2000, 51),
	(519, 540, 'Clase C', 2000, 52),
	(520, 541, 'Clase E', 2000, 52),
	(521, 542, 'Clase Sl', 2000, 52),
	(522, 543, 'Clase S', 2000, 52),
	(523, 544, 'Clase Cl', 2000, 52),
	(524, 545, 'Clase G', 2000, 52),
	(525, 546, 'Clase Slk', 2000, 52),
	(526, 547, 'Clase V', 2000, 52),
	(527, 548, 'Viano', 2000, 52),
	(528, 549, 'Clase Clk', 2000, 52),
	(529, 550, 'Clase A', 2000, 52),
	(530, 551, 'Clase M', 2000, 52),
	(531, 552, 'Vaneo', 2000, 52),
	(532, 553, 'Slklasse', 2000, 52),
	(533, 554, 'Slr Mclaren', 2000, 52),
	(534, 555, 'Clase Cls', 2000, 52),
	(535, 556, 'Clase R', 2000, 52),
	(536, 557, 'Clase Gl', 2000, 52),
	(537, 558, 'Clase B', 2000, 52),
	(538, 559, '100d', 2000, 52),
	(539, 560, '140d', 2000, 52),
	(540, 561, '180d', 2000, 52),
	(541, 562, 'Sprinter', 2000, 52),
	(542, 563, 'Vito', 2000, 52),
	(543, 564, 'Transporter', 2000, 52),
	(544, 565, '280', 2000, 52),
	(545, 566, '220', 2000, 52),
	(546, 568, '190', 2000, 52),
	(547, 570, '400', 2000, 52),
	(548, 571, 'Clase Sl R129', 2000, 52),
	(549, 572, '300', 2000, 52),
	(550, 574, '420', 2000, 52),
	(551, 575, '260', 2000, 52),
	(552, 576, '230', 2000, 52),
	(553, 577, 'Clase Clc', 2000, 52),
	(554, 578, 'Clase Glk', 2000, 52),
	(555, 579, 'Sls Amg', 2000, 52),
	(556, 580, 'Mgf', 2000, 53),
	(557, 581, 'Tf', 2000, 53),
	(558, 582, 'Zr', 2000, 53),
	(559, 583, 'Zs', 2000, 53),
	(560, 584, 'Zt', 2000, 53),
	(561, 585, 'Ztt', 2000, 53),
	(562, 587, 'Countryman', 2000, 53),
	(563, 588, 'Paceman', 2000, 53),
	(564, 589, 'Montero', 2000, 55),
	(565, 590, 'Galant', 2000, 55),
	(566, 591, 'Colt', 2000, 55),
	(567, 592, 'Space Wagon', 2000, 55),
	(568, 593, 'Space Runner', 2000, 55),
	(569, 594, 'Space Gear', 2000, 55),
	(570, 595, '3000 Gt', 2000, 55),
	(571, 596, 'Carisma', 2000, 55),
	(572, 597, 'Eclipse', 2000, 55),
	(573, 598, 'Space Star', 2000, 55),
	(574, 599, 'Montero Sport', 2000, 55),
	(575, 600, 'Montero Io', 2000, 55),
	(576, 601, 'Outlander', 2000, 55),
	(577, 602, 'Lancer', 2000, 55),
	(578, 603, 'Grandis', 2000, 55),
	(579, 604, 'L200', 2000, 55),
	(580, 605, 'Canter', 2000, 55),
	(581, 606, '300 Gt', 2000, 55),
	(582, 607, 'Asx', 2000, 55),
	(583, 608, 'Imiev', 2000, 55),
	(584, 609, '44', 2000, 56),
	(585, 610, 'Plus 8', 2000, 56),
	(586, 611, 'Aero 8', 2000, 56),
	(587, 612, 'V6', 2000, 56),
	(588, 613, 'Roadster', 2000, 56),
	(589, 614, '4', 2000, 56),
	(590, 615, 'Plus 4', 2000, 56),
	(591, 616, 'Terrano Ii', 2000, 57),
	(592, 617, 'Terrano', 2000, 57),
	(593, 618, 'Micra', 2000, 57),
	(594, 619, 'Sunny', 2000, 57),
	(595, 620, 'Primera', 2000, 57),
	(596, 621, 'Serena', 2000, 57),
	(597, 622, 'Patrol', 2000, 57),
	(598, 623, 'Maxima Qx', 2000, 57),
	(599, 624, '200 Sx', 2000, 57),
	(600, 625, '300 Zx', 2000, 57),
	(601, 626, 'Patrol Gr', 2000, 57),
	(602, 627, '100 Nx', 2000, 57),
	(603, 628, 'Almera', 2000, 57),
	(604, 629, 'Pathfinder', 2000, 57),
	(605, 630, 'Almera Tino', 2000, 57),
	(606, 631, 'Xtrail', 2000, 57),
	(607, 632, '350z', 2000, 57),
	(608, 633, 'Murano', 2000, 57),
	(609, 634, 'Note', 2000, 57),
	(610, 635, 'Qashqai', 2000, 57),
	(611, 636, 'Tiida', 2000, 57),
	(612, 637, 'Vanette', 2000, 57),
	(613, 638, 'Trade', 2000, 57),
	(614, 639, 'Vanette Cargo', 2000, 57),
	(615, 640, 'Pickup', 2000, 57),
	(616, 641, 'Navara', 2000, 57),
	(617, 642, 'Cabstar E', 2000, 57),
	(618, 643, 'Cabstar', 2000, 57),
	(619, 644, 'Maxima', 2000, 57),
	(620, 645, 'Camion', 2000, 57),
	(621, 646, 'Prairie', 2000, 57),
	(622, 647, 'Bluebird', 2000, 57),
	(623, 648, 'Np300 Pick Up', 2000, 57),
	(624, 649, 'Qashqai2', 2000, 57),
	(625, 650, 'Pixo', 2000, 57),
	(626, 651, 'Gtr', 2000, 57),
	(627, 652, '370z', 2000, 57),
	(628, 653, 'Cube', 2000, 57),
	(629, 654, 'Juke', 2000, 57),
	(630, 655, 'Leaf', 2000, 57),
	(631, 656, 'Evalia', 2000, 57),
	(632, 657, 'Astra', 2000, 58),
	(633, 658, 'Vectra', 2000, 58),
	(634, 659, 'Calibra', 2000, 58),
	(635, 660, 'Corsa', 2000, 58),
	(636, 661, 'Omega', 2000, 58),
	(637, 662, 'Frontera', 2000, 58),
	(638, 663, 'Tigra', 2000, 58),
	(639, 664, 'Monterey', 2000, 58),
	(640, 665, 'Sintra', 2000, 58),
	(641, 666, 'Zafira', 2000, 58),
	(642, 667, 'Agila', 2000, 58),
	(643, 668, 'Speedster', 2000, 58),
	(644, 669, 'Signum', 2000, 58),
	(645, 670, 'Meriva', 2000, 58),
	(646, 671, 'Antara', 2000, 58),
	(647, 673, 'Combo', 2000, 58),
	(648, 674, 'Movano', 2000, 58),
	(649, 675, 'Vivaro', 2000, 58),
	(650, 676, 'Kadett', 2000, 58),
	(651, 677, 'Monza', 2000, 58),
	(652, 678, 'Senator', 2000, 58),
	(653, 679, 'Rekord', 2000, 58),
	(654, 680, 'Manta', 2000, 58),
	(655, 681, 'Ascona', 2000, 58),
	(656, 682, 'Insignia', 2000, 58),
	(657, 683, 'Zafira Tourer', 2000, 58),
	(658, 684, 'Ampera', 2000, 58),
	(659, 685, 'Mokka', 2000, 58),
	(660, 686, 'Adam', 2000, 58),
	(661, 687, '306', 2000, 59),
	(662, 688, '605', 2000, 59),
	(663, 689, '106', 2000, 59),
	(664, 690, '205', 2000, 59),
	(665, 691, '405', 2000, 59),
	(666, 692, '406', 2000, 59),
	(667, 693, '806', 2000, 59),
	(668, 694, '807', 2000, 59),
	(669, 695, '407', 2000, 59),
	(670, 696, '307', 2000, 59),
	(671, 697, '206', 2000, 59),
	(672, 698, '607', 2000, 59),
	(673, 699, '308', 2000, 59),
	(674, 700, '307 Sw', 2000, 59),
	(675, 701, '206 Sw', 2000, 59),
	(676, 702, '407 Sw', 2000, 59),
	(677, 703, '1007', 2000, 59),
	(678, 704, '107', 2000, 59),
	(679, 705, '207', 2000, 59),
	(680, 706, '4007', 2000, 59),
	(681, 707, 'Boxer', 2000, 59),
	(682, 708, 'Partner', 2000, 59),
	(683, 709, 'J5', 2000, 59),
	(684, 710, '604', 2000, 59),
	(685, 711, '505', 2000, 59),
	(686, 712, '309', 2000, 59),
	(687, 713, 'Bipper', 2000, 59),
	(688, 714, 'Partner Origin', 2000, 59),
	(689, 715, '3008', 2000, 59),
	(690, 716, '5008', 2000, 59),
	(691, 717, 'Rcz', 2000, 59),
	(692, 718, '508', 2000, 59),
	(693, 719, 'Ion', 2000, 59),
	(694, 720, '208', 2000, 59),
	(695, 721, '4008', 2000, 59),
	(696, 723, 'Firebird', 2000, 60),
	(697, 724, 'Trans Am', 2000, 60),
	(698, 725, '911', 2000, 61),
	(699, 726, 'Boxster', 2000, 61),
	(700, 727, 'Cayenne', 2000, 61),
	(701, 728, 'Carrera Gt', 2000, 61),
	(702, 729, 'Cayman', 2000, 61),
	(703, 730, '928', 2000, 61),
	(704, 731, '968', 2000, 61),
	(705, 732, '944', 2000, 61),
	(706, 733, '924', 2000, 61),
	(707, 734, 'Panamera', 2000, 61),
	(708, 735, '918', 2000, 61),
	(709, 736, 'Megane', 2000, 62),
	(710, 737, 'Safrane', 2000, 62),
	(711, 738, 'Laguna', 2000, 62),
	(712, 739, 'Clio', 2000, 62),
	(713, 740, 'Twingo', 2000, 62),
	(714, 741, 'Nevada', 2000, 62),
	(715, 742, 'Espace', 2000, 62),
	(716, 744, 'Scenic', 2000, 62),
	(717, 745, 'Grand Espace', 2000, 62),
	(718, 746, 'Avantime', 2000, 62),
	(719, 747, 'Vel Satis', 2000, 62),
	(720, 748, 'Grand Scenic', 2000, 62),
	(721, 749, 'Clio Campus', 2000, 62),
	(722, 750, 'Modus', 2000, 62),
	(723, 751, 'Express', 2000, 62),
	(724, 752, 'Trafic', 2000, 62),
	(725, 753, 'Master', 2000, 62),
	(726, 754, 'Kangoo', 2000, 62),
	(727, 755, 'Mascott', 2000, 62),
	(728, 756, 'Master Propulsion', 2000, 62),
	(729, 757, 'Maxity', 2000, 62),
	(730, 758, 'R19', 2000, 62),
	(731, 759, 'R25', 2000, 62),
	(732, 760, 'R5', 2000, 62),
	(733, 761, 'R21', 2000, 62),
	(734, 762, 'R4', 2000, 62),
	(735, 763, 'Alpine', 2000, 62),
	(736, 764, 'Fuego', 2000, 62),
	(737, 765, 'R18', 2000, 62),
	(738, 766, 'R11', 2000, 62),
	(739, 767, 'R9', 2000, 62),
	(740, 768, 'R6', 2000, 62),
	(741, 769, 'Grand Modus', 2000, 62),
	(742, 770, 'Kangoo Combi', 2000, 62),
	(743, 771, 'Koleos', 2000, 62),
	(744, 772, 'Fluence', 2000, 62),
	(745, 773, 'Wind', 2000, 62),
	(746, 774, 'Latitude', 2000, 62),
	(747, 775, 'Grand Kangoo Combi', 2000, 62),
	(748, 776, 'Siver Dawn', 2000, 63),
	(749, 777, 'Silver Spur', 2000, 63),
	(750, 778, 'Park Ward', 2000, 63),
	(751, 779, 'Silver Seraph', 2000, 63),
	(752, 780, 'Corniche', 2000, 63),
	(753, 781, 'Phantom', 2000, 63),
	(754, 782, 'Touring', 2000, 63),
	(755, 783, 'Silvier', 2000, 63),
	(756, 784, '800', 2000, 64),
	(757, 790, '45', 2000, 64),
	(758, 792, '25', 2000, 64),
	(759, 795, 'Streetwise', 2000, 64),
	(760, 796, 'Sd', 2000, 64),
	(761, 797, '900', 2000, 65),
	(762, 798, '93', 2000, 65),
	(763, 799, '9000', 2000, 65),
	(764, 800, '95', 2000, 65),
	(765, 801, '93x', 2000, 65),
	(766, 802, '94x', 2000, 65),
	(767, 804, '350', 2000, 66),
	(768, 805, 'Anibal', 2000, 66),
	(769, 806, 'Anibal Pick Up', 2000, 66),
	(770, 807, 'Ibiza', 2000, 67),
	(771, 808, 'Cordoba', 2000, 67),
	(772, 809, 'Toledo', 2000, 67),
	(773, 810, 'Marbella', 2000, 67),
	(774, 811, 'Alhambra', 2000, 67),
	(775, 812, 'Arosa', 2000, 67),
	(776, 813, 'Leon', 2000, 67),
	(777, 814, 'Altea', 2000, 67),
	(778, 815, 'Altea Xl', 2000, 67),
	(779, 816, 'Altea Freetrack', 2000, 67),
	(780, 817, 'Terra', 2000, 67),
	(781, 818, 'Inca', 2000, 67),
	(782, 819, 'Malaga', 2000, 67),
	(783, 820, 'Ronda', 2000, 67),
	(784, 821, 'Exeo', 2000, 67),
	(785, 822, 'Mii', 2000, 67),
	(786, 823, 'Felicia', 2000, 68),
	(787, 824, 'Forman', 2000, 68),
	(788, 825, 'Octavia', 2000, 68),
	(789, 826, 'Octavia Tour', 2000, 68),
	(790, 827, 'Fabia', 2000, 68),
	(791, 828, 'Superb', 2000, 68),
	(792, 829, 'Roomster', 2000, 68),
	(793, 830, 'Scout', 2000, 68),
	(794, 832, 'Favorit', 2000, 68),
	(795, 833, '130', 2000, 68),
	(796, 834, 'S', 2000, 68),
	(797, 835, 'Yeti', 2000, 68),
	(798, 836, 'Citigo', 2000, 68),
	(799, 837, 'Rapid', 2000, 68),
	(800, 838, 'Smart', 2000, 69),
	(801, 839, 'Citycoupe', 2000, 69),
	(802, 840, 'Fortwo', 2000, 69),
	(803, 841, 'Cabrio', 2000, 69),
	(804, 842, 'Crossblade', 2000, 69),
	(805, 844, 'Forfour', 2000, 69),
	(806, 845, 'Korando', 2000, 70),
	(807, 846, 'Family', 2000, 70),
	(808, 847, 'K4d', 2000, 70),
	(809, 848, 'Musso', 2000, 70),
	(810, 849, 'Korando Kj', 2000, 70),
	(811, 850, 'Rexton', 2000, 70),
	(812, 851, 'Rexton Ii', 2000, 70),
	(813, 852, 'Rodius', 2000, 70),
	(814, 853, 'Kyron', 2000, 70),
	(815, 854, 'Actyon', 2000, 70),
	(816, 855, 'Sports Pick Up', 2000, 70),
	(817, 856, 'Actyon Sports Pick Up', 2000, 70),
	(818, 857, 'Kodando', 2000, 70),
	(819, 858, 'Legacy', 2000, 71),
	(820, 859, 'Impreza', 2000, 71),
	(821, 860, 'Svx', 2000, 71),
	(822, 861, 'Justy', 2000, 71),
	(823, 862, 'Outback', 2000, 71),
	(824, 863, 'Forester', 2000, 71),
	(825, 864, 'G3x Justy', 2000, 71),
	(826, 865, 'B9 Tribeca', 2000, 71),
	(827, 866, 'Xt', 2000, 71),
	(828, 867, '1800', 2000, 71),
	(829, 868, 'Tribeca', 2000, 71),
	(830, 869, 'Wrx Sti', 2000, 71),
	(831, 870, 'Trezia', 2000, 71),
	(832, 871, 'Xv', 2000, 71),
	(833, 872, 'Brz', 2000, 71),
	(834, 873, 'Maruti', 2000, 72),
	(835, 874, 'Swift', 2000, 72),
	(836, 875, 'Vitara', 2000, 72),
	(837, 876, 'Baleno', 2000, 72),
	(838, 877, 'Samurai', 2000, 72),
	(839, 878, 'Alto', 2000, 72),
	(840, 879, 'Wagon R', 2000, 72),
	(841, 880, 'Jimny', 2000, 72),
	(842, 881, 'Grand Vitara', 2000, 72),
	(843, 882, 'Ignis', 2000, 72),
	(844, 883, 'Liana', 2000, 72),
	(845, 884, 'Grand Vitara Xl7', 2000, 72),
	(846, 885, 'Sx4', 2000, 72),
	(847, 886, 'Splash', 2000, 72),
	(848, 887, 'Kizashi', 2000, 72),
	(849, 888, 'Samba', 2000, 73),
	(850, 889, 'Tagora', 2000, 73),
	(851, 890, 'Solara', 2000, 73),
	(852, 891, 'Horizon', 2000, 73),
	(853, 892, 'Telcosport', 2000, 74),
	(854, 893, 'Telco', 2000, 74),
	(855, 894, 'Sumo', 2000, 74),
	(856, 895, 'Safari', 2000, 74),
	(857, 896, 'Indica', 2000, 74),
	(858, 897, 'Indigo', 2000, 74),
	(859, 898, 'Grand Safari', 2000, 74),
	(860, 899, 'Tl Pick Up', 2000, 74),
	(861, 900, 'Xenon Pick Up', 2000, 74),
	(862, 901, 'Vista', 2000, 74),
	(863, 902, 'Xenon', 2000, 74),
	(864, 903, 'Aria', 2000, 74),
	(865, 904, 'Carina E', 2000, 75),
	(866, 905, '4runner', 2000, 75),
	(867, 906, 'Camry', 2000, 75),
	(868, 907, 'Rav4', 2000, 75),
	(869, 908, 'Celica', 2000, 75),
	(870, 909, 'Supra', 2000, 75),
	(871, 910, 'Paseo', 2000, 75),
	(872, 911, 'Land Cruiser 80', 2000, 75),
	(873, 912, 'Land Cruiser 100', 2000, 75),
	(874, 913, 'Land Cruiser', 2000, 75),
	(875, 914, 'Land Cruiser 90', 2000, 75),
	(876, 915, 'Corolla', 2000, 75),
	(877, 916, 'Auris', 2000, 75),
	(878, 917, 'Avensis', 2000, 75),
	(879, 918, 'Picnic', 2000, 75),
	(880, 919, 'Yaris', 2000, 75),
	(881, 920, 'Yaris Verso', 2000, 75),
	(882, 921, 'Mr2', 2000, 75),
	(883, 922, 'Previa', 2000, 75),
	(884, 923, 'Prius', 2000, 75),
	(885, 924, 'Avensis Verso', 2000, 75),
	(886, 925, 'Corolla Verso', 2000, 75),
	(887, 926, 'Corolla Sedan', 2000, 75),
	(888, 927, 'Aygo', 2000, 75),
	(889, 928, 'Hilux', 2000, 75),
	(890, 929, 'Dyna', 2000, 75),
	(891, 930, 'Land Cruiser 200', 2000, 75),
	(892, 931, 'Verso', 2000, 75),
	(893, 932, 'Iq', 2000, 75),
	(894, 933, 'Urban Cruiser', 2000, 75),
	(895, 934, 'Gt86', 2000, 75),
	(896, 938, '110 Stawra', 2000, 77),
	(897, 939, '111 Stawra', 2000, 77),
	(898, 940, '215', 2000, 77),
	(899, 941, '112 Stawra', 2000, 77),
	(900, 942, 'Passat', 2000, 78),
	(901, 943, 'Golf', 2000, 78),
	(902, 944, 'Vento', 2000, 78),
	(903, 945, 'Polo', 2000, 78),
	(904, 946, 'Corrado', 2000, 78),
	(905, 947, 'Sharan', 2000, 78),
	(906, 948, 'Lupo', 2000, 78),
	(907, 949, 'Bora', 2000, 78),
	(908, 950, 'Jetta', 2000, 78),
	(909, 951, 'New Beetle', 2000, 78),
	(910, 952, 'Phaeton', 2000, 78),
	(911, 953, 'Touareg', 2000, 78),
	(912, 954, 'Touran', 2000, 78),
	(913, 955, 'Multivan', 2000, 78),
	(914, 956, 'Caddy', 2000, 78),
	(915, 957, 'Golf Plus', 2000, 78),
	(916, 958, 'Fox', 2000, 78),
	(917, 959, 'Eos', 2000, 78),
	(918, 960, 'Caravelle', 2000, 78),
	(919, 961, 'Tiguan', 2000, 78),
	(920, 963, 'Lt', 2000, 78),
	(921, 964, 'Taro', 2000, 78),
	(922, 965, 'Crafter', 2000, 78),
	(923, 967, 'Santana', 2000, 78),
	(924, 968, 'Scirocco', 2000, 78),
	(925, 969, 'Passat Cc', 2000, 78),
	(926, 970, 'Amarok', 2000, 78),
	(927, 971, 'Beetle', 2000, 78),
	(928, 972, 'Up', 2000, 78),
	(929, 973, 'Cc', 2000, 78),
	(930, 974, '440', 2000, 79),
	(931, 975, '850', 2000, 79),
	(932, 976, 'S70', 2000, 79),
	(933, 977, 'V70', 2000, 79),
	(934, 978, 'V70 Classic', 2000, 79),
	(935, 979, '940', 2000, 79),
	(936, 980, '480', 2000, 79),
	(937, 981, '460', 2000, 79),
	(938, 982, '960', 2000, 79),
	(939, 983, 'S90', 2000, 79),
	(940, 984, 'V90', 2000, 79),
	(941, 985, 'Classic', 2000, 79),
	(942, 986, 'S40', 2000, 79),
	(943, 987, 'V40', 2000, 79),
	(944, 988, 'V50', 2000, 79),
	(945, 989, 'V70 Xc', 2000, 79),
	(946, 990, 'Xc70', 2000, 79),
	(947, 991, 'C70', 2000, 79),
	(948, 992, 'S80', 2000, 79),
	(949, 993, 'S60', 2000, 79),
	(950, 994, 'Xc90', 2000, 79),
	(951, 995, 'C30', 2000, 79),
	(952, 996, '780', 2000, 79),
	(953, 997, '760', 2000, 79),
	(954, 998, '740', 2000, 79),
	(955, 999, '240', 2000, 79),
	(956, 1001, '340', 2000, 79),
	(957, 1002, 'Xc60', 2000, 79),
	(958, 1003, 'V60', 2000, 79),
	(959, 1004, 'V40 Cross Country', 2000, 79),
	(960, 1005, '353', 2000, 80);
/*!40000 ALTER TABLE `modelo` ENABLE KEYS */;

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

-- Volcando estructura para procedimiento repuestos.ModificarDetalleFabricacion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarDetalleFabricacion`(
	IN `p0` int(10),
	IN `p1` DECIMAL(7,3),
	IN `p2` DATE,
	IN `p3` varchar(5),
	IN `p4` varchar(5),
	IN `p5` int(11),
	IN `p6` int(11),
	IN `p7` int(11),
	IN `p8` varchar(45),
	IN `p9` int(11),
	IN `p10` int(11),
	IN `p11` decimal(8,1),
	IN `p12` int(11),
	IN `p13` varchar(100),
	IN `p14` varchar(100),
	IN `p15` int(11)



,
	IN `p16` DECIMAL(8,1)


,
	IN `p18` INT(1),
	IN `p19` DECIMAL(10,2)
,
	IN `p20` INT
)
BEGIN
START TRANSACTION;
UPDATE detalleFabricacion df
SET
pesoMetro=p1,
fecha=p2,
horaInicio=p3,
horaFin=p4,
puesto_ID=p5,
turno_ID=p6,
Aleacion_ID=p7,
colada=p8,
largoTocho=p9,
cantidadTochos=p10,
kgs=p11,
tiras=p12,
largoPerfil=p13,
observaciones=p14,
matriz_ID=p15,
diamTocho = p18,
kgPrensa = p19

where df.ID= p0;



UPDATE matriz m
SET  
pesoActual = p1 ,
kgAcumulados  =  m.KgAcumulados + p11-p16,
KgAcumDesdeNit = m.KgAcumDesdeNit + p11-p16

where ID=p15;

UPDATE articulo 
SET  
Puesto_ID = p5
where ID = 

(select  p.Articulo_ID
from pedido p
where p.ID = p20)
;

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

-- Volcando estructura para procedimiento repuestos.ModificarMatriz
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarMatriz`(
	IN `p1` int,
	IN `p2` INT,
	IN `p3` DECIMAL(7,4),
	IN `p4` int  ,
	IN `p5` int

,
	IN `p6` INT
,
	IN `p7` INT
,
	IN `p8` TINYINT
)
update matriz m
SET
cantidadSalidas = p2,
pesoActual =  p3,
Cliente_ID = p4,
EstadoMatriz_ID =  p5,
kgAcumulados =  p6,
KgAcumDesdeNit = p7,
Controlada = p8
where m.ID = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ModificarPedido
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ModificarPedido`(
	IN `p1` int ,
	IN `p2` int,
	IN `p3` date,
	IN `p4` decimal,
	IN `p5` varchar(45),
	IN `p6` varchar(100),
	IN `p7` int,
	IN `p8` int,
	IN `p9` int,
	IN `p10` int,
	IN `p11` int,
	IN `p12` int,
	IN `p13` int
,
	IN `P14` INT


)
BEGIN
START TRANSACTION;
UPDATE pedido p
SET  
numero = p2,
fecha = p3,
KgEstimados = p4,
OC = p5,
observaciones = p6,
cliente_ID = p7,
articulo_ID = p8,
unidad_ID = p9,
terminacion_ID = p10, 
prioridad_ID = p11,
aleacion_ID = p12,
temple_ID = p13,
matriz_ID = p14
where p.ID = p1;
COMMIT;
END//
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

-- Volcando estructura para tabla repuestos.nitrurado
CREATE TABLE IF NOT EXISTS `nitrurado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `matriz_ID` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `nitrurado_ibfk_1` (`matriz_ID`),
  CONSTRAINT `nitrurado_ibfk_1` FOREIGN KEY (`matriz_ID`) REFERENCES `matriz` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.nitrurado: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `nitrurado` DISABLE KEYS */;
/*!40000 ALTER TABLE `nitrurado` ENABLE KEYS */;

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

-- Volcando estructura para procedimiento repuestos.obtenerEjemplar
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerEjemplar`(
	IN `parametro` varchar(40)
)
select  id, concat('Ejemplar nº: ', ejemplar) as ejemplar
from matriz m
where m.Articulo_ID =  parametro//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ObtenerKgDia
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerKgDia`(
	IN `p1` date



)
select p.numero,c.Alias,a.descripcion,df.kgs,pu.descripcion,df.KgPrensa, df.largoTocho,df.cantidadTochos,df.diamTocho,df.horaFin,df.horaInicio
from detallefabricacion df
inner join puesto pu on df.Puesto_ID = pu.id
inner join pedido p on df.Pedido_ID = p.ID
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.id
where df.fecha = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ObtenerKgRango
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerKgRango`(
	IN `p1` date,
	IN `p2` date
)
select pd.fecha as fecha ,sum(pd.kgs) as kgs
from detallefabricacion pd
where pd.fecha>= p1 and pd.fecha<= p2


group by pd.fecha
order by pd.fecha//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.ObtenerMatriz
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObtenerMatriz`(
	IN `parametro1` int




)
BEGIN
select m.ID,concat('ejemplar nº ',ejemplar,' (',pesoactual,' kg/m)') as matriz,m.ejemplar,m.cantidadSalidas as salidas,m.pesoActual as peso,a.codigo,e.estado,c.ID as cliente,
 m.KgAcumulados as KgAcumulados, m.KgAcumDesdeNit as KgAcumulados2, m.Controlada
from matriz m
inner join articulo a on m.Articulo_ID= a.ID
inner join estadoMatriz e on m.EstadoMatriz_ID = e.ID
inner join cliente c on m.Cliente_ID  =  c.ID
where m.ID = parametro1
limit 1
;END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.obtenerProductosPorEstado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `obtenerProductosPorEstado`(IN p1 VARCHAR(50))
BEGIN
    SELECT * 
    FROM articulo a
    WHERE a.codigo = p1;
END//
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

-- Volcando estructura para tabla repuestos.pedido
CREATE TABLE IF NOT EXISTS `pedido` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `numero` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `kgEstimados` decimal(10,2) DEFAULT NULL,
  `OC` varchar(45) DEFAULT NULL,
  `Observaciones` varchar(100) DEFAULT NULL,
  `Cliente_ID` int(11) NOT NULL,
  `Articulo_ID` int(11) NOT NULL,
  `Unidad_ID` int(11) NOT NULL,
  `Terminacion_ID` int(11) NOT NULL,
  `Estado_ID` int(11) NOT NULL DEFAULT '1',
  `Prioridad_ID` int(11) NOT NULL,
  `Aleacion_ID` int(11) NOT NULL,
  `Temple_ID` int(11) NOT NULL,
  `Matriz_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `numero_UNIQUE` (`numero`),
  KEY `fk_Pedido_Cliente1_idx` (`Cliente_ID`),
  KEY `fk_Pedido_Articulo1_idx` (`Articulo_ID`),
  KEY `fk_Pedido_Unidad1_idx` (`Unidad_ID`),
  KEY `fk_Pedido_Terminacion1_idx` (`Terminacion_ID`),
  KEY `fk_Pedido_Estado1_idx` (`Estado_ID`),
  KEY `fk_Pedido_Prioridad1_idx` (`Prioridad_ID`),
  KEY `fK_Pedido_Aleacion1` (`Aleacion_ID`),
  KEY `fk_Pedido_Temple1` (`Temple_ID`),
  KEY `fk_Pedido_Matriz` (`Matriz_ID`),
  CONSTRAINT `fK_Pedido_Aleacion1` FOREIGN KEY (`Aleacion_ID`) REFERENCES `marca` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Articulo1` FOREIGN KEY (`Articulo_ID`) REFERENCES `articulo` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Cliente1` FOREIGN KEY (`Cliente_ID`) REFERENCES `cliente` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Estado1` FOREIGN KEY (`Estado_ID`) REFERENCES `estado` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Matriz` FOREIGN KEY (`Matriz_ID`) REFERENCES `matriz` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Prioridad1` FOREIGN KEY (`Prioridad_ID`) REFERENCES `prioridad` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Temple1` FOREIGN KEY (`Temple_ID`) REFERENCES `rubro` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Terminacion1` FOREIGN KEY (`Terminacion_ID`) REFERENCES `terminacion` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Unidad1` FOREIGN KEY (`Unidad_ID`) REFERENCES `unidad` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.pedido: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `pedido` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedido` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.pedidodetalle
CREATE TABLE IF NOT EXISTS `pedidodetalle` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `cantidad` int(11) NOT NULL,
  `largo` int(11) NOT NULL,
  `Pedido_ID` int(11) NOT NULL,
  `kgEstimados` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `fk_PedidoDetalle_Pedido1_idx` (`Pedido_ID`),
  CONSTRAINT `fk_PedidoDetalle_Pedido1` FOREIGN KEY (`Pedido_ID`) REFERENCES `pedido` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.pedidodetalle: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `pedidodetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `pedidodetalle` ENABLE KEYS */;

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

-- Volcando estructura para tabla repuestos.prioridad
CREATE TABLE IF NOT EXISTS `prioridad` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  `plazo` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.prioridad: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `prioridad` DISABLE KEYS */;
REPLACE INTO `prioridad` (`ID`, `Descripcion`, `plazo`) VALUES
	(1, '1 semana', 7),
	(2, '2 semanas', 14),
	(3, '3 semanas', 21),
	(4, '4 semanas', 28),
	(5, '5 semanas', 35),
	(6, '6 semanas', 42),
	(7, '7 semanas', 49),
	(8, '8 semanas', 56),
	(10, '9 semanas', 63);
/*!40000 ALTER TABLE `prioridad` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=832 DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

-- Volcando datos para la tabla repuestos.proveedor: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
REPLACE INTO `proveedor` (`ID`, `numero`, `Alias`, `razonSocial`, `cuit`, `telefono1`, `telefono2`, `email`, `Direccion_ID`, `Dir_Ent_ID`, `TipoDoc_ID`, `Iva_ID`) VALUES
	(830, 1, 'EL POSITIVO', 'EL POSITIVO', 1, '5274-7445', '5274-7446', NULL, 121, 122, 1, 1),
	(831, 2, 'REPUESTOS OMARCITO', 'REPUESTOS OMAR', 2, '4686-6567', '4686-6567', NULL, 123, 124, 1, 1);
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

-- Volcando estructura para procedimiento repuestos.Proyeccion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proyeccion`(
	IN `p1` DATE










,
	IN `p2` INT
)
BEGIN

select p.ID,p.numero,p.fecha,
ifnull (p.kgEstimados

-(SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p.id
GROUP BY dt.Pedido_ID
limit 1),p.kgEstimados )as kgPendientes,

c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,

ifnull (
(sum(pd.cantidad) / (select count(*)
from detallefabricacion dp 
inner join pedido pe on dp.Pedido_ID = pe.ID
where pe.numero = p.numero limit 1)),sum(pd.cantidad)) as cantidad,

 a.codigo as codigo, DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) AS proyeccion
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
left join detallefabricacion dt on dt.pedido_id=p.id
where a.Puesto_ID = p2 and e.ID< 4 and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) <= p1
group by p.ID 
order by  DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY),p.numero;

END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.proyeccion2
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `proyeccion2`(
	IN `p1` date




,
	IN `p2` INT
)
BEGIN

select p.ID,p.numero,p.fecha,
ifnull (p.kgEstimados

-(SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p.id
GROUP BY dt.Pedido_ID
limit 1),p.kgEstimados )as kgPendientes,

c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,

ifnull (
(sum(pd.cantidad) / (select count(*)
from detallefabricacion dp 
inner join pedido pe on dp.Pedido_ID = pe.ID
where pe.numero = p.numero limit 1)),sum(pd.cantidad)) as cantidad,


 a.codigo as codigo, DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) AS proyeccion
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
left join detallefabricacion dt on dt.pedido_id=p.id
where a.Puesto_ID = p2 and e.ID< 4 and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) <= p1 
              and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) >= CURDATE()
group by p.ID 
order by  DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY),p.numero;

END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.Proyeccion3
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `Proyeccion3`(
	IN `p1` DATE











)
BEGIN

select p.ID,p.numero,p.fecha,
ifnull (p.kgEstimados

-(SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p.id
GROUP BY dt.Pedido_ID
limit 1),p.kgEstimados )as kgPendientes,

c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,

ifnull (
(sum(pd.cantidad) / (select count(*)
from detallefabricacion dp 
inner join pedido pe on dp.Pedido_ID = pe.ID
where pe.numero = p.numero limit 1)),sum(pd.cantidad)) as cantidad,

 a.codigo as codigo, DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) AS proyeccion
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
left join detallefabricacion dt on dt.pedido_id=p.id
where e.ID< 4 and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) <= p1
group by p.ID 
order by  DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY),p.numero;

END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.proyeccion4
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `proyeccion4`(
	IN `p1` date





)
BEGIN

select p.ID,p.numero,p.fecha,
ifnull (p.kgEstimados

-(SELECT SUM(DT.KGS)
FROM DETALLEFABRICACION dt
WHERE dt.pedido_id = p.id
GROUP BY dt.Pedido_ID
limit 1),p.kgEstimados )as kgPendientes,

c.Alias as cliente ,a.descripcion as articulo,
u.Descripcion as unidad,t.Descripcion as terminacion ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,

ifnull (
(sum(pd.cantidad) / (select count(*)
from detallefabricacion dp 
inner join pedido pe on dp.Pedido_ID = pe.ID
where pe.numero = p.numero limit 1)),sum(pd.cantidad)) as cantidad,


 a.codigo as codigo, DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) AS proyeccion
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
left join detallefabricacion dt on dt.pedido_id=p.id
where  e.ID< 4 and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) <= p1 
              and DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY) >= CURDATE()
group by p.ID 
order by  DATE_ADD(p.fecha, INTERVAL (pr.plazo) DAY),p.numero;

END//
DELIMITER ;

-- Volcando estructura para tabla repuestos.puesto
CREATE TABLE IF NOT EXISTS `puesto` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `maquinista` varchar(50) NOT NULL,
  `encargado` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.puesto: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `puesto` DISABLE KEYS */;
REPLACE INTO `puesto` (`ID`, `descripcion`, `maquinista`, `encargado`) VALUES
	(1, 'Prensa 3', 'Alcaraz Adrian', 'Diomedez Alcaraz'),
	(2, 'Prensa 4', 'Alcaraz Adrian', 'Diomedez Alcaraz'),
	(3, 'Prensa 5', 'Alcaraz Adrian', 'Diomedez Alcaraz'),
	(5, 'Prensa Burzaco', 'Burello Nestor', 'Zapata Guillermo'),
	(6, 'Prensa 7', 'Diomedez Alcaraz', 'Adrian'),
	(7, 'Sin Asignar', ' ', ' ');
/*!40000 ALTER TABLE `puesto` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.reporteNitrurado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `reporteNitrurado`(
	IN `p0` int,
	IN `p1` int,
	IN `p2` int

)
select m.ID,c.Alias as Cliente,a.codigo as Codigo,a.descripcion as Articulo,m.ejemplar as Matriz,m.CantidadNitrurados as Nitrurados,m.KgAcumDesdeNit as KgAcumulados
from matriz m
inner join articulo a on m.Articulo_ID = a.id
inner join cliente c on m.Cliente_ID = c.id

where
-- condición 1
m.Controlada = true
and
m.CantidadNitrurados=0 
and
m.KgAcumDesdeNit >= p0
or
-- condición 2
m.Controlada = true
and
m.CantidadNitrurados=1 
and
m.KgAcumDesdeNit >= p1
or
-- condición 3
m.Controlada = true
and
m.CantidadNitrurados>1 
and
m.KgAcumDesdeNit >= p2

order by m.CantidadNitrurados, m.KgAcumDesdeNit//
DELIMITER ;

-- Volcando estructura para tabla repuestos.rubro
CREATE TABLE IF NOT EXISTS `rubro` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.rubro: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `rubro` DISABLE KEYS */;
REPLACE INTO `rubro` (`ID`, `descripcion`) VALUES
	(1, 'Tren Delantero'),
	(2, 'Tren Trasero'),
	(3, 'Amortiguación'),
	(4, 'Rodamientos'),
	(6, 'Correas y Bombas');
/*!40000 ALTER TABLE `rubro` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.terminacion
CREATE TABLE IF NOT EXISTS `terminacion` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.terminacion: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `terminacion` DISABLE KEYS */;
REPLACE INTO `terminacion` (`ID`, `Descripcion`) VALUES
	(1, 'Natural'),
	(2, 'Pintado Blanco'),
	(3, 'Pintado Negro'),
	(4, 'Pintado Bronce'),
	(5, 'Anod. Natural Mate'),
	(6, 'Anod. Negro'),
	(7, 'Pintado Blanco ALUAR'),
	(8, 'Ver Detalle'),
	(9, 'Pintado Gris');
/*!40000 ALTER TABLE `terminacion` ENABLE KEYS */;

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

-- Volcando estructura para tabla repuestos.topologia
CREATE TABLE IF NOT EXISTS `topologia` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.topologia: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `topologia` DISABLE KEYS */;
REPLACE INTO `topologia` (`ID`, `descripcion`) VALUES
	(1, 'SOLIDA'),
	(2, 'TUBULAR'),
	(3, 'SEMI-TUBO');
/*!40000 ALTER TABLE `topologia` ENABLE KEYS */;

-- Volcando estructura para tabla repuestos.turno
CREATE TABLE IF NOT EXISTS `turno` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(45) NOT NULL,
  `horarioInicio` varchar(45) NOT NULL,
  `horarioFin` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `descripcion_UNIQUE` (`descripcion`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.turno: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
REPLACE INTO `turno` (`ID`, `descripcion`, `horarioInicio`, `horarioFin`) VALUES
	(1, 'Mañana', '6:00 ', '14:00'),
	(2, 'Tarde', '14:00', '22:00'),
	(3, 'Noche', '22:00', '6:00');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla repuestos.usuario: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
REPLACE INTO `usuario` (`ID`, `usuario`, `clave`, `verCliente`, `verArchivo`, `verArticulos`, `verPedidos`, `verMatrices`, `verUsuarios`, `verReportes`, `altaArticulos`, `bajaArticulos`, `modificaArticulos`, `altaClientes`, `modificaClientes`, `altaPedidos`, `modificaPedidos`, `detallePedidos`, `altaMatrices`, `modificaMatrices`, `nitruradoMatrices`) VALUES
	(1, 'Rodrigo', '1234', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
	(2, 'Facturacion', 'factura', 0, 1, 1, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0),
	(4, 'Administrador', 'admin1234', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para procedimiento repuestos.verCompatibilidad
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verCompatibilidad`(
	IN `p1` int
)
select mv.descripcion,m.descripcion,m.`año`
from compatibilidad c
inner join modelo m on c.Modelo_ID = m.ID
inner join marcaVehiculo mv on m.Marca_ID = mv.id
where c.Articulo_ID = p1//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.VerDetalleFabricacion
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `VerDetalleFabricacion`(
	IN `p1` int



)
BEGIN
select dt.ID,p.numero,dt.fecha,c.Alias,a.descripcion,dt.matriz_ID,dt.pesoMetro,pt.descripcion,
t.descripcion,al.descripcion,dt.colada,dt.largoTocho,dt.cantidadTochos,dt.horaInicio,
dt.horaFin,dt.kgs,dt.tiras,dt.largoPerfil,dt.observaciones,dt.diamTocho,dt.KgPrensa
from detallefabricacion dt
inner join puesto pt on dt.Puesto_ID = pt.ID
inner join aleacion al on dt.Aleacion_ID = al.ID
inner join turno t on dt.turno_ID =t.id
inner join pedido p on dt.pedido_ID = p.ID
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.articulo_ID = a.ID
where p.numero = p1
order by dt.ID 
;END//
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

-- Volcando estructura para procedimiento repuestos.VerEstado
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `VerEstado`(
	IN `p1` varchar(40)
)
BEGIN
SELECT P.ID,E.DESCRIPCION
FROM PEDIDO P
INNER JOIN ESTADO E ON P.ESTADO_ID = E.ID
WHERE P.NUMERO = p1
;END//
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

-- Volcando estructura para procedimiento repuestos.VerMatricesPesadas
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `VerMatricesPesadas`()
select m.ID, c.Alias as Cliente,a.codigo as Codigo, a.descripcion  as Perfil, m.ejemplar as Ejemplar, a.pesoNominal as Peso_Plano, m.pesoActual as Peso_Actual
from matriz m
inner join articulo a on m.Articulo_ID = a.ID
inner join cliente c on a.Cliente_ID = c.id
where a.pesoNominal>0 and m.pesoActual > (a.pesoNominal+ a.pesoNominal*(a.tolerancia/100))//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verMatriz
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verMatriz`(
	IN `parametro1` VARCHAR(50)







)
BEGIN
select m.ID,concat('ejemplar nº ',ejemplar,' (',pesoactual,' kg/m) (',m.cantidadSalidas,' salidas)') as matriz,m.ejemplar,m.cantidadSalidas as salidas,m.pesoActual as peso,a.codigo,e.estado
from matriz m
inner join articulo a on m.Articulo_ID= a.ID
inner join estadoMatriz e on m.EstadoMatriz_ID = e.ID
where a.codigo = parametro1 and m.EstadoMatriz_ID <3
order by m.pesoActual desc
;END//
DELIMITER ;

-- Volcando estructura para procedimiento repuestos.verPedidos
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `verPedidos`(
	IN `param1` INT,
	IN `param2` varchar(40),
	IN `fecha1` date ,
	IN `fecha2` date



)
BEGIN
select p.ID,p.numero,p.fecha,p.kgEstimados,p.OC,p.Observaciones,c.Alias as cliente ,a.descripcion as aleacion,
u.Descripcion as unidad,t.Descripcion as temple ,e.Descripcion as estado ,pr.Descripcion as prioridad ,al.descripcion as aleacion ,tp.descripcion as temple,
pd.largo,sum(pd.cantidad) as cantidad,count(*) as detalle
from pedido p
inner join cliente c on p.Cliente_ID = c.ID
inner join articulo a on p.Articulo_ID = a.ID
inner join unidad u on p.Unidad_ID = u.ID
inner join terminacion t on p.Terminacion_ID = t.ID
inner join estado e on p.Estado_ID = e.ID

inner join prioridad pr on p.Prioridad_ID = pr.ID
inner join aleacion al on p.Aleacion_ID = al.ID
inner join temple tp on p.Temple_ID = tp.ID
inner join pedidodetalle pd on pd.Pedido_ID = p.ID
where e.ID< param1 
and c.Alias like param2
and p.fecha >= fecha1
and p.fecha <= fecha2

group by p.ID 
order by p.numero
;END//
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
