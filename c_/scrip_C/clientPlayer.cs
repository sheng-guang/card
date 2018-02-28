using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientPlayer : MonoBehaviour {
    [Header("玩家")]
    public miniG m;
    bool w, s, d, a;
    public inputpackage tosend;
	// Update is called once per frame
	void Update () {
        if (!m) { gameObject.SetActive(false); return; }
        m.freshWSDA(getkey.W, getkey.S, getkey.D, getkey.A);
        if(tosend==null) tosend= new inputpackage();
        m.getinput(tosend);
        tosend = null;
        
	}

    [Header("地图")]
    public map_usecard map;
    public float realmap_L;
    [ContextMenu("refresh_hand")]
    public void flashUI_hand()
    {
        int g = 0;
        foreach (int i in m.inhand)
        {
            group[g].text.text = m.mini(i).GetType().ToString();
            g++;
        }
    }

    [Header("手牌")]
    public int lastselected;
    public UI_card[] group;
    public int wide, high;
    [ContextMenu("load")]
    public void load()
    {
        group = transform.GetComponentsInChildren<UI_card>();
        int i = 0;

        while (group.Length > i)
        {
            group[i].group = this;
            group[i].transform.localPosition = new Vector3(i * wide, high, 0);
            group[i].which = i;
            i++;

        }
    }
    public void slected(int which)
    {
        lastselected = which;
    }

    public void clickMap(Vector3 local_l)
    {

        if (lastselected != -1)
        {
            tosend = new inputpackage();
            tosend.useCard_skill = true;
            //----------------------------------------------
            tosend.user = m.hero.ID;
            tosend.use_mini = m.inhand[lastselected];
            //-----------------------------------------------
            tosend.targetposs = new Vector3(local_l.x,0,local_l.y) * realmap_L;

            tosend.action = cardM_Action.card_Become_mini;
        }

    }
    public void refresh(miniG p)
    {

    }




    public void getinfo(out_info i)
    {
        if (i.isdiffer&&i.D_info == different.active_start)
        {
            info = new List<out_info>();
        }
       else  if (i.isdiffer && i.D_info == different.active_end)
        {
            doinfo();
        }
        else
        {
            info.Add(i);
        } 
    }
    List<out_info> info;
    public void doinfo()
    {
        out_info last=null;
        int i = 0;
        while (info.Count >i)
        {
            out_info f = info[i];
            print(""+f.w.GetType()+f.poped);
            last = info[i];
            i++;
        }
    }
}

public class out_info
{
    public different D_info;
    public bool isdiffer;
    public out_info(different info)
    {
        D_info = info;        isdiffer = true; 
    }
    public out_info (CardTxt which,step_target step,bool p)
    {
        D_info = different.doing;
        isdiffer = false;
        w = which;
        s = step;
        poped = p;
    }
    public bool poped;
   public  CardTxt w;
    public step_target s;
}
public enum different
{
    doing,
    active_start,
    active_end,
}
public enum txtchange
{
    movecall,

}