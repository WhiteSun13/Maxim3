using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource GFire;
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int lives = 3;
    private SpriteRenderer sprite;

    public Transform[] shotSpawns;
    public GameObject bullet;
    public GameObject bulletEffect;
    private bool isDead = false;
    private CharacterLife characterLife;
    private float nextFire;
    public float fireRate;
    private Vector3 respawnPoint;
    public float spawnTime;
    public float invencibilityTime;
    public Transform CurrentPlayerPosition;
    public static bool GameOver = false;
    //public static bool BullTime = false;
    public GameObject Spawntriger;

    private void Start()
    {
        GameOver = false;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        characterLife = GetComponent<CharacterLife>();
        if (PlayerPrefs.HasKey("PosX"))  // проверяем, есть ли в сохранении подобная информация
            loadPosition();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isDead)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }
    private void Update()
    {
        if (!isDead)
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
                FindObjectOfType<AudioManager>().Play("Jump");
            }
            if (Input.GetMouseButton(0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GFire.Play();
                Instantiate(bulletEffect, shotSpawns[0].position, shotSpawns[0].rotation);
                Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            savePosition();
        }
    }
    public void Respawn()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(Spawni());
    }
    IEnumerator Spawni()
    {
        FindObjectOfType<AudioManager>().Play("G");
        isDead = true;
        GameOver = true;
        sprite.enabled = false;
        gameObject.layer = 11;
        yield return new WaitForSeconds(spawnTime);
        FindObjectOfType<AudioManager>().Stop("MainMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void savePosition()
    {

        Transform CurrentPlayerPosition = this.gameObject.transform;

        PlayerPrefs.SetFloat("PosX", CurrentPlayerPosition.position.x); // т.к. автоматической работы 
        PlayerPrefs.SetFloat("PosY", CurrentPlayerPosition.position.y); // с массивами нет, разбиваем на
        PlayerPrefs.SetFloat("PosZ", CurrentPlayerPosition.position.z);  // отдельные float и записываем

        PlayerPrefs.SetFloat("AngX", CurrentPlayerPosition.eulerAngles.x);
        PlayerPrefs.SetFloat("AngY", CurrentPlayerPosition.eulerAngles.y);

        //PlayerPrefs.SetString("level", Application.loadedLevelName); // ещё можно писать/читать строки
        //PlayerPrefs.SetInt("level_id", Application.loadedLevel); // и целые
    }
    public void loadPosition()
    {

        Transform CurrentPlayerPosition = this.gameObject.transform;

        Vector3 PlayerPosition = new Vector3(PlayerPrefs.GetFloat("PosX"),
                    PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
        Vector3 PlayerDirection = new Vector3(PlayerPrefs.GetFloat("AngX"), // генерируем новые вектора 
                    PlayerPrefs.GetFloat("AngY"), 0);  // на основе загруженных данных

        CurrentPlayerPosition.position = PlayerPosition; // и применяем их
        CurrentPlayerPosition.eulerAngles = PlayerDirection;
    }
}
