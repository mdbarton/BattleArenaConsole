using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v2.Objects.Weapons
{
	//THIS IS THE BASE WEAPON CLASS - ALL WEAPONS WILL DERIVE FROM IT
	// THIS CLASS IS NOT INTENDED TO BE USED DIRECTLY, LATER, WE'll IMPLEMENT AS AN INTERFACE
	internal class Weapon
	{
		//Like Class Methods, Fields have an "accessibility" level : Public = anything can see it, Private, only code in this class
		//ALSO we should use "get" and "set" accessors to set and read values
		//these will later allow us to modify if/how those properties can be accessed and modified
		public Int16 Damage { get; set; }
		public Int16 Defense { get; set; }
		//The previous get/set accessors allow the value to be set/read directly from any code
		//the below does the same though explicityly and using a secondary private field to store the value
		//in more complex applications this becomes more common/necessary
		public string Name {
			get { return this.name; }  // when some code looks for weapon.Name, this will return the lowercase "name" value
			set { this.name = value; } // this sets the lowercase "name" to whatever cpde assigns to it
		}
		private string name;

		public Weapon()
		{
			this.Damage = 0;
			this.Defense = 0;
			this.Name = nameof(Weapon);
		}
	}
}
