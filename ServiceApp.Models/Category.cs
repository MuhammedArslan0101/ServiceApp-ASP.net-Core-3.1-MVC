using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceApp.Models
{
    class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Category Name")]
        public string Name { get; set; }


        [Required]
        [Display(Name="Display Order")]
        public int DisplyOrder { get; set; }

    }
}
