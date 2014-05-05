﻿using FixMath.NET;
using FrEee.Game.Interfaces;
using NewtMath.f16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrEee.Game.Objects.Combat2
{
	/// <summary>
	/// A combat object which can be controlled by an empire.
	/// </summary>
	public abstract class CombatControlledObject : CombatObject
	{
		protected CombatControlledObject(ICombatant start, ICombatant working, PointXd position, PointXd vector, int battleseed, string IDprefix)
			: base(working, position, vector, start.ID, IDprefix)
		{
			//StartCombatant = working; wtf?
            StartCombatant = start;
            WorkingCombatant = working;
			newDice(battleseed);
			RefreshWeapons();
		}

		/// <summary>
		/// The object's state at the start of combat.
		/// </summary>
		public ICombatant StartCombatant { get; protected set; }

		/// <summary>
		/// Weapons equipped by this combatant.
		/// </summary>
		public IEnumerable<CombatWeapon> Weapons { get; protected set; }

		/// <summary>
		/// The current state of the object.
		/// </summary>
		public ICombatant WorkingCombatant { get { return (ICombatant)WorkingObject; } private set { WorkingObject = value; } }

		/// <summary>
		/// endgoal for helm is for the  ship to get to and match speed with the comObj.targetWaypiont as fast as possible.
		/// the strategic AI script should be responsible for setting where the waypoint is and where thet waypoint is going. 
		/// </summary>
		/// <param name="comObj"></param>
		public override void helm()
		{
			this.debuginfo += "HelmInfo:" + "\r\n";
			var ship = this.WorkingCombatant;
			string name = ship.Name;
			//rotate ship
			Fix16 timetoturn = (Fix16)0;
			//Compass angletoturn = new Compass(Trig.angleto(comObj.cmbt_face, comObj.waypointTarget.cmbt_loc));
			combatWaypoint wpt = this.waypointTarget;
			Compass angletoWaypoint = new Compass(this.cmbt_loc, this.waypointTarget.cmbt_loc); //relitive to me. 
			Compass angletoturn = new Compass(angletoWaypoint.Radians - this.cmbt_head.Radians);
			PointXd vectortowaypoint = this.cmbt_loc - this.waypointTarget.cmbt_loc;
			//if (comObj.lastVectortoWaypoint != null)
			//    angletoturn.Radians = Trig.angleA(vectortowaypoint - comObj.lastVectortoWaypoint);

			timetoturn = angletoturn.Radians / this.maxRotate.Radians;
			Fix16 oneEightytime = Fix16.Pi / this.maxRotate.Radians;
			//PointXd offsetVector = comObj.waypointTarget.cmbt_vel - comObj.cmbt_vel; // O = a - b
			//PointXd combinedVelocity = comObj.cmbt_vel - comObj.waypointTarget.cmbt_vel;
			//PointXd distancePnt = comObj.waypointTarget.cmbt_loc - comObj.cmbt_loc;
			//double closingSpeed = Trig.dotProduct(combinedVelocity, distancePnt);
			Fix16 closingSpeed = NMath.closingRate(this.cmbt_loc, this.cmbt_vel, this.waypointTarget.cmbt_loc, this.waypointTarget.cmbt_vel);

			Fix16 myspeed = Trig.hypotinuse(this.cmbt_vel);

			Fix16 timetokill_ClosingSpeed = closingSpeed / (this.maxfowardThrust / this.cmbt_mass); //t = v / a
			Fix16 strafetimetokill_ClosingSpeed = closingSpeed / (this.maxStrafeThrust / this.cmbt_mass);
			Fix16 timetokill_MySpeed = myspeed / (this.maxfowardThrust / this.cmbt_mass);

			Fix16 distance = vectortowaypoint.Length;


			Fix16 nominaldistance = this.maxStrafeThrust;
			Fix16 timetowpt = distance / closingSpeed;

			bool? thrustToWaypoint = true;
			string helmdo = "";

			if (closingSpeed > (Fix16)0) //getting closer?
			{
				if (distance <= nominaldistance)  // close to the waypoint (within strafe thrust range)
				{
					thrustToWaypoint = null; // should attempt to match speed using strafe thrust
				}
				if (timetowpt <= timetokill_ClosingSpeed + oneEightytime) // if/when we're going to overshoot the waypoint.
				{
					if (timetowpt < strafetimetokill_ClosingSpeed) //if time to waypoint is less than time to kill speed with strafe thrusters
					{
						thrustToWaypoint = false; // thrust AWAY from the waypoint! slow down!
					}
					else
					{
						helmdo = "null" + "\r\n";
						thrustToWaypoint = null; // driiift! iiiin! spaaaace! should use only strafe thrust to match speed
					}
				}
			}
			else
			{
				// getting farther away or maintaining distance, just thrust toward the target
			}

			if (thrustToWaypoint == false)
			{
				helmdo = "Initiating Turnaround" + "\r\n"; //turn around and thrust the other way
				angletoturn.Degrees = (angletoWaypoint.Degrees - (Fix16)180) - this.cmbt_head.Degrees; //turn around and thrust the other way
				angletoturn.normalize();
			}
			else if (thrustToWaypoint == null)
			{
				angletoturn.Radians = Trig.angleA(this.waypointTarget.cmbt_vel);
			}

			this.debuginfo += "timetowpt:\t" + timetowpt.ToString() + "\r\n";
			this.debuginfo += "strafetime:\t" + strafetimetokill_ClosingSpeed.ToString() + "\r\n";
			this.debuginfo += "speedkilltime:\t" + timetokill_ClosingSpeed.ToString() + "\r\n";
			this.debuginfo += "180time:\t" + oneEightytime.ToString() + "\r\n";
			this.debuginfo += "ThrustTo:\t" + thrustToWaypoint.ToString() + "\r\n";
			this.debuginfo += helmdo + "\r\n";

			turnship(angletoturn, angletoWaypoint);

			thrustship(angletoturn, thrustToWaypoint);

			this.lastVectortoWaypoint = vectortowaypoint;
		}

		/// <summary>
		/// Refreshes the list of available weapons that this combat object can fire.
		/// </summary>
		protected abstract void RefreshWeapons();

        /// <summary>
        /// attempt to move firecontrol to the combatObject
        /// </summary>
        /// <param name="tic_countr"></param>
        /// <param name="IsReplay"></param>
        /// <param name="ReplayLog"></param>
        /*
        public override void firecontrol(int tic_countr, bool IsReplay, CombatReplayLog ReplayLog)
        {
            //is a ship, base, unit, or planet
            //ControlledCombatObject ccobj = (ControlledCombatObject)comObj;
            foreach (var wpn in Weapons)
            {
                ICombatant ship = (ICombatant)WorkingObject;

                if (weaponTarget.Count() > 0 && //if there ARE targets
                    wpn.CanTarget(weaponTarget[0].WorkingObject) && //if we CAN target 
                    tic_countr >= wpn.nextReload) //if the weapon is ready to fire.
                {
                    if (wpn.isinRange(this, weaponTarget[0]))
                    {
                        //this function figures out if there's a hit, deals the damage, and creates an event.

                        //first create the event for the target ship
                        CombatTakeFireEvent targets_event = FireWeapon(tic_countr, this, wpn, weaponTarget[0]);
                        //then create teh event for this ship firing on the target
                        CombatFireOnTargetEvent attack_event = new CombatFireOnTargetEvent(tic_countr, this, cmbt_loc, wpn, targets_event);
                        targets_event.fireOnEvent = attack_event;

                        if (!IsReplay)
                        {
                            ReplayLog.Events.Add(targets_event);
                            ReplayLog.Events.Add(attack_event);
                        }

                    }
                }
            }
            //update any events where this ship has taken fire, and set the location. 
            if (!IsReplay)
            {
                foreach (CombatEvent comevnt in ReplayLog.EventsForObjectAtTick(this, tic_countr))
                {
                    if (comevnt.GetType() == typeof(CombatTakeFireEvent))
                    {
                        CombatTakeFireEvent takefire = (CombatTakeFireEvent)comevnt;
                        takefire.setLocation(cmbt_loc);
                    }
                }
            }
        }
        */
	}
}
