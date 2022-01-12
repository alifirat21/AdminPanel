using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(150)]
        public string Subject { get; set; }
        [StringLength(2000)]
        public string MesssageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
