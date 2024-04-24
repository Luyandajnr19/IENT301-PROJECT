using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IENT301
{
	class IENT301Pro
	{

		class Program
		{
			static void Main()
			{
				Console.Write("Are you an intern or a lecturer: ");
				string userType = Console.ReadLine();

				User user;

				if (userType.ToLower() == "intern")
				{
					user = new Intern();
					user.AllocateRole(new InternCoordinator());
				}
				else if (userType.ToLower() == "lecturer")
				{
					user = new Lecturer();
					user.AllocateRole(null);
				}
				else
				{
					Console.WriteLine("Invalid user type entered.");
					return;
				}

				Console.Write("Enter your name: ");
				string name = Console.ReadLine();

				Console.Write("Enter your surname: ");
				string surname = Console.ReadLine();

				user.Register(name, surname);
				Console.WriteLine(name + " " + surname+" you have been registered successfully as " + user.Role);
				Console.WriteLine("Registration number: " + user.RegistrationNumber);
			}
		}

		class User
		{
			public string Role { get; set; }
			public string Name { get; set; }
			public string Surname { get; set; }
			public string RegistrationNumber { get; set; }

			public void AllocateRole(Role role)
			{
				Role = role?.GetType().Name ?? "No specific role";
			}

			public void Register(string name, string surname)
			{
				Name = name;
				Surname = surname;
				RegistrationNumber = GenerateRegistrationNumber();
			}

			private string GenerateRegistrationNumber()
			{
				return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
			}
		}

		class Intern : User
		{

		}

		class Lecturer : User
		{

		}

		class Role
		{

		}

		class InternCoordinator : Role
		{

		}
	}

}
