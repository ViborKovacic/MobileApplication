using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ConfigurationColumnsDetails")]
    public class ConfigurationColumns
    {
        [Key]
        public int COLUMN_ID { get; set; }
        public int TABLE_ID { get; set; }
        public string COLUMN_NAME { get; set; }
        public int GENERATE_COLUMN { get; set; }
    }
}