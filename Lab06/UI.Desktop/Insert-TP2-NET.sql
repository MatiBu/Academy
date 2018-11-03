USE [Academia]
GO

INSERT INTO [dbo].[especialidades]
           ([desc_especialidad])
     VALUES
           ('Sitemas')
GO


select *
from especialidades

USE [Academia]
GO

INSERT INTO [dbo].[planes]
           ([desc_plan]
           ,[id_especialidad])
     VALUES
           ('2008', 1)
GO

select *
from planes

USE [Academia]
GO

INSERT INTO [dbo].[personas]
           (nombre
           ,apellido
           ,direccion
           ,email
           ,telefono
           ,fecha_nac
           ,legajo
           ,tipo_persona
           ,id_plan)
     VALUES
           ('Pepito', 'Gonzales', 'corrientes 123', 'pGonzales@yahoo.com',
		    '1234656789', '3-11-2018', '12345', '1', '1')
GO

select *
from personas


USE [Academia]
GO

INSERT INTO [dbo].[usuarios]
           (nombre_usuario, clave, habilitado, nombre, apellido, email
           ,cambia_clave, id_persona)
     VALUES
           ('pepitoGonzales', '123', CONVERT(bit,'True'), 'Pepito', 'Gonzales', 'pGonzales@hotmail.com',
		    '123', '1')
GO

select *
from usuarios