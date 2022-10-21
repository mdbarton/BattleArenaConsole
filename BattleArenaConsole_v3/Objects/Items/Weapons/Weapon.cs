using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items
{
	//we're defining this as an abstract class, like the Interface it "implements" it has no code logic
	//it does however define the basic properties a weapon will have and allows us to set default values
	internal abstract class Weapon : IItem
	{
		//the "?" marks this type as "nullable" - it will not throw an error if the class is instantiated without a value
		public string? Name { get; set; }
		public Int16 Weight { get; set; }

		//Notice there are two ways we're setting a default value here for a property/field
		[DefaultValue(0)]
		public Int32 Cost { get; set; }
		[DefaultValue(0)]
		public Int16 DefenseModifier { get; set; }
		[DefaultValue(1)]
		public Int16 HandsRequired { get; set; }
		//Notice there are two ways we're setting a default value here for a property/field
		public string DamageRoll { get; set;} = "1d4";

		//the "?" marks this type as "nullable" - it will not throw an error if the class is instantiated without a value
		public string? Description { get; set;}

		//public Int16 Defense { get; set; }
		//public Int16 Attack { get; set; }
	}
}
