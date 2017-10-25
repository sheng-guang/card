using System;
using System.Collections.Generic;
using System.Text;

public abstract class mi_base : layer_base
{
    public override void link_load(Mini_G g)
    {
        upGroup = g;
        ID = host().NextminiID;
        load();
    }
    private Mini_G upGroup;

    public override Mini_G Group()  { return upGroup;  }
    public override Host host() {  return upGroup.host(); }
    public skill_[] skills;
    public bool haveskill(int which)
    {
        if (skills.Length > which && skills[which] != null) return true;
        else return false;
    }
}
public abstract  class Mini:mi_base
{    
    public override Mini mini(){return this; }
    //加入技能
    public T addskill<T>() where T : skill_, new()
    {
        T newone = new T();
        newone.link_load(this);
        return newone;
    }
    public void doSkill(int which,List<byte>d)
    {

    }

    public void Be()
    {

    }


}


public abstract class skill_base : layer_base
{
    public override void link_load(Mini m) {upMini = m;load();}
    public Mini upMini;
    public override Mini mini(){ return upMini;}
    public override Mini_G Group() {return mini().Group();}
    public override Host host(){ return Group().host(); }
}
public abstract class skill_:skill_base
{
    public virtual bool test_data(List<byte> d) { return false; }
    public virtual void  do_(List<byte> d) { }
}