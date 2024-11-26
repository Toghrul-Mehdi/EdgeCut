﻿using TaskMvc.Models;

namespace TaskMvc.ViewModels.ProductVM.CreateProduct
{
    public class CreateProduct
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public IFormFile CoverFile { get; set; }
        public int? CategoryId { get; set; }
    }
}