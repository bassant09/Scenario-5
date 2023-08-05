namespace AppNest_Project.DTOS.Shelter
{
    public class FilterShelterDto
    {
        public bool Water { get; set; } = false;
        public bool Clothes { get; set; } = false;
        public bool Toy { get; set; } = false;
        public bool Medicine { get; set; } = false;
        public bool Food { get; set; } = false;
    }
}
