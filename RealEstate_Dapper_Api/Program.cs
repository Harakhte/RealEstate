﻿using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.Last5ProductsRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
//using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
//using RealEstate_Dapper_Api.Repositories.YeniRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();

builder.Services.AddTransient<IServiceRepository, ServiceRepository>(); 

builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();



//builder.Services.AddTransient<IYeniRepository ,YeniRepository>();

builder.Services.AddTransient<ILoksiyonInPopularRepository, LoksiyonInPopularRepository>();

//builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();



builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>(); 

builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>(); 

builder.Services.AddTransient<IEmployeeRepository , EmployeeRepository >();

builder.Services.AddTransient<IContactUsRepository, ContactUsRepository>();

builder.Services.AddTransient<IToDoListRepository,ToDoListRepository >();
builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
builder.Services.AddTransient<IMessageRepository,MessageRepository>();

//builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepositor>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:44330")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();

    });
});
builder.Services.AddHttpClient();
builder.Services.AddSignalR();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");
//locathost:12345/swagger/product/index we can use instead of
//locathost:12345/signalrhub.
//Bu kod, AllowSpecificOrigin adlı CORS politikasını etkinleştirir.
//app.UseCors("AllowSpecificOrigin");

app.Run();
