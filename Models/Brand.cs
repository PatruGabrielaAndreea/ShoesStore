using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class Brand
    {
        [Key]
        public int Id_Brand { get; set; }
        public string Nume { get; set; }
    }
}
