using System.ComponentModel.DataAnnotations;

namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        public int? Id { get; set; }

        [Required]
        public double Rayon { get; set; }

        [Required]
        public Point_DAL Centre { get; set; }

        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }
    }
}
