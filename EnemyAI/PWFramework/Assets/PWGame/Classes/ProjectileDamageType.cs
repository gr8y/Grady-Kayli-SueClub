using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageType : BaseDamageType
{

    public ProjectileDamageType()
    {
        verb = "hits";
        CausedByWorld = true;
    }
}
