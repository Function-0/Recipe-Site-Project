using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public RecipeItem Recipe { get; set; }
    }
}
