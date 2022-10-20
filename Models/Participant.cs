using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciusss.Models
{

    [Table("Participants")]
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public string Prenom { get; set; } = "";
        public string Nom { get; set; } = "";
        public int Salaire { get; set; }

    }
}
