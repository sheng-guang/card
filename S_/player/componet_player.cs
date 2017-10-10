using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class componet_player
{
    //组件的主人
    public CardPlayer player;
    public cards cards { get { return player.cards; } }
    public Pskills pskills { get { return player.pskills; } }
    public Pget_effect Pget { get { return player.get_P; } }
    public Dictionary<int, SkillObj> ID_obj { get { return player.ID_obj; } }
    public void output(outinfo info) { player.host.output(info); }
}

