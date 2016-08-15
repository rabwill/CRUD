using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Business.DAL.Entities
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string Description { get; set; }

       
    }
}
