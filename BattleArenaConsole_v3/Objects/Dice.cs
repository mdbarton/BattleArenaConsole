using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects
{
	internal class Dice
	{
		public Int16 Sides { get; set; }
		private Int16 Rolls { get; set; }

		private Int16 RollModifier { get; set; } = 0;
		 
		public Dice() { }
		public Dice(Int16 sides = 20)
		{
			this.Sides = sides;
			this.Rolls = 1;
		}
		public Dice(string rollType)
		{
			try
			{
				// we moved this code from the Roll method to this constructor as it makes more sense
				// we've also implemented using the roll modifier
				string pattern = @"^(\d+)d(\d+)(\/-?\d+)?$";

				Match match = Regex.Match(rollType, pattern, RegexOptions.IgnoreCase);

				string rolls = match.Groups[1].Value.Trim();
				string sides = match.Groups[2].Value.Trim();
				string rollModifier = match.Groups[3].Value.Trim();

				this.Rolls = Int16.Parse(rolls);
				this.Sides = Int16.Parse(sides);
				this.RollModifier = Int16.Parse(rollModifier);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}
		public Int32 Roll()
		{
			Int32 result = 0;
			Random d = new Random();
			for (var x = 0; x < this.Rolls; x++)
			{
				result += d.Next(1, this.Sides + 1);
			}
			return result + this.RollModifier; // + modifer
		}
		public Int32 Roll(Int16 timesToRoll)
		{
			this.Rolls = timesToRoll;
			return this.Roll();
		}
	}
}
