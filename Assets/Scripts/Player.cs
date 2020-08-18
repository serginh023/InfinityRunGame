using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    public static GameObject player;
    public static GameObject currentPlataform;
    public bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false;
    Rigidbody rb;
    public GameObject m_Spell;
    public Transform spellStartPosition;
    Rigidbody spellRG;
        

    void Start()
    {
        anim = GetComponent<Animator>();

        player = this.gameObject;

        GenerateWorld.RunDummy();

        startPosition = player.transform.position;

        rb = GetComponent<Rigidbody>();

        spellRG = m_Spell.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isMagic") == false )
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 250);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            transform.Rotate(Vector3.up * 90);
            GenerateWorld.m_DummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();
            if (GenerateWorld.m_lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            transform.Rotate(Vector3.up * -90);
            GenerateWorld.m_DummyTraveller.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.m_lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x, this.transform.position.y, startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(.5f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Wall")
        {
            anim.SetTrigger("isDead");
            isDead = true;
        }
            
        else 
            currentPlataform = collision.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.m_lastPlatform.gameObject.tag != "platformTSection")
            GenerateWorld.RunDummy();

        if (other is SphereCollider)
            canTurn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
            canTurn = false;
    }

    void CastSpell()
    {
        m_Spell.transform.position = spellStartPosition.position;
        m_Spell.SetActive(true);
        spellRG.AddForce(transform.forward * 4000);
        Invoke("KillSpell", .75f);
    }

    void KillSpell()
    {
        m_Spell.SetActive(false);
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
