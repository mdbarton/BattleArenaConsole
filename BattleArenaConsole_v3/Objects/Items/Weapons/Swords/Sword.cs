using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Weapons//.Swords by default namespace follows folder structure
{
	internal class Sword : Weapon
	// this code inherits from the "Weapon" class, the ":" tells .net what "base" class to inherit from
	// it will automatically have "damage and defense" properties and any other code from the base class
	{
		//we can also add new properties and code to this child class (we're not using these yet though)
		//public int slashDamage;
		//public int thrustDamage;

		public Sword()
		{
			//the default constructor here sets the base damage value a tad higher than a default weapon
			//this.Damage = 3;
			this.Name = nameof(Sword);
			this.DamageRoll = "1d6";
			this.DefenseModifier = 1;
		}

		//public Sword(Int16 thrust)
		//{
		//	this.thrustDamage = thrust;
		//}

		//public Sword(Int16 thrust, Int16 slash)
		//{
		//	this.thrustDamage = thrust;
		//	this.slashDamage = slash;
		//}
	}
}
