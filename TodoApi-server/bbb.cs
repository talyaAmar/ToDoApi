// using System.Diagnostics;
// using Microsoft.AspNetCore.Cors.Infrastructure;
// using Microsoft.EntityFrameworkCore;
// using ToDoApi;
// using Microsoft.OpenApi.Models;
// using System.Security.Claims;
// using Microsoft.IdentityModel.Tokens;
// using System.Text;
// using System.IdentityModel.Tokens.Jwt;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.CodeAnalysis.CSharp.Syntax;
// using Microsoft.AspNetCore.Mvc;


// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllers();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddCors(opt =>
// {
//     opt.AddPolicy("CorsPolicy", PolicyBuilder =>
//     {
//         PolicyBuilder
//     .AllowAnyOrigin()
//     .AllowAnyHeader()
//     .AllowAnyMethod();
//     });
// });

// builder.Services.AddDbContext<ToDoDbContext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("tododb"),
//     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("tododb"))));

    
// builder.Services.AddSwaggerGen(options =>
// {
//     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         Scheme = "Bearer",
//         BearerFormat = "JWT",
//         In = ParameterLocation.Header,
//         Name = "Authorization",
//         Description = "Bearer Authentication with JWT Token",
//         Type = SecuritySchemeType.Http
//     });
//     options.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//         Reference = new OpenApiReference
//                 {
//                     Id = "Bearer",
//                     Type = ReferenceType.SecurityScheme
//                 }
//             },
//             new List<string>()
//         }
//     });
// });

// var app = builder.Build();
// app.UseCors("CorsPolicy");
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.Use(async (context, next) =>
// {
//     try
//     {
//         await next(); // המשך לבקשה הבאה
//     }
//     catch (Exception ex)
//     {
//         var logger = app.Services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "שגיאה התרחשה במהלך עיבוד הבקשה.");

//         context.Response.StatusCode = 500;
//         context.Response.ContentType = "application/json";
//       await context.Response.WriteAsync($"{{\"שגיאה\": \"אירעה שגיאה בשרת: {ex.Message}\", \"סטאק\": \"{ex.StackTrace}\"}}");
//     }
// });




// System.Console.WriteLine("hiijgyhjf");



// app.MapGet("/", () => "Hello World!");

// app.MapGet("/items", async (ToDoDbContext context) =>
//     await context.Items.ToListAsync());



// app.MapPost("/addTask", async (ToDoDbContext context, Item i) =>
// {
//     i.IsComplete = false;
//     await context.Items.AddAsync(i);
//     await context.SaveChangesAsync();
//     var result = await context.Items.FindAsync(i.Id);
//     return result;
// }
// );

// app.MapPut("/update/{id}", async (ToDoDbContext context,int id,Item item) =>
// {

//     var r = await context.Items.FindAsync(id);

//     if (r == null)
//     {
//         return Results.NotFound();  // החזרת שגיאה אם המשימה לא קיימת
//     }
//     else
//     {
//        r.Id=item.Id;
//        r.Name=item.Name;
//        r.IsComplete=item.IsComplete;
//     }
//     await context.SaveChangesAsync();
//     return Results.Ok(r);
// }
// );


// app.MapDelete("/delete/{id}", async (ToDoDbContext context, int id) =>
// {
//     var r = await context.Items.FindAsync(id);

//     if (r == null)
//     {
//         return Results.NotFound();  // החזרת שגיאה אם המשימה לא קיימת
//     }

//     context.Items.Remove(r);
//     await context.SaveChangesAsync();
//     return Results.Ok(r);
// }
// );

// app.UseAuthentication();
// app.UseAuthorization();
// app.UseHttpsRedirection();
// app.Run();