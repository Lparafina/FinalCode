namespace FGF.Models
{
    public enum Types
    {
        Music, Art, Entertainment, Academic, Others
    }

    public class Register
    {
        public int RegisterID { get; set; }
        public int EventID { get; set; }
        public int StudentID { get; set; }
        public Types? Types { get; set; }

        public virtual Event Event { get; set; }
        public virtual Student Student { get; set; }
    }
}
