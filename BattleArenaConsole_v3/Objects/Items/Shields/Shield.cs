using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArenaConsole_v3.Objects.Items.Shields
{
	internal abstract class Shield : IItem
	{
		public string? Name { get; set; }
		public Int16 Weight { get; set; }
		[DefaultValue(5)]
		public Int32 Cost { get; set; }
		[DefaultValue(1)]
		public Int16 HandsRequired { get; set; }
		[DefaultValue(2)]
		public Int16 DefenseModifier { get; set; }
		public string? Description { get; set; }


	}
}
