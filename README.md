# School Management System

A comprehensive web-based school management system built with ASP.NET Web Forms that enables efficient management of students, teachers, courses, attendance tracking, grading, and automated report generation.

## 🎯 Overview

This system provides a complete solution for educational institutions to manage their daily operations, including:

- **Student Management** - Register, update, and track student information and enrollment status
- **Teacher Management** - Manage teacher profiles, specializations, and course assignments
- **Course/Subject Management** - Create and organize courses with start/end dates and descriptions
- **Attendance Tracking** - Monitor student attendance with date-based records
- **Grading System** - Assign and manage student grades for various assignments
- **Report Generation** - Generate PDF reports for academic performance and attendance records
- **User Authentication** - Secure login system for administrators and teachers

## 🚀 Technology Stack

### Backend
- **Framework:** ASP.NET Web Forms 4.8.1
- **Language:** C# 8.0 (with nullable reference types)
- **Database:** MySQL Server
- **ORM:** Entity Framework 6.5.1
- **Database Connector:** MySqlConnector 2.4.0

### Frontend
- **UI Framework:** Bootstrap 5.3.5
- **JavaScript:** jQuery 3.7.1
- **AJAX:** AjaxControlToolkit 20.1.0

### Libraries & Tools
- **PDF Generation:** iTextSharp 5.5.13.4
- **Dependency Injection:** Microsoft.Extensions.DependencyInjection 5.0.0
- **Logging:** Microsoft.Extensions.Logging 5.0.0
- **Optimization:** ASP.NET Web Optimization 1.1.3
- **Routing:** ASP.NET FriendlyUrls 1.0.2

## 📁 Project Structure

```
SistemsProyect/
├── Model/                              # Data models and business logic
│   ├── Classes/                        # Entity classes
│   │   ├── Student.cs                  # Student entity
│   │   ├── Teacher.cs                  # Teacher entity
│   │   ├── Subject.cs                  # Course/Subject entity
│   │   ├── Attendance.cs               # Attendance tracking entity
│   │   ├── Assignament.cs              # Assignment/Grade entity
│   │   ├── User.cs                     # User authentication entity
│   │   ├── SubjectStudent.cs           # Student-Subject relationship
│   │   └── SubjectReport.cs            # Report generation entity
│   ├── DataBase/                       # Database layer
│   │   ├── Singleton.cs                # Database connection (Singleton pattern)
│   │   └── Controllers/                # Database operations
│   │       ├── StudentOperations.cs    # CRUD operations for students
│   │       ├── TeacherOperations.cs    # CRUD operations for teachers
│   │       ├── SubjectOperations.cs    # CRUD operations for subjects
│   │       ├── AttendanceOperations.cs # Attendance management
│   │       ├── AssigmentOperations.cs  # Grade management
│   │       ├── UserOperations.cs       # User authentication
│   │       └── ReportOperations.cs     # PDF report generation
│   └── Enums/                          # Enumeration types
├── Components/                         # UI Components
│   ├── NavBar/                         # Navigation components
│   └── Pages/                          # Page components
│       ├── Login/                      # Login functionality
│       ├── Actions/                    # Action pages
│       │   ├── Admin/                  # Admin-specific pages
│       │   │   ├── Reports/            # Report viewing pages
│       │   │   └── ViewsButton/        # Admin dashboard views
│       │   └── Teacher/                # Teacher-specific pages
│       │       ├── Course/             # Course management
│       │       └── Grades/             # Grade management
│       └── About/                      # About page
├── App_Start/                          # Application startup configuration
│   ├── BundleConfig.cs                 # Script and style bundling
│   └── RouteConfig.cs                  # URL routing configuration
├── Content/                            # CSS and static resources
├── Scripts/                            # JavaScript files
├── bin/                                # Compiled binaries and DLLs
├── Global.asax                         # Application lifecycle events
├── Web.config                          # Application configuration
├── Site.Master                         # Master page layout
└── Default.aspx                        # Landing page
```

## 🔧 Prerequisites

Before running this application, ensure you have the following installed:

1. **Visual Studio 2019 or later** (or JetBrains Rider)
2. **.NET Framework 4.8.1 SDK**
3. **MySQL Server 5.7 or later**
4. **IIS Express** (usually included with Visual Studio)
5. **NuGet Package Manager**

## 📦 Installation & Setup

### 1. Clone the Repository

```bash
git clone <repository-url>
cd Sistems_Proyect
```

### 2. Database Configuration

The application connects to a MySQL database named `school`. Configure the connection settings in the `Singleton.cs` file:

**Default Configuration:**
- **Server:** localhost
- **Port:** 3307
- **Database:** school
- **Username:** root
- **Password:** (empty)

**Location:** `Model/DataBase/Singleton.cs`

```csharp
mySqlConnectionStringBuilder.Server = "localhost";
mySqlConnectionStringBuilder.UserID = "root";
mySqlConnectionStringBuilder.Password = "";
mySqlConnectionStringBuilder.Database = "school";
mySqlConnectionStringBuilder.Port = 3307;
```

⚠️ **Security Note:** These credentials are for development only. Use secure credentials and connection strings for production environments.

### 3. Create Database

Create the MySQL database and required tables:

```sql
CREATE DATABASE school;
USE school;

-- Create your tables here based on the entity models
-- (Students, Teachers, Subjects, Attendance, Assignments, Users, etc.)
```

### 4. Restore NuGet Packages

Open the solution in Visual Studio or Rider and restore all NuGet packages:

**Visual Studio:**
```
Tools > NuGet Package Manager > Restore NuGet Packages
```

**Command Line:**
```bash
nuget restore SistemsProyect.sln
```

### 5. Build the Project

Build the solution to compile all dependencies:

```bash
MSBuild SistemsProyect.sln /p:Configuration=Debug
```

Or use Visual Studio/Rider's build functionality (Ctrl+Shift+B).

### 6. Run the Application

Press `F5` in Visual Studio/Rider or run:

```bash
# The application will start on IIS Express
# Default URL: https://localhost:44310
```

## 🎨 Features & Functionality

### 1. User Authentication
- Secure login system for administrators and teachers
- Password encryption and validation
- Session management

### 2. Student Management
- Add, edit, and delete student records
- Track student information (name, email, phone, birth date, entry date)
- Monitor student status (Active, Inactive, Graduated, etc.)
- View student enrollment history

### 3. Teacher Management
- Maintain teacher profiles with specializations
- Track hire dates and employment status
- Assign teachers to subjects/courses
- Manage teacher contact information

### 4. Subject/Course Management
- Create and manage courses with descriptions
- Set course start and end dates
- Assign teachers to subjects
- Track active and inactive courses
- Enroll students in subjects

### 5. Attendance Tracking
- Record daily attendance for students
- Mark attendance status (Present, Absent, Late, Excused)
- Date-based attendance records
- Generate attendance reports

### 6. Grading System
- Create assignments for subjects
- Assign grades to students
- Track assignment descriptions and submission details
- View grade history

### 7. Report Generation
- Generate PDF reports using iTextSharp
- Student performance reports
- Attendance summaries
- Course enrollment reports
- Customizable report templates

## 🏗️ Architecture & Design Patterns

### Singleton Pattern
The database connection uses the Singleton design pattern to ensure only one database connection instance exists throughout the application lifecycle:

```csharp
public static Singleton GetInstance()
{
    if (_instance == null)
    {
        _instance = new Singleton();
    }
    return _instance;
}
```

### MVC-like Structure
Although built with Web Forms, the project follows an MVC-like architecture:
- **Model:** Entity classes in `Model/Classes/`
- **View:** ASPX pages and User Controls in `Components/`
- **Controller:** Database operations in `Model/DataBase/Controllers/`

### Nullable Reference Types
The project uses C# 8.0 nullable reference types for improved null safety:

```csharp
public string? FirstName { get; set; }
public string? Email { get; set; }
```

## 🔐 Configuration Files

### Web.config
Contains application settings, connection strings, and assembly bindings.

### Bundle.config
Defines script and CSS bundle configurations for optimization.

### packages.config
Lists all NuGet package dependencies and versions.

## 📊 Database Schema

The system uses a MySQL database with the following main tables:

- **students** - Student information and enrollment status
- **teachers** - Teacher profiles and specializations
- **subjects** - Course information and scheduling
- **attendance** - Daily attendance records
- **assignments** - Assignment definitions and grades
- **users** - Authentication and authorization
- **subject_student** - Many-to-many relationship between subjects and students

## 🛠️ Development

### Building the Project

**Debug Mode:**
```bash
MSBuild SistemsProyect.sln /p:Configuration=Debug
```

**Release Mode:**
```bash
MSBuild SistemsProyect.sln /p:Configuration=Release
```

### Running Tests
(Add your testing framework and instructions here)

## 🚨 Troubleshooting

### Common Issues

**1. Database Connection Failed**
- Verify MySQL server is running
- Check connection settings in `Singleton.cs`
- Ensure the `school` database exists
- Verify port number (default: 3307)

**2. NuGet Package Restore Failed**
- Clear NuGet cache: `nuget locals all -clear`
- Restore packages manually: `nuget restore`

**3. Build Errors**
- Ensure .NET Framework 4.8.1 is installed
- Check all NuGet packages are restored
- Clean and rebuild the solution

**4. IIS Express Issues**
- Delete `.vs` folder and restart Visual Studio
- Check if port 44310 is available
- Verify IIS Express is installed

## 📝 Code Examples

### Creating a New Student

```csharp
var student = new Student
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com",
    Phone = "123-456-7890",
    BirthDate = new DateTime(2005, 5, 15),
    DateEntry = DateTime.Now,
    Status = StudentStatus.Active
};

var studentOps = new StudentOperations();
studentOps.Insert(student);
```

### Recording Attendance

```csharp
var attendance = new Attendance
{
    IdSubject = subjectId,
    IdStudent = studentId,
    Attenndace = AttendanceStatus.Present,
    Date = DateTime.Now
};

var attendanceOps = new AttendanceOperations();
attendanceOps.Insert(attendance);
```

### Generating a PDF Report

```csharp
var reportOps = new ReportOperations();
reportOps.GenerateStudentReport(studentId, filePath);
```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

### Coding Standards
- Follow C# naming conventions
- Use nullable reference types appropriately
- Add XML documentation comments for public methods
- Write meaningful commit messages

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Authors

- Project Developer - School Management System

## 📞 Support

For questions, issues, or feature requests, please open an issue on the project repository.

## 🔄 Version History

- **v1.0.0** (2026) - Initial release
  - Student and teacher management
  - Attendance tracking
  - Grading system
  - PDF report generation

## 🎓 Acknowledgments

- Built with ASP.NET Web Forms and Bootstrap
- PDF generation powered by iTextSharp
- Database connectivity via MySqlConnector
- Icons and UI components from Bootstrap 5

---

**Note:** This is an educational project for learning ASP.NET Web Forms and database management concepts. Ensure proper security measures are implemented before deploying to production environments.

