using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_point : MonoBehaviour {
    public skill_Trigger upone;
    public List<skill_Trigger> follows;
    public int num;
    public buff_team_mini from;
    public buff_team_mini to;
    public float disTO { get { return (to.transform.position - transform.position).magnitude; } }
    public bool move;
    public bool flash;
    public bool navigation;
    public virtual void firstLoad()
    {
    }
    public virtual void fix(float speed)
    {
        changeposs(speed);
        foreach (skill_Trigger t in follows)
        {
            t. test_trigger();
        }
    }
    public virtual void changeposs(float speed)
    {
        transform.position += speed*0.02f*(to.transform.position - transform.position);
    }
 
}
public enum skill_need
{

}

public enum skill_K
{
    point,
    squard,
}