using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPFE.Models
{
    public class Soutenance
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Heure { get; set; }
        [ForeignKey("PFE")]
       
        public int PFEID { get; set; }
        public PFE? PFE { get; set; }

        [ForeignKey("President")]
        [InverseProperty("PresidentSoutenances")]
        

        public int PresidentID { get; set; }
        public Enseignant? President { get; set; }

        [ForeignKey("Rapporteur")]
        [InverseProperty("RapporteurSoutenances")]
        
        public int RapporteurID { get; set; }
        public Enseignant? Rapporteur { get; set; }
    }
}
