var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();

var app = builder.Build();

// Configurar el pipeline HTTP
app.UseHttpsRedirection();

app.UseAuthorization();

// Importante: habilita tus controllers (ProductsController, etc.)
app.MapControllers();

app.Run();
