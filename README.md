Chair Project - Team Zeta (CYB206-25S-001)

Welcome to **Team Zeta's** official repository for our project **"Chair"**, developed as part of the coursework for **CYB206-25S-001**.

This project was assigned by our professor, and it's a comprehensive ASP.NET Core MVC application demonstrating CRUD operations, routing, data binding, seeding, and more.

---

 Project Timeline & Milestones

2025-05-27
Team Zeta was formed under the guidance of our professor.
Project topic "Chair" was assigned.

#2025-06-01
15:10: Project officially selected and initialized.
Created ASP.NET Core MVC project using Visual Studio.
Scaffolded a basic MVC structure.
Successfully ran the default app at `https://localhost:7092/`.

Feature Development
Added `HelloWorldController`, routed `/HelloWorld/Chair`.
Implemented parameter passing: `/HelloWorld/chair?name=rick&numtimes=4`.
Used `ViewData` for data passing.
Created and tested Razor views: `Index.cshtml`, `Chairs.cshtml`.

CRUD & Database
Used scaffolding to create CRUD for Chair.
Ran EF Core migrations to set up the database:
20250601160123_InitialCreate.cs`
Seeded initial data using a custom `SeedData.cs` initializer.
Enhanced UI with data annotations and placeholders.

2025-06-02
 Added search filter and rating field.
 Updated model and controller accordingly.
New migration: `20250601203833_UpdateChairRatingToDecimal.cs`.
Implemented and tested input validation.

 2025-06-03
 Added a logo image to represent the "Chair" theme in the UI.




 Features

- Create, Read, Update, Delete (CRUD) operations for Chair entities
- URL routing and parameter passing
- Razor views with dynamic data
- Search filter functionality
- Input validation and annotations
- Database seeding with custom initializer
- Responsive UI with logo and styling
- Full MVC separation and clean project structure



