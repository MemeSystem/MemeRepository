namespace MemeSystem.Entities
{
    class Histories
    {
        public int id { get; set; }
        public string Author { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string tag { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int likes { get; set; }
        public override string ToString()
        {
            return $"{id};{Author};{Name};{tag};{Text};{likes}";
        }
    }
}
