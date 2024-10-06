var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return "API is working fine";
});

app.MapGet("/hello", () => 
{
    return "Hello World! this is my first api";
});

app.MapPost("/hello",()=>
{
    return "Post method: Hello";
});

app.MapPut("/hello",()=>
{
    return "Put method: Hello";
});

app.MapPatch("/hello",()=>
{
    return "Put method: Hello";
});

app.MapDelete("/hello",()=>
{
    return "Delete method: Hello";
});



app.Run();