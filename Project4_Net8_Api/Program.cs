using Lib_Config;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Cors
builder.Services.RegisterAddCors();

//Connect database sqlsever
builder.Services.RegisterDbContext(builder.Configuration);

// Cấu hình JWT
builder.Services.RegisterJwt(builder.Configuration);

//Scoped
builder.Services.RegisterRepositoryScoped();

// AddHttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
