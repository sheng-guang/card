using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load : MonoBehaviour {

    public Transform center;
    
    public int  l=10;
    public int size = 1;
    public Transform oneHex;
    public Transform Line;
    Vector3 poss { get { return center.position; } }

    public GameObject last;
    [ContextMenu("load")]
    public void load_()
    {
        if (last != null) { last.SetActive(false); }
        GameObject o = new GameObject();
        GameObject land_G = Instantiate(o, center);
        for(int x= -l; x <= l; x++)
        {
            for(int y = -l; y <= l; y++)
            {
                if (y > (-x + l) || y < (-x - l)) continue;
               Transform t= Instantiate(oneHex, land_G.transform);
                t.transform.localPosition += new Vector3(2*x+y, 0, 1.732f* y);
                //0.8660254038//1.7320508076
               // 2/ 1.7320508076= 1.1547005384
            }
        }

        GameObject line_G = Instantiate(o, land_G.transform);
        for (int i = 0; i < 6; i++)
        {
            Transform t = Instantiate(Line, center);
            t.localPosition += new Vector3(0, 0, 1.732f*l+l1_);
            t.localScale = new Vector3(2 * l+long_, 1, dis);
            t.parent = line_G.transform;
            line_G.transform.eulerAngles += new Vector3(0,60,0);
        }
        land_G.transform.localScale = new Vector3(size, size, size);
        o.transform.parent = land_G.transform;
        
        last = land_G;
    }
    public float l1_, long_, dis=0.1f;
}
