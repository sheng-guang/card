using System;
using System.Collections.Generic;
using System.Text;

//随从
public abstract class mi_base : layer_base
{
    public abstract int skillCount { get; }
    public  void link_load(Mini_G g)
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
    //加入技能
    public void addskill<T>( int n) where T : skill_, new()
    {
        if(skills.Length>n&&n>=0)
            skills[n]= addskill<T>();
    }

    public void doSkill(int which,List<byte>d)
    {
        skills[which].getData(d);
        skills[which].run();
    }

    public void Be()
    {

    }
}

public abstract class skill_ : change_
{
    public Mini upmini;
    public virtual void link_load(Mini m) { upmini = m; load(); }
    public override Mini mini() { return upmini; }
    public override change_ Change() { return this; }
    public Queue<change_> list = new Queue<change_>();
    //测试
    public virtual bool test_data(List<byte> d) { return true; }
    public virtual void getData(List<byte> d) { }
}