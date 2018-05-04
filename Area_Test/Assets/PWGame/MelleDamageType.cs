using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageType : BaseDamageType {

    MeleeDamageType()
    {
        verb = "I Slapped You";
        CausedByWorld = true;
    }
}
