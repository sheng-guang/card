using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum miniKind
{
    friend=1,
    enemy=2,all=3,
    onlytarget=4,
}
public enum miniKind2
{    hero=16,
    normal=32,hero_normal=48,

}

public class Tr_minienter : Trigger_bymove{
    public card_mini lastenter;
    public miniKind isfriend;
    public miniKind2 ishero;
    public int kind { get { return (int)isfriend + (int)ishero; } }
    public bool debug=false;
    public void OnTriggerEnter(Collider c)
    {
        if (debug) { print(c.gameObject.name); }
        card_mini m = c.gameObject.GetComponent<card_mini>();
        if (!m) return;
        if (debug) { print("get"); }
        if (isfriend == miniKind.onlytarget)
        {
            if (m == mini().target) { lastenter = m; return; }
            else return;
        }
        
        int k = 0;
        if (m.player() == player()) k += 1; else k += 2;
        if (m.player().hero == m) k += 16; else k += 32;
        //print("" + k + kind);
        if ((k & (int)isfriend) != 0&& (k & (int)ishero) != 0) { lastenter = m; }
    }

    public override step_target test()
    {
        if (!lastenter) return null;
        step_target n = new step_target();
        n.user = mini();
        n.targretposs = transform.position;
        n.targetcard = lastenter;
        //print(n);
        lastenter = null;
        return n;
    }

}
