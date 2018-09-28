﻿using FrEee.Game.Objects.Abilities;
using FrEee.Game.Objects.Civilization;
using FrEee.Modding.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FrEee.Modding.Loaders
{
	/// <summary>
	/// Loads race/empire traits from RacialTraits.txt.
	/// </summary>
	public class TraitLoader : DataFileLoader
	{
		public TraitLoader(string modPath)
			: base(modPath, Filename, DataFile.Load(modPath, Filename))
		{
		}

		public const string Filename = "RacialTraits.txt";

		public override IEnumerable<IModObject> Load(Mod mod)
		{
			Trait t;
			int index = -1;
			foreach (var rec in DataFile.Records)
			{
				t = new Trait();
				t.TemplateParameters = rec.Parameters;
				mod.Traits.Add(t);

				t.ModID = rec.Get<string>("ID", t);
				t.Name = rec.Get<string>("Name", t, ref index);
				t.Description = rec.Get<string>("Description", t, ref index);
				t.Cost = rec.Get<int>("Cost", t, ref index);

				for (int count = 1; ; count++)
				{
					var f = rec.FindField(new string[] { "Trait Type", "Trait Type " + count }, ref index, false, index + 1);
					if (f == null)
						break;
					var abil = new Ability(t);
					abil.Rule = Mod.Current.FindAbilityRule(f.Value);
					for (int vcount = 1; ; vcount++)
					{
						var vf = rec.FindField(new string[] { "Value", "Value " + vcount }, ref index, false, index + 1);
						if (vf == null)
							break;
						abil.Values.Add(vf.Value);
					}
					t.Abilities.Add(abil);
				}

				if (t.Abilities.Count == 0)
					Mod.Errors.Add(new DataParsingException("Trait \"" + t.Name + "\" does not have any abilities.", Mod.CurrentFileName, rec));

				yield return t;
			}

			// second pass for required/restricted traits
			foreach (var rec in DataFile.Records)
			{
				index = -1;

				t = mod.Traits.Single(t2 => t2.Name == rec.Get<string>("Name", null));

				for (int count = 1; ; count++)
				{
					var f = rec.FindField(new string[] { "Required Trait", "Required Trait " + count }, ref index, false, index + 1);
					if (f == null || f.Value == "None")
						break;
					var rt = mod.Traits.SingleOrDefault(t2 => t2.Name == f.Value);
					if (rt == null)
						Mod.Errors.Add(new DataParsingException("Required trait \"" + f.Value + "\" for trait \"" + t.Name + "\" does not exist in RacialTraits.txt.", Mod.CurrentFileName, rec));
					t.RequiredTraits.Add(rt);
				}

				for (int count = 1; ; count++)
				{
					var f = rec.FindField(new string[] { "Restricted Trait", "Restricted Trait " + count }, ref index, false, index + 1);
					if (f == null || f.Value == "None")
						break;
					var rt = mod.Traits.SingleOrDefault(t2 => t2.Name == f.Value);
					if (rt == null)
						Mod.Errors.Add(new DataParsingException("Restricted trait \"" + f.Value + "\" for trait \"" + t.Name + "\" does not exist in RacialTraits.txt.", Mod.CurrentFileName, rec));
					t.RestrictedTraits.Add(rt);
				}
			}
		}
	}
}