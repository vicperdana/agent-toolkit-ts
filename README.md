# Agent Toolkit

A .NET 10 Blazor Web App starter template using Clean Architecture patterns.

## Tech Stack

- **Framework**: ASP.NET Core 10.0 (LTS)
- **UI**: Blazor Web App with Server-Side Rendering (SSR)
- **Language**: C# 14
- **Styling**: Tailwind CSS 4.x
- **Testing**: xUnit + bUnit

## Project Structure

```
/
├── src/
│   ├── Web/                 # Blazor UI (entry point)
│   │   ├── Components/      # Razor components
│   │   ├── Styles/          # Tailwind CSS source
│   │   └── wwwroot/         # Static assets
│   └── Shared/              # Shared library
│       ├── Entities/        # Domain models
│       ├── Interfaces/      # Service interfaces
│       └── Extensions/      # Extension methods
├── tests/
│   └── Web.Tests/           # Unit + component tests
├── AgentToolkit.sln         # Solution file
├── Directory.Build.props    # Shared build properties
├── Directory.Packages.props # Central Package Management
├── global.json              # SDK version pin
├── .specs/                  # Spec-driven development
│   ├── templates/           # Requirements, design, tasks templates
│   └── features/            # Feature specifications
└── docs/                    # Project documentation
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (for Tailwind CSS)

## Getting Started

```bash
# Build entire solution
dotnet build

# Run web app with hot reload
dotnet watch --project src/Web

# Run all tests
dotnet test
```

## Development

### Build Tailwind CSS manually

```bash
cd src/Web
npm install
npm run css:build
```

### Watch mode for CSS

```bash
cd src/Web
npm run css:watch
```

## Architecture

This project follows **Clean Architecture** principles:

- **Shared**: Contains domain entities, interfaces, and extensions (no external dependencies)
- **Web**: Blazor UI that depends on Shared
- **Web.Tests**: Tests for both Web and Shared projects

The architecture is designed to be scalable - Shared can be split into ApplicationCore + Infrastructure as the project grows.

## Spec-Driven Development

This project uses a **spec-driven development** workflow for structured feature development:

1. **Requirements** — Define what to build (user stories + EARS acceptance criteria)
2. **Design** — Define how to build it (architecture, components, tests)
3. **Tasks** — Break into numbered implementation steps

Each phase requires approval before proceeding. See [docs/sdd-workflow.md](docs/sdd-workflow.md) for the full guide and [`.specs/features/001-sample-feature/`](.specs/features/001-sample-feature/) for an example.

## References

- [Microsoft Clean Architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
- [eShopOnWeb Reference Architecture](https://github.com/dotnet-architecture/eShopOnWeb)
- [ASP.NET Core Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
