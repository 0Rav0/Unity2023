using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI PointsText;
    [SerializeField] private TextMeshProUGUI LifeText;
    [SerializeField] private GameObject Pause;

    [Header("Game")]
    [SerializeField] private int Points;
    [SerializeField] private int Score;
    [SerializeField] private int Life;

    [Header("Player")]
    [SerializeField] private bool isGround = true;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementX;
    [SerializeField] private float movementZ;

    [Header("Audio")]
    public AudioClip collectClip;
    public AudioClip respawnClip;

    private GameManager gm;
    private Rigidbody rb;
    private AudioSource Audio;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        Audio = GetComponent<AudioSource>();
        UpdatePlayer();
    }

    public void UpdatePlayer()
    {
        Score = 0;
        Points = PlayerPrefs.GetInt("Points");

        // Ulepszenia
        int upgrades = PlayerPrefs.GetInt("Upgrades");

        switch (upgrades)
        {
            case 0:
                Life = 1;
                speed = 5f;
                jumpHeight = 175f;
                rb.angularDrag = 0.05f;
                break;
            case 1:
                Life = 2;
                transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                jumpHeight = 200f;
                speed = 5.5f;
                rb.angularDrag = 0.1f;
                break;
            case 2:
                Life = 2;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                jumpHeight = 220f;
                speed = 6f;
                rb.angularDrag = 0.25f;
                break;
            case 3:
                Life = 3;
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                jumpHeight = 230f;
                speed = 6.5f;
                rb.angularDrag = 0.5f;
                break;
            case 4:
                Life = 3;
                transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
                jumpHeight = 240f;
                speed = 7f;
                rb.angularDrag = 0.75f;
                break;
            case 5:
                Life = 3;
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                jumpHeight = 250f;
                speed = 7.5f;
                rb.angularDrag = 0.9f;
                break;
            case 6:
                Life = 4;
                transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
                jumpHeight = 260f;
                speed = 8f;
                rb.angularDrag = 1f;
                break;
            case 7:
                Life = 4;
                transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
                jumpHeight = 270f;
                speed = 8.5f;
                rb.angularDrag = 2f;
                break;
            case 8:
                Life = 4;
                transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                jumpHeight = 280f;
                speed = 9f;
                rb.angularDrag = 5f;
                break;
            case 9:
                Life = 4;
                transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
                jumpHeight = 290f;
                speed = 9.5f;
                rb.angularDrag = 7f;
                break;
            case 10:
                Life = 5;
                transform.localScale = new Vector3(2f, 2f, 2f);
                jumpHeight = 300f;
                speed = 10f;
                rb.angularDrag = 10f;
                break;

            default: 
                break;
        }

        LifeText.text = Life.ToString();
        PointsText.text = Points.ToString();
        ScoreText.text = Score.ToString() + "/" + PlayerPrefs.GetInt("HighScore");
    }

    public void DealDamage()
    {
        if(Life > 0)
        {
            Life--;
            LifeText.text = Life.ToString();
        }
        else
        {
            if (Score > PlayerPrefs.GetInt("Highscore"))
                PlayerPrefs.SetInt("Highscore", Score);

            PlayerPrefs.SetInt("Points", Points);
            PlayerPrefs.SetInt("Score", Score);
            SceneManager.LoadScene("Summary");
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && isGround)
        {
            Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
            rb.AddForce(jump);
            isGround = false;
        }

        if (Input.GetKeyDown("escape"))
        {
            if(Pause.activeInHierarchy == false)
            {
                Time.timeScale = 0f;
                Pause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                Pause.SetActive(false);
            }
            
        }

        if(gm.CurrentPlatform != null)
        {
            if (transform.position.y < -6f)
            {
                DealDamage();
                if(Life >= 0)
                {
                    rb.velocity = Vector3.zero;
                    transform.position = new Vector3(gm.CurrentPlatform.transform.position.x, gm.CurrentPlatform.transform.position.y + 2f, gm.CurrentPlatform.transform.position.z);
                    Audio.PlayOneShot(respawnClip, 0.2f);
                }
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        Pause.SetActive(false);
    }

    public void toMainMenu()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("Points", Points);
        SceneManager.LoadScene("Summary");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void FixedUpdate()
    {
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Audio.PlayOneShot(collectClip, 0.2f);
            Destroy(other.gameObject);
            Points++;
            PointsText.text = Points.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround = true;

            if (gm.UpdatePlatforms(collision.gameObject))
            {
                Score++;
                ScoreText.text = Score.ToString() + "/" + PlayerPrefs.GetInt("Highscore");
            }
        }
    }
}
