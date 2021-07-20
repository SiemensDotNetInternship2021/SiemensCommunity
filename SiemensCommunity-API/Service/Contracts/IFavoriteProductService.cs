﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFavoriteProductService
    {
        public Task<IEnumerable<FavoriteProduct>> GetAsync(int userId);

        public Task<FavoriteProduct> AddAsync(FavoriteProduct productDetails);

        public Task<FavoriteProduct> DeleteAsync(FavoriteProduct productDetails);
    }
}
