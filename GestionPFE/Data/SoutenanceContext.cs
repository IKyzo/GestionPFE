using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionPFE.Models;

    public class SoutenanceContext : DbContext
    {
        public SoutenanceContext (DbContextOptions<SoutenanceContext> options)
            : base(options)
        {
        }

        public DbSet<GestionPFE.Models.Enseignant> Enseignant { get; set; } = default!;

        public DbSet<GestionPFE.Models.Etudiant> Etudiant { get; set; } = default!;

        public DbSet<GestionPFE.Models.PFE> PFE { get; set; } = default!;

        public DbSet<GestionPFE.Models.PFE_Etudiant> PFE_Etudiant { get; set; } = default!;

        public DbSet<GestionPFE.Models.Societe> Societe { get; set; } = default!;

        public DbSet<GestionPFE.Models.Soutenance> Soutenance { get; set; } = default!;
    }
