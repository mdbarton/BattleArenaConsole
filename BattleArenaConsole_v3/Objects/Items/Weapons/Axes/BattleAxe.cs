using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Weapons//.Axes
{
	internal class BattleAxe : Axe
	{
		public BattleAxe() {
			this.Name = nameof(BattleAxe);
			this.DamageRoll = "1d12";
			this.HandsRequired = 2;
			this.Cost = 20;

		}

	}
}
