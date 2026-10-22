**Languages:** [English](Readme.md) · [Español](README.es.md)

# ichamn

ASP.NET MVC web application for forums, topics, and messages, with subscriptions and asynchronous delivery of updates through internal offices and warehouses.

Documentation based on local files reviewed on 21 October 2026.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2014.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2014-10-05**, [`ichamn/src/Ichamn/Ichamn.csproj`](src/Ichamn/Ichamn.csproj); date of the commit modifying the file, recovered from local Git history.
- First record in the original Git repository containing this code: **2014-10-05**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [Twitter.Bootstrap 2.0.1](https://www.nuget.org/packages/Twitter.Bootstrap/2.0.1), published on **2012-02-17** (declared version), in [`ichamn/src/Ichamn/packages.config`](src/Ichamn/packages.config).
- Additional reference: target `v4.0` in [`ichamn/src/Ichamn/Ichamn.csproj`](src/Ichamn/Ichamn.csproj); its [stable release was published on 2010-04-12](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

## Why this is worth exploring

Office and Warehouse distribute information to subscribed sessions, while an asynchronous controller delivers updates. This in-memory queue and subscription implementation is more distinctive than the forum screens and is worth exploring through its message flow.

Code entry points:

- [`src/Ichamn/Models/Office.cs`](src/Ichamn/Models/Office.cs)
- [`src/Ichamn/Models/Warehouse.cs`](src/Ichamn/Models/Warehouse.cs)
- [`src/Ichamn/Controllers/AForumController.cs`](src/Ichamn/Controllers/AForumController.cs)

<!-- END project-context -->

## Structure and responsibilities

| Path | Responsibility |
| --- | --- |
| `src/Ichamn/` | Main application, forum and account controllers, and templates. |
| `src/Ichamn/Models/Office.cs, src/Ichamn/Models/Warehouse.cs` | Subscriber model and message/job distribution. |
| `src/Ichamn.Tests/` | Project tests. |
| `src/Backup/, src/Backup1/` | Older application copies with their own configuration. |
| `src/wwwroot/` | Published website copy. |

## Technologies and requirements

Windows, Visual Studio/MSBuild, .NET Framework 4.0, ASP.NET MVC, and Entity Framework 4.1; SQL Server and ASP.NET Membership according to configuration.

Targets read from project files: `v4.0`.

## Setup and startup

Open src/Ichamn.sln, restore NuGet packages, and configure the main application in IIS Express. Do not treat Backup or wwwroot folders as the main source without comparing their versions.

Solutions present: `src/Ichamn.sln`, `src/Backup/Ichamn.sln`, `src/Backup1/Ichamn.sln`.

## Configuration and integrations

The ichamn connection and Membership databases appear in several copies. App_Data contains SQL Server files that may include personal data.

## Status of this copy


The review was static: dependencies were not restored, and applications and tests were neither built nor run. The commands above are setup instructions, not validation results. Listed versions describe the preserved code.


## Public copy

Original credentials have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Local data, sessions, private certificates, and deployment profiles are omitted. Configure your own services and credentials before running. Building and operation with external services have not been validated.
