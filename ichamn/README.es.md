**Languages:** [English](Readme.md) · [Español](README.es.md)

# ichamn

Aplicación web ASP.NET MVC para foros, temas y mensajes, con suscripciones y distribución asíncrona de novedades mediante oficinas y almacenes internos.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2014.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2014-10-05**, [`ichamn/src/Ichamn/Ichamn.csproj`](src/Ichamn/Ichamn.csproj); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro del repositorio Git original que contiene este código: **2014-10-05**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Twitter.Bootstrap 2.0.1](https://www.nuget.org/packages/Twitter.Bootstrap/2.0.1), publicada el **2012-02-17** (versión declarada), en [`ichamn/src/Ichamn/packages.config`](src/Ichamn/packages.config).
- Referencia adicional: destino `v4.0` en [`ichamn/src/Ichamn/Ichamn.csproj`](src/Ichamn/Ichamn.csproj); su [versión estable se publicó el 2010-04-12](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

Office y Warehouse distribuyen información a sesiones suscritas, mientras un controlador asíncrono entrega las novedades. Esa implementación de colas y suscripciones en memoria es más singular que las pantallas del foro y merece una lectura de su flujo de mensajes.

Puntos de entrada al código:

- [`src/Ichamn/Models/Office.cs`](src/Ichamn/Models/Office.cs)
- [`src/Ichamn/Models/Warehouse.cs`](src/Ichamn/Models/Warehouse.cs)
- [`src/Ichamn/Controllers/AForumController.cs`](src/Ichamn/Controllers/AForumController.cs)

<!-- END project-context -->

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
