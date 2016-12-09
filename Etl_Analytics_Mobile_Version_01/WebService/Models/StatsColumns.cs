using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("StatsColumnsDetails")]
    public class StatsColumns
    {
        [Key]
        public int TABLE_ID { get; set; }
        public DateTime DATE_ID { get; set; }
        public string OWNER { get; set; }
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public int NULL_ROWS { get; set; }
        public int NOT_NULL_ROWS { get; set; }
        public float FILL_PERCENTAGE { get; set; }
        public string LOW_OCCUPANCY { get; set; }
    }
}