using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SummerOfTech_Bootcamp.Models
{
    public partial class Post
    {
        public PostViewModel ToViewModel()
        {
            return new PostViewModel()
            {
                Title = Title,
                Id = Id,
                Content = Content

            };
        }
    }
    public class PostViewModel
    {

        [HiddenInput]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}