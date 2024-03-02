using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Day3_Assignment
{
    internal struct Employee
    {

        int ID;
        SecurityLevel SecurityLevel;
        float Salary;
        Hiredate Hiredate;
        Gender Gender;


        public int GetID()                      { return ID; }
        public SecurityLevel GetSecurityLevel() { return SecurityLevel; }
        public float GetSalary()                { return Salary; }
        public Hiredate GetHiredate()           { return Hiredate; }
        public Gender GetGender()               { return Gender; }


        public void SetID(int value)                      { ID = value; }
        public void SetSecurityLevel(SecurityLevel value) { SecurityLevel = value; }
        public void SetSalary(float value)                { Salary = value; }
        public void SetHiredate(Hiredate value)           { Hiredate = value; }
        public void SetGender(Gender value)               { Gender = value; }

        public override string ToString()
        {
            string gender = (Gender == Gender.F )? "Female" : "Male";
            return $"EmployeeID : {ID}\n EmployeeSalary: {string.Format("{0:C}", Salary)}\nSecurityPrevilage : {SecurityLevel}\nHiredate : {Hiredate}\nGender : {gender} ";
        }
    }
}
