using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_inhand : MonoBehaviour {
    public float z=1;
    public float wide = 1;
    public client_card hero;
    public client_card[] handList;
    public void Update()
    {
        if (hero)
            transform.position = hero.transform.position;
    }
    public void freshall()
    {

    }
}
