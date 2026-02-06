# AGENTS.md — Project Guidelines for AI Assistants

Guidelines for AI assistants (e.g., Codex, GitHub Copilot) contributing to this repo.

## Golden Rules

- Make small, correct, reviewable changes
- Keep diffs minimal; don't refactor unrelated code
- Prefer existing repo patterns over general best practices
- Don't add dependencies unless clearly necessary

## Tech Stack

- **Framework**: ASP.NET Core 10.0 (LTS) with Blazor Web App
- **Language**: C# 14
- **Architecture**: Clean Architecture (Simplified)
- **UI**: Blazor components with Server-Side Rendering (SSR)
- **Styling**: Tailwind CSS 4.x
- **Testing**: xUnit + bUnit
- **Package Management**: Central Package Management (Directory.Packages.props)

## Project Structure

```
/
├── src/
│   ├── Web/                 # Blazor UI (entry point)
│   └── Shared/              # Shared library (domain, interfaces)
├── tests/
│   └── Web.Tests/           # Unit + component tests
├── AgentToolkit.sln         # Solution file
├── Directory.Build.props    # Shared build properties
├── Directory.Packages.props # Central Package Management
└── global.json              # SDK version
```

## Quality Bar

Run these from the solution root:

```bash
# Build
dotnet build

# Run tests
dotnet test

# Format code
dotnet format

# Run web app
dotnet run --project src/Web
```

## Conventions

### Clean Architecture Layers
- **Shared**: Domain entities, interfaces, extensions (no external dependencies)
- **Web**: Blazor UI, depends on Shared only
- **Web.Tests**: Tests for both projects

### Blazor Conventions
- Use `@page` directive for routable components
- Prefer static SSR by default; add interactivity only when needed
- Use `<PageTitle>` for SEO-friendly page titles
- Keep components small and focused
- Use Tailwind utility classes for styling

### Central Package Management
- All NuGet package versions defined in `Directory.Packages.props`
- Project files use `<PackageReference Include="..." />` without Version attribute
- Prevents version drift across projects

### Code Style
- Defined in `.editorconfig`
- Use `var` when type is apparent
- Prefer expression-bodied members for single-line methods
- Interface names start with `I`

## Final Response Requirements

Include:

- What you changed (1–5 bullets)
- Why you changed it
- How you verified it (exact commands + results)
- Any follow-ups or risks
