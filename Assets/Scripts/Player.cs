using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    int m_livesLeft;
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;
    public GameObject panelGameOver;
    public static AudioSource[] sfx;

    void Start()
    {
        anim = GetComponent<Animator>();

        sfx = GameObject.FindWithTag("gameData").GetComponentsInChildren<AudioSource>();

        player = this.gameObject;

        GenerateWorld.RunDummy();

        startPosition = player.transform.position;

        rb = GetComponent<Rigidbody>();

        spellRG = m_Spell.GetComponent<Rigidbody>();

        isDead = false;

        m_livesLeft = PlayerPrefs.GetInt("lives");

        for (int i = 0; i < icons.Length;i++)
        {
            if (i >= m_livesLeft)
                icons[i].texture = deadIcon;
            else
                icons[i].texture = aliveIcon;
        }


    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isMagic") == false )
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 250);
            sfx[7].Play();
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
        if (collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "fallCube" && !isDead)
        {
            if (collision.gameObject.tag == "fallCube")
                anim.SetTrigger("isFalling");
            else
                anim.SetTrigger("isDead");

            sfx[3].Play();
            isDead = true;
            m_livesLeft--;
            PlayerPrefs.SetInt("lives", m_livesLeft);
            if (m_livesLeft > 0)
                Invoke("RestartGame", 1f);
            else
            {
                int highscore;
                icons[0].texture = deadIcon;
                panelGameOver.SetActive(true);

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));

                if (PlayerPrefs.HasKey("highscore"))
                {
                    highscore = PlayerPrefs.GetInt("highscore");

                    if(highscore < PlayerPrefs.GetInt("score"))
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                else
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
            }

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

    void RestartGame()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

    void StopJumping()
    {
        anim.SetBool("isJumping", false);
    }

    void Stopmagic()
    {
        anim.SetBool("isMagic", false);
    }

    void FootStep1()
    {
        sfx[5].Play();
    }

    void FootStep2()
    {
        sfx[6].Play();
    }

    void SpellSound()
    {
        sfx[2].Play();
    }
}
