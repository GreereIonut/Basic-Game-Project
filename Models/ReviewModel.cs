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
         [StringLength(50,ErrorMessage ="The{0} value cannot exceed {1} characters.")] 
        public string? userName { get; set; }
        [Required]
        [StringLength(250,ErrorMessage ="The{0} value cannot exceed {1} characters.")]
        public string? review { get; set; }
        [Required]
        [Range(1,5,ErrorMessage ="The minimum is 1 star and the maximum is 5 stars")]
        public int stars { get; set; }
        [DataType(DataType.Date)]
        public DateTime createdDateTime { get; set; }
        [Required]
        [ForeignKey("Games")]
        public int gameId { get; set; }
        public virtual GameModel? Games { get; set; }

    }
}