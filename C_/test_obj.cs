using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test_obj : MonoBehaviour {
    public test_player player;
    public int obj_id;
    public SkillObj obj_skill { get { return player.p.ID_obj[obj_id]; } }
    public Text PID, OID, HP, ATK;
     public void link_load(test_player  p,int i)
    {
        transform.localPosition = new Vector3(0, 0, 0);
        player = p;obj_id = i;
        player.id_obj.Add(i, this);
        OID.text = obj_skill.OID.ToString();
        PID.text = obj_skill.player.ID.ToString();
        upData_obj();
        c_data1();
        c_data2();
        change_which_skill();
    }
    public void upData_obj()
    {

        HP.text = obj_skill.nowHP.ToString();
        ATK.text = obj_skill.nowATK.ToString();
    }

    //ui------------------------------
    public Slider which_skill;
    public Text tskill;
    public Text skill_Name;
    public void change_which_skill() {
        w_skill = (byte)which_skill.value;
        tskill.text = w_skill.ToString();
        if (obj_skill.skills[w_skill] != null) skill_Name.text = obj_skill.skills[w_skill].ToString();
        else skill_Name.text = "---";
    }
    public Slider d1,d2;
    public Text t1, t2;
    public void c_data1() {
        
        _1 = (byte)d1.value;
        if (player.p.host.player_L.ContainsKey(_1))
        {
            t1.text = _1.ToString();
        }
        else t1.text = "---";
    }
    public void c_data2() {
        _2 = (byte)d2.value;
        if (player.p.host.player_L.ContainsKey(_1) && player.p.host.player_L[_1].ID_obj.ContainsKey(_2))
        { t2.text = _2.ToString(); }
        else t2.text = "---";
    }
    public byte w_skill, _1, _2;
    //运行技能
    public void give_order()
    { byte[] n = new byte[2];
        n[0] = _1;
        n[1] = _2;
        player.giveorder(n, order_K.useskill, obj_id, w_skill);
    }
}
