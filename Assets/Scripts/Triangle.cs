using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public float moveSpeed;
    public UIManager ui;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {

        ui = FindObjectOfType<UIManager>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.speed <= 30f)
            GameController.speed += GameController.speedup * Time.deltaTime;
        if (!gameController.isGameover)
        {
            gameObject.transform.position -= new Vector3(Time.deltaTime * GameController.speed, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone")&&!gameController.isGameover) {
            gameController.score++;
            ui.setScoreText("Score: " + gameController.score);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.changeAudio(gameController.deathAudio);
            Destroy(gameObject);
            gameController.isGameover = true;
        }
    }
}
