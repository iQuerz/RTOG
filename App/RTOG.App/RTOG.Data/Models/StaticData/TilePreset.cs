﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RTOG.Data.Models
{
    public class TilePreset : BaseEntity
    {
        public float PositionY { get; set; }
        public float PositionX { get; set; }

        [JsonIgnore]
        public MapPreset MapPreset { get; set; }


    }
}
