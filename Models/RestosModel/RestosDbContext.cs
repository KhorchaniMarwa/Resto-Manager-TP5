using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestoManager_Marwa.Models.RestosModel
{
    public class RestosDbContext : DbContext
    {
        public RestosDbContext(DbContextOptions<RestosDbContext> options)
           : base(options)
        {
        }

        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de l'entité Proprietaire
            modelBuilder.Entity<Proprietaire>(entity =>
            {
                entity.ToTable("TProprietaire", "resto");

                entity.HasKey(p => p.Gsm);

                entity.Property(p => p.Name)
                    .HasColumnName("NomProp")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(p => p.Email)
                    .HasColumnName("EmailProp")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.Gsm)
                    .HasColumnName("GsmProp")
                    .HasMaxLength(8)
                    .IsRequired();
            });

            // Configuration de l'entité Restaurant
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("TRestaurant", "resto");

                entity.HasKey(r => r.CodeResto);

                entity.Property(r => r.NomResto)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(r => r.Specialite)
                    .HasColumnName("SpecResto")
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasDefaultValue("Tunisienne");

                entity.Property(r => r.Ville)
                    .HasColumnName("VilleResto")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(r => r.Tel)
                    .HasColumnName("TelResto")
                    .HasMaxLength(8)
                    .IsRequired();
            });
            // Configuration de l'entité Avis
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.ToTable("TAvis", "admin");  // Nouveau schéma "admin"

                entity.HasKey(a => a.CodeAvis);  // Définition de la clé primaire

                entity.Property(a => a.NomPersonne)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(a => a.Note)
                    .IsRequired();

                entity.Property(a => a.Commentaire)
                    .HasMaxLength(256);
                // Configuration de la relation entre Avis et Restaurant
                entity.HasOne(a => a.LeResto)
                    .WithMany(r => r.LesAvis)
                    .HasForeignKey(a => a.NumResto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Relation_Resto_Avis");
            });


            modelBuilder.Entity<Restaurant>()
       .HasOne(r => r.LeProprio)
       .WithMany(p => p.LesRestos)
       .HasForeignKey(r => r.NumProp)
       .HasConstraintName("Relation_Proprio_Restos")
       .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Avis> TAvis { get; set; } = default!;
    }
}
