using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public  class componet_obj{
    //组件的主人
    public SkillObj obj;
    public GetEffect geteffect_ { get { return obj.geteffect; } }
}
public class GetEffect : componet_obj
{
    public bool getthis(Skill_K1 k)
    {
        return true;
    }
    //atk
    public void beATK1() { }
    //card
    //buff
}
//public class Skills : componet_obj
//{
//    public void ATK_(int orderNUM) { }
//    public void doSkill() { }
//    public bool TestGetSkill(int whichSkill,byte []data)
//    {
//        return false;
//    }
//}




public class EVE_Player_Do : EVE_
{//主要eve 准备攻击和攻击

}
public class EVE_call : EVE_
{
    //只有通知效果//可以触发trigger
}
public class EVE_trigger : EVE_
{
    //由通知触发//可以触发通知
}