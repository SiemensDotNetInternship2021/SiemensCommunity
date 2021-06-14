using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult BooksList()
        {
            return View(_bookRepository.AllBooks);
        }
    }
}
