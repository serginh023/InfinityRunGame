using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool dScheduled = false;
    private void OnCollisionExit(Collision player)
    {
        if (Player.isDead) return;

        if (player.gameObject.tag=="Player" && !dScheduled)
        {
            Invoke("SetInactive", 3f);
            dScheduled = true;
        }
    }


    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
