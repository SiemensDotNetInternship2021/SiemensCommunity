﻿using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBorrowedProductService
    {
        public Task<IEnumerable<BorrowedProduct>> GetAsync();

        public Task<IEnumerable<ProductDTO>> GetByCategoryIdAsync(int userId, int categoryId);

        public Task<BorrowedProduct> BorrowProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<ProductDTO>> GetBorrowedByUserIdAsync(int userId);

        public Task<BorrowedProduct> ReturnBorrowedProduct(BorrowedProduct borrowDetails);

        public Task<IEnumerable<ProductDTO>> GetBorrowedAsync(int userId);
    }
}
