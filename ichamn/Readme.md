# ichamn

Aplicación web ASP.NET MVC para foros, temas y mensajes, con suscripciones y distribución asíncrona de novedades mediante oficinas y almacenes internos.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

## Estructura y responsabilidades

| Ruta | Responsabilidad |
| --- | --- |
| `src/Ichamn/` | Aplicación principal, controladores de foro, cuentas y plantillas. |
| `src/Ichamn/Models/Office.cs, src/Ichamn/Models/Warehouse.cs` | Modelo de suscriptores y reparto de mensajes/trabajos. |
| `src/Ichamn.Tests/` | Pruebas del proyecto. |
| `src/Backup/, src/Backup1/` | Copias antiguas de la aplicación con su propia configuración. |
| `src/wwwroot/` | Copia de publicación del sitio. |

## Tecnologías y requisitos

Windows, Visual Studio/MSBuild, .NET Framework 4.0, ASP.NET MVC y Entity Framework 4.1; SQL Server y ASP.NET Membership según las configuraciones.

Destinos leídos de los proyectos: `v4.0`.

## Preparación y arranque

Abrir src/Ichamn.sln, restaurar NuGet y configurar la aplicación principal en IIS Express. No tomar las carpetas Backup o wwwroot como fuente principal sin comparar sus versiones.

Soluciones presentes: `src/Ichamn.sln`, `src/Backup/Ichamn.sln`, `src/Backup1/Ichamn.sln`.

## Configuración e integraciones

La conexión ichamn y las bases de Membership aparecen en varias copias. App_Data contiene archivos SQL Server con posibles datos personales.

## Estado de esta copia


La revisión fue estática: no se restauraron dependencias, no se compiló ni se ejecutaron aplicaciones o pruebas. Los comandos anteriores son instrucciones de preparación, no resultados de validación. Las versiones indicadas son las del código conservado.


## Copia pública

Las credenciales originales se han retirado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Los datos locales, sesiones, certificados privados y perfiles de despliegue se omiten. Configurar servicios y credenciales propios antes de ejecutar. La compilación y el funcionamiento con servicios externos no se han validado.
