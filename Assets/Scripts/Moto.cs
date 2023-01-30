using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moto : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public static bool GameOver = false;
    private bool isDead = false;
    private SpriteRenderer sprite;
    public float spawnTime;
    public float invencibilityTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindObjectOfType<AudioManager>().Play("da");
        GameOver = false;
        Time.timeScale = 1f;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
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
}
