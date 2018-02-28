using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientCreater : MonoBehaviour {
    public static clientCreater creater;
    public clientPlayer cpl;
    public clientPlayer getplayer()
    {
        return Instantiate(cpl);
    }


    public client_card cardnormal;

    public client_card getacard() {

        client_card c= Instantiate(cardnormal);
        return c;
    }
    //[ContextMenu("loadallcard_allplayer")]
    //public void loadc()
    //{
    //    Allcard = Resources.LoadAll<Card_m>("cards");
    //    AllPlayer = Resources.LoadAll<miniG>("players");
    //}
}
