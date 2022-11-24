﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    public class Vehicles
    {
        public string BrandName { get; set; }
        public List<Model> models { get; set; } = new List<Model>();
    }
    public class Model
    {
        public string ModelName { get; set; }
        public string ImgPath { get; set; }
    }
}
