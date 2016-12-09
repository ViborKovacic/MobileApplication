using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("ColumNameDetails")]
    public class ColumnName
    {
        [Key]
        public string COLUMN_NAME { get; set; }
    }
}