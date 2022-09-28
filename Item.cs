namespace OneListClientReDo
{
    public class Item
    {
        // not in Pascal case - ruby convention not C#
        public int id { get; set; }
        public string text { get; set; }
        public bool complete { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}