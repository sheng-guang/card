using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_team_mini : MonoBehaviour {
    public control_tool2 tool;
    public List<bu> all = new List<bu>();
    public List<int> top = new List<int>();
    public skill_point line;

    public buff_team_mini Target;
    public void ATK_point_Target() {
        skill_point p = Instantiate(line,transform.position,transform.rotation);
        p.from = this;
        p.to = Target;
        tool.transport(p );
        
    }
    public void ATK_aoe() { }
    public void ATK_lightLine() { }
    public void building() { }

    public void get(skill_point p) { }

}

public class bu
{
    public bool ison;

}