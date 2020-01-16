﻿using System;
using System.Collections.Generic;

namespace VogCodeChallenge.API.Models
{
    /// <summary>
    /// Model of Department
    /// </summary>
    public class Department: BaseModel
    {
        /// <summary>
        /// get or set DepartmentID
        /// </summary>
        public Guid DepartmentID { get; set; }


        /// <summary>
        /// get or set Department's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// get or set Department's Address, and the Address must unique, Some judgment must be made when inserting
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// get Department's Name 
        /// </summary>
        /// <returns>Department's Name</returns>
        public override string ToString() => this.Name;

    }
}
