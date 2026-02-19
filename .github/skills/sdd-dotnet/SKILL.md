---
name: sdd-dotnet
description: Spec-driven development methodology for .NET 10 — structured workflow, EARS criteria, and Clean Architecture patterns
---

# Spec-Driven Development for .NET 10

## When to Use This Skill

- Starting a new feature (use the spec-driven workflow before coding)
- Writing requirements or acceptance criteria
- Creating technical design documents
- Breaking features into implementation tasks
- Reviewing specs for completeness

## The Spec-Driven Workflow

The workflow uses three phases with approval gates between each:

### Phase 1: Requirements (`requirements.md`)
Define WHAT needs to be built using user stories and EARS acceptance criteria.

```markdown
## User Stories
- **As a** user, **I want to** view a product list, **so that** I can browse available items

## Acceptance Criteria (EARS Format)
- **WHEN** user navigates to /products, **THEN** the system **SHALL** display all products
- **IF** no products exist, **THEN** the system **SHALL** show an empty-state message
```

**Approval gate**: Requirements must be reviewed and approved before proceeding.

### Phase 2: Design (`design.md`)
Define HOW it will be built — architecture, components, data models, testing strategy.

```markdown
## Components
- Entity: `src/Shared/Entities/Product.cs`
- Interface: `src/Shared/Interfaces/IProductService.cs`
- Page: `src/Web/Components/Pages/Products.razor`

## Testing Strategy
- Unit tests for service logic
- bUnit component tests for page rendering
```

**Approval gate**: Design must be reviewed and approved before proceeding.

### Phase 3: Tasks (`tasks.md`)
Numbered implementation checklist with deliverables and requirement traceability.

```markdown
- [ ] **1.1** Create Product entity in `src/Shared/Entities/Product.cs`
- [ ] **2.1** Write unit tests (must FAIL first)
- [ ] **3.1** Implement ProductService to make tests pass
```

**Approval gate**: Tasks must be reviewed before implementation begins.

## Directory Structure

```
.specs/
├── templates/                    # Reusable templates
│   ├── requirements-template.md
│   ├── design-template.md
│   └── tasks-template.md
└── features/                     # Feature specifications
    └── {NNN}-{feature-name}/     # One folder per feature
        ├── requirements.md       # Phase 1 output
        ├── design.md             # Phase 2 output
        └── tasks.md              # Phase 3 output
```

## EARS Acceptance Criteria Format

EARS (Easy Approach to Requirements Syntax) uses structured patterns:

| Pattern | Usage | Example |
|---------|-------|---------|
| **WHEN** ... **THEN** ... **SHALL** | Event-driven behavior | WHEN user clicks Save, THEN the system SHALL persist the record |
| **IF** ... **THEN** ... **SHALL** | Conditional behavior | IF the input is empty, THEN the system SHALL show a validation error |
| **WHILE** ... **THE SYSTEM SHALL** | State-driven behavior | WHILE data is loading, THE SYSTEM SHALL display a spinner |

## .NET Clean Architecture Patterns

### Domain in Shared
```csharp
// src/Shared/Entities/ — domain models (no dependencies)
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}

// src/Shared/Interfaces/ — contracts
public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync();
}
```

### UI in Web
```razor
@* src/Web/Components/Pages/Products.razor *@
@page "/products"
@inject IProductService ProductService

<PageTitle>Products</PageTitle>

@if (products is null)
{
    <p class="text-gray-500">Loading...</p>
}
else
{
    @foreach (var product in products)
    {
        <div class="p-4 bg-white rounded shadow">@product.Name</div>
    }
}

@code {
    private IReadOnlyList<Product>? products;

    protected override async Task OnInitializedAsync()
    {
        products = await ProductService.GetAllAsync();
    }
}
```

### Tests
```csharp
// tests/Web.Tests/ComponentTests/ProductsTests.cs
public class ProductsTests : TestContext
{
    [Fact]
    public void Renders_ProductList()
    {
        // Register mock service, render component, assert output
    }
}
```

## Quality Gates

Before any feature is complete, verify:

1. `dotnet build` — zero warnings (`TreatWarningsAsErrors` is enabled)
2. `dotnet test` — all tests pass
3. `dotnet format --verify-no-changes` — code style matches `.editorconfig`
4. All acceptance criteria from `requirements.md` are satisfied
