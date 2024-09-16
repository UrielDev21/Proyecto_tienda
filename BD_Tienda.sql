-- Creacion de la tabla  --
CREATE TABLE producto
(
    id_producto int PRIMARY KEY auto_increment,
    nombre varchar(255),
    descripcion varchar(255),
    precio DECIMAL(5,2)
); 

describe producto; 

-- Procedimiento almacenado para insertar productos --
drop PROCEDURE if EXISTS p_insertar_productos; 
create PROCEDURE p_insertar_productos
(
    in _nombre varchar(255),
    in _descripcion varchar(255),
    in _precio decimal(5,2)
)
begin   
    insert into producto(nombre, descripcion, precio) values 
    (_nombre, _descripcion, _precio);
end; 

-- Procedimiento almacenado para modificar productos --
create procedure p_modificar_productos
(
    in _id_producto int,
    in _nombre varchar(255),
    in _descripcion varchar(255),
    in _precio decimal(5,2)
)
begin 
    update producto set nombre = _nombre, descripcion = _descripcion, precio = _precio
    where id_producto = _id_producto; 
end; 

-- Procedimiento almacenado para eliminar productos --
create procedure p_eliminar_productos
(
    in _id_producto int 
)
begin
    delete from producto 
    where id_producto = _id_producto; 
end; 

-- Pruebas de funcionamiento de los productos --

call p_insertar_productos('Coca cola', 'Refresco de la marca Coca-Cola', 37.00);
select * from producto; 
call p_modificar_productos(1, 'Coca cola', 'Refresco de la marca Coca Cola', 20.50); 
call p_eliminar_productos(1); 

-- Consulta que sera usada en el programa --
select * from producto where nombre like '%coquita%'; 