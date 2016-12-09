using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ConfigurationTableDetails")]
    public class ConfigurationTable
    {
        [Key]
        public int TABLE_ID { get; set; }
        public string TABLE_NAME { get; set; }
        public int GENERATE_TABLE { get; set; }
    }
}