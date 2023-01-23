namespace PE_Lists_of_Objects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student shiro = new Student("shiro", "GDD", 1);
            Console.WriteLine(shiro.ToString());

            List<Student> students = new List<Student>();

            Roster roster = new Roster("All Students", students);

            roster.DisplayRoster();

            roster.Add(shiro);

            roster.DistplayRoster();

            roster.SearchByName("shiro");
        }
    }
}