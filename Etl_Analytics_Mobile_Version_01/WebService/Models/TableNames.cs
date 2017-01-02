using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    [Table("TableNamesDetails")]
    public class TableNames
    {
        [Key]
        public string TABLE_NAME { get; set; }
    }
}