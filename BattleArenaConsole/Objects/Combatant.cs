using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleArenaConsole.Objects.Weapons;

namespace BattleArenaConsole.Objects
{
	internal class Combatant
	{
		//
		public Int16 Strength;
		public Int16 Dexterity; //not going to use yet
		public Int32 Hitpoints;
		public Weapon weapon;

		//constructors are invoced when the "object class" is created, aka "var x = new Combatant();"
		public Combatant()
		{
			//this constructor sets all basic attributes to "10" value
			this.Strength = 10;
			this.Dexterity = 10;
			this.Hitpoints = 30;
		}

		public Combatant(Int16 strenth, Int16 dexterity, Int16 hitpoints)
		{
			//this constructor has parameters so you can set those values to anything
			this.Strength = strenth;
			this.Dexterity = dexterity;
			this.Hitpoints = hitpoints;
		}

		public void Arm(Weapon w) {
			//this method (it has no return value) sets what weapon the instantiated Combatant is using
			this.weapon = w;
		}

		public void Attack(Combatant opponent) {
			var die = new Random();
			Int32 roll = die.Next(1, 3); //just random 1-3 for now
			var playerAttack = (this.Strength + this.weapon.Damage);
			var opponentDefense = (opponent.Strength + opponent.weapon.Defense);
			var damage = Math.Max(1, (playerAttack - opponentDefense)) * roll;

			Console.WriteLine("Your " + this.weapon.Name + " attack caused " + damage.ToString() + " damage.");
			opponent.Hitpoints -= damage;
			if (opponent.Hitpoints < 1) {
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Your enemy is dead.");
			}
			else {
				Thread.Sleep(1000); //pause for 1 second then process opponent's attack
				roll = die.Next(1, 3);
				damage = Math.Max(1, (opponent.Strength + opponent.weapon.Damage) - (this.Strength + this.weapon.Defense)) * roll;
				Console.WriteLine("Your opponent's " + opponent.weapon.Name + " counter attack caused " + damage + " damage");
				this.Hitpoints -= damage;
				if (this.Hitpoints < 1) {
					Console.BackgroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("You are dead.");
				}
			}
			Console.WriteLine("You have " + this.Hitpoints + " hitpoints left.");
			Console.WriteLine("You opponent has " + opponent.Hitpoints + " hitpoints left.");
		}
	}
}
