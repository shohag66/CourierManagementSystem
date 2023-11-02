﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CourierManagementSystem.Entity
{
    public class Bases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int? isDelete { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(250)]
        public string? createdBy { get; set; }
        [MaxLength(250)]
        public string? updatedBy { get; set; }
    }
}
