using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BattleArenaConsole_v3.Objects.Items;
using BattleArenaConsole_v3.Objects.Items.Shields;
using Display = BattleArenaConsole_v3.DisplayPresentation;

namespace BattleArenaConsole_v3.Objects.Combatants
{
	internal abstract class Combatant
	{
		public Int16 Strength { get; set; }
		public Int16 Dexterity { get; set; }
		public Int32 Hitpoints { get; set; }

		//Here's part of the value of inhertiance and interfaces
		//we can create a list of "Iitem"s that contains, weapons, shields. armor, etc.
		public List<IItem> Inventory { get; set; }

		//won't implement > 2 hands combatants yet but krishna may arrive in a later iteration
		public Int16 NumberOfHands { get; set; }

		public string CharacterClass { get; set; }

		public string AttackDisplayText { get; set; } = "Your opponent's "; // < this is a terrible way to handle this but we'll fix it later

		public Weapon Weapon { get { return this._weapon; } }
		private Weapon _weapon;

		public Shield Shield { get; set; }
		private Shield _shield;

		public Int32 ExperiencePoints { get { return this._experiencePoints; } }
		private Int32 _experiencePoints;

		public Int32 GoldPieces { get { return this._goldPieces; } set { this._goldPieces = value; } }
		private Int32 _goldPieces = 10;
		public Int16 Level { get { return this._level; } }
		private Int16 _level;

		public Int16 ArmorClass { get {return this._armorClass; } set {this._armorClass = value; } }
		private Int16 _armorClass;
		public Combatant()
		{
			//automatically all classes deriving from Combatant will be armed with their hands
			this._weapon = new Hands();
			this.CharacterClass = nameof(Combatant);
			this.ArmorClass = 5;

			this.Inventory = new List<IItem>(); // we could also do this as the Default value above
			this.GoldPieces = 10;
		}

		//we have several versions of the "Arm" method, they're differentiated by "Signature" the input parameter expected
		public void Arm(Weapon w)
		{
			//this method (it has no return value) sets what weapon the instantiated Combatant is using
			this._weapon = w;
		}

		public void Arm(Shield s)
		{
			this._shield = s;
			this.ArmorClass += s.DefenseModifier;
		}

		//The "signature" of this "Arm" method takes a string so we can find it in Plater's inventory
		public void Arm(string s)
		{
			try
			{
				//this isn't good as it forces the user 
				bool foundItem = false;
				foreach (var item in this.Inventory)
				{
					if (item.Name.ToLower() == s.ToLower())
					{
						//now we're checking to see if the item is derived from weapon or shield
						if (item.GetType().IsSubclassOf(typeof(Weapon)))
						{
							this.Arm((Weapon)item);
						} else if (item.GetType().IsSubclassOf(typeof(Shield)))
						{
							this.Arm((Shield)item);
						}
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
		}

		public void ListInventory()
		{
			Display.DisplayText("You have " + this.GoldPieces.ToString() + " Gold Pieces.");
			if (this.Inventory.Count > 0)
			{
				foreach (var item in this.Inventory)
				{
					Display.DisplayText("You have a " + item.Name);
				}
			}
		}

		public Int16 DefensiveCounter()
		{
			//we'll still tackle this in another iteration
			return 0;
		}

		//"virtual" keyword allows the method to be overriden in child classes, ie Paladin
		public virtual void EndTurnActions()
		{
			//by default, nothing happens, only Paladin will implement any logic for this method
		}

		public void Attack(Combatant opponent)
		{
			//we'll add more logic to this soon
			Int32 strikeChance = opponent.ArmorClass; // opponent's AC - weapon modifier
			Int32 roll = new Dice(20).Roll();
			bool strikeLands = roll > opponent.ArmorClass + opponent.Weapon.DefenseModifier;

			string r = "Roll:" + roll.ToString() + " AC:" + opponent.ArmorClass.ToString() + " mod:" + opponent.Weapon.DefenseModifier.ToString();

			if (strikeLands) {
				var damage = new Dice().Roll(this.Weapon.DamageRoll);
				Display.DisplayText(this.AttackDisplayText + this.Weapon.Name + " attack landed, causing " + damage.ToString() + " damage. (" + r + ")");
				opponent.Hitpoints -= damage;
			} else {
				Display.Write(this.AttackDisplayText + this.Weapon.Name + " strike missed. (" + r + ")");
			}
		}

		public void Defend(Combatant opponent)
		{
			// implement in future iteration
		}
	}
}
