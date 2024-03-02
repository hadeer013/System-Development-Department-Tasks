using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Assignment
{
    internal struct Hiredate
    {
        int day;
        int month;
        int year;

        public Hiredate(int _day,int _month,int _year)
        {
            day = _day;
            month = _month;
            year = _year;
        }
        public int GetDay(){ return day; }
        public int GetMonth() { return month; }
        public int GetYear() { return year; }


        public void SetDay(int value) { day = value >= 1 && value <= 31 ? value : 1; }
        public void SetMonth(int value) { month = value >= 1 && value <= 12 ? value : 1; }
        public void Setyear(int value) { day = value >= 1990 && value <= DateTime.Now.Year ? value : DateTime.Now.Year; }
        
        public override string ToString()
        {
            return $"{day}-{month}-{year}";
        }
    }
}
