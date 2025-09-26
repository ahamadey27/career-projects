# Project: Field Equipment Maintenance Log

**Goal:** To develop a full-stack CRUD (Create, Read, Update, Delete) application for logging and managing equipment maintenance records. The system will feature a Vue.js frontend, a C# .NET Core Web API backend, and a Microsoft SQL Server database, with all data operations handled exclusively through stored procedures.

---

# Components

## Application Architecture
- **Style:** Decoupled three-tier architecture.
- **Frontend (Client-Side):** Vue.js Single-Page Application (SPA).
- **Backend (Server-Side):** ASP.NET Core Web API.
- **Database (Persistence Layer):** Microsoft SQL Server.

## Environment & Tooling
- **IDE:** Visual Studio Code
- **Version Control:** Git
- **Core Runtimes:** .NET SDK, Node.js with npm
- **Key VS Code Extensions:** C# Dev Kit, Vue - Official, SQL Server (mssql)
- **Core Libraries:**
    - **Backend:** Entity Framework Core (for stored procedure execution)
    - **Frontend:** Axios (for HTTP requests)

---

# Core Services and Data Structures

## Database Schema (`MaintenanceLogDB`)
- **Responsibilities:** To provide persistent storage for all maintenance records and define the data access layer via stored procedures.
- **Table: `MaintenanceRecords`**
    - `Id`: `INT PRIMARY KEY IDENTITY(1,1)`
    - `EquipmentName`: `NVARCHAR(100)`
    - `Description`: `NVARCHAR(MAX)`
    - `MaintenanceDate`: `DATETIME2`
    - `PerformedBy`: `NVARCHAR(100)`
    - `IsCompleted`: `BIT`
- **Stored Procedures:**
    - `sp_GetAllMaintenanceRecords`: Retrieves all records.
    - `sp_GetMaintenanceRecordById`: Retrieves a single record by its ID.
    - `sp_CreateMaintenanceRecord`: Inserts a new record.
    - `sp_UpdateMaintenanceRecord`: Updates an existing record.
    - `sp_DeleteMaintenanceRecord`: Deletes a record by its ID.

## Backend .NET Model (`MaintenanceRecord.cs`)
- **Responsibilities:** To provide a C# class that represents the structure of a single record from the `MaintenanceRecords` table.
- **Properties:**
    - `Id`: `int`
    - `EquipmentName`: `string`
    - `Description`: `string`
    - `MaintenanceDate`: `DateTime`
    - `PerformedBy`: `string`
    - `IsCompleted`: `bool`

## Backend API Controller (`MaintenanceController.cs`)
- **Route:** `api/maintenance`
- **Responsibilities:** To expose the database's stored procedures as a RESTful API over HTTP, handling all CRUD operations.
- **Endpoints (Actions):**
    - `GET /`: Executes `sp_GetAllMaintenanceRecords`.
    - `GET /{id}`: Executes `sp_GetMaintenanceRecordById`.
    - `POST /`: Executes `sp_CreateMaintenanceRecord`.
    - `PUT /{id}`: Executes `sp_UpdateMaintenanceRecord`.
    - `DELETE /{id}`: Executes `sp_DeleteMaintenanceRecord`.

## Frontend API Service (`apiService.js`)
- **Responsibilities:** To centralize all communication with the backend API, providing a clean, reusable service layer for the Vue components.
- **Key Methods:**
    - `getAllRecords()`
    - `getRecord(id)`
    - `createRecord(record)`
    - `updateRecord(id, record)`
    - `deleteRecord(id)`

## Configuration
- **Backend (`appsettings.json`):** Contains the `DefaultConnection` string for connecting to the SQL Server database.
- **Backend (`Program.cs`):** Defines the Cross-Origin Resource Sharing (CORS) policy required to allow the Vue.js frontend to communicate with the API.

---

# Development Plan

## Part 1: Environment and Database Setup
- [ ] **Step 1.1: Install Core Tools:** Set up the development machine with the .NET SDK, Node.js (with npm), and Git.
- [ ] **Step 1.2: Configure VS Code:** Install and configure the essential extensions for C#, Vue.js, and SQL Server development.
- [ ] **Step 1.3: Provision Database:** Install SQL Server and use a script to create the `MaintenanceLogDB` database, the `MaintenanceRecords` table, and all five CRUD stored procedures.

## Part 2: Backend API Development
- [ ] **Step 2.1: Project Initialization:** Create a new .NET Web API project and initialize a Git repository for source control.
- [ ] **Step 2.2: Data Modeling:** Define the `MaintenanceRecord` C# class and the `MaintenanceContext` using Entity Framework Core.
- [ ] **Step 2.3: Database Connection:** Configure the connection string in `appsettings.json` and register the `DbContext` in `Program.cs`.
- [ ] **Step 2.4: Controller Implementation:** Build the `MaintenanceController` with API actions that call the corresponding stored procedures using `FromSqlRaw` and `ExecuteSqlRawAsync`.
- [ ] **Step 2.5: CORS Configuration:** Implement a CORS policy to securely allow requests from the Vue application's origin.

## Part 3: Frontend UI Development
- [ ] **Step 3.1: Project Initialization:** Scaffold a new Vue.js project using `npm create vue@latest`.
- [ ] **Step 3.2: API Service Layer:** Create a centralized `apiService.js` module using Axios to handle all HTTP communication with the backend.
- [ ] **Step 3.3: Component Construction:** Build the primary UI in a single `App.vue` component, which includes a form for creating/editing records and a list for displaying all records.
- [ ] **Step 3.4: State Management and Logic:** Implement the component's script to manage the application's state (e.g., list of records, current record being edited) and to call the API service for all CRUD operations.
- [ ] **Step 3.5: Styling:** Add scoped CSS to `App.vue` to provide a clean and usable layout for the application.

## Part 4: Integration and Finalization
- [ ] **Step 4.1: Full-Stack Execution:** Run both the .NET API backend and the Vue.js frontend development servers concurrently.
- [ ] **Step 4.2: End-to-End Testing:** Thoroughly test all application features: creating a record, viewing the list, updating a record, canceling an edit, and deleting a record.
- [ ] **Step 4.3: Version Control:** Commit all changes to Git using clear, descriptive messages that reflect the work completed.