using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Contexts
{
    public partial class AppContext(DbContextOptions<AppContext> options) : DbContext(options)
    {
        public virtual DbSet<ProfileEntity> Profiles { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<AllianceEntity> Alliances { get; set; }
        public virtual DbSet<LanguageEntity> Languages { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileEntity>(entity =>
            {
                entity.HasKey(e => e.ProfileId);
                entity.Property(e => e.FirstName).HasMaxLength(300).IsUnicode(true);
                entity.Property(e => e.LastName).HasMaxLength(300).IsUnicode(true);
                entity.Property(e => e.RoleId).HasColumnName("RoleId");
                entity.Property(e => e.AllianceId).HasColumnName("AllianceId");
                entity.Property(e => e.LanguageId).HasColumnName("LanguageId");
                entity.ToTable("Profiles");
            });

            modelBuilder.Entity<RoleEntity>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.Role).HasMaxLength(300).IsUnicode(true);
                entity.ToTable("Roles");
            });

            modelBuilder.Entity<AllianceEntity>(entity =>
            {
                entity.HasKey(e => e.AllianceId);
                entity.Property(e => e.Alliance).HasMaxLength(300).IsUnicode(true);
                entity.ToTable("Alliances");
            });

            modelBuilder.Entity<LanguageEntity>(entity =>
            {
                entity.HasKey(e => e.LanguageId);
                entity.Property(e => e.Language).HasMaxLength(300).IsUnicode(true);
                entity.ToTable("Languages");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
