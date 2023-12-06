using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPFE.Models
{
    public class PFE_Etudiant
    {
        public int ID { get; set; }
        [ForeignKey("PFE")]
        public int PFEID { get; set; }
        public PFE? PFE { get; set; }


        [ForeignKey("Etudiant")]
        public int EtudiantID { get; set; }
        public Etudiant? Etudiant { get; set; }
    }
}
