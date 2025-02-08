using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lesson24.PersonI;
using static lesson24.UserT;

namespace lesson24
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool flag = true;
			University university = new University();
			while (flag)
			{
				Console.WriteLine("Welcome to our University");
				Console.WriteLine("Press 1: Teacher | Press 2: Student | Press 3: Book | Press 4: Exit");
				int option = int.Parse(Console.ReadLine());
				if (option >= 1 && option <= 4)
				{
					switch (option)
					{
						case 1:
							Console.WriteLine("Press 1: Add Teacher | Press 2: Show Teachers | Press 3: Update Teacher | Press 4: Delete teacher");
							int optionT = int.Parse(Console.ReadLine());
							switch (optionT)
							{
								case 1:
									Console.WriteLine("Enter name");
									string name = Console.ReadLine();
									Console.WriteLine("Enter age");
									int age = int.Parse(Console.ReadLine());
									Console.WriteLine("Enter gender (Male, Female)");
									GenderType gender;
									while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(GenderType), gender))
									{
										Console.WriteLine("Invalid input. Please enter a valid gender (Male, Female, Other):");
									}
									Console.WriteLine("Enter the profession");
									string proffesion = Console.ReadLine();
									Console.WriteLine("Enter the type of time to work");
									EmployeeType type;
									while (!Enum.TryParse(Console.ReadLine(), true, out type) || !Enum.IsDefined(typeof(EmployeeType), type))
									{
										Console.WriteLine("Invalid input. Please enter a valid type for employee (FullTime, PartTime):");
									}
									Console.WriteLine("Enter the selary");
									int selary = int.Parse(Console.ReadLine());
									UserT teacher = new UserT(name, age, gender, proffesion, type, selary);
									university.AddUser(teacher);
									break;
								case 2:
									break;
								case 3:
									break;
								case 4:
									break;
							}
							break;
						case 2:
							break;
						case 3:
							break;
						case 4:
							flag = false;
							break;

					}
				}
				else
				{
					Console.WriteLine("You choose wrong option");
					continue;
				}
			}
		}
	}

	//------------  1   --------------------Encapsulation

	class Person
	{
		private string _name;

		public string Name { get { return _name; } set { _name = value; } }

		private string _adress;
		public string Adress { get { return _adress; } set { _adress = value; } }

		private int _age;
		public int Age
		{
			get { return _age; }
			set
			{
				if (value > 0)
				{
					_age = value;
				}
				else
				{
					throw new Exception("Age cant be less than zero");
				}
			}
		}

		public Person(string name, string adress, int age)
		{
			Name = name;
			Adress = adress;
			Age = age;
		}

		public void PrintInfo()
		{
			Console.WriteLine($"{Name} | {Adress} | {Age}");
		}
	}

	//-------------     2   ----------------------

	class BankAccount
	{
		private string _accountNumber;
		public string AccountNumber
		{
			get { return _accountNumber; }
			set { _accountNumber = value; }
		}

		private string _accountHolder;

		public string AccountHolder
		{
			get { return _accountHolder; }
			set { _accountHolder = value; }
		}

		private decimal _ballance;
		public decimal Ballance
		{
			get { return _ballance; }
			set
			{
				if (value > 0)
				{
					_ballance = value;
				}
				else
				{
					throw new Exception("Balance cant be less than zero");
				}
			}
		}

		public void Deposite(decimal amount)
		{
			if (amount > 0)
			{
				Ballance += amount;
			}
		}

		public void Withdraw(decimal amount)
		{
			if (amount > 0)
			{
				Ballance += amount;
			}
		}

		public void GetAccountDetails()
		{
			Console.WriteLine($"{AccountHolder} | {AccountNumber} | {Ballance}");
		}
	}

	//------------  1   --------------------Inheritance

	class Vehicle
	{
		public string Mark;
		public string Model;
		private int _year;
		public int Year
		{
			get { return _year; }
			set
			{
				if (value > 1700)
				{
					_year = value;
				}
				else
				{
					throw new Exception("Its not a car :))) ");
				}
			}
		}

		public Vehicle(string mark, string model, int year)
		{
			Mark = mark;
			Model = model;
			Year = year;
		}

		public virtual void ShowDetails()
		{
			Console.WriteLine($"{Mark} | {Model} | {Year}");
		}
	}

	class Car : Vehicle
	{
		private int _countOfDoors;

		public int CountOfDoors
		{
			get { return _countOfDoors; }
			set
			{
				if (value > 1)
				{
					_countOfDoors = value;
				}
				else
				{
					throw new Exception("Car doors cant be less than 1");
				}
			}
		}

		public Car(int doorCount, string mark, string model, int year) : base(mark, model, year)
		{
			CountOfDoors = doorCount;
		}

		public override void ShowDetails()
		{
			Console.WriteLine($"{Mark} | {Model} | {Year} | {CountOfDoors}");
		}
	}

	class Motocycle : Vehicle
	{
		public bool HasSideCar;
		public Motocycle(string mark, string model, int year, bool isSideCar) : base(mark, model, year)
		{
			HasSideCar = isSideCar;
		}

		public override void ShowDetails()
		{
			Console.WriteLine($"{Mark} | {Model} | {Year} | {HasSideCar}");
		}
	}

	//----------    2       --------------------

	class Employee
	{
		public string Name;

		public string EmployeeID
		{
			get
			{
				return Guid.NewGuid().ToString();
			}
		}

		public Employee(string name)
		{
			Name = name;
		}
	}

	class FullTimeEmployee : Employee
	{
		private int _selaryAmount;

		public int AnnualSalary
		{
			get { return _selaryAmount; }
			set
			{
				if (value > 0)
				{
					_selaryAmount = value;
				}
				else
				{
					throw new Exception("Selary amount cant be zero or less than zero");
				}
			}
		}
		public FullTimeEmployee(string name, int amount) : base(name)
		{
			AnnualSalary = amount;
		}

		public void ShowDetailes()
		{
			Console.WriteLine($"{Name} | {AnnualSalary} | {EmployeeID}");
		}
	}

	class PartTimeEmployee : Employee
	{
		private int _hourRate;

		public int HourRate
		{
			get { return _hourRate; }
			set
			{
				if (value > 0)
				{
					_hourRate = value;
				}
				else
				{
					throw new Exception("Rate of hpur cant be zero or less than zero");
				}
			}
		}

		public PartTimeEmployee(int hourRate, string name) : base(name)
		{
			HourRate = hourRate;
		}

		public void ShowDetailes()
		{
			Console.WriteLine($"{Name} | {HourRate} | {EmployeeID}");
		}
	}

	//-----------       1   -----------Overriding Method
	class Shape
	{
		public virtual void Draw()
		{
			Console.WriteLine("Draw a shape");
		}
	}

	class Circle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Draw a Circle");
		}
	}

	class Rectangle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Draw a Rectangle");
		}
	}

	class Triangle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Draw a Triangle");
		}
	}
	//-------------------------------------------------------------------------------
	//--------   Exercise: School Management System
	//-------------------------------------------------------------------------------

	class PersonI
	{
		public string Name;

		public enum GenderType
		{
			Male,
			Female
		}

		public GenderType Gender { get; set; }

		private int _age;

		public int Age
		{
			get { return _age; }
			set
			{
				if (value > 16)
				{
					_age = value;
				}
			}
		}

		public PersonI(string name, int age, GenderType gender)
		{
			Name = name;
			Age = age;
			Gender = gender;
		}

		public virtual void GetDetails()
		{
			Console.WriteLine($"{Name} | {Age} | {Gender}");
		}
	}

	class Student : PersonI
	{
		public string StudentID
		{
			get
			{
				return Guid.NewGuid().ToString();
			}
		}

		public bool Major { get; set; }

		public Student(string name, int age, GenderType gender, bool major) : base(name, age, gender)
		{
			Major = major;
		}

		public virtual void GetDetails()
		{
			Console.WriteLine($"{Name} | {Age} | {Gender} | {Major}");
		}
	}

	class Teacher : PersonI
	{
		public string EmployeeID
		{
			get
			{
				return Guid.NewGuid().ToString();
			}
		}

		public string Subject { get; set; }
		public Teacher(string name, int age, GenderType gender, string subject) : base(name, age, gender)
		{
			Subject = subject;
		}
		public virtual void GetDetails()
		{
			Console.WriteLine($"{Name} | {Age} | {Gender} | {Subject}");
		}
	}

	class UserT : Teacher
	{
		public enum EmployeeType
		{
			FullTime,
			PartTime
		}
		public EmployeeType Employee { get; set; }

		private int _selary;
		public int Selary
		{
			get { return _selary; }
			set
			{
				if (value > 0)
				{
					_selary = value;
				}
			}
		}

		public UserT(string name, int age, GenderType gender, string subject, EmployeeType employee, int selary) : base(name, age, gender, subject)
		{
			Employee = employee;
			Selary = TeacherSelaryCondition(selary);
		}

		public int TeacherSelaryCondition(int selary)
		{
			if (Employee == EmployeeType.FullTime)
			{
				return Selary;
			}
			else
			{
				return Selary / 2;
			}
		}

	}

	class UserS : Student
	{
		public UserS(string name, int age, GenderType gender, bool major) : base(name, age, gender, major)
		{ }
	}

	class Book
	{
		public string Author { get; set; }
		public string Title { get; set; }

		public string ISBN { get; set; }

		public Book(string author, string title, string iSBN)
		{
			Author = author;
			Title = title;
			ISBN = iSBN;
		}

	}

	class University
	{
		List<UserS> userStudents = new List<UserS>();
		List<UserT> userTeachers = new List<UserT>();
		List<Book> books = new List<Book>();

		public void AddUser(PersonI person/* UserS userS = null, UserT userT = null*/)
		{
			if (person != null && person is UserS)
			{
				userStudents.Add((UserS)person);
			}
			if (person != null && person is UserT)
			{
				userTeachers.Add((UserT)person);
			}
		}

		public void ShowUsers()
		{
			if (userStudents.Count > 0)
			{
				foreach (UserS el in userStudents)
				{
					Console.Write($"{el.Name} | {el.Age} | {el.StudentID} | {el.Major} | {el.Gender} \n");
				}
			}
			if (userTeachers.Count > 0)
			{
				foreach (UserT el in userTeachers)
				{
					Console.Write($"{el.Name} | {el.Age} | {el.EmployeeID} | {el.Gender} | {el.Subject} | {el.Selary} | {el.Employee} \n");
				}
			}
		}

		public void DeleteUser(string studentID = null, string employeeID = null)
		{
			if (studentID != null)
			{
				foreach (UserS student in userStudents)
				{
					if (student.StudentID == studentID)
					{
						userStudents.Remove(student);
					}
				}
			}
			if (employeeID != null)
			{
				foreach (UserT teacher in userTeachers)
				{
					if (teacher.EmployeeID == employeeID)
					{
						userTeachers.Remove(teacher);
					}
				}
			}
		}

		public void UpdateUser(string studentID = null, string employeeID = null)
		{
			if (studentID != null)
			{
				foreach (UserS student in userStudents)
				{
					if (student.StudentID == studentID)
					{
						Console.WriteLine("Please enter name");
						string name = Console.ReadLine();
						Console.WriteLine("Please enter age");
						int age = int.Parse(Console.ReadLine());
						Console.WriteLine("Please enter gender of student");
						GenderType gender;
						while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(GenderType), gender))
						{
							Console.WriteLine("Invalid input. Please enter a valid gender (Male, Female, Other):");
						}
						bool isMajor = bool.Parse(Console.ReadLine());

						student.Name = name;
						student.Age = age;
						student.Gender = gender;
						student.Major = isMajor;
					}
				}
				foreach (UserT teacher in userTeachers)
				{
					if (teacher.EmployeeID == employeeID)
					{
						Console.WriteLine("Please enter name");
						string name = Console.ReadLine();
						Console.WriteLine("Please enter age");
						int age = int.Parse(Console.ReadLine());
						Console.WriteLine("Please enter gender of student");
						GenderType gender;
						while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(GenderType), gender))
						{
							Console.WriteLine("Invalid input. Please enter a valid gender (Male, Female):");
						}
						Console.WriteLine("Enter the profession");
						string subject = Console.ReadLine();
						Console.WriteLine("Enter teacher work time condition");
						EmployeeType type;
						while (!Enum.TryParse(Console.ReadLine(), true, out type) || !Enum.IsDefined(typeof(EmployeeType), type))
						{
							Console.WriteLine("Invalid input. Please enter a valid type for employee (FullTime, PartTime):");
						}
						Console.WriteLine("Enter teacher selary");
						int selary = int.Parse(Console.ReadLine());


						teacher.Name = name;
						teacher.Age = age;
						teacher.Gender = gender;
						teacher.Subject = subject;
						teacher.Employee = type;
						teacher.Selary = selary;
					}
				}
			}
		}

		public void AddBook(Book book)
		{
			if (book != null)
			{
				books.Add(book);
			}
		}

		public void ShowBooks()
		{
			if (books.Count > 0)
			{
				foreach (Book book in books)
				{
					Console.Write($"{book.Author} | {book.Title} | {book.ISBN}");
				}
			}
		}

		public void UpdateBook(string isbn)
		{
			if (isbn != null)
			{
				foreach (Book book in books)
				{
					if (book.ISBN == isbn)
					{
						Console.WriteLine("Enter Author name");
						string name = Console.ReadLine();
						Console.WriteLine("Enter book tittle");
						string tittle = Console.ReadLine();

						book.Author = name;
						book.Title = tittle;
					}
				}
			}
		}
		public void DeleteBook(string isbn)
		{
			if (isbn != null)
			{
				foreach (Book book in books)
				{
					if (book.ISBN == isbn)
					{
						books.Remove(book);
					}
				}
			}
		}
	}
}
