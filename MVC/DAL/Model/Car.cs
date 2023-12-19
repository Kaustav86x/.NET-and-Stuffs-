using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Car
    {
            public Guid CarId { get; set; }
            [Required]
            public string? Name { get; set; }
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
