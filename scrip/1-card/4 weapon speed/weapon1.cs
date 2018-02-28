using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1 : ca_Magic_sprit {

    public override int CardID { get { return 3; } }

    public override bool move_New_pos(float deltaTime)
    {
        transform.position = player().hero.transform.position;
        return true;
    }
}
