using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource die;



    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap")) //CompareTag is more effiecient >>>>> WithTag
        {
            die.Play();

            Die();


        }
    }
    private void Die() //we would also need to set the rigidbody type to Static so we cant move after dying
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;//disables the movement of the player, makes the rigidbody STATIC



    }

    private void RestartLevel()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);




    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
