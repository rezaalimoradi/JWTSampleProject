﻿using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] Data { get; set; }
    }
}
