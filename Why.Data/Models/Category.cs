using System;
using System.Collections.Generic;
using System.Text;

namespace Why.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Thumb> CategoryThumbs { get; set; }
    }
}
