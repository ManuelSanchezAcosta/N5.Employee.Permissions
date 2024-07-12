# N5.Employee.Permissions
Net Core Api Rest to manage Employee Permissions

Caracteristicas funcionales 

Employee.Permissions.Api permite administrar empleados y sus roles. 

Acciones permitidas: 

Crear Empleados 

Crear Roles (tipos de  permiso) 

Asignar y Quitar roles al empleado 

 

Características técnicas 

La API Employee.Permissions está construida con las siguientes tecnologias  

Net Core 6 

SQL Server  

Entity Framework 

Kafka 

Elasticsearch 


De la misma forma está preparada para Docker 

  

La api incluye las validaciones de integridad de datos necesarias 

El api permite eliminar el Rol asignado al empleado 
 

Visualizar los nuevos mensajes publicados en Kafka: http://localhost:9021/clusters 

Visualizar los datos registrados en Elasticsearch: http://localhost:5601  

  

Pasos para descargar y ejecutar el proyecto localmente 

Descargar el repositorio desde github 

Descargar y ejecutar las imagenes docker => docker-compose up -d 

Iniciar la base de datos con el comando Update-Database (Migrations) 

 

 

 
