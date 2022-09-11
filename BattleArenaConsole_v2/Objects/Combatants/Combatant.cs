using BattleArenaConsole_v2.Objects.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Display = BattleArenaConsole_v2.PresentationUtility;

namespace BattleArenaConsole_v2.Objects.Combatants
{
	internal class Combatant
	{
		//"public" is the accessibility level of the property/field, other classes will be able to see/set it
		//"Int16" is the datatype, a 16bit Integer (-x through x)
		//Strength/Dexterity is the Property Name followed by get and set "accessors"
		public Int16 Strength { get; set; }
		public Int16 Dexterity { get; set; }
		public Int32 Hitpoints { get; set; }
		//"Inventory is an array, capable of storing "an array" (multiple) of weapons - we're not using it yet
		//public Weapon[] Inventory { get; set; }
		//List<type> is similar to an array with more flexibility
		public List<Weapon> Inventory {  get; set; }

		//"string" is just text
		public string CharacterClass {  get; set; }

		public string AttackDisplayText { get; set; }

		//we only allow a get accessor, this way the combatant's weapon can only be set internally - via the Arm method
		public Weapon Weapon { get { return this._weapon; } }
		private Weapon _weapon;

		//we'll want similar for Experience Points and "Level" > we won't implement any functionality yet tho
		public Int32 ExperiencePoints { get { return this._experiencePoints; } }
		private Int32 _experiencePoints;

		public Int16 Level { get { return this._level; } }
		private Int16 _level;

		public Combatant() {
			//automatically all classes deriving from Combatant will be armed with their hands
			this._weapon = new Hands();
			this.CharacterClass = nameof(Combatant);

			this.Inventory = new List<Weapon>();
		}

		public void Arm(Weapon w)
		{
			//this method (it has no return value) sets what weapon the instantiated Combatant is using
			this._weapon = w;
		}

		//The "signature" of this "Arm" method is different than the other...
		public void Arm(string s)
		{
//			Display.DisplayText("You are trying to arm... " + s);
			try
			{
				//this isn't good as it forces the user 
				bool foundItem = false;
				foreach (var item in this.Inventory)
				{
					if (item.Name.ToLower() == s.ToLower())
					{
						this.Arm(item);
						foundItem = true;
						Display.DisplayText("You have armed your " + item.Name);
					}
				}
				if (!foundItem) Display.DisplayText("Could not arm " + s);
			}
			catch (Exception e)
			{
				Display.DisplayText("ERROR: " + e.Message.ToString());
			}
			//Weapon weapon = this.Weapon;	
		}

		public void ListInventory() {
			if (this.Inventory.Count > 0) {
				foreach (var item in this.Inventory)
				{
					Display.DisplayText("You have a " + item.Name);
				}
			}
		}

		public Int16 DefensiveCounter() {
		//Will later account for Armed Defensive Items like shields
			return 0;
		}

		//"virtual" keyword allows the method to be overriden in child classes, ie Paladin
		public virtual void EndTurnActions() {
			//by default, nothing happens, only Paladin will implement any logic for this method
			Display.DisplayText("Base 'EndTurnActions' has executed");
			//this line is only so you can see when this code fires and when the derived/inherited code does
		}

		public void Attack(Combatant opponent)
		{
			//var die = new Random();  < using "var" to instantiate a variable determined the "implied" type based on it's first use, ie "Random"
			Random die = new Random(); // < specififying the exact type for the variable is "explicit" and generally preferred for better readability
			Int32 roll = die.Next(1, 3); //just random 1-3 for now
			var playerAttack = (this.Strength + this.Weapon.Damage);
			var opponentDefense = (opponent.Strength + opponent.Weapon.Defense);
			var damage = Math.Max(1, (playerAttack - opponentDefense)) * roll;

			//"Your" "Your opponent's"
			//Console.WriteLine("Your " + this.weapon.Name + " attack caused " + damage.ToString() + " damage.");
			Display.DisplayText(this.AttackDisplayText + this.Weapon.Name + " attack caused " + damage.ToString() + " damage.");
			opponent.Hitpoints -= damage;

		}

		public void Defend(Combatant opponent) {
		}
	}
}
