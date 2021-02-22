using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    //hp_3を用意
    private int hp = 3;
    private int poison_hp = 0;
    public GameObject hp_1;
    public GameObject hp_2;
    public GameObject hp_3;

    public GameObject hp_4;

    public AudioClip poisonmode_sound;
    public AudioClip poisonend_sound;
    public AudioClip damege_sound;
    public AudioClip recovery_sound;

    AudioSource audioSource;

    public bool PoisonFlg = false;
    private bool Poison_mode = false;
    public bool RecoveryFlg = false;
    float recoverytime;
    float poisontime;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      //hp量の管理
        switch (hp)
        {
            case 3:
                hp_3.SetActive(true);
                break;
            case 2:
                hp_2.SetActive(true);
                hp_3.SetActive(false);
                break;
            case 1:
                hp_2.SetActive(false);
                break;
            case 0:
                hp_1.SetActive(false);
                SceneManager.LoadScene("GameOverScene");
                break;
        }

        if (RecoveryFlg)
        {
                recoverytime += 1 * Time.deltaTime;
                if(recoverytime > 1)
                {
                    RecoveryFlg = false;
                    recoverytime = 0; 
                }
        }
        if (PoisonFlg)
        {
            poisontime += 1 * Time.deltaTime;
            if (poisontime > 1)
            {
                PoisonFlg = false;
                poisontime = 0;
            }
        }

        switch (poison_hp)
        {
            case 0:
                hp_4.SetActive(false);
                break;
            case 1:
                hp_4.SetActive(true);
                break;
        }

    }

   public void PushGreenButton()
    {
        RecoveryFlg = true;
        PoisonFlg = true;
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.name == "recovery_human")
        {
            if (RecoveryFlg == true)
            {
                if (hp < 3)
                {
                    hp += 1;
                    RecoveryFlg = false;
                    Destroy(collision.gameObject);
                    audioSource.PlayOneShot(recovery_sound);
                }

            }

        }

        if (collision.gameObject.name == "human_black")
        {
            if(PoisonFlg == true)
            {
                Poison_mode = true;
                this.gameObject.GetComponent<Animator>().SetBool("Poisonmode", true);
                audioSource.PlayOneShot(poisonmode_sound);
                poison_hp = 1;
                PoisonFlg = false;
            }
            
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "alligator")
        {
            if(Poison_mode == true)
            {  
                Destroy(collision.gameObject);//衝突したワニを消す
                Poison_mode = false;//poisonモード終了
                poison_hp = 0;
                this.gameObject.GetComponent<Animator>().SetBool("Poisonmode", false);
                audioSource.PlayOneShot(poisonend_sound);
            }
            else{
                this.gameObject.GetComponent<Animator>().SetBool("Damage", true);
                collision.gameObject.GetComponent<Animator>().SetBool("hit", true);
                audioSource.PlayOneShot(damege_sound);
                hp -= 1;
            }
                
        
            
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "alligator")
        {
            this.gameObject.GetComponent<Animator>().SetBool("Damage", false);
            collision.gameObject.GetComponent<Animator>().SetBool("hit", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "goal")
        {
            SceneManager.LoadScene("ClearScene");
        }

        if (collision.gameObject.name == "Wall_Down")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
