using System.ComponentModel.DataAnnotations;

namespace SaveToTextFileOnServer.Models
{
    public class TwoStringsModel
    {
        [Required]
        [StringLength(160)]
        public string StringOne { get; set; }

        [Required]
        [StringLength(160)]
        public string StringTwo { get; set; }
    }
}