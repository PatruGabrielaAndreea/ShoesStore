using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class CosCumparaturi
    {
        [Key]
        public int Id_Cos { get; set; }

        [DisplayName("Cantitate")]
        public int Cantitate { get; set; }

        public Produs? Produs { get; set; }
        public int Id_Produs { get; set; }

    }
}
