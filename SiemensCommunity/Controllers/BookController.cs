using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Model.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    public class BookController : Controller
    {
        MockBookRepository mockBookRepository = new MockBookRepository();

        public BookController()
        {

        }

        public IActionResult BooksList()
        {
            var bookList = mockBookRepository.AllBooks;

            return View(bookList);
        }
    }
}
