using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public  class componet_obj{
    //组件的主人
    public SkillObj obj;
    public GetEffect geteffect_ { get { return obj.geteffect; } }
    public void output(outinfo info) { obj.player.host.output(info); }
}
public class GetEffect : componet_obj
{

    //获取这个单位作为目标
    public bool getthis(Skill_K1 k)
    {
        return true;
    }
    //get-HP
   public void  getHPchange(Skill_K1 k,int number){
        //报告观察者
        //
        //运行改变
        obj.nowHP += number;
        output(new outinfo(obj.OID, obj.player.ID, outinfo_K.c_hp));
    }
    //get-
    public void  getBuff() {

    }
    public void getTrigger()
    {

    }
    //card
    //buff
}
