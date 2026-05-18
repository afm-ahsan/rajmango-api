using System.ComponentModel.DataAnnotations.Schema;

namespace RajMango.Domain.Entities
{
    [Table("OrderNumberCounters")]
    public class OrderNumberCounter
    {
        /// <summary>Calendar date (DATE column). Acts as the primary key.</summary>
        public DateTime Date { get; set; }

        /// <summary>Monotonically increasing sequence for the day. Incremented atomically by MERGE.</summary>
        public int Counter { get; set; }
    }
}
