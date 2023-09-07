using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class Comanda
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id_Comanda { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data_Comenzii { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [DisplayName("Nume")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [DisplayName("Prenumele")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Adresa este obligatorie.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Tara este obligatorie.")]
        public string Tara { get; set; }

        [Required(ErrorMessage = "Judetul este obligatoriu.")]
        public string Judet { get; set; }

        [Required(ErrorMessage = "Orasul este obligatoriu.")]
        public string Oras { get; set; }

        [Required(ErrorMessage = "Numarul de telefon este obligatoriu.")]
        [DisplayName("Telefon")]
        [StringLength(10)]
        public int Telefon { get; set; }

        [Required(ErrorMessage = "Adresa de email este obligatorie.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        public string Plata { get; set; }

        public Produs? Produs { get; set; }
        public int Id_Produs { get; set; }
        public User? User { get; set; }
        public int Id_User { get; set; }
    }
}
