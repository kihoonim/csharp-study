using System;
using System.ComponentModel.DataAnnotations;

namespace book_service.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsOnSale { get; set; }

        public override string ToString()
        {
            return 
                $"Id = {Id}\n" +
                $"Name = {Name}\n" +
                $"Description = {Description}\n" +
                $"IsOnSale = {IsOnSale}\n";
        }
    }
}
