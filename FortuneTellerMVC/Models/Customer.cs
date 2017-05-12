//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FortuneTellerMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Display(Name=" First Name")]
        [Required (ErrorMessage =" Please Enter a Valid Name")]
        public string FirstName { get; set; }

        [Display(Name= "Last Name")]
        [Required(ErrorMessage = " Please Enter a Valid Name")]
        public string LastName { get; set; }

        [Display(Name="Age")]
        [Required(ErrorMessage = " Please Enter a Valid Number")]
        public int Age { get; set; }

        [Display(Name = "Birth Month ")]
        [Required(ErrorMessage = " Please Enter the Month's Numerical Value")]
        public int BirthMonth { get; set; }

        [Display (Name = "Favorite Color")]
        [Required(ErrorMessage = "Please enter a valid ROYGBIV color.")]
        public string FavoriteColor { get; set; }

        [Display (Name = "Your Number of Siblings")]
        [Required (ErrorMessage = "Please enter a valid number.")]
        [Range (0, 25, ErrorMessage = "Please enter a number between 0 and 25.")]
        public int NumberofSiblings { get; set; }
    }
}
