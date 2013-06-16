﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FrEee.Game;
using System.Drawing;
using FrEee.Game.Objects.Abilities;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Technology;
using FrEee.Game.Objects.Space;
using FrEee.Modding.Loaders;
using FrEee.Modding.Templates;
using FrEee.Utility;
using FrEee.Game.Interfaces;

namespace FrEee.Modding
{
	/// <summary>
	/// A set of data files containing templates for game objects.
	/// </summary>
	[Serializable]
	public class Mod
	{
		/// <summary>
		/// The currently loaded mod.
		/// </summary>
		public static Mod Current { get; set; }

		/// <summary>
		/// The file name being loaded. (For error reporting)
		/// </summary>
		public static string CurrentFileName { get; private set; }

		/// <summary>
		/// Loads a mod.
		/// </summary>
		/// <param name="path">The mod root path, relative to the Mods folder. Or null to load the stock mod.</param>
		/// <param name="setCurrent">Set the current mod to the new mod?</param>
		/// <param name="status">A status object to report status back to the GUI.</param>
		/// <param name="desiredProgress">How much progress should we report back to the GUI when we're done loading the mod? 1.0 means all done with everything that needs to be done.</param>
		public static Mod Load(string path, bool setCurrent = true, Status status = null, double desiredProgress = 1.0)
		{
			var mod = new Mod();
			mod.RootPath = path;

			if (setCurrent)
				Current = mod;

			// TODO - change the number at the end to match whatever number of data files we have
			// TODO - just have a list of ILoader objects
			var progressPerFile = (desiredProgress - (status == null ? 0 : status.Progress)) / 14;

			var datapath = path == null ? "Data" : Path.Combine("Mods", path, "Data");

			// TODO - fall back on stock when mod data not found

			if (status != null)
				status.Message = "Loading SystemNames.txt";
			foreach (var line in File.ReadAllLines(Path.Combine(datapath, "SystemNames.txt")))
				mod.StarSystemNames.Add(line);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading AbilityRules.txt";
			CurrentFileName = Path.Combine(datapath, "AbilityRules.txt");
			new AbilityRuleLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading PlanetSize.txt";
			CurrentFileName = Path.Combine(datapath, "PlanetSize.txt");
			new StellarObjectSizeLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading SectType.txt";
			CurrentFileName = Path.Combine(datapath, "SectType.txt");
			new StellarObjectLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading RacialTraits.txt";
			CurrentFileName = Path.Combine(datapath, "RacialTraits.txt");
			new TraitLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading TechArea.txt";
			CurrentFileName = Path.Combine(datapath, "TechArea.txt");
			new TechnologyLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading Facility.txt";
			CurrentFileName = Path.Combine(datapath, "Facility.txt");
			new FacilityLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading VehicleSize.txt";
			CurrentFileName = Path.Combine(datapath, "VehicleSize.txt");
			new HullLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading Components.txt";
			CurrentFileName = Path.Combine(datapath, "Components.txt");
			new ComponentLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading CompEnhancement.txt";
			CurrentFileName = Path.Combine(datapath, "CompEnhancement.txt");
			new MountLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading StellarAbilityTypes.txt";
			CurrentFileName = Path.Combine(datapath, "StellarAbilityTypes.txt");
			new StellarAbilityLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading SystemTypes.txt";
			CurrentFileName = Path.Combine(datapath, "SystemTypes.txt");
			new StarSystemLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading QuadrantTypes.txt";
			CurrentFileName = Path.Combine(datapath, "QuadrantTypes.txt");
			new GalaxyLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			if (status != null)
				status.Message = "Loading Happiness.txt";
			CurrentFileName = Path.Combine(datapath, "Happiness.txt");
			new HappinessModelLoader(new DataFile(File.ReadAllText(CurrentFileName))).Load(mod);
			if (status != null)
				status.Progress += progressPerFile;

			CurrentFileName = null;

			// TODO - display errors to user
			/*foreach (var err in Mod.Errors)
				Console.WriteLine(err.Message);*/

			return mod;
		}

		public Mod()
		{
			Errors = new List<DataParsingException>();
			DefaultColonyConstructionRate = new Resources();
			// TODO - moddable default colony construction rate
			DefaultColonyConstructionRate.Add(Resource.Minerals, 2000);
			DefaultColonyConstructionRate.Add(Resource.Organics, 2000);
			DefaultColonyConstructionRate.Add(Resource.Radioactives, 2000);
			PopulationFactor = (long)1e6; // TODO - let population factor be specified by mod files
			AbilityRules = new List<AbilityRule>();
			StarSystemNames = new List<string>();
			Traits = new List<Trait>();
			Technologies = new List<Technology>();
			FacilityTemplates = new List<FacilityTemplate>();
			Hulls = new List<IHull<IVehicle>>();
			ComponentTemplates = new List<ComponentTemplate>();
			Mounts = new List<Mount>();
			StellarObjectSizes = new List<StellarObjectSize>();
			StarSystemTemplates = new List<StarSystemTemplate>();
			StellarAbilityTemplates = new List<RandomAbilityTemplate>();
			GalaxyTemplates = new List<GalaxyTemplate>();
			StellarObjectTemplates = new List<StellarObject>();
			HappinessModels = new List<HappinessModel>();
		}

		/// <summary>
		/// How many people does 1 population represent in the mod files?
		/// </summary>
		public long PopulationFactor { get; set; }

		/// <summary>
		/// The path to the mod's root folder, relative to the Mods folder.
		/// </summary>
		public string RootPath { get; set; }

		/// <summary>
		/// The construction rate for colonies lacking a spaceyard.
		/// </summary>
		public Resources DefaultColonyConstructionRate { get; set; }

		/// <summary>
		/// Rules for grouping and stacking abilities.
		/// </summary>
		public ICollection<AbilityRule> AbilityRules { get; private set; }

		/// <summary>
		/// Names to use for star systems.
		/// </summary>
		public ICollection<string> StarSystemNames { get; private set; }

		/// <summary>
		/// Planet and asteroid field sizes.
		/// </summary>
		public ICollection<StellarObjectSize> StellarObjectSizes { get; private set; }

		/// <summary>
		/// Templates for star systems.
		/// </summary>
		public ICollection<StarSystemTemplate> StarSystemTemplates { get; private set; }

		/// <summary>
		/// The facilities in the mod.
		/// </summary>
		public ICollection<FacilityTemplate> FacilityTemplates { get; private set; }

		/// <summary>
		/// The vehicle hulls in the mod.
		/// </summary>
		public ICollection<IHull<IVehicle>> Hulls { get; private set; }

		/// <summary>
		/// The components in the mod.
		/// </summary>
		public ICollection<ComponentTemplate> ComponentTemplates { get; private set; }

		/// <summary>
		/// The component mounts in the mod.
		/// </summary>
		public ICollection<Mount> Mounts { get; private set; }

		/// <summary>
		/// Templates for stellar abilities.
		/// </summary>
		public ICollection<RandomAbilityTemplate> StellarAbilityTemplates { get; private set; }

		/// <summary>
		/// Templates for galaxies.
		/// </summary>
		public ICollection<GalaxyTemplate> GalaxyTemplates { get; private set; }

		/// <summary>
		/// Templates for stellar objects.
		/// </summary>
		public ICollection<StellarObject> StellarObjectTemplates { get; private set; }

		/// <summary>
		/// The technologies in the game.
		/// </summary>
		public ICollection<Technology> Technologies { get; private set; }

		/// <summary>
		/// The happiness models in the game.
		/// </summary>
		public ICollection<HappinessModel> HappinessModels { get; private set; }

		/// <summary>
		/// The race/empire traits in the game.
		/// </summary>
		public ICollection<Trait> Traits { get; private set; }

		/// <summary>
		/// Errors encountered when loading the mod.
		/// </summary>
		public static IList<DataParsingException> Errors { get; private set; }
	}
}
