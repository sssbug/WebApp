using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Why.Data.Models
{
    public class Biography
    {
        [Key]
        public int BiographyId { get; set; }
        public string BiographyUserName { get; set; }
        public string BiographyTitle { get; set; }
        public string BiographyContent { get; set; }
        public int UsersId { get; set; }
        public User User { get; set; }
        public int ThumbsId { get; set; }
        public Thumb Thumb { get; set; }
    }
}

