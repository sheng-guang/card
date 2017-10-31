using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class mini_main : Mini
{
    public override int skillCount { get{return 5;}}

    public override void load()
    {
        addskill<skill_one_damage>(0);
        addskill<skill_one_damage>(1);
    }
    
}
public class skill_one_damage : skill_
{
    public override void load()
    {
       
    }

    public override void run()
    {
        
    }
}
