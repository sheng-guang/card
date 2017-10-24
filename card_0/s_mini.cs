using System;
using System.Collections.Generic;
using System.Text;

public abstract class mi_base : layer_base
{
    private Mini_G upGroup;


    public override Mini_G Group()  { return upGroup;  }
    public override Host host() {  return upGroup.host(); }

}
public  class Mini:mi_base
{
    
    public bool testorder(List<byte> d) {
        return false;
    }

    public void doSkill()
    {

    }

    public void Be()
    {

    }
}

