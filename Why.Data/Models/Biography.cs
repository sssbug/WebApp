using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public string ImageDataList { get; set; } // Resim verilerini saklamak için string alan
        public User User { get; set; }
        public int ThumbsId { get; set; }
        public Thumb Thumb { get; set; }
    }
}