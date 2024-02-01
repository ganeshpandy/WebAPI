using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentEntities.Model
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public double TamilMark {  get; set; }
        public double EnglishMark {  get; set; }
        public double MathsMark {  get; set; }
        public double ScienceMark {  get; set; }
        public double SocialMark {  get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

    }
}