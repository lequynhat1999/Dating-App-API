# Active Context: Dating App API

**Current Work Focus:**
- Initial setup of the .NET API project.
- Defining project structure and core components.
- Setting up basic project configurations.
- Planning the initial database model.

**Recent Changes:**
- Created `projectbrief.md`, `productContext.md`, `systemPatterns.md`, and `techContext.md` to initialize the memory bank.

**Next Steps:**
- Create the initial .NET API project using the dotnet CLI.
- Define the basic folder structure for Controllers, Services, and Data Access layers.
- Set up a basic Git repository.
- Choose between SQL Server and PostgreSQL for the database.

**Active Decisions and Considerations:**
- **Database Choice:** SQL Server vs PostgreSQL - considering developer familiarity, deployment environment, and licensing. PostgreSQL is favored for its open-source nature and cross-platform compatibility. SQL Server might be simpler to set up initially on Windows. *Decision: Start with SQL Server for initial development, but keep PostgreSQL as a potential alternative for production.*
- **Project Structure:**  Ensuring a clean and scalable project structure from the beginning is crucial. Three-layer architecture will be strictly followed.
- **Authentication:**  Planning for JWT authentication setup early in the development process.

**Important Patterns and Preferences:**
- **Clean Architecture Principles:** Aim for a clean and maintainable codebase, separating concerns clearly.
- **Convention over Configuration:**  Follow .NET conventions to reduce boilerplate and increase consistency.
- **Test-Driven Development (TDD) (Ideally):**  Start with unit tests for core logic as we build services and repositories.

**Learnings and Project Insights:**
- Initial memory bank setup provides a solid foundation for project understanding and future development.
- Documenting decisions and considerations in `activeContext.md` helps maintain context across sessions.
