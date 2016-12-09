using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("StatsTablesDetails")]
    public class StatsTables
    {
        [Key]
        public int table_id { get; set; }
        public string table_name { get; set; }
        public DateTime date_id { get; set; }
        public int null_columns { get; set; }
        public int amount_of_trs_data { get; set; }
        public float diff_last_trans { get; set; }
        public string big_deviation { get; set; }
    }
}