using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Player.isDead) 
        {
            return;
        }

        this.transform.position += Player.player.transform.forward * -0.1f;

        if (Player.currentPlataform == null) return;

        if (Player.currentPlataform.tag == "stairsUp")
            this.transform.Translate(0, -0.06f, 0);
        if (Player.currentPlataform.tag == "stairsDown")
            this.transform.Translate(0, 0.06f, 0);
    }
}
