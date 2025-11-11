//using MerchantApplication
//using MerchantInfrastructure

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//step 01 // ✅ Register Application Layer
builder.Services.AddApplication();


//step 02 // ✅ Register MediatR — register all handlers in the Application assembly
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(MerchantApplication.Features.Merchants.Commands.AddMerchant.AddMerchantHandler).Assembly)
);

// step 03 // ✅ Register AutoMapper (optional)
builder.Services.AddAutoMapper(typeof(MerchantApplication.AssemblyMarker));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
