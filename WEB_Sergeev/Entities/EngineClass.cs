﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_Sergeev.Entities
{
    public class EngineClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Engine> Engines { get; set; }
    }
}
