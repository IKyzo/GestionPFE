using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPFE.Models
{
    public class Enseignant
    {
        public int ID {  get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // Navigation property for PFE 
        public ICollection<PFE>? EncadrantPFEs { get; set; }

        // Navigation property for soutenance 
        [InverseProperty("President")]
        public ICollection<Soutenance>? PresidentSoutenances { get; set; }
        [InverseProperty("Rapporteur")]
        public ICollection<Soutenance>? RapporteurSoutenances { get; set; }
    }
}
