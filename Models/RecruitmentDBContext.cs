using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class RecruitmentDBContext : IdentityDbContext
    {
        public RecruitmentDBContext()
        {
        }

        public RecruitmentDBContext(DbContextOptions<RecruitmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
        public virtual DbSet<Mailing> Mailings { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=RecruitmentDB; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(35);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.ToTable("Applicant");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FirstName");


                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LastName");

                entity.Property(e => e.UploadFile).IsRequired();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DepId).HasColumnName("Dep_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");


                entity.Property(e => e.Gender).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");


                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Employee__Dep_Id__29572725");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.VacId).HasColumnName("Vac_Id");

                entity.HasOne(d => d.InterviewerOneNavigation)
                    .WithMany(p => p.InterviewInterviewerOneNavigations)
                    .HasForeignKey(d => d.InterviewerOne)
                    .HasConstraintName("FK__Interview__Inter__32E0915F");

                entity.HasOne(d => d.InterviewerThreeNavigation)
                    .WithMany(p => p.InterviewInterviewerThreeNavigations)
                    .HasForeignKey(d => d.InterviewerThree)
                    .HasConstraintName("FK__Interview__Inter__34C8D9D1");

                entity.HasOne(d => d.InterviewerTwoNavigation)
                    .WithMany(p => p.InterviewInterviewerTwoNavigations)
                    .HasForeignKey(d => d.InterviewerTwo)
                    .HasConstraintName("FK__Interview__Inter__33D4B598");

                entity.HasOne(d => d.Vac)
                    .WithMany(p => p.Interviews)
                    .HasForeignKey(d => d.VacId)
                    .HasConstraintName("FK__Interview__Vac_I__31EC6D26");
            });

            modelBuilder.Entity<Mailing>(entity =>
            {
                entity.ToTable("Mailing");

                entity.Property(e => e.Subject).IsRequired();

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.InterviewId).HasColumnName("Interview_Id");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.InterviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__Interv__37A5467C");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancy");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DepId).HasColumnName("Dep_Id");

                entity.Property(e => e.EndedDate).HasColumnType("date");

                entity.Property(e => e.UploadDate).HasColumnType("date");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK__Vacancy__Dep_Id__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
