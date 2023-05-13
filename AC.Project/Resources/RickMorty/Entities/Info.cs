namespace AC.Project.Resources.RickMorty.Entities
{
    public class Info
    {
        public int count { get; set; }
        
        public int pages { get; set; }

        public string? next { get; set; }

        public string? prev { get ; set; }

        public Info(int count, int pages, string? next, string? prev)
        {
            this.count = count;
            this.pages = pages;
            this.next = next;
            this.prev = prev;
        }
    }
}
