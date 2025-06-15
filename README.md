# Communication Domain-Driven Microservice Ready with API Gateway and Authentication

This repository is a sample implementation of a modular microservices / onion architure with  in .NET 8, demonstrating:

- AuthenticationService.API (JWT token generation)
- CommunicationService.API (manages templates, customers, and sending communications)
- CommunicationService.ApiGateway (Ocelot-based API gateway that validates JWT)

---

## 📁 Project Structure

![](structure.png)
1. **AuthenticationService.API**: Handles user authentication and JWT generation.
2. **CommunicationService.API**: Manages templates, customers, and communication logs.
3. **CommunicationService.ApiGateway**: Ocelot-based API gateway that routes requests and validates JWT tokens.
4. **CommunicationService.Infrastructure**: Contains shared infrastructure code, such as database context and migrations.
5. **CommunicationService.Domain**: Contains domain models and interfaces.
6. **CommunicationService.Application**: Contains application logic, services, and DTOs.
7. **CommunicationService.Tests**: Contains unit and integration tests for the application.

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

1. ![](swagger.png)
---

### Postman file collection
- Swagger file is available at '/Denske CCM.postman_collection.json'.

---


---
## ✨ Credits

Created by Syed Shujaat Ali as a modular microservice demo project.