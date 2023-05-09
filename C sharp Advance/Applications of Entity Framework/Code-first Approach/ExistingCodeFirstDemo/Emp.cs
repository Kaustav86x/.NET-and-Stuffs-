namespace ExistingCodeFirstDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emp")]
    public partial class Emp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }

        [StringLength(100)]
        public string fname { get; set; }

        [StringLength(100)]
        public string lname { get; set; }

        [StringLength(100)]
        public string jobd { get; set; }
    }
}
