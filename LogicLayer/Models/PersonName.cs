namespace LogicLayer.Models
{
    public class PersonName
    {
        public string FirstName { get; set; }
        public string? MiddleName1 { get; set; }
        public string? MiddleName2 { get; set; }
        public string LastName { get; set; }

        public PersonName(string fullName)
        {
            var nameParts = fullName.Split(' ');

            switch (nameParts.Length)
            {
                case 2:
                    FirstName = nameParts[0];
                    LastName = nameParts[1];
                    break;
                case 3:
                    FirstName = nameParts[0];
                    MiddleName1 = nameParts[1];
                    LastName = nameParts[2];
                    break;
                case 4:
                    FirstName = nameParts[0];
                    MiddleName1 = nameParts[1];
                    MiddleName2 = nameParts[2];
                    LastName = nameParts[3];
                    break;
                default:
                    throw new ArgumentException($"Unexpected name format: {fullName}");
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(MiddleName1) && !string.IsNullOrEmpty(MiddleName2))
            {
                return $"{FirstName} {MiddleName1} {MiddleName2} {LastName}".Trim();
            }
            if (!string.IsNullOrEmpty(MiddleName1))
            {
                return $"{FirstName} {MiddleName1} {LastName}".Trim();
            }
            return $"{FirstName} {LastName}";
        }
    }
}
