using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CocShop.Model
{
    public class HubUserConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Connection { get; set; }
        public string Username { get; set; }

        [ForeignKey("UserId")]
        public virtual MyUser User { get; set; }
    }
}
