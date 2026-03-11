# School Management System

ASP.NET Web Forms application for managing a school workflow, including user access, student/teacher administration, subjects, attendance, assignments, and reporting.

## Tech stack

- C# / ASP.NET Web Forms
- .NET Framework `4.8.1`
- SQL Server (via `System.Data.SqlClient`)
- Bootstrap 5 + jQuery
- NuGet package management (`packages.config`)

## Current capabilities

- Role-based navigation for guest, teacher, and administrator users
- Login flow and user session handling
- Student and teacher management views
- Subject/course management
- Attendance registration and lookup
- Assignment and grading pages
- Report generation page

## Project structure

- `App_Start/` startup configuration (`RouteConfig`, `BundleConfig`)
- `Components/` UI components and page modules
- `Model/` domain classes, enums, and database controllers
- `Content/` CSS and static styles
- `Scripts/` JavaScript dependencies and WebForms scripts
- `Global.asax` ASP.NET application lifecycle entry
- `Web.config` application configuration

## Prerequisites

- Windows
- Visual Studio 2022 (ASP.NET and web development workload) or JetBrains Rider with .NET Framework support
- .NET Framework Developer Pack `4.8.1`
- SQL Server instance with the expected schema

## Getting started

1. Clone the repository.
2. Open `SistemsProyect.sln`.
3. Restore NuGet packages.
4. Configure your SQL Server connection.
5. Run with IIS Express.

### Package restore (optional CLI)

```bash
nuget restore SistemsProyect.sln
```

## Database configuration

The current data access entry point is `Model/DataBase/SingletonSafe.cs` (`CreateConnection`).

Before running in your environment:

- replace hardcoded credentials with your own connection string
- prefer moving connection strings to `Web.config` for safer configuration management
- ensure required tables (for users, students, teachers, subjects, attendances, assignments) exist

## Notes

- This branch includes dependencies under `packages/` and build output under `bin/`.
- Keep secrets out of source control.

## License

This project is licensed under the MIT License. See `LICENSE` for details.

