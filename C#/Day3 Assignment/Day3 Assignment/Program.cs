namespace Day3_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] EmpArr = {new Employee(),new Employee(),new Employee() };
            EmpArr[0].SetSecurityLevel(SecurityLevel.DBA);
            EmpArr[1].SetSecurityLevel(SecurityLevel.Guest);
            EmpArr[2].SetSecurityLevel(SecurityLevel.DBA^SecurityLevel.Secretary^SecurityLevel.Developer);


            for (int i=0;i<3;i++)
            {
                Console.WriteLine($"Data of employee {i+1}\n");
                Console.Write("Enter Your Id : ");
                int Id = int.Parse(Console.ReadLine());


                Console.Write("\nEnter your Salary : ");
                float salary = float.Parse(Console.ReadLine());

                Console.Write("\nEnter your Hire date : \nDay : ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("\nMonth : ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("\nYear : ");
                int year = int.Parse(Console.ReadLine());


                Hiredate hiredate = new Hiredate(day,month,year);

                Console.Write("\nEnter your gender F or M : ");
                Gender gender =(Gender)Enum.Parse(typeof(Gender),Console.ReadLine());

                Console.WriteLine("\n=======================================================");

                EmpArr[i].SetID(Id);
                EmpArr[i].SetSalary(salary);
                EmpArr[i].SetGender(gender);
                EmpArr[i].SetHiredate(hiredate);

            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{EmpArr[i].ToString()}\n");
                Console.WriteLine("=======================================================");
            }
                

        }
        
    }
}
