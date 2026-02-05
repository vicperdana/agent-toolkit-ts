# Agent Toolkit - .NET 10 Web App

A Blazor Web App built with .NET 10 LTS, featuring server-side rendering (SSR) and Tailwind CSS.

## Tech Stack

- **Framework**: ASP.NET Core 10.0 (LTS)
- **UI**: Blazor Web App with Server-Side Rendering
- **Language**: C# 14
- **Styling**: Tailwind CSS 4.x
- **Font**: Inter (Google Fonts)

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (for Tailwind CSS compilation)

## Getting Started

### Development

```bash
# Install dependencies and build CSS
npm install
npm run css:build

# Run the app with hot reload
dotnet watch run
```

### Build

```bash
dotnet build
```

### Publish

```bash
dotnet publish -c Release
```

## Project Structure

```
web/
├── Components/
│   ├── App.razor              # Root component (HTML shell)
│   ├── Routes.razor           # Router configuration
│   ├── _Imports.razor         # Global using directives
│   ├── Layout/
│   │   └── MainLayout.razor   # Main layout component
│   └── Pages/
│       ├── Home.razor         # Home page (@page "/")
│       ├── Error.razor        # Error page
│       └── NotFound.razor     # 404 page
├── Styles/
│   └── app.css                # Tailwind CSS source
├── wwwroot/
│   ├── css/                   # Compiled CSS (gitignored)
│   └── favicon.ico
├── Program.cs                 # App entry point
├── Web.csproj                 # Project file
├── appsettings.json           # Configuration
└── package.json               # Tailwind CSS build scripts
```

## Styling

This project uses Tailwind CSS 4.x. The source CSS is in `Styles/app.css` and compiles to `wwwroot/css/app.css`.

### Build CSS manually

```bash
npm run css:build
```

### Watch mode (for development)

```bash
npm run css:watch
```

> Note: The MSBuild target automatically builds CSS when you run `dotnet build` if the compiled CSS doesn't exist or in Release mode.

## Architecture Notes

- **SSR by default**: All components render on the server and send HTML to the client
- **No interactivity by default**: To add client-side interactivity, enable Interactive Server or WebAssembly render modes
- **Equivalent to Next.js RSC**: Server-side rendering model is conceptually similar to React Server Components
