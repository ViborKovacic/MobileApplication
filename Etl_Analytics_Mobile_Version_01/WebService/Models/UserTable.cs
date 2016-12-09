using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService.Models
{
    [Table("UserTableDetails")]
    public class UserTable
    {
        
        [Key]
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int USER_TYPE { get; set; }
    }
}