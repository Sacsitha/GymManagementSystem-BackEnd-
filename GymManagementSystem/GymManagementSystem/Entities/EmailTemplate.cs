namespace GymManagementSystem.Entities
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }
        public Email emailTypes { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
