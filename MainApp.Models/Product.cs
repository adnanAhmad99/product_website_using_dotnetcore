﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please Enter Product Name")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Range(0,50,ErrorMessage ="Please Enter Number between 0-50")]
        public int Quantity { get; set; }

        public string ImageUrl { get; set; } = "";

        public int CategoryDataId { get; set; }
        [ForeignKey("CategoryDataId")]
        [ValidateNever]
        public Category Category { get; set; }

    }
}
