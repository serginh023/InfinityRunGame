using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    MeshRenderer[] meshs;

    private void Start()
    {
        meshs = this.GetComponentsInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(10);

            Player.sfx[8].Play();

            foreach (MeshRenderer m in meshs)
                m.enabled = false;
        }
    }

    private void OnEnable()
    {
        if(meshs != null)
            foreach (MeshRenderer m in meshs)
                m.enabled = false;
    }

}
