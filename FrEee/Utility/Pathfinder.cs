﻿using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Space;
using FrEee.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FrEee.Utility
{
	/// <summary>
	/// Finds paths avoiding obstacles.
	/// Adapted from http://roguebasin.roguelikedevelopment.org/index.php?title=Pathfinding
	/// </summary>
	public static class Pathfinder
	{
		/// <summary>
		/// Navigation for space objects.
		/// </summary>
		/// <param name="me"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="avoidEnemies"></param>
		/// <returns></returns>
		public static IEnumerable<Sector> Pathfind(IMobileSpaceObject me, Sector start, Sector end, bool avoidEnemies, bool avoidDamagingSectors)
		{
			if (end == null)
				throw new Exception("Cannot pathfind to a null sector.");
			if (end.StarSystem == null)
				throw new Exception("Cannot pathfind to a sector without a star system.");

			if (start == end)
				return Enumerable.Empty<Sector>();

			var map = CreateDijkstraMap(me, start, end, avoidEnemies, avoidDamagingSectors);

			if (!map.Any())
				return Enumerable.Empty<Sector>(); // nowhere to go!

			if (map.Any(n => n.Location == end))
			{
				// can reach it
				var nodes = new List<Node<Sector>>();
				var node = map.Where(n => n.Location == end).OrderBy(n => n.Cost).First();
				while (node != null)
				{
					nodes.Add(node);
					node = node.PreviousNode;
				}
				return nodes.Select(n => n.Location).Where(s => s != start).Reverse();
			}
			else
			{
				// can't reach it; get as close as possible
				var reverseMap = CreateDijkstraMap(null, end, start, false, avoidDamagingSectors);
				var target = reverseMap.Join(map, rev => rev.Location, fwd => fwd.Location, (rev, fwd) => new { Location = rev.Location, ForwardCost = fwd.Cost, ReverseCost = rev.Cost }).WithMin(n => n.ReverseCost).WithMin(n => n.ForwardCost).FirstOrDefault();
				if (target == null)
					return Enumerable.Empty<Sector>(); // can't go anywhere
				else
				{
					// go to the closest point
					var nodes = new List<Node<Sector>>();
					var node = map.Where(n => n.Location == target.Location).OrderBy(n => n.Cost).First();
					while (node != null)
					{
						nodes.Add(node);
						node = node.PreviousNode;
					}
					return nodes.Select(n => n.Location).Where(s => s != start).Reverse();
				}
			}
		}

		public static IEnumerable<Node<Sector>> CreateDijkstraMap(IMobileSpaceObject me, Sector start, Sector end, bool avoidEnemies, bool avoidDamagingSectors)
		{
			var startSys = start.StarSystem;

			// pathfind!
			// step 1: empty priority queue with cost to reach each node
			var queue = new List<Node<Sector>>();

			// step 2: empty set of previously visited nodes, along with costs and previous-node references
			var visited = new List<Node<Sector>>();

			// step 3: add start node and cost
			queue.Add(new Node<Sector>(start, 0, null, EstimateDistance(start, end)));

			// step 4: quit if there are no nodes (all paths exhausted without finding goal)
			bool success = false;
			while (queue.Any() && !success)
			{
				// step 5: take lowest cost node out of queue
				// also prefer straight line movement to diagonal
				var minCost = queue.Min(n => n.Cost);
				var node = queue.Where(n => n.Cost == minCost).First();
				queue.Remove(node);

				// step 6: if node is the goal, stop - success!
				if (node.Location == end)
					success = true;

				// step 7: check possible moves
				var moves = GetPossibleMoves(node.Location, me == null ? true : me.CanWarp);

				// step 7a: remove blocked points (aka calculate cost)
				if (avoidEnemies)
					// avoid enemies, even if they are at the destination; wait for them to leave before entering (unlike SE4)
					moves = moves.Where(m => m == null || !m.SpaceObjects.Any(sobj => sobj.IsHostileTo(me == null ? null : me.Owner))).ToList();
				if (avoidDamagingSectors)
					// don't avoid the destination, even if it is a damaging sector
					moves = moves.Where(m => m == end || m == null || !m.SpaceObjects.Any(sobj => sobj.GetAbilityValue("Sector - Damage").ToInt() > 0)).ToList();

				// step 7b: update priority queue
				foreach (var move in moves)
				{
					if (!visited.Any(n => n.Location == move))
					{
						// didn't visit yet
						var newnode = new Node<Sector>(move, node.Cost + 1, node, EstimateDistance(move, end));
						queue.Add(newnode);
						visited.Add(newnode);
					}
					else
					{
						// already visited - but is it by a longer path?
						var items = queue.Where(n => n.Location == move && n.Cost > node.Cost + 1);
						if (items.Any())
						{
							foreach (var old in items.ToArray())
								queue.Remove(old);
							var newnode = new Node<Sector>(move, node.Cost + 1, node);
							queue.Add(newnode);
							visited.Add(newnode);
						}
					}
				}
			}

			return visited;
		}

		/// <summary>
		/// Makes a minimum estimate of the distance to reach a sector.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static int EstimateDistance(Sector start, Sector end)
		{
			int sublightDistance = int.MaxValue;
			int ftlDistance = int.MaxValue;

			// same system? just go along grid, ignoring obstacles
			if (start != null && end != null && start.StarSystem == end.StarSystem)
				sublightDistance = start.Coordinates.EightWayDistance(end.Coordinates);

			// different system? find nearest warp point in each system, and assume they are connected to each other ("warp nexus")
			var wps1 = FindNearestWarpPointSectorInSystem(start);
			var wps2 = FindNearestWarpPointSectorInSystem(end);
			if (wps1 != null && wps2 != null)
				ftlDistance = start.Coordinates.EightWayDistance(wps1.Coordinates) + end.Coordinates.EightWayDistance(wps2.Coordinates) + 1;

			// sector is null? then it must be the target of an unexplored warp point
			if (wps1 != null && end == null)
				ftlDistance = start.Coordinates.EightWayDistance(wps1.Coordinates) + 1;
			if (start == null && wps2 != null)
				ftlDistance = end.Coordinates.EightWayDistance(wps2.Coordinates) + 1;
			if (start == null && end == null)
				ftlDistance = 0;

			return Math.Min(sublightDistance, ftlDistance);
		}

		public static Sector FindNearestWarpPointSectorInSystem(Sector sector)
		{
			if (sector == null || sector.StarSystem == null)
				return null;
			return sector.StarSystem.FindSpaceObjects<WarpPoint>().Flatten().Select(wp => wp.FindSector()).WithMin(s => sector.Coordinates.EightWayDistance(s.Coordinates)).PickRandom();
		}

		public static IEnumerable<Sector> GetPossibleMoves(Sector s, bool canWarp)
		{
			var moves = new List<Sector>();
			var sys = s.StarSystem;

			// normal moves
			if (sys != null)
			{
				foreach (var dx in new int[] { 0, -1, 1 })
				{
					foreach (var dy in new int[] { 0, -1, 1 })
					{
						if (dx == 0 && dy == 0)
							continue; // no need to sit still!
						var coords = s.Coordinates;
						if (Math.Abs(coords.X + dx) <= sys.Radius && Math.Abs(coords.Y + dy) <= sys.Radius)
							moves.Add(sys.GetSector(new Point(coords.X + dx, coords.Y + dy)));
					}
				}
			}

			if (canWarp)
			{
				// warp points
				foreach (var wp in s.SpaceObjects.OfType<WarpPoint>())
					moves.Add(wp.Target);
			}

			return moves;
		}

		/// <summary>
		/// Navigation via warp points with each jump counting as 1 move.
		/// </summary>
		/// <param name="me"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="avoidEnemies"></param>
		/// <returns></returns>
		public static IEnumerable<StarSystem> Pathfind(StarSystem start, StarSystem end)
		{
			if (start == end)
				return Enumerable.Empty<StarSystem>();

			var map = CreateDijkstraMap(start, end);

			if (!map.Any())
				return Enumerable.Empty<StarSystem>(); // can't go there

			if (map.Any(n => n.Location == end))
			{
				// can reach it
				var nodes = new List<Node<StarSystem>>();
				var node = map.Where(n => n.Location == end).OrderBy(n => n.Cost).First();
				while (node != null)
				{
					nodes.Add(node);
					node = node.PreviousNode;
				}
				return nodes.Select(n => n.Location).Where(s => s != start).Reverse();
			}
			else
			{
				// can't reach it; get as close as possible
				var reverseMap = CreateDijkstraMap(end, start);
				var target = reverseMap.Join(map, rev => rev.Location, fwd => fwd.Location, (rev, fwd) => new { Location = rev.Location, ForwardCost = fwd.Cost, ReverseCost = rev.Cost }).WithMin(n => n.ReverseCost).WithMin(n => n.ForwardCost).FirstOrDefault();
				if (target == null)
					return Enumerable.Empty<StarSystem>(); // can't go there
				else
				{
					// go to the closest point
					var nodes = new List<Node<StarSystem>>();
					var node = map.Where(n => n.Location == target.Location).OrderBy(n => n.Cost).First();
					while (node != null)
					{
						nodes.Add(node);
						node = node.PreviousNode;
					}
					return nodes.Select(n => n.Location).Where(s => s != start).Reverse();
				}
			}
		}

		public static IEnumerable<Node<StarSystem>> CreateDijkstraMap(StarSystem start, StarSystem end)
		{
			// pathfind!
			// step 1: empty priority queue with cost to reach each node
			var queue = new List<Node<StarSystem>>();

			// step 2: empty set of previously visited nodes, along with costs and previous-node references
			var visited = new List<Node<StarSystem>>();

			// step 3: add start node and cost
			queue.Add(new Node<StarSystem>(start, 0, null));

			// step 4: quit if there are no nodes (all paths exhausted without finding goal)
			bool success = false;
			while (queue.Any() && !success)
			{
				// step 5: take lowest cost node out of queue
				// also prefer straight line movement to diagonal
				var minCost = queue.Min(n => n.Cost);
				var node = queue.Where(n => n.Cost == minCost).OrderBy(n => n.MinimumCostRemaining).First();
				queue.Remove(node);

				// step 6: if node is the goal, stop - success!
				if (node.Location == end)
					success = true;

				// step 7: check possible moves
				var moves = node.Location.FindSpaceObjects<WarpPoint>().Flatten().Select(wp => wp.TargetStarSystemLocation.Item);

				// step 7a: remove blocked points (aka calculate cost)
				// nothing to do here

				// step 7b: update priority queue
				foreach (var move in moves)
				{
					if (!visited.Any(n => n.Location == move))
					{
						// didn't visit yet
						var newnode = new Node<StarSystem>(move, node.Cost + 1, node);
						queue.Add(newnode);
						visited.Add(newnode);
					}
					else
					{
						// already visited - but is it by a longer path?
						var items = queue.Where(n => n.Location == move && n.Cost > node.Cost + 1);
						if (items.Any())
						{
							foreach (var old in items.ToArray())
								queue.Remove(old);
							var newnode = new Node<StarSystem>(move, node.Cost + 1, node);
							queue.Add(newnode);
							visited.Add(newnode);
						}
					}
				}
			}

			return visited;
		}

		/// <summary>
		/// Navigation on an arbitrary connectivity graph.
		/// </summary>
		/// <param name="me"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="avoidEnemies"></param>
		/// <returns></returns>
		public static IEnumerable<T> Pathfind<T>(T start, T end, ConnectivityGraph<T> graph)
		{
			if (start.Equals(end))
				return Enumerable.Empty<T>();

			var map = CreateDijkstraMap(start, end, graph);

			if (!map.Any())
				return Enumerable.Empty<T>(); // can't go there

			if (map.Any(n => n.Location.Equals(end)))
			{
				// can reach it
				var nodes = new List<Node<T>>();
				var node = map.Where(n => n.Location.Equals(end)).OrderBy(n => n.Cost).First();
				while (node != null)
				{
					nodes.Add(node);
					node = node.PreviousNode;
				}
				return nodes.Select(n => n.Location).Where(s => !s.Equals(start)).Reverse();
			}
			else
			{
				// can't reach it; get as close as possible
				var reverseMap = CreateDijkstraMap(end, start, graph);
				var target = reverseMap.Join(map, rev => rev.Location, fwd => fwd.Location, (rev, fwd) => new { Location = rev.Location, ForwardCost = fwd.Cost, ReverseCost = rev.Cost }).WithMin(n => n.ReverseCost).WithMin(n => n.ForwardCost).FirstOrDefault();
				if (target == null)
					return Enumerable.Empty<T>(); // can't go there
				else
				{
					// go to the closest point
					var nodes = new List<Node<T>>();
					var node = map.Where(n => n.Location.Equals(target.Location)).OrderBy(n => n.Cost).First();
					while (node != null)
					{
						nodes.Add(node);
						node = node.PreviousNode;
					}
					return nodes.Select(n => n.Location).Where(s => !s.Equals(start)).Reverse();
				}
			}
		}

		public static IEnumerable<Node<T>> CreateDijkstraMap<T>(T start, T end, ConnectivityGraph<T> graph)
		{
			// pathfind!
			// step 1: empty priority queue with cost to reach each node
			var queue = new List<Node<T>>();

			// step 2: empty set of previously visited nodes, along with costs and previous-node references
			var visited = new List<Node<T>>();

			// step 3: add start node and cost
			queue.Add(new Node<T>(start, 0, null));

			// step 4: quit if there are no nodes (all paths exhausted without finding goal)
			bool success = false;
			while (queue.Any() && !success)
			{
				// step 5: take lowest cost node out of queue
				// also prefer straight line movement to diagonal
				var minCost = queue.Min(n => n.Cost);
				var node = queue.Where(n => n.Cost == minCost).First();
				queue.Remove(node);

				// step 6: if node is the goal, stop - success!
				if (node.Location.Equals(end))
					success = true;

				// step 7: check possible moves
				var moves = graph.GetExits(node.Location);

				// step 7a: remove blocked points (aka calculate cost)
				// nothing to do here

				// step 7b: update priority queue
				foreach (var move in moves)
				{
					if (!visited.Any(n => n.Location.Equals(move)))
					{
						// didn't visit yet
						var newnode = new Node<T>(move, node.Cost + 1, node);
						queue.Add(newnode);
						visited.Add(newnode);
					}
					else
					{
						// already visited - but is it by a longer path?
						var items = queue.Where(n => n.Location.Equals(move) && n.Cost > node.Cost + 1);
						if (items.Any())
						{
							foreach (var old in items.ToArray())
								queue.Remove(old);
							var newnode = new Node<T>(move, node.Cost + 1, node);
							queue.Add(newnode);
							visited.Add(newnode);
						}
					}
				}
			}

			return visited;
		}

		public class Node<T>
		{
			public Node(T location, int cost, Node<T> previousNode, int minRemaining = 0)
			{
				Location = location;
				Cost = cost;
				PreviousNode = previousNode;
				MinimumCostRemaining = minRemaining;
			}

			/// <summary>
			/// The current location.
			/// </summary>
			public T Location { get; set; }

			/// <summary>
			/// The cost to reach this node from the start node.
			/// </summary>
			public int Cost { get; set; }

			/// <summary>
			/// A minimum estimate on the remaining cost to reach the destination.
			/// This must never be an overestimate, or the pathfinding might fail even when it is possible to reach the destination!
			/// </summary>
			public int MinimumCostRemaining { get; set; }

			/// <summary>
			/// The previous node in the current path.
			/// </summary>
			public Node<T> PreviousNode { get; set; }

			public override string ToString()
			{
				return "From " + PreviousNode.Location + " to " + Location + " (cost=" + Cost + ", minRemaining=" + MinimumCostRemaining + ")";
			}
		}
	}
}
