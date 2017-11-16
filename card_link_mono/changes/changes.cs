using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//public enum change_k1
//{//1   //2     //4 / 8  /16/          //32
    //第一位是前后//第二位加减//第三四五位分类型//后面为实际类型
    //before_reduce=0,
    //after=1,//add=2,
    //use_card_skill = 32,
    //HP = 64,
    //mini = 128,
    //time = 256,
    //before,//}
//------------------------------------------------------
public static class ChangeToMini
{
    public static void changeHP(Mini m, HPchange d)
    {
        Host h= d.host();
        //m.buffList
    }
}
public class HPchange:change_
{
    public int n;
    public override int kind  (){  return 64; }
    public override void run(Mini m)
    {  ChangeToMini.changeHP(m, this);  }
}
//------------------------------------------------------
public static class ChangeToPlayer
{
    public static void newMini(miniG player,Mini newone)
    {
        //先测试是否可以接收
        newone.link_GetID(player);
    }
}