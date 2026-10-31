class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;
    private double _weight;

    public Person(string firstName, string lastName, int age, double weight)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
        _weight = weight;

    }
    
    public string GetPersonInformation()
    {
        return $"{_firstName} {_lastName} is {_age} years old and weighs {_weight} pounds";
    }
}