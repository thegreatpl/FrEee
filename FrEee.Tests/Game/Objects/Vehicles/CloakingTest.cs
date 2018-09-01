﻿using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Abilities;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Space;
using FrEee.Game.Objects.Vehicles;
using FrEee.Modding;
using FrEee.Utility.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace FrEee.Tests.Game.Objects.Vehicles
{
	/// <summary>
	/// Tests cloaking of vehicles.
	/// </summary>
	[TestClass]
	public class CloakingTest
	{
		/// <summary>
		/// The ship that is looking for an enemy ship.
		/// </summary>
		private static Ship destroyer;

		/// <summary>
		/// They're controlling the submarine.
		/// </summary>
		private static Empire hiders;

		/// <summary>
		/// They're controlling the destroyer.
		/// </summary>
		private static Empire seekers;

		/// <summary>
		/// The ship that is hiding.
		/// </summary>
		private static Ship submarine;

		/// <summary>
		/// Where the ships are.
		/// </summary>
		private static StarSystem sys;

		[ClassInitialize]
		public static void ClassInit(TestContext ctx)
		{
			// initialize galaxy
			new Galaxy();
			Mod.Load(null);

			// initialize empires
			seekers = new Empire();
			seekers.Name = "Seekers";
			hiders = new Empire();
			hiders.Name = "Hiders";

			// initialize ships
			Assert.IsNotNull(Mod.Current);
			var dsDesign = new Design<Ship>();
			dsDesign.BaseName = "TestDestroyer";
			dsDesign.CreateHull();
			dsDesign.Owner = seekers;
			destroyer = dsDesign.Instantiate();
			destroyer.Owner = seekers;
			var subDesign = new Design<Ship>();
			subDesign.BaseName = "TestSubmarine";
			subDesign.CreateHull();
			subDesign.Owner = hiders;
			submarine = subDesign.Instantiate();
			submarine.Owner = hiders;
		}

		/// <summary>
		/// If we have no cloaks, and they have a sensor, they should still be able to see us.
		/// </summary>
		[TestMethod]
		public void AnySensorNoCloakCanSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			Assert.IsFalse(submarine.IsHiddenFrom(seekers), "Submarine should be visible.");
		}

		/// <summary>
		/// If we have high level sight obscuration from our star system, we should be hidden.
		/// </summary>
		[TestMethod]
		public void HighLevelSectorSightObscuration()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			AddObscurationAbility(submarine.StarSystem, 2);
			Assert.IsTrue(submarine.IsHiddenFrom(seekers), "Submarine should be hidden.");
		}

		/// <summary>
		/// If we have a cloak, and they have a higher level sensor of the same type, they should be able to see us.
		/// </summary>
		[TestMethod]
		public void HighLevelSensorCanSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 2);
			AddCloakAbility(submarine.Hull, "Foobar", 1);
			Assert.IsFalse(submarine.IsHiddenFrom(seekers), "Submarine should be visible.");
		}

		[TestInitialize]
		public void Init()
		{
			// create star system
			sys = new StarSystem(0);
			Galaxy.Current.StarSystemLocations.Add(new ObjectLocation<StarSystem>(sys, new Point()));

			// place ships
			sys.Place(destroyer, new Point());
			sys.Place(submarine, new Point());
		}

		/// <summary>
		/// If we have a cloak, and they have a lower level sensor of the same type, we should be hidden.
		/// </summary>
		[TestMethod]
		public void LowLevelSensorCantSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			AddCloakAbility(submarine.Hull, "Foobar", 2);
			Assert.IsTrue(submarine.IsHiddenFrom(seekers), "Submarine should be hidden.");
		}

		/// <summary>
		/// If we have a cloak, and they have a different type of sensor that we don't have a cloak in, they should be able to see us.
		/// </summary>
		[TestMethod]
		public void MismatchedSensorTypeCanSee()
		{
			AddSensorAbility(destroyer.Hull, "Narf", 1);
			AddCloakAbility(submarine.Hull, "Foobar", 999);
			Assert.IsFalse(submarine.IsHiddenFrom(seekers), "Submarine should be visible.");
		}

		/// <summary>
		/// If everyone is in a nebula with a system cloaking ability, the enemy ship should be hidden.
		/// </summary>
		[TestMethod]
		public void NebulaCantSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			sys.Abilities.Add(new Ability(sys, Mod.Current.AbilityRules.FindByName("System - Sight Obscuration"), null, 999));
			Assert.IsTrue(submarine.IsHiddenFrom(seekers), "Submarine should be hidden.");
		}

		/// <summary>
		/// If we have a cloak, and they have no sensors, they should not be able to see us.
		/// </summary>
		[TestMethod]
		public void NoSensorAnyCloakCantSee()
		{
			AddCloakAbility(submarine.Hull, "Foobar", 1);
			Assert.IsTrue(submarine.IsHiddenFrom(seekers), "Submarine should be hidden.");
		}

		/// <summary>
		/// If we have no cloaks, and they have no sensors, they should still be able to see us.
		/// </summary>
		[TestMethod]
		public void NoSensorNoCloakCanSee()
		{
			// by default the ships will have no abilities, so let's just test
			Assert.IsFalse(submarine.IsHiddenFrom(seekers), "Submarine should be visible.");
		}

		/// <summary>
		/// If we have a cloak, and they have the same level sensor of the same type, they should be able to see us.
		/// </summary>
		[TestMethod]
		public void SameLevelSensorCanSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			AddCloakAbility(submarine.Hull, "Foobar", 1);
			Assert.IsFalse(submarine.IsHiddenFrom(seekers), "Submarine should be visible.");
		}

		/// <summary>
		/// If the enemy is in a storm with a sector cloaking ability, the enemy ship should be hidden.
		/// </summary>
		[TestMethod]
		public void StormCantSee()
		{
			AddSensorAbility(destroyer.Hull, "Foobar", 1);
			var storm = new Storm();
			storm.Abilities.Add(new Ability(sys, Mod.Current.AbilityRules.FindByName("Sector - Sight Obscuration"), null, 999));
			sys.Place(storm, new Point());
			Assert.IsTrue(submarine.IsHiddenFrom(seekers), "Submarine should be hidden.");
		}

		// TODO - same/low level sight obscuration from star system

		// TODO - sight obscuration from sector

		private void AddCloakAbility(IHull hull, string sightType, int level)
		{
			var a = new Ability(hull);
			hull.Abilities.Add(a);
			a.Rule = Mod.Current.AbilityRules.FindByName("Cloak Level");
			a.Values.Add(sightType);
			a.Values.Add(level.ToString());
		}

		private void AddObscurationAbility(IAbilityContainer obj, int level)
		{
			var a = new Ability(obj);
			obj.Abilities.Add(a);
			a.Rule = Mod.Current.AbilityRules.FindByName("Sector - Sight Obscuration");
			a.Values.Add(level.ToString());
		}

		private void AddSensorAbility(IHull hull, string sightType, int level)
		{
			var a = new Ability(hull);
			hull.Abilities.Add(a);
			a.Rule = Mod.Current.AbilityRules.FindByName("Sensor Level");
			a.Values.Add(sightType);
			a.Values.Add(level.ToString());
		}
	}
}