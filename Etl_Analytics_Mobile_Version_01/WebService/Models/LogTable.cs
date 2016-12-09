using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("logtable")]
    public class LogTable
    {

        [Key]
        public int LOG_ID { get; set; }
        public int PROCEDURE_ID { get; set; }
        public string PROCEDURE_NAME { get; set; }
        public DateTime DATE_TIME { get; set; }
        public string ACTION { get; set; }
        public string ERROR_DESCRIPTION { get; set; }
    }
}