
# Este comando de EF Core scaffolding genera automáticamente las clases de entidad y la clase de contexto de base de datos
# a partir de una base de datos PostgreSQL existente, facilitando la implementación del patrón Database-First en aplicaciones .NET.
# Utiliza Npgsql como el proveedor de EF Core para PostgreSQL, especificando una cadena de conexión definida en el archivo de configuración.
# Las clases generadas se organizan en namespaces y directorios específicos, siguiendo una estructura de proyecto que separa claramente
# el dominio de la infraestructura y otros aspectos de la aplicación. Este enfoque promueve una arquitectura limpia y mantenible.
#
# Parámetros detallados:
# - La cadena de conexión se especifica directamente desde el archivo de configuración del proyecto.
# - Se define un namespace específico y un directorio para el contexto de la base de datos, alineándolo con la infraestructura del proyecto.
# - Las clases de entidad se colocan en un directorio y namespace que reflejan su pertenencia al dominio de la aplicación.
# - El comando sobrescribe archivos existentes para facilitar las actualizaciones del esquema de base de datos.
# - Se especifica el proyecto de inicio para el caso de soluciones con múltiples proyectos.
# - Se omite la generación del método `OnConfiguring` en la clase del contexto para permitir la configuración de la cadena de conexión en otro lugar.
#
# Requisitos:
# - .NET Core SDK y las herramientas de Entity Framework Core deben estar instalados.
# - El paquete Npgsql.EntityFrameworkCore.PostgreSQL debe estar presente en el proyecto para permitir la comunicación con PostgreSQL.
#
# Ejemplo de uso:
# dotnet ef dbcontext scaffold Name=ConnectionStrings:cnnstr Npgsql.EntityFrameworkCore.PostgreSQL --context-namespace Assistant.Infrastructure.Contexts --context-dir 3.Infrastructure/Contexts --context Context --output-dir 1.Domain/Entities --namespace Assistant.Domain.Entities  --no-onconfiguring
#
# Este comando es esencial para los desarrolladores que trabajan con bases de datos PostgreSQL en proyectos .NET, 
# proporcionando una base sólida para el desarrollo eficiente y organizado.

dotnet ef dbcontext scaffold Name=ConnectionStrings:cnnstr Npgsql.EntityFrameworkCore.PostgreSQL --context-namespace  Assistant.Infrastructure.Contexts --context-dir 3.Infrastructure/Contexts --context Context --output-dir  1.Domain/Entities --namespace Assistant.Domain.Entities --no-onconfiguring -f
