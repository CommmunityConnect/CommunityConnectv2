using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityConnect.Model
{
    public class Person 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string LastLocation { get; set; }
        public DateTime DateReported { get; set; }
        public string ContactNumber { get; set; }
        public string Photo { get; set; }
    }
}