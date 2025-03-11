
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = "User ID=postgres;Password=runle303;Host=localhost;Port=5432;Database=ODataWebAPI;";
    options.UseNpgsql(connectionString);
});

builder.Services.AddControllers().AddOData(options =>
{
    options.EnableQueryFeatures();
});

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapOpenApi();

app.MapScalarApiReference();

app.MapGet("seed-data/categories", async (AppDbContext dbContext) =>
{
    Faker faker = new();

    var categoryNames = faker.Commerce.Categories(100);
    List<Category> categories = categoryNames.Select(s => new Category
    {
        Name = s,
    }).ToList();

    dbContext.AddRange(categories);

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
}).Produces(204).WithTags("SeedCategories");

app.MapControllers();

app.Run();
