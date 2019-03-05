namespace ClientLourd_Agenda
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class agenda_DB : DbContext
    {
        public agenda_DB()
            : base("name=CLAgendaModel")
        {
        }

        public virtual DbSet<appointements> appointements { get; set; }
        public virtual DbSet<brokers> brokers { get; set; }
        public virtual DbSet<customers> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brokers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .HasMany(e => e.appointements)
                .WithRequired(e => e.brokers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.subject)
                .IsUnicode(false);
        }
    }
}
