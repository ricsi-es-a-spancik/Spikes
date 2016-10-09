namespace LiteDBConsoleApp.Model
{
    public class Phone
    {
        public int Code { get; set; }

        public string Number { get; set; }

        public PhoneType Type { get; set; }

        public override string ToString()
        {
            return $"[{Code}] {Number} ({Type})";
        }
    }
}
