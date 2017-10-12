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

    //获取这个单位作为目标
    public bool getthis(Skill_K1 k)
    {
        return true;
    }
    //atk
   public void  getHPchange(Skill_K1 k,int number){
        
    }
    public void  getBuff() {

    }

    //card
    //buff
}
