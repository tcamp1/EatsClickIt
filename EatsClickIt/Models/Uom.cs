//-----------------------------------------------------------------------
// <copyright file="Uom.cs" company="University of Memphis">
//     Copyright (c) University of Memphis All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EatsClickIt.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Unit of Measure class
    /// This houses Units of Measure
    /// </summary>
    public class Uom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Uom"/> class
        /// Any properties that need an initial value should be assigned here
        /// </summary>
        public Uom()
        {
            this.Active = true;
        }

        /// <summary>
        /// Gets or sets the Uom ID
        /// </summary>
        [Key]
        [DisplayName("UOM ID")]
        public int UomId { get; set; }

        /// <summary>
        /// Gets or sets Unit of Measure
        /// </summary>
        [Required]
        [DisplayName("UOM")]
        [StringLength(20, MinimumLength = 1)]
        public string UofM { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the record is Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time the record was created
        /// </summary>
        [ScaffoldColumn(false)]
        [DisplayName("Create Timestamp")]
        public DateTime? Created { get; set; }
    }
}