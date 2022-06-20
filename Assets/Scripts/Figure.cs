using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    public float hightJump;
    private bool isOnGround;
    public GameController gameController;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       gameController = FindObjectOfType<GameController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround&& !gameController.isGameover)
        {
            animator.SetBool("isInGround", false);
            gameObject.transform.position += new Vector3(0, hightJump, 0);
            isOnGround = false;
            gameController.changeAudio(gameController.jumpAudio);
            //animator.SetBool("isInGround", false);
        }
        //if (!isOnGround) animator.SetBool("isInGround", false);
        //else animator.SetBool("isInGround", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
            animator.SetBool("isInGround", true);
        }
    }
}
