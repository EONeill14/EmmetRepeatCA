﻿using EmmetRepeatCA.Models.ViewModels;
using EmmetRepeatCA.Models;
using System.Collections.Generic;

namespace EmmetRepeatCA.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Vinyl> Vinyls { get; set; } = Enumerable.Empty<Vinyl>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
        public string? CurrentGenre { get; set; }
    }
}