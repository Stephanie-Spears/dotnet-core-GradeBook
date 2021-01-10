using System;
using System.Collections.Generic;

namespace GradeBook
{

	class Program
	{
		static void Main(string[] args)
		{

			var book = new Book("Dummy's Grade Book");

			while (true)
			{
				Console.WriteLine("Enter a numerical grade or 'q' to quit");
				var input = Console.ReadLine();
				
				if (input == "q")
				{
					break;
				}

				try
				{
					var grade = double.Parse(input);
					book.AddGrade(grade);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					throw;
				}

			}


			var stats = book.GetStatistics();

			Console.WriteLine($"The lowest grade is {stats.Low}");
			Console.WriteLine($"The highest grade is {stats.High}");
			Console.WriteLine($"The average grade is {stats.Average:N1}");
			Console.WriteLine($"The letter grade is {stats.Letter}");
		}
	}
}
