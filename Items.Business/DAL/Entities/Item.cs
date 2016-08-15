using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Items.Business.DAL.Entities
{
    public class Item
    {
        #region id
  
        [Key]
        public int Id { get; set; }

        #endregion

        #region name

        [MaxLength(200)]
        [Index(IsUnique = true)]
        public string Place { get; set; }

        #endregion

        #region userird

        public string Userid { get; set; }

        #endregion
        #region date of travel

        public string DateOfTravel { get; set; }

        #endregion

      //  #region migratingto

     //  public virtual City MigratingTo { get; set; }

    //    #endregion
    }
}