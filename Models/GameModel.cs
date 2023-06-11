using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Games.Models
{
    public class GameModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(75,ErrorMessage ="The{0} value cannot exceed {1} characters.")]
        public string? Title { get; set; }
        [Required]
         [StringLength(75,ErrorMessage ="The{0} value cannot exceed {1} characters.")]
        public string? Genere { get; set; }
    }
}