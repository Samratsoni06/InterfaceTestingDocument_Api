using InterfaceTestingDocument_Api.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var connectionString = builder.Configuration.GetConnectionString("ConStr");

        // Register the TestRepository with the connection string
        builder.Services.AddScoped<ITestRepository>(provider => new TestRepository(connectionString));

        // Register the TestService
        builder.Services.AddScoped<ITestService, TestService>();


        // Add Repository DI
        //builder.Services.AddScoped<ITestingDocumentRepo, TestingDocument>();

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
    }
}