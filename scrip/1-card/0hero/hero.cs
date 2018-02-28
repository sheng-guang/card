using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : card_mini
{
    public override int CardID  { get { return 0; }  }

    public override float base_MaxHP { get { return 50; } }


    public Tr_usecard Trigger_usecard;
    public Tr_dec_card Trigger_decopose;
    //改写版本 用于使用手牌
    public override bool get_Input_order(order o)
    {
        bool ret = false;
        if (o.action == cardM_Action.card_Become_mini)
        {
            ret = Trigger_usecard.Do_order(o);
        }
        else ret = base.get_Input_order(o);

        return ret;
    }


    //move
    [Header("move")]
    public Rigidbody rig;

    public override bool move_New_pos(float deltaTime)
    {
        Vector3 fo = _0_camera.camera_.vector3_for_move;
        Vector3 to = player().wsda.ws * fo + player().wsda.da * new Vector3(fo.z, 0, -fo.x);
        transform.position += to.normalized * v*deltaTime;
        return true;
    }

}
