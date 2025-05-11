using System.ComponentModel.DataAnnotations;

namespace RestoManager_Marwa.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }

        [Required]
        [StringLength(30)]
        public required string NomPersonne { get; set; }

        [Required]
        [Range(1, 5)]  // La note doit être comprise entre 1 et 5
        public int Note { get; set; }

        [StringLength(256)]
        public string Commentaire { get; set; }

        public string NumResto { get; set; }  // Clé étrangère vers Restaurant

        // Propriété de navigation
        public Restaurant? LeResto { get; set; }
    }
}
