using BookManagement.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
List<BookDto> books = [
    new BookDto { Id = 1, Name = "Book 1", Author = "Author 1", Publisher = "Publisher 1" },
    new BookDto { Id = 2, Name = "Book 2", Author = "Author 2", Publisher = "Publisher 2" },
    new BookDto { Id = 3, Name = "Book 3", Author = "Author 3", Publisher = "Publisher 3" },
];

app.UseHttpsRedirection();

app.MapGet("/books", () => books);
app.MapGet("/books/{id}", (int id) => books.Find(book => book.Id == id));
app.MapPost("/books", (AddBookDto book) => books.Add(new BookDto
{
    Id = books.Count + 1,
    Name = book.Name,
    Author = book.Author,
    Publisher = book.Publisher
}));

app.Run();
