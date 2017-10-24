using System;
using System.Collections.Generic;
using System.Text;

public abstract class mi_base : layer_base
{
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
public  class Mini:mi_base
{
    
    public bool testorder(List<byte> d) {
        return false;
    }

    public void doSkill(int which,List<byte>d)
    {

    }

    public void Be()
    {

    }
}

public class skill_
{
    public virtual bool test_data(List<byte> d) { return false; }
    public virtual void  do_(List<byte> d) { }
}