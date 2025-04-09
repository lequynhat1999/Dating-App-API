# Technical Context: Dating App API

**Technologies Used:**
- **.NET:**  Primary backend framework.
- **ASP.NET Core:**  For building the RESTful API.
- **C#:**  Programming language.
- **Entity Framework Core (EF Core):**  ORM for database interactions.
- **SQL Server (or PostgreSQL):** Relational database for data persistence. (To be decided)
- **Authentication and Authorization:**  JWT (JSON Web Tokens) for API security.
- **Dependency Injection:**  Built-in .NET DI container.
- **Logging:**  .NET Logging libraries.
- **Testing:**  xUnit, Moq (for unit and integration testing).
- **Versioning:** Git for source control.

**Development Setup:**
- **IDE:**  Visual Studio or Visual Studio Code.
- **.NET SDK:**  Latest stable .NET SDK.
- **Database Server:**  Local SQL Server or PostgreSQL instance.
- **API Testing Tool:**  Postman or similar.

**Technical Constraints:**
- **Performance:**  API should be performant and handle concurrent requests efficiently.
- **Security:**  API must be secure and protect user data.
- **Scalability:**  Design should consider future scalability requirements.
- **Database Choice:**  Need to decide between SQL Server and PostgreSQL based on project needs and deployment environment.

**Dependencies:**
- List NuGet packages for ASP.NET Core, EF Core, JWT, testing libraries, etc. (To be detailed in progress.md as project evolves)

**Tool Usage Patterns:**
- **dotnet CLI:**  For project creation, building, running, and managing dependencies.
- **EF Core Migrations:**  For managing database schema changes.
- **Git CLI:** For version control.
