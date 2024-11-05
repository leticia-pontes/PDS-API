using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> books { get; set; } = new List<Book>();

        [HttpPost(Name = "Livros")]
        public IActionResult Post(Book book) // Interface do .NET Core que possibilita retornar qualquer tipo de dado (genérico)
        {
            books.Add(book);
            return Ok(books);
        }

        [HttpGet(Name = "Livros")]
        public IActionResult Get() 
        {
            return Ok(books);
        }

        [HttpPut(Name = "Livros")]
        public IActionResult Put(int id, Book book)
        {
            var livro = books.FirstOrDefault(book => book.Id == id);

            if (livro == null) 
            {
                return NotFound("Livro não encontrado");
            }

            livro.Nome = book.Nome;
            livro.Autor = book.Autor;

            return Ok("Livro atualizado com sucesso");
        }

        [HttpDelete(Name = "Livros")]
        public IActionResult Delete(int id) 
        {
            var livro = books.FirstOrDefault(book => book.Id == id);

            if (livro == null)
            {
                return NotFound("Livro não encontrado");
            }

            books.Remove(livro);
            return Ok("Livro deletado com sucesso");
        }
    }
}
