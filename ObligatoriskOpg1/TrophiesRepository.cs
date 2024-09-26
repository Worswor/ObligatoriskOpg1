using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpg1
{
	public class TrophiesRepository
	{
		private int nextId = 1;
		private List<Trophy> trophies = new List<Trophy>();

		public void AddTrophy(Trophy trophy)
		{
			trophy.Validate();
			trophy.Id = nextId++;
			trophies.Add(trophy);
		}

		public List<Trophy> Get()
		{
			return new List<Trophy>(trophies);
		}

		public Trophy? GetById(int id)
		{
			return trophies.FirstOrDefault(t => t.Id == id);
		}

		public IEnumerable<Trophy> GetFilter(string? theCompetition = null, int? theYear = null, string? sortBy = null )
		{
			List<Trophy> result = new List<Trophy>(trophies);
			if (theCompetition != null)
			{
				result = result.FindAll(t => t.Competition == theCompetition);
			}
			if (theYear != null)
			{
				result = result.FindAll(t => t.Year == theYear);
			}
			if (sortBy != null)
			{
				sortBy = sortBy.ToLower();
				switch (sortBy.ToLower())
				{
					case "name":
						result.Sort((t1, t2) => t1.Competition.CompareTo(t2.Competition));
						break;
					case "namedesc":
						result.Sort((t1, t2) => t2.Competition.CompareTo(t1.Competition));
						break;
					case "year":
						result.Sort((t1, t2) => t1.Year - t2.Year);
						break;
					default:
						throw new ArgumentException($"Unknown sort field {sortBy}");
				}
			}
			return result;
		}

		public Trophy? Remove(int id)
		{
			Trophy? trophy = GetById(id);
			if (trophy == null)
			{
				throw new ArgumentException($"Trophy with id {trophy.Id} does not exist.");
			}
			trophies.Remove(trophy);
			return trophy;
		}

		public Trophy? Update(int id, Trophy data)
		{
			Trophy? excistingTrophy = GetById(id);
			if (excistingTrophy == null)
			{
				return null;
			}
			excistingTrophy.Competition = data.Competition;
			excistingTrophy.Year = data.Year;
			return excistingTrophy;
		}
	}
}