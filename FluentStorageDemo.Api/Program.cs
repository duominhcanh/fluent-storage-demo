using FluentStorageDemo.Api.Configuration;
using FluentStorageDemo.BlobStorage.Configuration;
using FluentStorageDemo.BlobStorage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AwsOptions>(builder.Configuration.GetSection("Aws"));

builder.Services.Configure<BlobStorageOptions>(builder.Configuration.GetSection("BlobStorage"));

builder.Services.AddDiskBlobStorage("uploads");

//builder.Services.AddS3BlobStorage(
//    new BasicAWSCredentials(
//        builder.Configuration.GetValue<string>("Aws:AccessKey"),
//        builder.Configuration.GetValue<string>("Aws:SecretKey")
//    ),
//    builder.Configuration.GetValue<string>("BlobStorage:S3BucketName"),
//    builder.Configuration.GetValue<string>("Aws:Region")
//);

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
