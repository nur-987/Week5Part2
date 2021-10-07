using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp
{
    /// <summary>
    /// The organization uses a multiple objective answering system to evaluate the students. 
    /// but first you need to signup as a student 
    /// then appear for the exam . 
    /// After completion of the exam it shows the result 
    /// and the correct answer of the respective questions. 
    /// But there is two conditions first “one can sit for the exam once only” 
    /// and the second one is the admin allows the students to take the exam or not .
    /// </summary>


    delegate void Enrollment(string name);

    class Program
    {
        public static event Enrollment newStudentAdded;

        public static List<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            bool b = true;
            while (b)
            {
                Console.WriteLine("1) Register Student 2) Check Eligibility & Take exam 3)Display All Students 4)Exit");
                int input = Int32.Parse(Console.ReadLine());

                if (input == 1)
                {
                    newStudentAdded += Program_newStudentAdded;

                    Console.WriteLine("Student ID:");
                    int tempId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Student Name:");
                    string tempName = Console.ReadLine();
                    RegisterStudent(tempId, tempName);

                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter Student ID");
                    int tempId2 = Int32.Parse(Console.ReadLine());
                    TakenExamCheck(tempId2);
                }
                else if (input == 3)
                {
                    DisplayAllStudents();
                }
                else if(input == 4)
                {
                    b = false;
                }

            }


            Console.ReadLine();

        }

        private static void Program_newStudentAdded(string name)
        {
            Console.WriteLine("New student added! Student Name: " + name);
        }

        public static void RegisterStudent(int Id, string name)
        {
            Student newStudent = new Student();
            newStudent.StudentId = Id;
            newStudent.StudentName = name;
            newStudent.StudentResult = 0;
            newStudent.HasTakenExam = false;

            studentList.Add(newStudent);

            if(newStudentAdded != null)
            {
                newStudentAdded.Invoke(newStudent.StudentName);
            }

            Console.WriteLine("registration succesfull!");

        }

        public static void TakenExamCheck(int Id)
        {
            foreach(Student item in studentList)
            {
                if(item.StudentId == Id)
                {
                    if (item.HasTakenExam)
                    {
                        Console.WriteLine("DENIED");
                        Console.WriteLine("you have sat for an exam. Cannot resit for exam again.");
                    }
                    else
                    {
                        Console.WriteLine("CLEARED CHECKS");
                        Console.WriteLine("proceed to take exam");
                        SitForExam(Id);
                    }
                }
            }
        }

        public static void SitForExam(int Id)
        {

            //mark bool flag as true; =>HasTakenExam = true
            foreach (Student item in studentList)
            {
                if (item.StudentId == Id)
                {
                    item.HasTakenExam = true;
                }
            }

            //QUESTION 1   
            Console.WriteLine("1) 2+2 =");
            Console.WriteLine("a) 4, b)1, c)6, d)8");
            string ans1 = Console.ReadLine();
            if (ans1 == "a")
            {
                Console.WriteLine("CorrectAnswer!");
                //award a point
                foreach (Student item in studentList)
                {
                    if (item.StudentId == Id)
                    {
                        item.StudentResult++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Answer!");
                Console.WriteLine("Corrrect answer is: a");
            }
            //QUESTION 2    
            Console.WriteLine("2) 6+3");
            Console.WriteLine("a) 3, b)6, c)9, d)8");
            string ans2 = Console.ReadLine();
            if (ans2 == "c")
            {
                Console.WriteLine("CorrectAnswer!");
                //award a point
                foreach (Student item in studentList)
                {
                    if (item.StudentId == Id)
                    {
                        item.StudentResult++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Answer!");
                Console.WriteLine("Corrrect answer is: c");
            }

            //QUESTION 3    
            Console.WriteLine("3) 10-3");
            Console.WriteLine("a) 1, b)7, c)9, d)4");
            string ans3 = Console.ReadLine();
            if (ans3 == "b")
            {
                Console.WriteLine("CorrectAnswer!");
                //award a point
                foreach (Student item in studentList)
                {
                    if (item.StudentId == Id)
                    {
                        item.StudentResult++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Answer!");
                Console.WriteLine("Corrrect answer is: b");
            }

            Console.WriteLine("Exam completed");
            foreach (Student item in studentList)
            {
                if (item.StudentId == Id)
                {
                    Console.WriteLine("result: " + item.StudentResult);
                }
            }
        }

        public static void DisplayAllStudents()
        {
            foreach(Student item in studentList)
            {
                Console.WriteLine("Student ID: " + item.StudentId);
                Console.WriteLine("Student Name: " + item.StudentName);
                Console.WriteLine("Taken Exam: " + item.HasTakenExam);
                Console.WriteLine("Exam Result: " + item.StudentResult);

            }
        }


    }
}
