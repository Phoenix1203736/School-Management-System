# School Management System

ASP.NET Web Forms application for managing school operations such as authentication, users, teachers, students, subjects, attendance, assignments, and reports.

## Stack

- C# / ASP.NET Web Forms
- .NET Framework 4.8.1
- SQL Server (`System.Data.SqlClient`)
- Bootstrap + jQuery

## Key folders

- `App_Start/` startup configuration (`RouteConfig`, `BundleConfig`)
- `Components/` pages, controls, and role-specific UI
- `Model/` classes, enums, and database operations
- `Content/` styles
- `Scripts/` JavaScript dependencies

## Run locally

1. Open `SistemsProyect.sln`.
2. Restore NuGet packages.
3. Update the SQL connection in `Model/DataBase/SingletonSafe.cs`.
4. Run with IIS Express.

## Notes

- Keep credentials out of source control.
- This project currently uses direct SQL queries in controller classes under `Model/DataBase/Controllers/`.

## License

MIT License. See `LICENSE`.

