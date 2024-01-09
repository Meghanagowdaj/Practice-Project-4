using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storing_School_Data
{
    internal class Program
    {
        public class SchoolDataStorage
        {
            private static SchoolDataStorage instance;
            public List<Student> Students { get; set; }
            public List<Teacher> Teachers { get; set; }
            public List<Subject> Subjects { get; set; }

            private SchoolDataStorage()
            {
                Students = new List<Student>();
                Teachers = new List<Teacher>();
                Subjects = new List<Subject>();
            }

            public static SchoolDataStorage Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SchoolDataStorage();
                    }
                    return instance;
                }
            }
        }
        public class Subject
        {
            public string Name { get; set; }
            public string SubjectCode { get; set; }
            public Teacher Teacher { get; set; }
        }
        public class Teacher
        {
            public string Name { get; set; }
            public string ClassAndSection { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public string ClassAndSection { get; set; }
        }

        public class SchoolRepository // Repository Pattern
        {
            private SchoolDataStorage dataStorage;
            public SchoolRepository()
            {
                dataStorage = SchoolDataStorage.Instance;
            }
            public void AddStudent(Student student)
            {
                dataStorage.Students.Add(student);
            }

            public void AddTeacher(Teacher teacher)
            {
                dataStorage.Teachers.Add(teacher);
            }

            public void AddSubject(Subject subject)
            {
                dataStorage.Subjects.Add(subject);
            }

            public List<Student> GetStudentsInClass(string classAndSection)
            {
                return dataStorage.Students.FindAll(student => student.ClassAndSection == classAndSection);
            }

            public List<Subject> GetSubjectsTaughtByTeacher(string teacherName)
            {
                return dataStorage.Subjects.FindAll(subject => subject.Teacher.Name == teacherName);
            }
        }

        class program
        {
            static void Main()
            {
                SchoolRepository repository = new SchoolRepository();
                repository.AddStudent(new Student { Name = "Tarun", ClassAndSection = "ClassA" });
                repository.AddStudent(new Student { Name = "Dhuvan", ClassAndSection = "ClassA" });
                repository.AddStudent(new Student { Name = "Janya", ClassAndSection = "ClassA" });
                repository.AddStudent(new Student { Name = "Krishna", ClassAndSection = "ClassA" });
                repository.AddStudent(new Student { Name = "Divya", ClassAndSection = "ClassA" });

                repository.AddStudent(new Student { Name = "Poorva", ClassAndSection = "ClassB" });
                repository.AddStudent(new Student { Name = "Sharanya", ClassAndSection = "ClassB" });
                repository.AddStudent(new Student { Name = "Likith", ClassAndSection = "ClassB" });
                repository.AddStudent(new Student { Name = "Manoj", ClassAndSection = "ClassB" });


                 repository.AddTeacher(new Teacher { Name = "Teacher1", ClassAndSection = "ClassA" });
                //repository.AddTeacher(new Teacher { Name = "Teacher2", ClassAndSection = "ClassB" });

                repository.AddSubject(new Subject
                {
                    Name = "English",
                    SubjectCode = "ENG110",
                    Teacher = new Teacher { Name = "Teacher1", ClassAndSection = "ClassA" }

                });


                Console.WriteLine("Students in ClassA:"); // Displaying lists
                foreach (var student in repository.GetStudentsInClass("ClassA"))
                {
                    Console.WriteLine(student.Name);
                }

                Console.WriteLine("\nSubjects taught by Teacher1:");
                foreach (var subject in repository.GetSubjectsTaughtByTeacher("Teacher1"))
                {
                    Console.WriteLine(subject.Name);
                }


                repository.AddSubject(new Subject
                {
                    Name = "Science",
                    SubjectCode = "SCI65",
                    Teacher = new Teacher { Name = "Teacher2", ClassAndSection = "ClassB" }

                });
                Console.WriteLine("");
                Console.WriteLine("Students in ClassB:");
                foreach (var student in repository.GetStudentsInClass("ClassB"))
                {
                    Console.WriteLine(student.Name);
                }

                Console.WriteLine("\nSubjects taught by Teacher2:");
                foreach (var subject in repository.GetSubjectsTaughtByTeacher("Teacher2"))
                {
                    Console.WriteLine(subject.Name);
                }
            }
        }
    }
}

