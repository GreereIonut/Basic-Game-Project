using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Games.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string? UserName { get; set; }
        [Required]

        public string? review { get; set; }
        [Required]

        public int Stars { get; set; }

        public DateTime createdDateTime { get; set; }=DateTime.Now;
        [Required]
        [ForeignKey("Games")]
        public int gameId { get; set; }
        public virtual GameModel? Games { get; set; }
        
    }
}