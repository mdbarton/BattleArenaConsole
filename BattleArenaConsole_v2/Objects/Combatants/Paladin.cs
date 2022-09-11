using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleArenaConsole_v2.Objects.Weapons;
using Display = BattleArenaConsole_v2.PresentationUtility;


namespace BattleArenaConsole_v2.Objects.Combatants
{
	internal class Paladin : Combatant
	{
		public Paladin() {
			this.Strength = 12;
			this.Dexterity = 10;
			this.Hitpoints = 20;
			this.CharacterClass = nameof(Paladin);
			this.Inventory.Add(new Sword());
		}

		public override void EndTurnActions() {
			//Paladins will regenrate a hitpoint even while in combat
			Int16 RegenerationPoints = 1;
			Hitpoints += RegenerationPoints;
			Display.DisplayText("[Paladin] has regenated " + RegenerationPoints.ToString() + " hitpoints.", ConsoleColor.DarkGreen);
			//Display.DisplayText("Base 'EndTurnActions' has executed");
		}
	}
}
