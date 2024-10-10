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

List<Category> categories = new List<Category>();

//Get:  /api/categories => read a category
app.MapGet("/api/categories",() => {
    return Results.Ok(categories    );
});


//Post:  /api/categories => create a category
app.MapPost("/api/categories",() => {
    var newCategory=new Category
    {
        CategoryId = Guid .Parse("d1a653f0-5d2e-48fc-8a31-1b92dccc6b66"),
        Name="Smartphone",
        Description="This is the description of the smartphone",
        CreatedAt=DateTime.UtcNow
    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory );
});

//Delete:  /api/categories => delete a category
app.MapDelete("/api/categories",() => {
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId ==Guid .Parse("d1a653f0-5d2e-48fc-8a31-1b92dccc6b66"));
    if(foundCategory==null){
        return Results.NotFound("Category with this id does not exists");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();
});


//Update:  /api/categories => update a category
app.MapPut("/api/categories",() => {
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId ==Guid .Parse("d1a653f0-5d2e-48fc-8a31-1b92dccc6b66"));
    if(foundCategory==null){
        return Results.NotFound("Category with this id does not exists");
    }
    foundCategory.Name="smartphone";
    foundCategory.Description="updated description";
    return Results.NoContent();
});




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

public record Category
{
    public Guid CategoryId { get; set; }
    public String? Name { get; set; }
    public String? Description { get; set; }
    public DateTime CreatedAt { get; set; }
};

//CRUD 
//Create => create a category => POST : /api/categories 
//Read   => read a category   => GET : /api/categories
//Update => update a category => PUT : /api/categories
//Delete => delete a category => DELETE : /api/categories
