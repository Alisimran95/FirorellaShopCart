using System;
using Microsoft.VisualBasic;

namespace FiorellaBackToFrontProject.Models
{
    public class BlogItem
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string BlogTitle { get; set; }
        public string BlogSubtitle { get; set; }
        public DateTime Date  { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return Date.ToString("MM/dd/yyyy").Replace("/", ".");

        }
    }
}
