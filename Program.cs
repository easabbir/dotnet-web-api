var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
    return "Patch method: Hello";
});

app.MapDelete("/hello",()=>
{
    return "Delete method: Hello";
});



app.Run();