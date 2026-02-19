# [Feature Name] Implementation Tasks

## Task Overview

**Feature**: [Feature name from requirements.md]
**Total Tasks**: [X] tasks in [Y] phases
**References**: [`requirements.md`](requirements.md) · [`design.md`](design.md)

## Implementation Tasks

### Phase 1: Domain & Contracts

- [ ] **1.1** Create domain entity in `src/Shared/Entities/[Entity].cs`
  - **Deliverables**: Entity class with properties per design.md
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: None

- [ ] **1.2** Create service interface in `src/Shared/Interfaces/I[Service].cs`
  - **Deliverables**: Interface with method signatures per design.md
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 1.1

- [ ] **1.3** Register service in `src/Shared/Extensions/ServiceCollectionExtensions.cs`
  - **Deliverables**: Add registration in `AddSharedServices()`
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 1.2

### Phase 2: Tests (Write First)

- [ ] **2.1** Create unit tests in `tests/Web.Tests/UnitTests/[Service]Tests.cs`
  - **Deliverables**: Tests for all service interface methods; tests MUST FAIL initially
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 1.2

- [ ] **2.2** Create component tests in `tests/Web.Tests/ComponentTests/[Page]Tests.cs`
  - **Deliverables**: bUnit tests for page rendering and interactions; tests MUST FAIL initially
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 1.2

### Phase 3: Implementation

- [ ] **3.1** Implement service in `src/Web/Services/[Service].cs` (or `src/Shared/`)
  - **Deliverables**: Service implementation that makes unit tests pass
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 2.1

- [ ] **3.2** Create page component in `src/Web/Components/Pages/[Page].razor`
  - **Deliverables**: Blazor page with `@page` directive, `<PageTitle>`, Tailwind CSS styling
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 3.1

- [ ] **3.3** Create UI components in `src/Web/Components/UI/` (if needed)
  - **Deliverables**: Reusable Razor components with parameters
  - **Requirements**: [Reference acceptance criteria]
  - **Dependencies**: 3.2

### Phase 4: Validation & Polish

- [ ] **4.1** Verify all tests pass
  - **Deliverables**: `dotnet test` passes with all green
  - **Requirements**: All acceptance criteria
  - **Dependencies**: 3.2

- [ ] **4.2** Verify build has zero warnings
  - **Deliverables**: `dotnet build` compiles with no warnings (`TreatWarningsAsErrors`)
  - **Requirements**: Build quality
  - **Dependencies**: 4.1

- [ ] **4.3** Verify code formatting
  - **Deliverables**: `dotnet format --verify-no-changes` passes
  - **Requirements**: Code style per `.editorconfig`
  - **Dependencies**: 4.1

## Task Guidelines

### Completion Criteria
Each task is complete when:
- [ ] All deliverables are implemented
- [ ] Related tests pass (or fail as expected in Phase 2)
- [ ] Code follows `AGENTS.md` conventions
- [ ] No new warnings introduced

### Path Conventions
- **Entities**: `src/Shared/Entities/`
- **Interfaces**: `src/Shared/Interfaces/`
- **Extensions**: `src/Shared/Extensions/`
- **Pages**: `src/Web/Components/Pages/`
- **UI Components**: `src/Web/Components/UI/`
- **Layout**: `src/Web/Components/Layout/`
- **Unit Tests**: `tests/Web.Tests/UnitTests/`
- **Component Tests**: `tests/Web.Tests/ComponentTests/`

---

**Task Status**: Not Started
**Current Phase**: Phase 1
**Progress**: 0/[X] tasks completed
**Last Updated**: [Date]
