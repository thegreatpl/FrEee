﻿using FrEee.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrEee.Game.Objects.Abilities;

namespace FrEee.Modding.Loaders
{
	/// <summary>
	/// Loads ability rules from AbilityRules.txt.
	/// </summary>
	 [Serializable] public class AbilityRuleLoader : DataFileLoader
	{
		 public AbilityRuleLoader(DataFile df)
			 : base(df)
		 {
		 }

		public override void Load(Mod mod)
		{
			foreach (var rec in DataFile.Records)
			{
				var r = new AbilityRule();
				mod.AbilityRules.Add(r);

				int index = -1;

				r.Name = rec.GetString("Name", ref index, true, 0, true);
				r.GroupingRule = rec.GetEnum<AbilityGroupingRule>("Grouping Rule", ref index, true, 0, true);
				for (int i = 1; i <= 2; i++)
				{
					var f = rec.FindField("Value " + i + " Stacking Rule", ref index, false, 0, true);
					if (f == null)
						r.StackingRules.Add(AbilityValueStackingRule.DoNotStack);
					else
						r.StackingRules.Add(f.EnumValue<AbilityValueStackingRule>(rec));
				}
				int j = 3;
				while (true)
				{
					var f = rec.FindField("Value " + j + " Stacking Rule", ref index, false, 0, true);
					if (f == null)
						break;
					else
						r.StackingRules.Add(f.EnumValue<AbilityValueStackingRule>(rec));
				}
			}
		}
	}
}
