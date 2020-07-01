using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    GameObject m_DummyTraveller;

    // Start is called before the first frame update
    void Start()
    {
        m_DummyTraveller = new GameObject("dummy");

        for(int i = 0; i < 20; i++)
        {
            GameObject go = Pool.singleton.GetRandom();

            if (go == null) return;

            go.SetActive(true);
            go.transform.position = m_DummyTraveller.transform.position;
            go.transform.rotation = m_DummyTraveller.transform.rotation;

            if (go.tag == "stairsUp")
            {
                m_DummyTraveller.transform.Translate(0, 5, 0);
            }
            else if(go.tag == "stairsDown")
            {
                m_DummyTraveller.transform.Translate(0, -5, 0);
                go.transform.Rotate( new Vector3(0, 180, 0) );
                go.transform.position = m_DummyTraveller.transform.position;
            }
            else if (go.tag == "platformTSection")
            {
                if(Random.Range(0, 2) == 0)
                    m_DummyTraveller.transform.Rotate( new Vector3(0, 90, 0) );
                else
                    m_DummyTraveller.transform.Rotate(new Vector3(0, -90, 0));

                m_DummyTraveller.transform.Translate(Vector3.forward * -10);//avança
            }

            m_DummyTraveller.transform.Translate(Vector3.forward * -10);//avança
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
