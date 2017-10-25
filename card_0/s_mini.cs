using System;
using System.Collections.Generic;
using System.Text;

//随从
public abstract class mi_base : layer_base
{
    public abstract int skillCount { get; }
    public override void link_load(Mini_G g)
    {
        upGroup = g;
        ID = host().NextminiID;
        skills = new skill_[skillCount];
        load();
    }
    private Mini_G upGroup;

    public override Mini_G Group()  { return upGroup;  }
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

//技能触发者
public abstract class skill_base : layer_base
{
    public override void link_load(Mini m) {upMini = m;load();}
    public Mini upMini;
    public override Mini mini(){ return upMini;}
}
public abstract class skill_:skill_base
{
    public override skill_ skill(){return this; }


    public virtual bool askByGroup { get { return true; } }
    public virtual bool isTriggerskill { get { return false; } }
    public  bool test_data(Mini_G asker, List<byte> d) {

        if (overrideTest() == false) return false;
        return true;
    }
    public virtual bool overrideTest() { return false; }
    public virtual void  do_(List<byte> d) { }
    public Queue<change_> list = new Queue<change_>();
}

//技能效果
public abstract class change_:layer_base
{
    public skill_ upskill;
    public override void link_load(skill_ m) { upskill = m; load(); }
    public override skill_ skill()  {  return upskill; }
    public override change_ change() {return this;}

    public virtual int kind() { return 0; }
    public abstract void run();
}
