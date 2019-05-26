using System.ComponentModel.DataAnnotations;

namespace AquaparkSystemApi.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public int MaxAmountOfPeople { get; set; }
        public Zone Zone { get; set; }
    }
}