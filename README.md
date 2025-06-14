# CommunicationService

A modular .NET 8/9 solution for managing and sending communication templates (such as emails) to customers. The project is built with ASP.NET Core Web API, Entity Framework Core, and supports clean architecture with separate Application, Domain, Infrastructure, and API layers.

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
   - The API uses SQLite by default. Connection string is in `appsettings.json`: ```json
 "ConnectionStrings": {
   "DefaultConnection": "Data Source=communication.db"
 }3. **Build and run the API:** Build the solution and start the API.

---

## Screenshots

### Project Structure

![Project Structure](https://user-images.githubusercontent.com/26799490/273420012-structure.png)

### Example API Response

![API Response](https://user-images.githubusercontent.com/26799490/273420013-apiresponse.png)

---

## Using the API

### Swagger UI

After running the API, navigate to:

You will see the interactive Swagger UI:

![Swagger UI Screenshot](https://raw.githubusercontent.com/swagger-api/swagger-ui/master/docs/screenshot.png)

- **Try out** endpoints directly from the browser.
- **Authorize** with JWT tokens if required.

### Example: Creating a Template

1. Go to the `POST /api/Template` endpoint in Swagger.
2. Click **Try it out**.
3. Enter the following JSON:
4. Click **Execute** to create a new template.

### Example: Sending a Communication

1. Use the appropriate endpoint (e.g., `POST /api/Communication/SendToCustomer`).
2. Provide the required template and customer IDs.

---

## Running Tests

Unit and integration tests are in the `CommunicationService.Tests` project.

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