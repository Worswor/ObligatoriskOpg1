using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Trophy
{

	#region Properties
	public int Id { get; set; }
	public string Competition { get; set; }
	public int Year { get; set; }
	#endregion


	public void ValidateCompetition()
	{
		if (Competition == null)
		{
			throw new ArgumentNullException("Name of competition cannot be null");
		}
		if (Competition.Length < 3)
		{
			throw new ArgumentException("Name of competition must be at least three character long");
		}
	}

	public void ValidateYear()
	{
		if (Year < 1970 || Year > 2024)
		{
			throw new ArgumentException(Year + " is not a valid year, as it have to be between 1970 and 2024");
		}
	}

	public void Validate()
	{
		ValidateCompetition();
		ValidateYear();
	}

	#region methods
	public override string ToString()
	{
		return $"{Id} {Competition} {Year}";
	}
	#endregion
}