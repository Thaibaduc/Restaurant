
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateAdd { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateExpiry { get; set; }

        //public virtual Kho Kho { get; set; }
    }
}
