# PeopleStack – HR Management System

PeopleStack is a basic HR Management System built using ASP.NET Core Web API. The project follows a clean 3-Tier Architecture and provides core HR functionalities such as attendance management, payroll processing, and role-based access control. It was developed to practice enterprise-level backend design, API standards, and database integration.

## 🚀 Tech Stack

### Backend
- ASP.NET Core Web API  
- C#  

### Architecture
- 3-Tier Architecture  
  - Presentation Layer (API Controllers)  
  - Business Logic Layer (Services)  
  - Data Access Layer (Repositories)  

### Database
- MySQL  
- Entity Framework Core  

### API & Testing Tools
- Swagger UI (API Documentation & Testing)  
- Postman (API Testing)  

### Other Integrations
- Role-Based Authorization  
- SMS Notification System (integration required)  

## ✨ Key Features
- Role-based access control (Admin, HR, Employee)  
- Attendance management system  
- Payroll management system  
- Employee management with CRUD operations  
- RESTful APIs using proper HTTP methods and JSON format  

## 🛠️ Setup

```bash
# Clone the repository
git clone <repo-url>

# Restore dependencies
dotnet restore

# Update database connection string in appsettings.json

# Apply migrations (if available)
dotnet ef database update

# Run the project
dotnet run
