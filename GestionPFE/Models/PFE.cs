using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPFE.Models
{
    public class PFE
    {
        public int PFEID { get; set; }
        public string Titre { get; set;}
        public string Desc { get; set;}
        public DateTime DateD {  get; set; }
        public DateTime DateF { get; set; }

        [ForeignKey("Encadrant")]
        public int EncadrantID { get; set; }
        public Enseignant? Encadrant { get; set; }

        [ForeignKey("Societe")]
        public int SocieteID { get; set; }
        public Societe? Societe { get; set; }

        public ICollection<PFE_Etudiant>? PFE_Etudiants { get; set; }
    }
}
