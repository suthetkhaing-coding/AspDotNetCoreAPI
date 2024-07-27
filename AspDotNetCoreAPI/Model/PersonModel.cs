using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetCoreAPI.Model
{
    [Table("tblPerson")]
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [DisplayName("Person Number")]
        public string PersonNo { get; set; }
        [Required]
        [DisplayName("လူနာမည်")]
        public string PersonName { get; set; }
        [Required]
        [DisplayName("ကျား/မ")]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string NrcNo { get; set; }

        public string Photo { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string POB { get; set; }
        [Required]
        public string Height_ft { get; set; }
        [Required]
        public string Height_in { get; set; }

        public string BloodType { get; set; }

        public string? DistinguishMark { get; set; }

        public DateTime? JoinDate { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }

        public string? PrevOccupation { get; set; }

        public string? OtherQualification { get; set; }
        [Required]
        public string PerAddress { get; set; }
        [Required]
        public string TownshipCode { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? Heir_Person { get; set; }

        public DateTime? EmployDate { get; set; }

        public string? duty_start { get; set; }

        public decimal? insurance { get; set; }

        public string? policyno { get; set; }
    }
}
