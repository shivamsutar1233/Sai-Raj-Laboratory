using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sai_Raj_Laboratory.Models
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientSex { get; set; }
        public float PatientHB { get; set; }
        public int PatientWBC { get; set; }
        public int PatientNeutrophils { get; set; }
        public int PateintLymphocytes { get; set; }
        public int PateintEosinophils { get; set; }
        public int PatientMonocytes { get; set; }
        public int PatientBasophils { get; set; }
        public int PatientPlateletesCount { get; set; }
        public string PatientWBCStatus { get; set; }
        public string PatientRBCStatus { get; set; }
        public string PatientPlateletesStatus { get; set; }
        public string PatientParasitesStatus { get; set; }
        [Required]
        public string UHID { get; set; }

        public float? PatientBS { get; set; }
        public float? PatientCreatinine { get; set; }
    }

}
