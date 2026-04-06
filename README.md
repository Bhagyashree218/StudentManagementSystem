# 🎓 Student Management System - ASP.NET Core Web API

## 📌 Project Description

The Student Management System is a backend application built using ASP.NET Core Web API to manage student records efficiently. It supports CRUD operations such as adding, retrieving, updating, and deleting students.

The project follows a clean layered architecture (Controller, Service, Repository) and includes JWT authentication, global exception handling, logging, and Swagger API documentation.

---

## 🚀 Features

* Get all students
* Add new student
* Update student
* Delete student
* JWT Authentication
* Global Exception Handling Middleware
* Logging (Serilog / Built-in)
* Swagger API Documentation

---

## 🏗️ Architecture

* Controller Layer
* Service Layer
* Repository Layer
* DTO-based communication

---

## 🗄️ Database

* SQL Server
* Table: Students

  * Id
  * Name
  * Email
  * Age
  * Course
  * CreatedDate

---

## ⚙️ Setup Instructions

1. Clone the repository

```
git clone https://github.com/Bhagyashree218/StudentManagementSystem.git
```

2. Open in Visual Studio

3. Update Connection String

Edit `appsettings.json`:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StudentDb;Trusted_Connection=True;"
}
```

4. Apply Migrations

```
Update-Database
```

5. Run the Project

```
dotnet run
```

6. Open Swagger

```
https://localhost:<port>/swagger
```

---

## 🔐 Authentication

* JWT-based authentication implemented
* Secure endpoints using token

---


## 📎 Submission

GitHub Repo: https://github.com/Bhagyashree218/StudentManagementSystem
