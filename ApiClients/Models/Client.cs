using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClients.Models
{
    public class Client
    {
        #nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string Address { get; set; }
        [Required]
        public string Cell_phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Cuit { get; set; }
    }
}
