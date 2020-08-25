using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject[] bricks;
    List<Rigidbody> bricksRB = new List<Rigidbody>();
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();
    Collider col;
    public GameObject m_explosion;


    private void OnEnable()
    {
        col.enabled = true;
        for(int i = 0; i < bricks.Length; i++)
        {
            bricks[i].transform.localPosition = positions[i];
            bricks[i].transform.rotation = rotations[i];
            bricksRB[i].isKinematic = true;
        }
    }


    private void Awake()
    {
        col = GetComponent<Collider>();

        foreach (GameObject go in bricks)
        {
            bricksRB.Add(go.GetComponent<Rigidbody>());
            positions.Add(go.transform.localPosition);
            rotations.Add(go.transform.rotation);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Spell")
        {
            Instantiate(m_explosion, collision.contacts[0].point, Quaternion.identity);
            col.enabled = false;
            foreach (Rigidbody rb in bricksRB)
                rb.isKinematic = false;

        }
    }
}
