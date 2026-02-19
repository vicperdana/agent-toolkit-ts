# Spec-Driven Development Workflow

This project uses a **spec-driven development** workflow. Instead of jumping straight into code, features are planned through three structured phases with approval gates.

## Why Spec-Driven?

- **Reduces rework** — requirements and design are validated before any code is written
- **Better AI output** — structured context produces higher-quality generated code
- **Traceability** — every task links back to requirements, every design choice is documented
- **Incremental delivery** — each phase produces a reviewable artifact

## The 3-Phase Workflow

```
 ┌─────────────┐     ┌─────────────┐     ┌─────────────┐     ┌─────────────┐
 │ Requirements │ ──▶ │   Design    │ ──▶ │    Tasks    │ ──▶ │ Implement   │
 │   (WHAT)     │     │   (HOW)     │     │   (DO)      │     │   (CODE)    │
 └─────────────┘     └─────────────┘     └─────────────┘     └─────────────┘
    ▲ approve           ▲ approve           ▲ approve
```

Each phase requires **explicit approval** before proceeding to the next.

## Quick Start

### Step 1: Create Requirements

Describe your feature idea to the `@speckit-specify` agent:

```
@speckit-specify Add a product catalog page that shows browsable products with name, description, and price
```

The agent will:
1. Read the requirements template from `.specs/templates/requirements-template.md`
2. Scan `.specs/features/` to determine the next feature number
3. Generate `.specs/features/{NNN}-{feature-name}/requirements.md`
4. Present it for your review

**What to look for:**
- Are the user stories accurate and complete?
- Do the EARS acceptance criteria cover edge cases?
- Are there any `[NEEDS CLARIFICATION]` markers to resolve?

Say **"approved"** when satisfied, or provide feedback to refine.

### Step 2: Create Design

Use the handoff button **"Create Design"** from the specify agent, or invoke the plan agent directly:

```
@plan Create a technical design for the product catalog feature. 
Read the requirements from .specs/features/001-product-catalog/requirements.md 
and the design template from .specs/templates/design-template.md.
Save as .specs/features/001-product-catalog/design.md
```

The design document covers:
- Component architecture (entities, interfaces, pages)
- Data models and relationships
- Error handling strategy
- Testing strategy (unit + component tests)

**What to look for:**
- Does the architecture follow Clean Architecture (Shared → Web)?
- Are the right render modes chosen (SSR by default)?
- Is the testing strategy comprehensive?

Say **"approved"** when satisfied.

### Step 3: Create Tasks

Use the handoff button **"Break into Tasks"**, or invoke the task agent:

```
@task Break the product catalog feature into implementation tasks.
Read the requirements and design from .specs/features/001-product-catalog/
and the tasks template from .specs/templates/tasks-template.md.
Save as .specs/features/001-product-catalog/tasks.md
```

Tasks are organized into phases:
1. **Domain & Contracts** — entities, interfaces, service registration
2. **Tests (Write First)** — unit and component tests that MUST FAIL initially
3. **Implementation** — services, pages, UI components
4. **Validation & Polish** — verify tests pass, build clean, formatting

### Step 4: Implement

Work through the tasks incrementally. Each task has:
- Clear deliverables (exact file paths)
- Requirements traceability
- Dependencies on other tasks

Validate after each phase:
```bash
dotnet build    # Zero warnings
dotnet test     # All tests pass
dotnet format --verify-no-changes   # Code style
```

## Directory Structure

```
.specs/
├── templates/                          # Reusable templates (don't modify)
│   ├── requirements-template.md        # Phase 1: user stories + EARS criteria
│   ├── design-template.md              # Phase 2: architecture + components
│   └── tasks-template.md               # Phase 3: numbered implementation checklist
└── features/                           # Feature specifications (one folder per feature)
    └── 001-sample-feature/             # Example: product catalog
        ├── requirements.md             # What to build
        ├── design.md                   # How to build it (created in Phase 2)
        └── tasks.md                    # Step-by-step plan (created in Phase 3)
```

## Agent Reference

| Agent | When to Use | Input | Output |
|-------|------------|-------|--------|
| `@speckit-specify` | Starting a new feature | Feature description in plain language | `requirements.md` |
| `@plan` | After requirements are approved | Requirements doc + design template | `design.md` |
| `@task` | After design is approved | Requirements + design + tasks template | `tasks.md` |

## EARS Acceptance Criteria Format

This project uses [EARS](https://ieeexplore.ieee.org/document/5328509) (Easy Approach to Requirements Syntax) for acceptance criteria:

| Pattern | When to Use | Example |
|---------|-------------|---------|
| **WHEN** X, **THEN SHALL** Y | Event-driven | WHEN user navigates to /products, THEN the system SHALL display all products |
| **IF** X, **THEN SHALL** Y | Conditional | IF no products exist, THEN the system SHALL show an empty-state message |
| **WHILE** X, **SHALL** Y | State-driven | WHILE data is loading, the system SHALL display a spinner |

## Tips

- **Start small** — your first spec doesn't need to cover everything. Add detail iteratively.
- **Resolve all `[NEEDS CLARIFICATION]` markers** before approving requirements.
- **Don't skip phases** — the approval gates exist to catch issues early.
- **Keep specs in version control** — they're living documentation that evolves with the code.
- **Reference the sample** — see [`.specs/features/001-sample-feature/requirements.md`](../.specs/features/001-sample-feature/requirements.md) for a complete example.

## Example Walkthrough

Here's a complete example building a product catalog:

```
User:   @speckit-specify Add a product catalog page with browsable products

Agent:  [Generates requirements.md with user stories, EARS criteria, tech context]
        "Here's the requirements document. Review and approve, or provide feedback."

User:   Approved. Create the design.

Agent:  [Hands off to @plan, generates design.md with architecture, components, tests]
        "Here's the technical design. Review and approve."

User:   Approved. Break into tasks.

Agent:  [Hands off to @task, generates tasks.md with numbered checklist]
        "Here are the implementation tasks organized by phase."

User:   Start implementing from task 1.1.

Agent:  [Begins incremental implementation, one task at a time]
```

Total planning time: ~10 minutes. Result: a fully documented, traceable feature with clear implementation steps.
