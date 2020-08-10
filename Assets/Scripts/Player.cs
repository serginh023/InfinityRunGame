using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    public static GameObject player;
    public static GameObject currentPlataform;

    //public Rigidbody rigidbody;

    private void OnEnable()
    {
        Debug.Log("Enable");
    }

    private void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        anim = GetComponent<Animator>();

        player = this.gameObject;

        //rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -90);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-.25f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(.25f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentPlataform = collision.gameObject;
    }

    void StopJumping()
    {
        anim.SetBool("isJumping", false);
    }

    void Stopmagic()
    {
        anim.SetBool("isMagic", false);
    }
}
