# Communication Microservice with API Gateway and Authentication

This repository is a sample implementation of a microservices architecture in .NET 8, demonstrating:

- AuthenticationService.API (JWT token generation)
- CommunicationService.API (manages templates, customers, and sending communications)
- CommunicationService.ApiGateway (Ocelot-based API gateway that validates JWT)

---

## 🧱 Projects Overview

### 1. **AuthenticationService.API**
- **Purpose**: Authenticates users and generates JWT tokens.
- **Endpoint**:
  - `POST /api/auth/login` – Accepts username/password and returns a JWT token.
- **Mock Credentials**:
  - `Username: denske`
  - `Password: ccm`

### 2. **CommunicationService.API**
- **Purpose**: Core service to handle templates, customers, and communication logs.
- **Endpoints**:
  - `GET /api/template`
  - `POST /api/template`
  - `GET /api/customer`
  - `POST /api/customer`
  - `POST /api/communication/send/{customerId}/{templateId}`
- **Data**: Uses SQLite (in-memory or file) via EF Core.

### 3. **CommunicationService.ApiGateway**
- **Purpose**: Acts as an API Gateway using **Ocelot**.
- **Features**:
  - Routes traffic to `CommunicationService.API`.
  - Validates JWT tokens using **AuthenticationService.API** as the authority.

---

## 🔐 JWT Authentication

- JWT token is issued by `AuthenticationService.API`.
- Token is then passed as `Authorization: Bearer {token}` header for secured endpoints.
- `CommunicationService.API` itself does **not** validate JWT.
- **Validation is handled at the API Gateway level.**

---

## 🧪 Testing with Postman

1. **Login to get token**:
    ```http
    POST /api/auth/login
    {
      "username": "denske",
      "password": "ccm"
    }
    ```

2. **Use token in other requests**:
    Add this header:
    ```
    Authorization: Bearer <your_token_here>
    ```

3. **Access communication endpoints through the API Gateway**.

---

## ⚙️ Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- JWT Authentication
- Ocelot API Gateway
- Swagger / OpenAPI

---

## ▶️ How to Run

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or VS Code

### Steps

1. Clone the repository
2. Update connection strings if needed (uses SQLite by default)
3. Run each project:
    - `AuthenticationService.API`
    - `CommunicationService.API`
    - `CommunicationService.ApiGateway`
4. Use Swagger UI or Postman to test endpoints.

---

## ✨ Credits

Created by Syed Shujaat Ali as a modular microservice demo project.

---

## 📁 Project Structure

```
structure.png
```

---

## 🛡️ Disclaimer

This is a simplified demo for learning purposes and not intended for production without further enhancements in security, logging, configuration management, and error handling.

