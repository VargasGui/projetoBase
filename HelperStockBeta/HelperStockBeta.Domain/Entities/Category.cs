using HelperStockBeta.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        //Relações de Entidade
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidationDomain(name);
            Name = name;
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Identification is positive values");
            Id = id;
            ValidationDomain(name);
            Name = name;
        }
        public void Update(int id, string name)
        {
            ValidationDomain(name);
        }

        public void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Name is too short. Minimum 3 caracters!");
        }

    }
}
