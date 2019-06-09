namespace MccathyDataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using McarthyDataEntity;

    public partial class MaccarthyDataContext : DbContext
    {
        public MaccarthyDataContext()
            : base("name=MaccarthyMeasurementModel")
        {
        }



        public virtual DbSet<Style_Group_Master> Style_Group_Master { get; set; }
        public virtual DbSet<Style_Group_Measurement_Parameter> Style_Group_Measurement_Parameter { get; set; }
        public virtual DbSet<Style_Master> Style_Master { get; set; }
        public virtual DbSet<Style_Size_Detail> Style_Size_Detail { get; set; }
        public virtual DbSet<Style_Size_Master> Style_Size_Master { get; set; }
        public virtual DbSet<Style_Size_Specification> Style_Size_Specification { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.group_name)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.last_update_by)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.group_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.group_performance_report_name)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.gropu_category)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Master>()
                .Property(e => e.group_category_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Style_Group_Measurement_Parameter>()
                .Property(e => e.sgmp_name)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Measurement_Parameter>()
                .Property(e => e.sgmp_notes)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Group_Measurement_Parameter>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.last_update_by)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_desc)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_picture_back)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_picture_front)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_fabric_desc)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.style_catalog_name)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Master>()
                .Property(e => e.spec_pdf)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Size_Master>()
                .Property(e => e.last_update_by)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Size_Master>()
                .Property(e => e.size_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Size_Master>()
                .Property(e => e.size_type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Style_Size_Specification>()
                .Property(e => e.measurement)
                .IsUnicode(false);

            modelBuilder.Entity<Style_Size_Specification>()
                .Property(e => e.last_update_by)
                .IsUnicode(false);
        }
    }
}
