namespace LiteDBConsoleApp.Model
{
    public class Address
    {
        public int PostalCode { get; set; }

        public string Residence { get; set; }

        public override string ToString()
        {
            return $"Address {PostalCode} {Residence}";
        }
    }
}
