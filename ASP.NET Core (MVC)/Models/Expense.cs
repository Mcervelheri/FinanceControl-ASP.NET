using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core__MVC_.Models
{
    public class Expense
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Defina um valor para o gasto")]
        public decimal? Amount { get; set; }
        [Required(ErrorMessage = "Defina uma data para o gasto")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Selecione uma categoria")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }

}
