using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createrMono : MonoBehaviour,Icreater {

    public static createrMono creater;
    public miniG[] AllPlayer;
    public Card_m[] Allcard;
    public Dictionary<string, Card_m> String_card=new Dictionary<string, Card_m>();
    public Dictionary<string, miniG> String_P=new Dictionary<string, miniG>();
    [ContextMenu("loadallcard_allplayer")]
    public void loadc()
    {
        Allcard = Resources.LoadAll<Card_m>("cards");
        AllPlayer = Resources.LoadAll<miniG>("players");
    }
    public void loadOnenable()
    {
        foreach (Card_m i in Allcard)
            String_card.Add( i.GetType().ToString(),i);
        foreach (miniG p in AllPlayer)
        {
            String_P.Add(p.GetType().ToString(), p);
        }
    }


//可以加入id锁 只能给一次id/还有id可能重复
    //=================================
    public T  aEmptycard<T>() where T:Card_m
    {
        T ne=String_card[typeof(T).ToString()].GetComponent<T>(); 
        if (ne)
        { T c = Instantiate(ne);
            c.ID = NextminiID;

            foreach(Trigger t in c.callTrigger)  t.ID = NextTriggerID;
            if(c.minion)
            foreach (Trigger t in c.minion.skillTrigger) t.ID = NextTriggerID;
            return c;

        }
        else return null;
    }
    //====================================
    
    public T aEmptyPlayer<T>() where T : miniG
    {
        T ne = String_P[typeof(T).ToString()].GetComponent<T>();
        if (ne)
        { T p = Instantiate(ne);p.ID = NextGID; return p;}
        else return null;
    }

    public int lastPlayer = 0, lastmini = 0, lastTrigger = 0;
    int NextGID { get { return ++lastPlayer; } }
    int NextminiID { get { return ++lastmini; } }
    int NextTriggerID { get { return ++lastTrigger; } }

}





//public class creater : Icreater
//{
//    public T addminiToPlayer<T>(miniG p) where T : Card, new()
//    {
//        T ne = new T();
//        ne.upone = p;
//        p.beens.Add(ne);
//        ne.load_logic();
//        return ne;
//    }

//    public miniG addPlayerTohost(int which, Host h)
//    {
//        return null;
//    }

//    public Card addminiToPlayer(int which, miniG h)
//    {
//        return null;
//    }

//    public T addminiToPlayer<T>(miniG p, Vector3 position) where T : Card, new()
//    {
//        throw new System.NotImplementedException();
//    }

//    public T addPlayerToHost<T>(Host h) where T : miniG, new()
//    {
//        T ne = new T();
//        ne.upone = h;
//        h.Beens.Add(ne);
//        ne.load_logic();
//        return ne;
//    }

//    public T addPlayerToHost<T>(Host h, Vector3 center) where T : miniG, new()
//    {
//        throw new System.NotImplementedException();
//    }
//}
public interface Icreater
{
    T aEmptyPlayer<T>() where T : miniG;

    T aEmptycard<T>() where T : Card_m;

}
