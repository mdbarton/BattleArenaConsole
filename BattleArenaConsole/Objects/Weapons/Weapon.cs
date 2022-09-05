using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole.Objects.Weapons
{
	internal class Weapon
	{
		public Int16 Damage;
		public Int16 Defense;
		public string Name;

		public Weapon() {
			this.Damage = 2;
			this.Defense = 2;
			this.Name = nameof(Weapon);
		}
	}
}
