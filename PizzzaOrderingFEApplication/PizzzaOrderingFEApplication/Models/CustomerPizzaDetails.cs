﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Models
{
    public class CustomerPizzaDetails
    {
        public PizzaViewDTO pizzaDetail { get; set; }
        public string pizzaId { get; set; }
        public bool onion { get; set; }
        public bool crispCapsicum { get; set; }
        public bool GrilledMushroom { get; set; }
        public int qty { get; set; }
    }
}
