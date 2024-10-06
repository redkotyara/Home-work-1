using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.BusinessLogic.Models
{
    public class GenderModel
    {
        public int GenderId { get; set; }

        [Display(Name = "Gender")]
        public string GenderName { get; set; }
    }
}