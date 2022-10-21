using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Shields
{
	internal class SmallShield : Shield
	{
		public SmallShield() {
			this.Name = nameof(SmallShield);
			this.DefenseModifier = 6;
			this.Cost = 10;

		}
	}
}
