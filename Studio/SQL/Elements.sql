 
  delete Elements
  
  DBCC CHECKIDENT ('Elements', RESEED, 0);
  
  insert into [Elements](RelativeId,Name,Estado,Eliminado,UsuarioCreacion,UsuarioModificacion)
  values(0,'Aplicacion',1,0,'system','system')
  
  insert into [Elements](RelativeId,Name,Estado,Eliminado,UsuarioCreacion,UsuarioModificacion)
  values(0,'Area',1,0,'system','system')
  
  insert into [Elements](RelativeId,Name,Estado,Eliminado,UsuarioCreacion,UsuarioModificacion)
  values(0,'Controlador',1,0,'system','system')
  
  insert into [Elements](RelativeId,Name,Estado,Eliminado,UsuarioCreacion,UsuarioModificacion)
  values(0,'Vista',1,0,'system','system')
  
  insert into [Elements](RelativeId,Name,Estado,Eliminado,UsuarioCreacion,UsuarioModificacion)
  values(0,'Elemento',1,0,'system','system')
  
  select * from [Elements]