using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour {
    //-----------------------------------
    
    public createrMono factory;
    public clientCreater cFactory;

    public hostDriver1 driver;
    public _0_camera cam;
    //-------------------------------
    public Host h;
    public void OnEnable()
    {
        //工厂
        createrMono.creater = factory;
        clientCreater.creater = cFactory;

        h.creater = factory;
        h.outGeter = driver.getinfo;
        //摄像机
        getkey.cam = cam;
        //ui

        //--------------------------------------
        load();
    }



    public void load()
    {
        factory.loadOnenable();
    }
}
