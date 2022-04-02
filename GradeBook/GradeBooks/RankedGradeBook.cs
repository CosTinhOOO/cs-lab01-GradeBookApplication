﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            double top20 = Students.Count * 0.2;
            double top40 = Students.Count * 0.4;
            double top60 = Students.Count * 0.6;
            double top80 = Students.Count * 0.8;

            List<double> grades = new List<double>();
            List<double> gradesSorted = new List<double>();
            
            int i = 0;
            foreach(Student student in Students)
            {
                if (student.AverageGrade > averageGrade) { i++; }
            }

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else if (i < top20)
            {
                return 'A';
            }
            else if(i <  top40 && i > top20)
            {
                return 'B';
            }
            else if (i > top40 && i < top60)
            {
                return 'C';
            }
            else if (i > top60 && i < top80)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }

        }
    }
}
