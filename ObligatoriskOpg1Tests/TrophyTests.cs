using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	[TestClass()]
	public class TrophyTests
	{
		[TestMethod()]
		public void ValidateCompetitionTest()
		{
			Trophy trophy1 = new Trophy()
			{
				Id = 1,
			};
			Trophy trophy2 = new Trophy()
			{
				Id = 2,
				Competition = "Hi"
			};

			Assert.ThrowsException<ArgumentNullException>(() => trophy1.ValidateCompetition());
			Assert.ThrowsException<ArgumentException>(() => trophy2.ValidateCompetition());
		}

		[TestMethod()]
		public void ValidateYearTest()
		{
			Trophy trophy1 = new Trophy()
			{
				Id = 1,
				Year = 1245
			};

			Assert.ThrowsException<ArgumentException>(() => trophy1.ValidateYear());
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Trophy trophy1 = new Trophy()
			{
				Id = 1,
				Competition = "Dancing",
				Year = 1997
			};

			Assert.AreEqual("1 Dancing 1997", trophy1.ToString());
		}
	}
}