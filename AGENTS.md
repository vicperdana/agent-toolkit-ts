# AGENTS.md — Project Guidelines for AI Assistants

Guidelines for AI assistants (e.g., Codex, GitHub Copilot) contributing to this repo.

## Golden rules

- Make small, correct, reviewable changes. Prefer the simplest solution that fits existing patterns.
- Keep diffs minimal; don't refactor unrelated code.
- Prefer existing repo patterns over general best practices.
- Don't add dependencies unless clearly necessary (explain why).
- You have access to skills in `.github/skills` for project-specific best practices and patterns.

## Tech Stack

- **Framework**: ASP.NET Core 10.0 (LTS) with Blazor Web App
- **Language**: C# 14
- **UI**: Blazor components with Server-Side Rendering (SSR)
- **Styling**: Tailwind CSS 4.x
- **Linting/formatting**: `dotnet format` / Roslyn Analyzers
- **Testing**: xUnit + bUnit (if tests exist)

## Project Structure

```
web/
├── Components/           # Razor components
│   ├── Layout/          # Layout components
│   └── Pages/           # Routable page components
├── Styles/              # Tailwind CSS source files
├── wwwroot/             # Static assets
├── Program.cs           # App entry point
└── Web.csproj           # Project configuration
```

## Quality Bar

Run these from the `web/` directory:

```bash
# Build
dotnet build

# Run (with hot reload)
dotnet watch run

# Format
dotnet format

# Test (if tests exist)
dotnet test
```

## Blazor Conventions

- Use `@page` directive for routable components
- Prefer static SSR by default; add interactivity only when needed
- Use `<PageTitle>` for SEO-friendly page titles
- Keep components small and focused
- Use Tailwind utility classes for styling

## Final Response Requirements

Include:

- What you changed (1–5 bullets)
- Why you changed it
- How you verified it (exact commands + results; if you couldn't run commands, say so)
- Any follow-ups or risks (if applicable)
