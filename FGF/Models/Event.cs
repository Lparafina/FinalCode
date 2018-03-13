using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FGF.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }
        public string Title { get; set; }
        public int NumofEvents { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}
