---
name: blazor-best-practices
description: Blazor Web App best practices for .NET 10 - component patterns, SSR, routing, state management, and Tailwind CSS integration
---

# Blazor Web App Best Practices

## When to Use This Skill

- Creating new Blazor components
- Implementing page routing
- Managing component state
- Integrating Tailwind CSS with Blazor
- Choosing render modes (SSR vs Interactive)

## Component Structure

### Page Components

```razor
@page "/products"
@page "/products/{Id:int}"

<PageTitle>Products</PageTitle>

<div class="container mx-auto px-4">
    @if (products is null)
    {
        <p class="text-gray-500">Loading...</p>
    }
    else
    {
        <ul class="space-y-2">
            @foreach (var product in products)
            {
                <li class="p-4 bg-white rounded shadow">@product.Name</li>
            }
        </ul>
    }
</div>

@code {
    [Parameter]
    public int? Id { get; set; }

    private List<Product>? products;

    protected override async Task OnInitializedAsync()
    {
        products = await ProductService.GetAllAsync();
    }
}
```

### Reusable Components

```razor
@* Components/UI/Button.razor *@

<button class="@ComputedClass" @onclick="OnClick" disabled="@Disabled">
    @ChildContent
</button>

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string Variant { get; set; } = "primary";

    private string ComputedClass => Variant switch
    {
        "primary" => "px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700 disabled:opacity-50",
        "secondary" => "px-4 py-2 bg-gray-200 text-gray-800 rounded hover:bg-gray-300 disabled:opacity-50",
        "danger" => "px-4 py-2 bg-red-600 text-white rounded hover:bg-red-700 disabled:opacity-50",
        _ => "px-4 py-2 bg-blue-600 text-white rounded"
    };
}
```

## Render Modes

### Static SSR (Default)

```razor
@* No render mode attribute = static SSR *@
@page "/about"

<PageTitle>About</PageTitle>

<div class="prose">
    <h1>About Us</h1>
    <p>This content is rendered on the server.</p>
</div>
```

### Interactive Server

```razor
@page "/counter"
@rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<p class="text-xl">Current count: @currentCount</p>

<button class="px-4 py-2 bg-blue-600 text-white rounded" @onclick="IncrementCount">
    Click me
</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

### Per-Component Interactivity

```razor
@* Static page with interactive component *@
@page "/dashboard"

<PageTitle>Dashboard</PageTitle>

<div class="grid grid-cols-2 gap-4">
    @* Static content *@
    <div class="p-4 bg-white rounded shadow">
        <h2>Statistics</h2>
        <p>Total users: @totalUsers</p>
    </div>

    @* Interactive component *@
    <LiveChart @rendermode="InteractiveServer" />
</div>

@code {
    private int totalUsers = 1234;
}
```

## Routing

### Route Parameters

```razor
@page "/users/{UserId:int}"
@page "/users/{UserId:int}/posts/{PostId:guid}"

@code {
    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public Guid PostId { get; set; }
}
```

### Query Parameters

```razor
@page "/search"

@code {
    [SupplyParameterFromQuery]
    public string? Query { get; set; }

    [SupplyParameterFromQuery(Name = "page")]
    public int CurrentPage { get; set; } = 1;
}
```

### Navigation

```razor
@inject NavigationManager Navigation

<button @onclick="GoToProducts">View Products</button>

@code {
    private void GoToProducts()
    {
        Navigation.NavigateTo("/products");
    }
}
```

## Forms and Validation

```razor
@page "/contact"

<EditForm Model="@contactForm" OnValidSubmit="@HandleSubmit" FormName="contact">
    <DataAnnotationsValidator />
    <ValidationSummary class="text-red-600 mb-4" />

    <div class="mb-4">
        <label class="block text-sm font-medium mb-1">Name</label>
        <InputText @bind-Value="contactForm.Name" 
                   class="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500" />
        <ValidationMessage For="@(() => contactForm.Name)" class="text-red-600 text-sm" />
    </div>

    <div class="mb-4">
        <label class="block text-sm font-medium mb-1">Email</label>
        <InputText @bind-Value="contactForm.Email" type="email"
                   class="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500" />
        <ValidationMessage For="@(() => contactForm.Email)" class="text-red-600 text-sm" />
    </div>

    <button type="submit" class="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700">
        Submit
    </button>
</EditForm>

@code {
    [SupplyParameterFromForm]
    private ContactForm contactForm { get; set; } = new();

    private async Task HandleSubmit()
    {
        // Process form
    }

    public class ContactForm
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}
```

## Dependency Injection

```razor
@page "/products"
@inject IProductService ProductService
@inject ILogger<Products> Logger

@code {
    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("Loading products");
        // Use ProductService
    }
}
```

## Tailwind CSS Integration

### Conditional Classes

```razor
<div class="@GetCardClass(isSelected)">
    @content
</div>

@code {
    private string GetCardClass(bool selected) =>
        selected
            ? "p-4 bg-blue-100 border-2 border-blue-500 rounded"
            : "p-4 bg-white border border-gray-200 rounded";
}
```

### Dark Mode

```razor
<div class="bg-white dark:bg-zinc-900 text-gray-900 dark:text-gray-100">
    Content adapts to color scheme
</div>
```

## Anti-Patterns to Avoid

```razor
@* ❌ WRONG: Don't use @onclick with static SSR *@
@page "/static-page"
<button @onclick="DoSomething">Click</button>  @* Won't work without interactivity *@

@* ✅ CORRECT: Use form submission for static pages *@
<form method="post" @onsubmit="DoSomething" @formname="action-form">
    <AntiforgeryToken />
    <button type="submit">Click</button>
</form>

@* ❌ WRONG: Blocking async operations *@
protected override void OnInitialized()
{
    data = GetDataAsync().Result;  // NEVER block
}

@* ✅ CORRECT: Proper async pattern *@
protected override async Task OnInitializedAsync()
{
    data = await GetDataAsync();
}

@* ❌ WRONG: Heavy logic in component *@
@code {
    private decimal CalculateComplexTax(Order order) { /* 100 lines */ }
}

@* ✅ CORRECT: Move to service *@
@inject ITaxService TaxService
@code {
    private decimal tax = await TaxService.CalculateAsync(order);
}
```

## File Structure Convention

```
Components/
├── _Imports.razor          # Global usings
├── App.razor               # Root component
├── Routes.razor            # Router
├── Layout/
│   └── MainLayout.razor    # Main layout
├── Pages/
│   ├── Home.razor          # @page "/"
│   ├── Products.razor      # @page "/products"
│   └── Error.razor         # Error page
└── UI/                     # Reusable components
    ├── Button.razor
    ├── Card.razor
    └── Modal.razor
```
