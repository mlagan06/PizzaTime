using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.Models
{
    public class OrderModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="Persons Name can only be 40 characters long.")]
        public string PersonsName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int PizzaSize { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Pizza Name can only be 12 characters long.")]
        public string PizzaName { get; set; }

        public DateTime DateOrdered { get; set; }
    }
}
