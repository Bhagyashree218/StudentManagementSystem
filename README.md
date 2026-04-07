# 🎓 Student Management System - ASP.NET Core Web API

## 📌 Project Description

The Student Management System is a backend application built using ASP.NET Core Web API to manage student records efficiently. It supports CRUD operations such as adding, retrieving, updating, and deleting students.

The project follows a clean layered architecture (Controller, Service, Repository) and includes JWT authentication, global exception handling, logging, and Swagger API documentation.

---

## 🚀 Features

* ✅ Get all students
* ✅ Get student by ID
* ✅ Add new student
* ✅ Update student
* ✅ Delete student (Soft Delete)
* ✅ JWT Authentication (Login/Register)
* ✅ Role-based Authorization (Admin)
* ✅ Global Exception Handling (Middleware)
* ✅ Logging (Built-in ILogger)
* ✅ Swagger API Documentation

---

## 🏗 Architecture

The project follows a layered architecture:

* Controller Layer → Handles HTTP requests
* Service Layer → Business logic
* Repository Layer → Database access
* Domain Layer → Entities
* Contracts Layer → DTOs

---

## 🛠 Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* BCrypt (Password Hashing)
* Swagger (Swashbuckle)

---

## ⚙️ Setup Instructions

1. Clone the repository

```
git clone <your-repo-link>
```

2. Update database connection string in `appsettings.json`

3. Run migrations

```
Add-Migration InitialCreate
Update-Database
```

4. Run the application

---

## 🔐 Authentication Flow

1. Register user
   `POST /api/auth/register`

2. Login
   `POST /api/auth/login`

3. Copy JWT token

4. In Swagger → Click **Authorize**
   👉 Paste ONLY token (no Bearer)

5. Access secured endpoints

---

## 📬 API Endpoints

### Auth

* POST `/api/auth/register`
* POST `/api/auth/login`

### Student (Protected)

* GET `/api/student`
* GET `/api/student/{id}`
* POST `/api/student`
* PUT `/api/student`
* DELETE `/api/student/{id}`

---

## 📌 Notes

* All student APIs are protected using JWT
* Only Admin role can access endpoints
* Passwords are securely hashed using BCrypt

---

## 👩‍💻 Author

Bhagyashree
