using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : layer_ID {
    public override Mini mini()  { return this;  }
    public override layer_kind getT() { return layer_kind.mini; }
    public mini_be be;
    public Buffs buffList;
}
