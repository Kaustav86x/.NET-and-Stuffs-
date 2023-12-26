using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Car
    {
            [Key]
        // identity column
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long CarId { get; set; }
            [Required]
            public string? Model { get; set; }
            [Required]
            public string? Type { get; set; }
            [Required]
            public double? Kms { get; set; }
            [Required]
            public double? Rating { get; set; }
            [Required]
            public string? Description { get; set; }
        }
    }
