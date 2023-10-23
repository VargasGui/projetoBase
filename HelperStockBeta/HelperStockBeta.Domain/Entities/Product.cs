﻿using HelperStockBeta.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid negative values for id.");
            ValidationDomain(name, description, price, stock, image);
        }
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name, name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid short names, minimun 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description, description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid short descriptions, minimun 5 characters.");
            DomainExceptionValidation.When(price < 0, "Invalid negative values for price.");
            DomainExceptionValidation.When(stock < 0, "Invalid negative values for stock.");
            DomainExceptionValidation.When(image.Length > 250, "Invalid long URL, maximun 250 characters.");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        //Relacionamento com category
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
    }
}
