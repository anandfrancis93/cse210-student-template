double SmallestNumber(List<double> list)
{
    double smallest = list[0];
    foreach(var i in list)
    {
        if(i < smallest)
        {
            smallest = i;
        }
    }
    return smallest;
}

List<double> sprintTimes = new List<double> {9.58, 9.69, 9.72, 9.74, 9.78};

Console.WriteLine($"The smallest number is: {SmallestNumber(sprintTimes)}");