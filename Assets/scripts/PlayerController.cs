using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;

    bool walking, jumped, jumping, grounded = false;
    float speed = 3f, height = 20f , jumpTime, walkTime;
    int moveState;
    int mang = 3;
    int thong = 0;
    int tg = 0;
    int score = 0;

    private Text txtMang;
    private Text txtQuaThong;
    private Text txtTG;
    private Text txtScore;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

        txtMang = GameObject.Find("txtMang").GetComponent<Text>();
        txtQuaThong = GameObject.Find("txtThong").GetComponent<Text>();
        txtTG = GameObject.Find("txtGian").GetComponent<Text>();
        txtScore = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        State();

        if ( gameObject.transform.position.y < -7 )
        {
            gameObject.SetActive(false);

            GameController.instance.Game_Over();

            Time.timeScale = 0;
        }
        else if ( mang <= 0)
        {
            gameObject.SetActive(false);

            GameController.instance.Game_Over();

            Time.timeScale = 0;
        }

    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.RightArrow) || !(Input.GetKey(KeyCode.UpArrow))
            || !Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveState = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 2;
        }

        Jump();
    }

    void Move(Vector3 dir)
    {
        walking = true;
        //speed = Mathf.Clamp(speed, speed, 8f);
        walkTime += Time.deltaTime;

        transform.Translate(dir * speed * Time.fixedDeltaTime);
        if (walkTime < 3f && walking)
        {
            speed += .025f;
        }
        else if (walkTime > 3f)
        {
            speed = 3f;
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, height);
            }
        }

        if (jumping && jumped)
        {
            rbody.gravityScale -= (0.1f * Time.fixedDeltaTime);
        }
        if (jumpTime > 1f)
            jumping = false;
        if (!jumping && jumped)
            rbody.gravityScale += .2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            mang -= 1;
            Destroy(collision.gameObject);
            txtMang.text = mang.ToString();

            //gameObject.SetActive(false);

            //GameController.instance.Game_Over();

            //Time.timeScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            anim.SetBool("Jump", false);
            jumpTime = 0;
            rbody.gravityScale = 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //gameObject.SetActive(false);

            //GameController.instance.Game_Over();

            //Time.timeScale = 0;

            mang -= 1;
            Destroy(collision.gameObject);
            txtMang.text = mang.ToString();
        }

        if ( collision.gameObject.tag == "thong" )
        {
            thong += 1;
            Destroy(collision.gameObject);
            txtQuaThong.text = thong.ToString();
        }

        if (collision.gameObject.tag == "TG")
        {
            tg += 1;
            Destroy(collision.gameObject);
            if ( tg == 3)
            {
                mang += 1;
                tg = 0;
                txtMang.text = mang.ToString();
            }
            txtTG.text = tg.ToString();
        }

        if (collision.gameObject.tag == "Reward")
        {
            score += 100;
            Destroy(collision.gameObject);
            txtScore.text = score.ToString();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.right);
                break;
            case 2:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.left);
                break;
            default:
                walking = false;
                walkTime = 0;
                speed = 3f;
                anim.SetBool("Run", false);
                break;
        }
        //8888888
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumped = true; jumping = true;
            jumpTime += Time.fixedDeltaTime;

        }
        else jumping = false;
    }

}