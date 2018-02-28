using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//一张手牌ui
public class UI_card : MonoBehaviour {
    public clientPlayer group;
    public Toggle t;
    public Text text;
    public int which;
    public void change()
    {
        if (t.isOn) group.slected(which);
        else group.slected(-1);
    }

}
