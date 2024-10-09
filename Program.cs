var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if(app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () => "API is working fine"
);

app.MapGet("/hello", () => 
{
    
     var response = new { Message= "Success, this is a json object", 
        Success= true };
        return Results.Ok(response);  //200 
   
});

var products = new List <Product>(){
        new Product ("Samsung s24", 2000),
        new Product ("Apple", 2500)
};


app.MapGet("/products",() =>{
    return Results.Ok(products);

});

app.MapPost("/hello",()=>
{
    return Results.Created(); //201
});

app.MapPut("/hello",()=>
{
    return Results.NoContent(); //204
});

app.MapPatch("/hello",()=>
{
    return Results.NoContent(); //204
});

app.MapDelete("/hello",()=>
{
    return Results.NoContent(); //204
});

app.Run();


public record Product
(
 String Name, Decimal Price
);