class Program
{
    public static void Main()
    {
        Person myPerson = new Person("John", "Revelator", 50, 180.0);
        Console.WriteLine(myPerson.GetPersonInformation());

        Doctor myDoctor= new Doctor("Bob", "Payne", 45, 279, "Knife");
        Console.WriteLine(myDoctor.GetPersonInformation());

        Console.WriteLine(myDoctor.GetDoctorInformation());

        Police myPolice = new Police("Gary", "Goodman", 61, 181, "Guns");
        Console.WriteLine(myDoctor.GetPersonInformation());

        Console.WriteLine(myPolice.GetPersonInformation());

        List<Person> myPeople = new List<Person>();

        myPeople.Add(myPerson);
        myPeople.Add(myDoctor);
        myPeople.Add(myPolice);

        foreach(Person person in myPeople)
        {
            if(person is Doctor doctor)
            {
                Console.WriteLine(doctor.GetPersonInformation());
            }
            else
            {
                Console.WriteLine(person.GetPersonInformation());
            }
        }

    }
}