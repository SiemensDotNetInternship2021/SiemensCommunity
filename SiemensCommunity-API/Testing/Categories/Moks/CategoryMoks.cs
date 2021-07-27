using Data.Contracts;
using Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Categories.Moks
{
    public class CategoryMoks
    {
        public static Mock<IGenericRepository<Category>> GetCategorryRepository()
        {
            var categories = new List<Category>() {
                new Category {Id =1, Name = "Books"},
                new Category {Id =2, Name = "Movies"},
                new Category {Id =3, Name = "Music"},
                new Category {Id =4, Name = "Games"}
            };

            var mockCatgeoryRepository = new Mock<IGenericRepository<Category>>();

            mockCatgeoryRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(categories);
            mockCatgeoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });

            return mockCatgeoryRepository;
        }
    }
}
