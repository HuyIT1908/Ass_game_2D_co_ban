using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCharacter : MonoBehaviour
{
    // khai bao cac bien su dung
    public static bool isGameOver = false; //Trạng Thái kết thúc Game
    public float jumpheight, speed; // độ cao khi nhảy  , tốc độ chạy
    private Animator player; // Nhân vật

    // KHai báo đối tượng chứa hiệu ứng
    //public GameObject particleSystem;
    //public GameObject particleSystem_2;
    int score = 0; // Điểm của người chơi

    public Text txtScore;

    public GameObject gameOverText;
    int mang = 3;
    int thong = 0;
    int tg = 0;

    private Text txtMang;
    private Text txtQuaThong;
    private Text txtTG;


    void Start()
    {
        // Ánh xạ Component
        player = GetComponent<Animator>();
        Time.timeScale = 1; //tỉ lệ với thời gian thực
        isGameOver = false;
        // ánh xạ đến txtScore GUI
        txtScore = GameObject.Find("ScoreText").GetComponent<Text>();
        txtMang = GameObject.Find("txtMang").GetComponent<Text>();
        txtQuaThong = GameObject.Find("txtThong").GetComponent<Text>();
        txtTG = GameObject.Find("txtGian").GetComponent<Text>();
    }

    void OnCollisionEnter2D(Collision2D collision) // Xử lí va chạm
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            mang -= 1;
            Destroy(collision.gameObject);
            txtMang.text = mang.ToString();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Reward")
        {
            score += 10;
            Destroy(collision.gameObject);
            txtScore.text = score.ToString();

            //GameObject g = Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity);
            //Destroy(g, 0.5f);
        }

        if (collision.gameObject.tag == "Obstacle")
        {

            mang -= 1;
            Destroy(collision.gameObject);
            txtMang.text = mang.ToString();
        }

        if (collision.gameObject.tag == "thong")
        {
            thong += 1;
            Destroy(collision.gameObject);
            txtQuaThong.text = thong.ToString();
        }

        if (collision.gameObject.tag == "TG")
        {
            tg += 1;
            Destroy(collision.gameObject);
            if (tg == 3)
            {
                mang += 1;
                tg = 0;
                txtMang.text = mang.ToString();
            }
            txtTG.text = tg.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) //Nếu game chưa kết thúc
        {
            if (Input.GetKey(KeyCode.LeftArrow)) // nếu nhấn phím mũi tên trái
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("Run", true);
                player.SetBool("Jump", false);
                // di chuyển nhân vật
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                //Quay đầu nhân vật
                if (gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(
                        gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y,
                        gameObject.transform.localScale.z
                        );
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow)) // nếu nhấn phím mũi tên phải
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("Run", true);
                player.SetBool("Jump", false);
                // di chuyển nhân vật
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                //Quay đầu nhân vật
                if (gameObject.transform.localScale.x < 0)
                {
                    gameObject.transform.localScale = new Vector3(
                        gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y,
                        gameObject.transform.localScale.z
                        );
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow)) //Nếu nhấn phím mũi tên lên thì nhân vật sẽ  nhảy
            {
                player.SetBool("Jump", true);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    gameObject.GetComponent<Rigidbody2D>().velocity.x,
                    jumpheight
                    );
            }
            else // Nếu ko nhấn gì thì nhân vật đứng im
            {
                // Thay đổi trạng thái của nhân vật
                player.SetBool("Run", false);
                player.SetBool("Jump", false);
            }

            if (gameObject.transform.position.y < -7)
            {
                gameObject.SetActive(false);

                //gameOverScoreText.text = "Your Score : " + this.score.ToString();
                gameOverText.SetActive(true);

                isGameOver = true;

                Time.timeScale = 0;
            }
            else if (mang <= 0)
            {
                gameObject.SetActive(false);

                gameOverText.SetActive(true);

                isGameOver = true;

                Time.timeScale = 0;
            }
            // trong ham update
        }
    }
}
