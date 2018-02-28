using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostTxt : CardTxt
{
    public hostDriver1 h2;

    public override bool run_and_Pop(Dictionary<CardTxt, step_target> data)
    {
        hero he = createrMono.creater.aEmptycard<hero>();
        h2.player[0].TXT_move_card_to(he, cardWhere.space3d);
        h2.player[0].TXT_setHero(he);
        _0_camera.camera_.tarTest = he.transform;

        card1_tower t= createrMono.creater.aEmptycard<card1_tower>();
        h2.player[0].TXT_move_card_to(t, cardWhere.hand);

        t = createrMono.creater.aEmptycard<card1_tower>();
        h2.player[0].TXT_move_card_to(t, cardWhere.hand);


        weapon1 w = createrMono.creater.aEmptycard<weapon1>();
        h2.player[0].TXT_move_card_to(w, cardWhere.hand);

        return true;

    }
}
