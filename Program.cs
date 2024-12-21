using System;
using System.Collections.Generic;
using System.Numerics;

class StudentSystem {
    static Dictionary<string, Student> students = new Dictionary<string, Student>();
    private void mainMenu(){
        Console.WriteLine("<-=-=-=-> Main Menu <-=-=-=->\n");
        Console.WriteLine("1. Add Student\n");
        Console.WriteLine("2. Assign Grade\n");
        Console.WriteLine("3. Calculate Average\n");
        Console.WriteLine("4. Display Records\n");
        Console.WriteLine("5. Exit\n");
        Console.Write("Choose an option: ");
    }

    private void addStudent(){
        Console.Clear();
        Console.WriteLine("<-=-=-=-> Add Student <-=-=-=->\n");
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        if(students.ContainsKey(id)){
            Console.WriteLine("A Student with this ID already exists. Please try again...");
        } else {
            students[id] = new Student { Name = name, Grades = new List<Grade>()};
            Console.WriteLine($"'{name}' with ID '{id}' was added successfully.");
        }
    }

    private void assignGrade(){
        Console.Clear();
        Console.WriteLine("<-=-=-=-> Assign Grade <-=-=-=->");
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        if(!students.ContainsKey(id)){
            Console.WriteLine("Student not found. Try again...");
        } else {
            Console.Write("Enter the Subject name: ");
            string subName = Console.ReadLine();

            Console.Write("Enter the Grade: ");
            float grade = float.Parse(Console.ReadLine());
            
            var newGrade = new Grade{Subject = subName, GradeValue = grade};
            students[id].Grades.Add(newGrade);
            Console.WriteLine($"Grade added: {subName} - {grade} for Student: {id}");
        }
    }

    private void calculateAverage(){
        Console.Clear();
        Console.WriteLine("<-=-=-=-> Calculate Average <-=-=-=->");
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        if(!students.ContainsKey(id)){
            Console.WriteLine("Student not found. Try again...");
        } else {
            float total = 0;
            foreach(var grade in students[id].Grades) {
                total += grade.GradeValue;
            }

            float average = total / students[id].Grades.Count;
            Console.WriteLine($"The Average grade of {students[id]}.name is {average:F2}");
        }
    }

    private void displayRecords(){
        Console.Clear();
        Console.WriteLine("<-=-=-=-> Display Records <-=-=-=->");

        if(students.Count == 0){
            Console.WriteLine("No students found...");
        } else {
            foreach(var studentK in students){
                string id = studentK.Key;
                Student student = studentK.Value;

                Console.WriteLine($"Student Name: {student.Name}");
                Console.WriteLine($"Student ID: {id}");

                if(student.Grades.Count > 0){
                    Console.WriteLine("Grades:");
                    float total = 0;

                    foreach(var grade in student.Grades){
                        Console.WriteLine($"{grade.Subject} - {grade.GradeValue:F2}");
                        total += grade.GradeValue;
                    }

                    float average = total / student.Grades.Count;
                    Console.WriteLine($"Average Grade: {average:F2}\n");
                } else {
                    Console.WriteLine("No grades recorded...");
                }
            }
        }
    }
    static void Main(){
        StudentSystem sm = new StudentSystem();
        bool running = true;

        while(running){
            sm.mainMenu();
            string choice = Console.ReadLine();

            switch(choice) {
                case "1":
                    sm.addStudent();
                    break;
                case "2":
                    sm.assignGrade();
                    break;
                case "3":
                    sm.calculateAverage();
                    break;
                case "4":
                    sm.displayRecords();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice...");
                    break;
            }
        }
    }
}

class Student {
    public string Name {get; set; }
    public List<Grade> Grades {get; set; }
}

class Grade {
    public string Subject {get; set; }

    public float GradeValue {get; set; }
}