using College.Models;

namespace College
{
    public partial class Output
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public DateTime SDOB { get; set; } = new DateTime();
        public long SPhno { get; set; }
        public string SEmail { get; set; }
        public string SCity { get; set; }
        public Gender SGender { get; set; }
        public int TeachId { get; set; }
        public string TeachName { get; set; }
        public Subject Subject { get; set; }
    }
}
