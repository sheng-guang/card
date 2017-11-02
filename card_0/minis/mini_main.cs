using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class player : Mini_G
{
    public override void load()
    {
        
    }
}
public  class mini_main : Mini
{
    public override int baseHp  {  get  {   return 50; }  }

    public override int skillCount { get{return 5;}}

    public override void load()
    {
         //skills[0]= addskill<skill_one_damage>();
        //addskill<skill_one_damage>(1);
    }
    
}
