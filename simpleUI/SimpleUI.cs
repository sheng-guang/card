using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleUI : MonoBehaviour {

    public Slider HP;
    public void setHP(card_mini m)
    {
        HP.value = m.now_HP / m.now_MaxHP;
    }

	void Start () {
		
	}
	void Update () {
		
	}
}
