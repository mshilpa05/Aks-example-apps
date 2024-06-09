using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<SecretClient>(provider =>
{ 
    var keyVaultUrl = builder.Configuration["KeyVaultUrl"];
    var clientId = builder.Configuration["ManagedUserIdentityClientId"];
    Console.WriteLine(keyVaultUrl);
    Console.WriteLine(clientId);
    return new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential(new DefaultAzureCredentialOptions
    {
        ManagedIdentityClientId = clientId
    }));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation($"Environment: {app.Environment.EnvironmentName}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
