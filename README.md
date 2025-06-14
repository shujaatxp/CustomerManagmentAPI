# CommunicationService

A modular solution for managing and sending communication templates (such as emails) to customers. Built with ASP.NET Core Web API, Entity Framework Core, and a clean architecture approach, the project is organized into Application, Domain, Infrastructure, and API layers.  
Supports both .NET 8 and .NET 9.

---

## Features

- **Template Management:** Create, update, delete, and retrieve communication templates.
- **Customer Management:** Manage customer data for personalized communications.
- **Send Communications:** Use templates to send messages to customers.
- **JWT Authentication:** Secure API endpoints.
- **Swagger UI:** Interactive API documentation and testing.
- **Unit & Integration Tests:** xUnit-based tests for services and controllers.

---

## Project Structure

1. **Clone the repository:** Clone the repository to your local machine.
2. **Configure the database:**
   - The API uses SQLite by default. The connection string is in `CommunicationService.API/appsettings.json`: 
"ConnectionStrings": {
  "DefaultConnection": "Data Source=communication.db"
}
3. **Build and run the API:** Build the solution and start the API.
   - The API uses SQLite by default. The connection string is in `CommunicationService.API/appsettings.json`: 
"ConnectionStrings": {
  "DefaultConnection": "Data Source=communication.db"
}
3. **Build and run the API:** Build the solution and start the API.
   - The API uses SQLite by default. The connection string is in `CommunicationService.API/appsettings.json`: 
"ConnectionStrings": {
  "DefaultConnection": "Data Source=communication.db"
}
3. **Build and run the API:** Build the solution and start the API.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK or newer](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- (Optional) [Postman](https://www.postman.com/) for API testing

### Setup

1. **Clone the repository:**

---

## Screenshots

### Project Structure

![Project Structure](https://user-images.githubusercontent.com/26799490/273420012-structure.png)

### Example API Response

![API Response](https://user-images.githubusercontent.com/26799490/273420013-apiresponse.png)

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes
4. Open a pull request

---

## License

This project is licensed under the MIT License.

---

## Contact

For questions or support, please open an issue or contact [your-email@example.com](mailto:your-email@example.com).

---

## Using the API

### Swagger UI

After running the API, navigate to:

---

You will see the interactive Swagger UI:

![Swagger UI Screenshot](https://raw.githubusercontent.com/swagger-api/swagger-ui/master/docs/screenshot.png)

- **Try out** endpoints directly from the browser.
- **Authorize** with JWT tokens if required (use the "Authorize" button and provide a valid JWT).
- **Authorize** with JWT tokens if required (use the "Authorize" button and provide a valid JWT).

---

### Example: Creating a Template

1. Go to the `POST /api/Template` endpoint in Swagger.
2. Click **Try it out**.
3. Enter the following JSON:
4. Click **Execute** to create a new template.

---

### Example: Sending a Communication

1. Use the appropriate endpoint (e.g., `POST /api/Communication/SendToCustomer`).
2. Provide the required template and customer IDs in the request body or parameters.

---

## Authentication

- The API uses JWT Bearer authentication.
- To access protected endpoints, obtain a JWT token (see `/api/Auth` or similar endpoint if implemented).
- Use the "Authorize" button in Swagger UI to enter your token.

---

## Running Tests

Unit and integration tests are in the `CommunicationService.Tests` project.

To run all tests: