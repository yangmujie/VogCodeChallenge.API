using System;
using System.ComponentModel.DataAnnotations;

namespace VogCodeChallenge.API.Models
{
    /// <summary>
    /// Models of Employee
    /// </summary>
    public class Employee: BaseModel
    {

        /// <summary>
        /// get or set EmployeeID
        /// </summary>
        public Guid EmployeeID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// get or set Employee's FirstName
        /// </summary>
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }


        /// <summary>
        /// get or set Employee's LastName
        /// </summary>
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// get or set Employee's JobTitle
        /// </summary>
        [StringLength(50)]
        [Required]
        public string JobTitle { get; set; }

        /// <summary>
        /// get or set Employee's Address
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Address { get; set; }


        /// <summary>
        /// get or set the Department ID to which the current employee belongs
        /// </summary>
        public Guid DepartmentID { get; set; }


        /// <summary>
        /// get or set Department object to which the current employee belongs
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// get employee's full name
        /// </summary>
        /// <returns>employee's full name</returns>
        public override string ToString() => string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}
