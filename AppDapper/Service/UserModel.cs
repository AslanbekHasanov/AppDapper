using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDapper.Service
{
    [Table("person")]
    public class UserModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fullname")]
        public string FullName { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("image_url")]
        public string ImageUrl { get; set; }

    }
}
