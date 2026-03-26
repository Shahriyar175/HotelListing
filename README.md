# HotelListing REST API  
A modular and scalable REST API for managing hotels and countries  
(ASP.NET Core • EF Core • JWT • AutoMapper • Serilog)

## 📌 Overview
HotelListing is a fully functional REST API built with ASP.NET Core.  
It follows a clean, layered architecture with clear separation of concerns (Controllers, Services, Repositories, DTOs, Configurations).  
The API includes authentication, authorization, logging, database migrations, and complete CRUD operations.

---

## 🚀 Technologies & Frameworks

| Area | Technologies |
|------|--------------|
| Backend | ASP.NET Core 8, C# |
| Database | SQL Server, Entity Framework Core |
| Authentication | ASP.NET Identity, JWT Tokens |
| Logging | Serilog (Rolling File Logging) |
| Mapping | AutoMapper |
| Documentation | Swagger / OpenAPI |
| Architecture | Repository Pattern, Unit of Work, DTO Layer |

---

## 🏗️ Architecture Overview

<pre>
HotelListing/
│
├── Configurations/        # Entity configurations, Identity, JWT setup
├── Controllers/           # API endpoints (Hotel, Country, Account)
├── Data/                  # DbContext, Entities
├── DTOs/                  # Data Transfer Objects
├── IRepository/           # Interfaces for repositories & Unit of Work
├── Repository/            # Repository implementations
├── Services/              # AuthManager, UserManager
├── Migrations/            # EF Core migrations
├── Program.cs             # Application startup
└── appsettings.json       # Configuration settings
</pre>



---

## 🔐 Authentication & Authorization

The API uses:

- ASP.NET Identity for user management  
- JWT Tokens for secure login  
- Role-based authorization (Admin, User)

Example endpoints:

POST /api/account/register
POST /api/account/login

## ✔ Features

Full REST API implementation

JWT authentication

Identity-based user management

AutoMapper for clean DTO mapping

Repository + Unit of Work pattern

Serilog logging

CORS enabled

SQL Server + EF Core migrations

Clean, extensible architecture
