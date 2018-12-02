namespace Lab8
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [System.Data.Linq.Mapping.Table(Name = "Departments")]
    public partial class Department
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [System.Data.Linq.Mapping.Column(IsPrimaryKey = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int departmentID { get; set; }

        [System.Data.Linq.Mapping.Column]
        [StringLength(50)]
        public string dname { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
