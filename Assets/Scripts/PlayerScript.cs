using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public float jumpAmount = 10;

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("idle", true);
        anim.SetBool("run", false);
        anim.SetBool("jump", false);
        float speed = 3;
 
        // Sprint
        if (Input.GetKey("left shift") == true)
        {
            speed = speed * 2;
        }


        // Attack1
        if (Input.GetKeyDown("f") == true)
        {
            anim.SetTrigger("attack");

        }
        // Jump
        if (Input.GetKeyDown("space") == true)
        {
            anim.SetBool("jump", true);
            rb.AddForce(new Vector3(0, 10, 0), (ForceMode2D)ForceMode.Impulse);

        }

        // Go Left
        if (Input.GetKey("a") == true)
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            sr.flipX = true;
            anim.SetBool("run", true);
        }

       // Go Right
        if (Input.GetKey("d") == true)
        {
            sr.flipX = false;
            anim.SetBool("run", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }


    }
}
