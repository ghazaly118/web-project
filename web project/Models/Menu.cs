using Humanizer;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace web_project.Models
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        public string DishDiscription { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string DishTypee { get; set; }


    }
}
