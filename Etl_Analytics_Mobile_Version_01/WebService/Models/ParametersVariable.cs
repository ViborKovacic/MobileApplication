using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ParametersVariableDetails")]
    public class ParametersVariable
    {
        [Key]
        public int TABLE_ID { get; set; }
        public string PARAMETER_CODE { get; set; }
        public string PARAMETER_CODE_TYPE { get; set; }
        public string PARAMETER_DESCRIPTION { get; set; }
        public string PARAMETER_VALUE { get; set; }
    }
}