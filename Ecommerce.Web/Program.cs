
using Dashboard.Filters;
using Dashboard.Repository;
using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Repository.Repositories;
using Ecommerce.Services.CartService;
using Ecommerce.Services.CategoryService;
using Ecommerce.Services.ProductService;
using Ecommerce.Services.ReviewService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(SessionIdCookieFilter));
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgresConnection")));
builder.Services.AddScoped<IProductBaseRepository,ProductBaseRepository>();
builder.Services.AddScoped<ICategoryBaseRepository, CategoryBaseRepository>();
builder.Services.AddScoped<ICartBaseRepository, CartBaseRepository>();
builder.Services.AddScoped<INotificationsBaseRepository,NotificationsBaseRepository>();
builder.Services.AddScoped<IOrderDetailBaseRepository,OrderDetailBaseRepository>();
builder.Services.AddScoped<IOrderBaseRepository,OrderBaseRepository>();
builder.Services.AddScoped<IReviewsBaseRepository,ReviewsBaseRepository>();
builder.Services.AddScoped<IUserBaseRepository,UserBaseRepository>();
builder.Services.AddScoped<ICartBaseRepository, CartBaseRepository>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IReviewService,ReviewService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{area=Client}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();