using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public static GameObject m_DummyTraveller;
    public static GameObject m_lastPlatform;

    void Awake()
    {
        m_DummyTraveller = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject go = Pool.singleton.GetRandom();

        if(go == null)  return;

        if (m_lastPlatform != null)
        {
            if (m_lastPlatform.tag == "platformTSection")
                m_DummyTraveller.transform.position = m_lastPlatform.transform.position +
                Player.player.transform.forward * 20;
            else 
                m_DummyTraveller.transform.position = m_lastPlatform.transform.position +
                    Player.player.transform.forward * 10;

            if(m_lastPlatform.tag == "stairsUp")
                m_DummyTraveller.transform.Translate(0, 5, 0);
        }

        m_lastPlatform = go;
        go.SetActive(true);
        go.transform.position = m_DummyTraveller.transform.position;
        go.transform.rotation = m_DummyTraveller.transform.rotation;


        if(go.tag == "stairsDown")
        {
            m_DummyTraveller.transform.Translate(0, -5, 0);
            go.transform.Rotate(0, 180, 0);
            go.transform.position = m_DummyTraveller.transform.position;
        }
    }
}
