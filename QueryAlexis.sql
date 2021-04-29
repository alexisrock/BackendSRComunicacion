

Create table Roles(
idRol int identity primary key not null,
Descripcion nvarchar(300) not null
)


CREATE TABLE Usuarios(
idUser int identity primary key not null,
documento nvarchar(200) not null,
username nvarchar(300) not null,
contrasena nvarchar(500) not null,
idrol int,
foreign key(idrol)
references Roles(idRol)
)

create table TipoRemDes(
idTipoRemDes int identity primary key not null,
Descripcion nvarchar(300)
)

Create Table RemDes(
idremitente int identity primary key not null,
documento nvarchar(200) not null,
nombres nvarchar(200) not null,
apellidos  nvarchar(200) not null,
direccion nvarchar(300) not null,
telefono nvarchar(300),
idTipoRemDes int,
foreign key(idTipoRemDes) 
references TipoRemDes(idTipoRemDes)
)


create table Correspondencia(
idCorrespondencia nvarchar(100) primary key,
idRemitente int,
idDestinatario int,
rutaArchivo nvarchar(max),
observacion nvarchar(200),
idusuariocreacion int,
fechaCreacion datetime,
idusuarioactualizacion int,
fechaactualizacion datetime,
foreign key(idRemitente)
references RemDes(idremitente),
foreign key(idDestinatario)
references RemDes(idremitente),
foreign key(idusuariocreacion)
references Usuarios(idUser),
foreign key(idusuarioactualizacion)
references Usuarios(idUser)
)


create table Auditoria(
id int identity primary key,
idRemitente int,
idDestinatario int,
rutaArchivo nvarchar(max),
observacion nvarchar(200),
idusuariocreacion int,
fechaCreacion datetime,
idusuarioactualizacion int,
fechaactualizacion datetime,
fecha datetime,
typeMov  VARCHAR(25)
);



create trigger tgAuditoria 
	ON Correspondencia
	after INSERT 
	as
	    BEGIN  			
			 INSERT INTO Auditoria
				select idRemitente
				  ,[idDestinatario]
				  ,[rutaArchivo]
				  ,[observacion]
				  ,[idusuariocreacion]
				  ,[fechaCreacion]
				  ,[idusuarioactualizacion]
				  ,[fechaactualizacion]
				,getdate(),
						'insert'	
				FROM Inserted				
		END;

			

create trigger tgAuditoriaupdate
	ON Correspondencia
	after update 
	as
	    BEGIN  			
			 INSERT INTO Auditoria
				select idRemitente
				  ,[idDestinatario]
				  ,[rutaArchivo]
				  ,[observacion]
				  ,[idusuariocreacion]
				  ,[fechaCreacion]
				  ,[idusuarioactualizacion]
				  ,[fechaactualizacion]
				,getdate(),
						'Before Update'	
				FROM deleted;
				INSERT INTO Auditoria
				select idRemitente
				  ,[idDestinatario]
				  ,[rutaArchivo]
				  ,[observacion]
				  ,[idusuariocreacion]
				  ,[fechaCreacion]
				  ,[idusuarioactualizacion]
				  ,[fechaactualizacion]
				,getdate(),
				'After Update'	
				FROM Inserted					
		END;

	

create trigger tgAuditoriaDelete
	ON Correspondencia
	after delete 
	as
	    BEGIN  			
			 INSERT INTO Auditoria
				select idRemitente
				  ,[idDestinatario]
				  ,[rutaArchivo]
				  ,[observacion]
				  ,[idusuariocreacion]
				  ,[fechaCreacion]
				  ,[idusuarioactualizacion]
				  ,[fechaactualizacion]
				,getdate(),
						'Delete'	
				FROM deleted				
		END;

		
		
create PROCEDURE  spAddCorrespondencia 
@idRemitente int,
@idDestinatario int,
@rutaArchivo nvarchar(max),
@observacion nvarchar(200),
@idusuariocreacion int,
@tipoCorrespondencia int

as
begin 

declare @idcadena varchar(12);
declare @cadena varchar(12);
declare @numero int;
	if (@tipoCorrespondencia = 1)
	begin
	set @cadena = (SELECT top 1 idCorrespondencia	FROM Correspondencia
	where idCorrespondencia like 'CI%'	ORDER by idCorrespondencia DESC);
		if	@cadena is not null
		begin
			set @numero = cast( SUBSTRING(@cadena, 3, 6) as int);
			set @numero =  @numero + 1;
			set @idcadena = 'CI'+RIGHT('00000000' + Ltrim(Rtrim(@numero)),8)

		end
		else
		begin
			set @idcadena = 'CI00000000';
		end	 
	end
	else
	begin 
		set @cadena = (SELECT top 1 idCorrespondencia	FROM Correspondencia
		where idCorrespondencia like 'CE%'	ORDER by idCorrespondencia DESC);
		if	@cadena is not null
		begin
			set @numero = cast( SUBSTRING(@cadena, 3, 6) as int);
			set @numero =  @numero + 1;
			set @idcadena = 'CE'+RIGHT('00000000' + Ltrim(Rtrim(@numero)),8)

		end
		else
		begin
			set @idcadena = 'CE00000000';
		end	 
	end


	insert Correspondencia
values(@idcadena,@idRemitente,@idDestinatario, @rutaArchivo, @observacion,
 @idusuariocreacion, getdate(),  null, null);

end 



	 insert [dbo].[TipoRemDes]
	 values('Remitente'), ('Destinatario')

	 insert [dbo].[RemDes] 
	 values ('123456', 'andres', 'vargas', 'calle 52a No 89 - 19', '2002020',1),
	 ('77788', 'carlos', 'vargas', 'cra 52  no 19 - 52', '7896523',2)


	 insert [dbo].[Roles]
	 values('Administrador'), ('Gestor'), ('Destinatario')



	 insert [dbo].[Usuarios]
	 values ('123789', 'prueba','12345',1)






exec spAddCorrespondencia 1, 2, 'C;//jdhfjhdjfh/iouiou', 'prueba 2', 1,2



create view vwCorrespondencia as
Select  c.idCorrespondencia
      ,c.idRemitente
      ,c.idDestinatario
      ,c.rutaArchivo
      ,c.observacion    
      ,c.fechaCreacion     
	  ,concat(r.nombres, ' ', r.apellidos) as Remitente
	  ,concat(d.nombres, ' ', d.apellidos) as Destinatario
from [Correspondencia] c 
inner join [dbo].[RemDes] r on c.idRemitente = r.idremitente
inner join [dbo].[RemDes] d on c.idDestinatario = d.idremitente






select * from vwCorrespondencia where fechaCreacion < Cast( '2021-04-28' as datetime)

	  

