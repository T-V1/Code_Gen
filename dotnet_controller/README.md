# User Registration and Login API

This ASP.NET Core Web API allows users to register and log in securely using email and password. The API returns JWT tokens for authenticated access and follows clean architecture principles.

## Features
- User registration with validation
- Secure password hashing
- JWT authentication
- DTOs for requests and responses
- Error handling with proper HTTP status codes

## Endpoints
- POST /api/auth/register
- POST /api/auth/login

## Project Structure
- Controllers/
- Models/
- DTOs/
- Services/
- Repositories/
- wwwroot/
- appsettings.json
- Program.cs
- Startup.cs

## Getting Started
1. Restore NuGet packages
2. Update connection string in appsettings.json if using SQL Server
3. Run the API

## Out of Scope
- Email verification
- Password reset
- Role-based authorization
- UI / Frontend
