﻿using FrEee.Game.Objects.Space;
using FrEee.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrEee.Game.Interfaces
{
	/// <summary>
	/// An object that can move about in space.
	/// </summary>
	public interface IMobileSpaceObject : ICombatSpaceObject, IOrderable, IContainable<Fleet>
	{
		double TimeToNextMove { get; set; }
		double TimePerMove { get; }
		int MovementRemaining { get; set; }
		int Speed { get; }
		int SupplyRemaining { get; set; }
		void SpendTime(double timeElapsed);
		new Sector Sector { get; set; }

		void AddOrder(IOrder order);

		/// <summary>
		/// The tonnage of the object, in kT, or null if it's a planet.
		/// </summary>
		int? Size { get; }

		/// <summary>
		/// The Dijkstra map used for pathfinding.
		/// </summary>
		IDictionary<PathfinderNode<Sector>, ISet<PathfinderNode<Sector>>> DijkstraMap { get; set; }
	}

	public interface IMobileSpaceObject<T> : IMobileSpaceObject where T : IMobileSpaceObject<T>
	{
		IList<IOrder<T>> Orders { get; }
	}
}