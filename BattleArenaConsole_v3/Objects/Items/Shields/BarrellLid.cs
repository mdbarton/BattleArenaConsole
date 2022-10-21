using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Shields
{
	internal class BarrellLid : Shield
	{
		//public string? Name { get; set; } = "BareelLid";
		//stuff

		public BarrellLid() {
			this.Name = nameof(BarrellLid);
			this.DefenseModifier = 4;
			this.Cost = 10;
		}
	}
}
