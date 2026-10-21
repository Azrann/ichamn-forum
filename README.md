# ichamn-forum

Foro web histórico Ichamn.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2014.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2014-10-05**, [`ichamn/src/Ichamn/Ichamn.csproj`](ichamn/src/Ichamn/Ichamn.csproj); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro del repositorio Git original que contiene este código: **2014-10-05**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Twitter.Bootstrap 2.0.1](https://www.nuget.org/packages/Twitter.Bootstrap/2.0.1), publicada el **2012-02-17** (versión declarada), en [`ichamn/src/Ichamn/packages.config`](ichamn/src/Ichamn/packages.config).
- Referencia adicional: destino `v4.0` en [`ichamn/src/Ichamn/Ichamn.csproj`](ichamn/src/Ichamn/Ichamn.csproj); su [versión estable se publicó el 2010-04-12](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

Office y Warehouse distribuyen información a sesiones suscritas, mientras un controlador asíncrono entrega las novedades. Esa implementación de colas y suscripciones en memoria es más singular que las pantallas del foro y merece una lectura de su flujo de mensajes.

Puntos de entrada al código:

- [`src/Ichamn/Models/Office.cs`](ichamn/src/Ichamn/Models/Office.cs)
- [`src/Ichamn/Models/Warehouse.cs`](ichamn/src/Ichamn/Models/Warehouse.cs)
- [`src/Ichamn/Controllers/AForumController.cs`](ichamn/src/Ichamn/Controllers/AForumController.cs)

<!-- END project-context -->

## Contenido

| Directorio | Función |
| --- | --- |
| [`ichamn/`](ichamn/) | Aplicación web ASP.NET MVC para foros, temas y mensajes, con suscripciones y distribución asíncrona de novedades mediante oficinas y almacenes internos. |

Se omiten copias de respaldo, cachés del IDE y resultados de pruebas.

## Requisitos y preparación

.NET Framework, ASP.NET MVC y NuGet.

Esta es una copia histórica. Consultar los archivos de proyecto y los README de cada componente para sus versiones y dependencias. Restaurar NuGet/npm desde la carpeta correspondiente; las bibliotecas internas pueden necesitar reconstrucción. Preparar las bases de datos y los servicios externos con cuentas propias.

Soluciones conservadas:

- `ichamn/src/Ichamn.sln`

## Configuración y seguridad

Los secretos originales se han eliminado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Buscar este marcador antes de ejecutar y aportar los valores mediante configuración local o variables de entorno. Las sesiones, claves privadas, certificados de firma, bases de datos, registros, perfiles de despliegue y paquetes binarios no se publican. El `.gitignore` protege estos archivos locales.

Se publica un historial nuevo: los commits antiguos permanecen únicamente en la copia local original. Los valores de ejemplo no permiten conectarse a los servicios originales.

## Estado de validación

Se realizó una revisión estática y un escaneo de secretos antes de publicar. No se ejecutaron aplicaciones, operaciones de trading, despliegues ni pruebas que contacten servicios externos. No se garantiza la compilación con herramientas actuales. Algunos proyectos necesitan dependencias históricas y activos que no están incluidos.

## Licencias y procedencia

Se conservan las licencias y atribuciones de terceros presentes en el código. No se añade una licencia global a los componentes que no la tenían. Esta importación conserva fuentes locales y no afirma ser una versión actual del proyecto original.
