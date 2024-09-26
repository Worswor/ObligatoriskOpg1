using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOpg1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpg1.Tests
{
	[TestClass()]
	public class TrophiesRepositoryTests
	{
		//[TestMethod()]
		//public void AddTrophyTest()
		//{
		//	Assert.Fail();
		//}

		//[TestMethod()]
		//public void GetTest()
		//{
		//	Assert.Fail();
		//}

		[TestMethod()]
		public void GetByIdTest()
		{
			TrophiesRepository repository = new TrophiesRepository();
			Trophy trophy1 = new Trophy() { Competition = "Chest", Year = 1997};
			Trophy trophy2 = new Trophy() { Competition = "Swimming", Year = 2001};
			repository.AddTrophy(trophy1);
			repository.AddTrophy(trophy2);

			Assert.AreEqual(trophy2, repository.GetById(2));
			Assert.IsNull(repository.GetById(3));
		}

		[TestMethod()]
		public void GetFilterTest()
		{
			TrophiesRepository repository = new TrophiesRepository();
			Trophy trophy1 = new Trophy() { Competition = "Math", Year = 1980 };
			Trophy trophy2 = new Trophy() { Competition = "Swimming", Year = 2001 };
			Trophy trophy3 = new Trophy() { Competition = "Boxing", Year = 1999 };
			Trophy trophy4 = new Trophy() { Competition = "Gaslighting", Year = 2020 };
			repository.AddTrophy(trophy1);
			repository.AddTrophy(trophy2);
			repository.AddTrophy(trophy3);
			repository.AddTrophy(trophy4);

			//Tester fliter
			Assert.AreEqual(trophy2.Competition, repository.GetFilter(null, null, "name").ToList()[3].Competition); //tester sortering af navne (z -> a)
			Assert.AreEqual(trophy1.Competition, repository.GetFilter(null, null, "yEaR").ToList()[0].Competition); //tester sortering af navne (z -> a) og lower-case for sort
			Assert.ThrowsException<ArgumentException>(() => repository.GetFilter(null, null, "404")); //tester ugyldigt sortering navn
			Assert.AreEqual(trophy3.Competition, repository.GetFilter("Boxing", null, null).ToList()[0].Competition.ToString()); //Finder Boxing
			Assert.AreEqual(trophy4.Competition, repository.GetFilter(null, 2020, null).ToList()[0].Competition.ToString()); //Finder 2020
		}

		//[TestMethod()]
		//public void RemoveTest()
		//{
		//	Assert.Fail();
		//}

		[TestMethod()]
		public void UpdateTest()
		{
			TrophiesRepository repository = new TrophiesRepository();
			Trophy trophy1 = new Trophy() { Competition = "100m run", Year = 2004 };
			repository.AddTrophy(trophy1);
			repository.Update(1, new Trophy() { Competition = "200m run", Year = 2003 });

			Assert.AreEqual("200m run", trophy1.Competition);
		}
	}
}