﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DnDCharacterTracker.Models
{
    public class ClassFeature
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Class")]
        public int FK_Class { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Feature")]
        public int FK_Feature { get; set; }
        public Feature Feature { get; set; }
        public int Level { get; set; }
    }
}
