namespace PersonAPI.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public string? FamilyName { get; set; }
        public string? FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int NationalCode { get; set; }
        public int Id { get; set; }
        private static int id;

        public Person Clone()
        {
            return (Person) this.MemberwiseClone();
        }
        public Person(string? name, string? familyName, string? fatherName, DateTime? birthDate, int nationalCode)
        {
            Name = name;
            FamilyName = familyName;
            FatherName = fatherName;
            BirthDate = birthDate;
            NationalCode = nationalCode;
            Id = ++id;
        }
    }
}
