﻿using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class PlaneType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Model Name")]
        public string modelName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Plane>? Planes { get; set; }
        public ICollection<Seat>? Seats { get; set; }
    }
}
