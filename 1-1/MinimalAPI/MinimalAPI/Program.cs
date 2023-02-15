using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonContext>(options => options.UseInMemoryDatabase("PersonList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// get method
app.MapGet("/", () => "Hello user");
// get complete 
app.MapGet("/Persons/complete", async (PersonContext pc) =>
    await pc.Persons.ToListAsync());
app.MapGet("/Persons/{id}", async(int id, PersonContext pc) => 
    await pc.Persons.FindAsync(id));
// post method
app.MapPost("/Persons/Add", async (Person person, PersonContext pc) =>
{
    pc.Persons.Add(person);
    await pc.SaveChangesAsync();
    return Results.Created($"/Persons/{person.Id}", person);
});
// put method
app.MapPut("/Persons/{id}", async (int id, Person person, PersonContext pc) =>
{
    var p1 = await pc.Persons.FindAsync(id);
    if (p1 == null) return Results.NotFound();
    p1.Id = id;
    p1.Name = person.Name;
    p1.age= person.age;
    await pc.SaveChangesAsync();
    return Results.Ok();
});

// delete method
app.MapDelete("/Persons/{id}", async (int id, PersonContext pc) =>
{
    if (await pc.Persons.FindAsync(id) is Person person)
    {
        pc.Persons.Remove(person);
        await pc.SaveChangesAsync();
        return Results.Ok(person);
    }
    return Results.NotFound();
});
/*app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});*/
app.Run();

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int age { get; set; }
}

class PersonContext : DbContext
{
    public PersonContext(DbContextOptions options) : base(options) {
        
    }
    public DbSet<Person> Persons { get; set;}
}