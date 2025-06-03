using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MVCChair.Models
{
    public class ChairTypeViewModel
    {
        public List<Chair>? Chairs { get; set; }
        public SelectList? Types { get; set; }
        public string? ChairType { get; set; }
        public string? SearchString { get; set; }
    }
}
