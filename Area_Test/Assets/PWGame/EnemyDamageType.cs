using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDamageType : BaseDamageType
{

    public EnemyDamageType()
    {
        verb = "hits";
        CausedByWorld = true;
    }
}
