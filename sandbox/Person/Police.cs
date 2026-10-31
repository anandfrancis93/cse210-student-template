class Police : Person
{
    private string _weapons;
    public Police(string firstName, string lastName, int age, double weight, string weapons) : base(firstName, lastName, age, weight)
    {
        _weapons = weapons;
    }

    public string GetDoctorInformation()
    {
        return $"Police: Weapons: {_weapons}: {GetPersonInformation()}";
    }
}