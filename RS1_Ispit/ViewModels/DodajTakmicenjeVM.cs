using System;
using System.Collections.Generic;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajTakmicenjeVM
    {
        public List<SelectListItem> Predmeti { get; set; }
        public int PredmetId { get; set; }
        public List<SelectListItem> DTSkole { get; set; }
        public int DTSkolaId { get; set; }
        public DateTime Datum { get; set; }
    }
}
