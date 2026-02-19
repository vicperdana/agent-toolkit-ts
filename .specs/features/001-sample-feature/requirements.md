# Product Catalog Requirements

## 1. Introduction

Add a product catalog page to the Agent Toolkit that displays a browsable list of products. This demonstrates a complete vertical slice through the Clean Architecture — entity, service interface, implementation, Blazor page, and tests.

**Architecture Overview**: A new `Product` entity in `src/Shared/Entities/`, a service interface in `src/Shared/Interfaces/`, and a Blazor page in `src/Web/Components/Pages/` that renders the catalog using static SSR with Tailwind CSS styling.

## 2. User Stories

### End Users
- **As a** visitor, **I want to** see a list of products on a catalog page, **so that** I can browse what's available
- **As a** visitor, **I want to** see product details (name, description, price), **so that** I can evaluate items
- **As a** visitor, **I want to** see a message when no products exist, **so that** I understand the catalog is empty

### Developers
- **As a** developer, **I want to** follow the existing Clean Architecture pattern, **so that** the feature is consistent with the codebase

## 3. Acceptance Criteria

### Core Functionality
- **WHEN** a user navigates to `/products`, **THEN** the system **SHALL** display a list of all products
- **WHEN** a product has a name, description, and price, **THEN** the system **SHALL** display all three fields
- **IF** no products exist, **THEN** the system **SHALL** display an empty-state message

### User Experience
- **WHEN** the product list is loading, **THEN** the system **SHALL** display a loading indicator
- **WHEN** products are displayed, **THEN** the system **SHALL** use Tailwind CSS card styling

### Error Handling
- **IF** the product service throws an exception, **THEN** the system **SHALL** log the error and display a user-friendly message

## 4. Technical Architecture

- **Framework**: ASP.NET Core 10.0 with Blazor Web App
- **Language**: C# 14
- **Rendering**: Static SSR (no interactive render mode needed)
- **Styling**: Tailwind CSS 4.x
- **Testing**: xUnit (unit) + bUnit (component)

### Project Structure
```
src/Shared/Entities/Product.cs            # Domain model
src/Shared/Interfaces/IProductService.cs  # Service contract
src/Web/Components/Pages/Products.razor   # Catalog page

tests/Web.Tests/UnitTests/ProductServiceTests.cs
tests/Web.Tests/ComponentTests/ProductsTests.cs
```

## 5. Success Criteria

- **WHEN** `dotnet build` is run, **THEN** the solution **SHALL** compile with zero warnings
- **WHEN** `dotnet test` is run, **THEN** all tests **SHALL** pass
- **WHEN** a user navigates to `/products`, **THEN** they **SHALL** see the product catalog

## 6. Assumptions and Constraints

### Assumptions
- Product data is seeded in-memory for this initial implementation (no database required)
- The product list is read-only (no create/update/delete operations)

### Constraints
- Use existing 3-project structure (Web, Shared, Web.Tests) — no new projects
- Use static SSR — no interactive render mode
- Follow conventions in `AGENTS.md`

---

**Document Status**: Sample (for demo purposes)
**Last Updated**: 2026-02-19
**Approval**: [x] Approved — proceed to Design phase
