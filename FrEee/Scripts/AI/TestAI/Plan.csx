﻿#r "../../../bin/Debug/FrEee.Core.dll"
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Space;
using FrEee.Utility;
using System;
using System.Collections.Generic;
using FrEee.Utility.Extensions;
using FrEee.Game.Objects.Orders;
using FrEee.Game.Objects.Vehicles;
using System.Linq; 

public static class PlanManager
{
    public static Empire Empire;

    public static PlanList CurrentPlans; 

    /// <summary>
    /// Unpacks all plans into 
    /// </summary>
    public static void Unpack()
    {
        if (Empire.AINotes.ContainsKey("PlanList"))
        {
            var str = Empire.AINotes["PlanList"] as string;
            if (str != null)
            {
                CurrentPlans = FrEee.Utility.JsonSerializer.DeserializeObjectFromJson<PlanList>(str);
                return; 
            }
        }          
        CurrentPlans = new PlanList();
        Empire.LogAIMessage("Failed to load plans"); 
        
    }

    public static void Pack()
    {
        CurrentPlans.AssignAllIds(); 

        if (Empire.AINotes.ContainsKey("PlanList"))
            Empire.AINotes.Remove("PlanList");

        var serializedPlans = FrEee.Utility.JsonSerializer.SerializeObjectToJson(CurrentPlans);
        Empire.LogAIMessage(serializedPlans); 
        Empire.AINotes.Add("PlanList", serializedPlans); 
    }


    public static void RemoveCompleted()
    {
        CurrentPlans.ColonizationPlans.RemoveAll(x => x.IsComplete);
        CurrentPlans.ShipBuildPlans.RemoveAll(x => x.IsComplete); 
    }

    
}

/// <summary>
/// The method of storing plans between turns for the AI. 
/// </summary>
[Serializable]
public class PlanList
{
    public List<ColonizationPlan> ColonizationPlans;

    public List<ShipBuildPlan> ShipBuildPlans; 

    [DoNotSerialize]
    public IEnumerable<Plan> AllPlans { 
        get
        {
            var plans = new List<Plan>();
            plans.AddRange(ColonizationPlans);
            plans.AddRange(ShipBuildPlans);
            return plans; 
        } 
    }


    public PlanList()
    {
        ColonizationPlans = new List<ColonizationPlan>();
        ShipBuildPlans = new List<ShipBuildPlan>(); 
    }

    public void AssignAllIds()
    {
        foreach (var p in ColonizationPlans)
            if (p.PlanId == null)
                p.AssignId();
        foreach (var p in ShipBuildPlans)
            if (p.PlanId == null)
                p.AssignId();
    }
}


[Serializable]
public abstract class Plan
{
    public string PlanId; 


    [DoNotSerialize]
    public virtual string TypeShorthand { get; }

    public bool IsComplete;

    /// <summary>
    /// The priority of the plan. Higher is better.  
    /// </summary>
    public int Priority; 


    public void AssignId()
    {
        PlanId = $"{TypeShorthand}-{DateTime.Now.Ticks}";
    }
}


[Serializable]
public class ColonizationPlan : Plan
{
    [DoNotSerialize]
    public override string TypeShorthand => "C";

    /// <summary>
    /// The planet intended to colonize. 
    /// </summary>
    [DoNotSerialize]
    public Planet Planet { get {
            if (PlanetId == 0)
                return null; return new GalaxyReference<Planet>(PlanetId);  } set { PlanetId = value.ID; } }

    /// <summary>
    /// The planet that will build the colony ship to colonize this world. 
    /// </summary>
    [DoNotSerialize]
    public Planet SourcePlanet { get
        {
            if (SourcePlanetId == 0)
                return null; return new GalaxyReference<Planet>(SourcePlanetId); } set { SourcePlanetId = value.ID; } }

    [DoNotSerialize]
    public ShipBuildPlan ShipBuildPlan
    {
        get
        {
            if (ShipBuildPlanId == null)
                return null;

            return PlanManager.CurrentPlans.ShipBuildPlans.FirstOrDefault(x => x.PlanId == ShipBuildPlanId); 
        }
    }


    /// <summary>
    /// The Id of the planet. 
    /// </summary>
    public long PlanetId;

    /// <summary>
    /// The source planet to build from. 
    /// </summary>
    public long SourcePlanetId; 

    /// <summary>
    /// Whether this plan is awaiting the build to complete. 
    /// </summary>
    public bool AwaitingBuild;

    /// <summary>
    /// The Shipbuild plan that uses this plan. 
    /// </summary>
    public string ShipBuildPlanId;

    /// <summary>
    /// Whether or not the colony ship has been despatched. 
    /// </summary>
    public bool ColonyShipDespatched; 

    /// <summary>
    /// The ship that will colonize this world. 
    /// </summary>
    [DoNotSerialize]
    public Ship Ship
    {
        get
        {
            if (ShipId == 0)
                return null;
            return new GalaxyReference<Ship>(ShipId);
        }
        set { ShipId = value.ID; }
    }

    /// <summary>
    /// The colony ship Id. 
    /// </summary>
    public long ShipId;

    /// <summary>
    /// The Id of this colony command. 
    /// </summary>
    public long ColonyCommandId; 

}

[Serializable]
public class ShipBuildPlan :Plan
{
    [DoNotSerialize]
    public override string TypeShorthand => "BS";

    /// <summary>
    /// The planId of the plan that requires this to be built. 
    /// </summary>
    public string RequestPlanId;

    /// <summary>
    /// The role this build is made for. 
    /// </summary>
    public string Role;

    /// <summary>
    /// The basename of this design. 
    /// </summary>
    public string DesignBaseName; 

    /// <summary>
    /// Whether or not the order to build the ship has been sent. 
    /// </summary>
    public bool SentOrder;

    [DoNotSerialize]
    public StarSystem StarSystem { get {
            if (StarSystemId == 0)
                return null; return new GalaxyReference<StarSystem>(StarSystemId); }set{ StarSystemId = value.ID; } }

    /// <summary>
    /// The star system this object is to be built in, if any. 
    /// </summary>
    public long StarSystemId; 


    [DoNotSerialize]
    public ConstructionQueue ConstructionQueue { get {
            if (ConstructionQueueID == 0)
                return null; return new GalaxyReference<ConstructionQueue>(ConstructionQueueID); } set { ConstructionQueueID = value.ID; } }

    /// <summary>
    /// The ID of the construction queue
    /// </summary>
    public long ConstructionQueueID; 



}