using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Task_3
{
    //-----------------------------------------------Student Class-----------------------------------------------------------------------------------------------
    class Student
    {
        private int studentId;
        private string name;
        private int age;
        public List<Course> Courses;

       
        public Student(int studentId)
        {
            this.studentId = studentId;
        }

        public Student(int studentId, string name, int age, List<Course> courses)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            Courses = courses;
        }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public int Age
        {
            get { return age; }
            set { if (age <= 120 && age > 0) age = value;
                else Console.WriteLine("Unexpected value.");
            }

        }

        //--------------------------------Student Methods------------------------------
        public bool Enroll(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public string printDetails()
        {

            return ($"\nStudent Id: {StudentId} \nStudent Name: {Name} \nStudent Age {Age} \nnumber of Enrolled courses: {Courses.Count}");
        }

    }
    //-----------------------------------------------Instructor Class-----------------------------------------------------------------------------------------------
    class Instructor
    {
        public int InstructorId;
        public string Name;
        string Specialzation;

        public Instructor(int instructorId)
        {
            InstructorId = instructorId;
        }

        public Instructor(int instructorId, string name, string specialzation)
        {
            InstructorId = instructorId;
            Name = name;
            Specialzation = specialzation;
        }
        //---------------------------------------------InstructorMethods--------------------------------------------------------------------------------
        public string PrintDetails()
        {
            return ($"\nInstructor Id:{InstructorId}\nInstructor Name: {Name}\nSpecialization: {Specialzation}");
        }
       
    }
    //-----------------------------------------------Course Class------------------------------------------------------------------------------------------------
    class Course
    {
        public int CourseId;
        public string Title;
        Instructor Instructor;

        public Course(int courseId)
        {
            CourseId = courseId;
        }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }
        //--------------------------------------------CourseMethods-------------------------------------------------------------------------------------
        public string PrintDetails()
        {
            return ($"Course Id: {CourseId}\nTitle of course: {Title}\nInsructor: {Instructor.Name}");
        }
        

    }
    //----------------------------------------------Student Manager---------------------------------------------------------------------------------------------
    class StudentManager
    {
        public List<Student> Students;
        public List<Course> Courses;
        public List<Instructor> Instructors;
        public StudentManager()
        {

        }
        public StudentManager(List<Student> students, List<Course> courses, List<Instructor> instructors)
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }
        //-----------------------------------------StudentManagerMethods--------------------
        public bool AddStudent(Student student)
        {

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == student.StudentId)
                {
                    Console.WriteLine("This student is ALREADY exist");
                    return false;
                }

            }
            Students.Add(student);
            return true;

        }
        public bool AddCourse(Course course)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    Console.WriteLine("This Course is exist");
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)
                {
                    Console.WriteLine("This Instructor is already exist");
                    return false;
                }
            }
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            Student a = new Student(studentId);
            for (int i = 0; i < Students.Count; i++)
            {

                if (Students[i].StudentId == studentId)
                {
                    Console.WriteLine($"This student is exist\n{Students[i].printDetails()}");
                    return Students[i];
                }
            }
            Console.WriteLine("This student is NOT exist");
            return a;
        }
        public Course FindCourse(int courseId)
        {
            Course a= new Course(courseId);
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId) {
                    
                    return Courses[i];
                        }
            }
            return a;

        }
        public Instructor FindInstructor(int instructorId)
        {
            Instructor a = new Instructor(instructorId);
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    Console.WriteLine($"This instructor is Exist\n {Instructors[i].PrintDetails()}");
                    return Instructors[i];
                }
            }
            Console.WriteLine("Not Found!");
            return a;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
           
           Student a= FindStudent(studentId);
            Course b =FindCourse(courseId);
               
            a.Enroll(b);
            return true;

        }
     

    }
    internal class Program
        {
            static void Main(string[] args)
            {
            int a,StId,StAge,InId,CoId;
            string StN,InN,InS,CoT;
            List<Course> Courses = new List<Course>();
            List<Student> students = new List<Student>();
            List<Instructor> instructors = new List<Instructor>();

            StudentManager School = new StudentManager();
            School.Students = students;
            School.Courses = Courses;
            School.Instructors = instructors;
            
            
           
            do
            {
                Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id ");
                Console.WriteLine("9. Fine the course by id ");
                Console.WriteLine("10. Exit");
                Console.WriteLine("Choose number");
                a = Convert.ToInt32(Console.ReadLine());
                switch(a)
                    {
                    case 1:
                        Console.Write("Enter student id:");
                        StId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter student name:");
                        StN=Console.ReadLine();
                        Console.Write("Enter Student age:");
                        StAge= Convert.ToInt32(Console.ReadLine());
                        Student NewOne=new Student(StId,StN,StAge,Courses);
                        School.AddStudent(NewOne);
                        break;
                    case 2:
                        Console.Write("Enter Instructor id: ");
                        InId= Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Instructor name: ");
                        InN=Console.ReadLine();
                        Console.Write("Enter Instructor specialization: ");
                        InS=Console.ReadLine();
                        Instructor NewIns = new Instructor(InId, InN, InS);
                        School.AddInstructor(NewIns);
                        break;
                    case 3:
                        Console.Write("Enter Course Id: ");
                        CoId= Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Course Name: ");
                        CoT=Console.ReadLine();
                        Console.Write("Enter instructor Id: ");
                        InId = Convert.ToInt32(Console.ReadLine());
                        Instructor newIns2 = School.FindInstructor(InId);
                        Course NewCo=new Course (CoId,CoT,newIns2);
                        School.AddCourse(NewCo);
                        break;
                    case 4:
                        Console.Write("Enter student id:");
                        StId = Convert.ToInt32(Console.ReadLine());
                        Student NewOne2 = new Student(StId);
                        Console.Write("Enter Course Id To Enroll: ");
                        CoId= Convert.ToInt32(Console.ReadLine());
                        School.EnrollStudentInCourse(StId, CoId);
                        break;
                    case 5:
                        for (int i = 0;i<students.Count;i++)
                        {
                            Console.WriteLine(students[i].printDetails());
                        }
                        break;
                    case 6:
                        for (int i = 0; i < Courses.Count; i++)
                        {
                            Console.WriteLine(Courses[i].PrintDetails());
                        }
                        break;
                    case 7:
                        for (int i = 0; i < instructors.Count; i++)
                        {
                            Console.WriteLine(instructors[i].PrintDetails());
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter student Id that you want to find: ");
                        StId= Convert.ToInt32(Console.ReadLine());
                        School.FindStudent(StId);
                        break;
                    case 9:
                        Console.WriteLine("Enter Course Id That you want to find: ");
                        CoId=Convert.ToInt32(Console.ReadLine());
                        School.FindCourse(CoId);
                        break;
                    case 10:
                        Console.WriteLine("Quit!");
                        break;

                }
            } while (a != 10);











            }
        
    }
}
