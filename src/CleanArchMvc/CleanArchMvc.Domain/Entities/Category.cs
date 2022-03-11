using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Category(string name)
        {
            SetName(name);
        }

        public Category(int id, string name)
        {
            SetId(id);
            SetName(name);
        }

        public ICollection<Product> Products { get; set; }

        private void SetId(int id)
        {
            ValidateId(id);

            Id = id;
        }

        private void ValidateId(int id)
        {
            var idIsNegative = id < 0;

            DomainExceptionValidation.When(idIsNegative, "Invalid Id. Id must be greather than zero");
        }

        private void SetName(string name)
        {
            ValidateName(name);

            Name = name;
        }

        private void ValidateName(string name)
        {
            var nameIsEmpty = string.IsNullOrWhiteSpace(name);

            DomainExceptionValidation.When(nameIsEmpty, "Invalid name. Name is required");

            var nameIsTooShort = name.Length <= 3;

            DomainExceptionValidation.When(nameIsTooShort, "Invalid name. Name is too short, minimum 3 chars");
        }
    }
}
