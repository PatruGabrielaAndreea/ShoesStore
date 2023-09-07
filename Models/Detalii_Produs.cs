using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class Detalii_Produs
    {
        [Key]
        public int Id_Detalii { get; set; }
        public string Nume { get; set; }
        public int Marime { get; set; }
        public string Material { get; set; }
        public string Culoare { get; set; }
        public string Gen { get; set; }
        public double Pret { get; set; }
        public string? ImageURL { get; set; }
        public Produs? Produs { get; set; }
        public int Id_Produs { get; set; }
    }
}
