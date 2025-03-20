using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
.AddEnvironmentVariables();

//הוספת הממשק של סוואגר
 builder.Services.AddEndpointsApiExplorer(); 
 
builder.Services.AddSwaggerGen(options=>
{
    options.SwaggerDoc("v1",new OpenApiInfo
    {
        Title="ToDoApi",
        Version="v1",
        Description="A simple API for managing tasks"
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {

                  policy.AllowAnyOrigin()  // מתיר לכל דומיין לגשת
                        .AllowAnyMethod()  // מתיר כל מתודה (GET, POST, PUT, DELETE)
                        .AllowAnyHeader(); // מתיר כל כותרת (Header)
    });
    });


builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"))
);


   builder.Services.AddAuthorization();

var app = builder.Build();
app.UseCors();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1");
    c.RoutePrefix = string.Empty;  // Swagger UI יהיה בכתובת הבסיס
});
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
    try
    {
        dbContext.Database.CanConnect();
        Console.WriteLine("✅ חיבור ל-MySQL תקין!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ שגיאה בחיבור ל-MySQL: {ex.Message}");
    }
}

 app.MapGet("/", () => "Hello World!");

// שליפת כל המשימות
app.MapGet("/items", async (ToDoDbContext context) =>
{
   
 Console.WriteLine("😊");
    var tasks = await context.itemes.ToListAsync();
    Console.WriteLine(tasks);
     return Results.Ok(tasks);
    
});

//הוספת משימה חדשה
// app.MapPost("/addTask", async (ToDoDbContext context, Itemes task) =>
// {
//     await context.itemes.AddAsync(task);
//     await context.SaveChangesAsync();
//     return Results.Created($"/items/{task.Id}", task);
// });
app.MapPost("/addTask", async (ToDoDbContext context, Itemes i) =>
{
    i.IsComplete = false;
    await context.itemes.AddAsync(i);
    await context.SaveChangesAsync();
    var result = await context.itemes.FindAsync(i.Id);
    return result;
}
);

// עדכון משימה
app.MapPut("/update/{id}", async (ToDoDbContext context, int id, Itemes updatedTask) =>
{
    var task = await context.itemes.FindAsync(id);
    if (task ==null) 
    return Results.NotFound(); // החזרת שגיאה אם המשימה לא קיימת

    task.Name = updatedTask.Name;
    task.IsComplete = updatedTask.IsComplete;

    await context.SaveChangesAsync();
    return Results.Ok(task);
});

// מחיקת משימה
app.MapDelete("/delete/{id}", async (ToDoDbContext context, int id) =>
{
    var task = await context.itemes.FindAsync(id);
    if (task is null)
     return Results.NotFound();

    context.itemes.Remove(task);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

 app.Run();




