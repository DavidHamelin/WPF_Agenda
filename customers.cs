namespace ClientLourd_Agenda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customers()
        {
            appointements = new HashSet<appointements>();
        }

        [Key]
        public int idCustomer { get; set; }

        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(100)]
        public string mail { get; set; }

        [StringLength(10)]
        public string phoneNumber { get; set; }

        public int budget { get; set; }

        [Column(TypeName = "text")]
        public string subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointements> appointements { get; set; }
    }
}
