﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class TakmicenjeVM
    {
        public int SkolaId { get; set; }
        public List<SelectListItem> Skole { get; set; }

        public List<Row> Data { get; set; }
    }
    public class Row
    {
        public int TakmicenjeId { get; set; }
        public string Skola { get; set; }
        public int Razred { get; set; }
        public DateTime Datum { get; set; }
        public string Predmet { get; set; }
        public string NajboljiUcenik { get; set; }
    }
}
