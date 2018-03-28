using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventInfo {

    public BaseDamageType DamageType;

    public DamageEventInfo()
    {
        DamageType = new BaseDamageType();
    }

    public DamageEventInfo(Type ThisDamageType)
    {
        DamageType = (BaseDamageType)System.Activator.CreateInstance(ThisDamageType); 
    }

}
