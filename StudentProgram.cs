using System;

public class Student
{
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public string StarId { get; }

    public Student(string firstName, string lastName, DateTime dateOfBirth, string starId)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        StarId = starId;
    }
}

public class DynamicArray
{
    private Student[] students;
    private int count;

    public DynamicArray()
    {
        students = new Student[2]; // Initial size
        count = 0;
    }

    public int Count
    {
        get { return count; }
    }

    public void Add(Student student)
    {
        if (count == students.Length)
        {
            ResizeArray();
        }
        students[count] = student;
        count++;
    }

    public Student Get(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Index is out of range.");
        }
        return students[index];
    }

    public Student FindFirst()
    {
        return count > 0 ? students[0] : null;
    }

    public Student FindFirst(string starId)
    {
        for (int i = 0; i < count; i++)
        {
            if (students[i].StarId == starId)
            {
                return students[i];
            }
        }
        return null;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine ("Index is out of range.");
        }

        for (int i = index; i < count - 1; i++)
        {
            students[i] = students[i + 1];
        }

        students[count - 1] = null; // Remove reference
        count--;
    }

    private void ResizeArray()
    {
        int newSize = students.Length * 2;
        Student[] newStudents = new Student[newSize];

        for (int i = 0; i < count; i++)
        {
            newStudents[i] = students[i];
        }

        students = newStudents;
    }
}

