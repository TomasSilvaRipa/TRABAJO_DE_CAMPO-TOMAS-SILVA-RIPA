﻿using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BE
{
    public class Entidad
    {
        [JsonIgnore]
        public int ID { get; set; }
    }
}
