using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Shields
{
		//because iShield is an interface, we have to implement each property/field here
		//compare to Weapon, which is an abstract class so children will inherit those properties from it
	internal class SmallShield : IShield
	{
		public string? Name { get; set; }
		public Int16 Weight { get; set; }
		[DefaultValue(5)]
		public Int32 Cost { get; set; }
		[DefaultValue(1)]
		public Int16 HandsRequired { get; set; }
		[DefaultValue(2)]
		public Int16 DefenseModifier { get; set; }
		public string? Description { get; set; }

		public SmallShield() {
			this.Name = nameof(SmallShield);
			this.DefenseModifier = 6;
			this.Cost = 10;
		}
	}
}
