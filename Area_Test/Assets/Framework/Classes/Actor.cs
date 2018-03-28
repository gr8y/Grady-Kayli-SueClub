using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : Info
{

    /// <summary>
    /// Boolean. If True, this actor ignored damage events
    /// </summary>
    public bool IgnoresDamage = true;

    /// <summary>
    /// Boolean. Controls if Damage Event Text is sent to Console
    /// </summary>
    public bool LogDamageEvents = true;

    /// <summary>
    /// Property, Easy Access to Get\Set gameObject.name
    /// </summary>
    public string ActorName
    {
        get { return gameObject.name; }
        set { gameObject.name = value; }
    }

    /// <summary>
    /// Property for Controller. Which Player owns or spawned this object. 
    /// Used for Determing credit for Damage
    /// </summary>
    public Controller Owner
    {
        get { return _Owner; }
        set { _Owner = value; }
    }

    /// <summary>
    /// Protected Variable Use Public Interface
    /// </summary>
    protected Controller _Owner;


    /// <summary>
    /// Public Method for Actors to take Damage, unless IgnoresDamage is true
    /// </summary>
    /// <param name="Source">Actor causing the damage (i.e. the bullet)</param>
    /// <param name="Value">How Much Damage Taken</param>
    /// <param name="EventInfo">Optional, Description of the Damage via Damage Event Info, if null Default Event\BaseDamageType used</param>
    /// <param name="Instigator">Optional, Who to Credit Damage (i.e. who shot the bullet), if null World Damage is assumed</param>
    /// <returns>Result of ProcessDamage</returns>
    public virtual bool TakeDamage( Actor Source, float Value, DamageEventInfo EventInfo = null, Controller Instigator = null)
    {
        // If we don't care about damage, just return true and be done!
        if (IgnoresDamage)
        {
            return true;
        }

        // Validate Event Info given
        if (EventInfo == null)
        {
            EventInfo = new DamageEventInfo();
        }

        return ProcessDamage(Source, Value, EventInfo, Instigator);
    }

    /// <summary>
    /// This is where Damage is processed and applied, Called by take Damage
    /// Protected as this should be only overriden by child actor classes. 
    /// Also does basic damage event loggin. 
    /// </summary>
    /// <returns>Return False if Dead!</returns>
    protected virtual bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        // Setup for Logging Dammage Information  
        string DamageEventString = Source.ActorName + " " + EventInfo.DamageType.verb + " " + this.ActorName + " (" + Value.ToString() + " damage)";
        if (Instigator)
        {
            DamageEventString = Instigator.Name + " via " + DamageEventString;
        }
        else
        {
            DamageEventString = "The World via " + DamageEventString;
        }
        DAMAGELOG(DamageEventString);

        return true; 
    }

  

    public virtual void DAMAGELOG(string s)
    {
        if (LogDamageEvents)
        {
            Debug.Log(s);
        }
    }
}
