using System;
using System.Collections.Generic;
using System.Text;

public abstract class mi_base : layer_base
{
    private mini_G upGroup;


    public override mini_G Group()  { return upGroup;  }
    public override Host host() {  return upGroup.host(); }

}
public  class mini:mi_base
{
    

    public void doSkill()
    {

    }

    public void Be()
    {

    }
}

