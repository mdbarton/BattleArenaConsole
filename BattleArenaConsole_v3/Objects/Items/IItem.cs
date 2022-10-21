using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items
{
	internal interface IItem
	{
		// this is an "interface", it has no code logic and only defines the basic requirements for inherited classes
		// To inherit "IItem" a class must define code for all these properties and methods
		// An Interface is basically a "rulebook" for descndent classes, 
		// this helps keep future developers disciplined and conform to a larger "architecture"
		// we'll see more of this later

		string? Name { get; set; }
		Int16 Weight { get; set; }

		[DefaultValue(0)]
		public Int32 Cost { get; set; }

		//we're not enforcing "DamageRoll" since that's only applicatble to weapons, we'll put it there
		//public string DamageRoll { get; set; }
		Int16 DefenseModifier { get; set; }

		Int16 HandsRequired { get; set; }

		string? Description { get; set;}

		//
		public void Arm() {
			//all "Items" must have a method that allows them to be "Armed"
		}
	}
}
