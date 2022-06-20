using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip jumpAudio; //<---drag mp3 into the inspector here
    public AudioClip backgroundAudio; //<---drag  mp3#2 into the inspector here
    public AudioClip deathAudio; //<---drag  mp3#2 into the inspector here
    AudioSource audio1;

    public GameObject player;
    public GameObject triangle;
    public UIManager ui;
    public bool isGameover;
    public float timeCreateTriangle;
    private float p_timeCreateTriangle;
    private float hsUp;

    public static float speed;
    public static float speedup;
    const float CSPEEDUP = 0.05f;
    const float CSPEED = 10.0f;
    public int score;

    GameObject newTriangle;
    // Start is called before the first frame update
    void Start()
    {
        p_timeCreateTriangle = 0;
        hsUp = 0.0001f;

        speed = CSPEED;
        speedup = CSPEEDUP;

        ui = FindObjectOfType<UIManager>();
        audio1 = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hsUp<0.007)
            hsUp += hsUp * 0.00015f;
        float deltaTime = Time.deltaTime + hsUp;
        p_timeCreateTriangle -= deltaTime;

        if (p_timeCreateTriangle <= 0 && !isGameover)
        {
            newTriangle = Instantiate(triangle, new Vector3(10.8f, -2.5f, 0f), Quaternion.identity);
            newTriangle.transform.localScale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.3f, 0.5f), 1);
            p_timeCreateTriangle = timeCreateTriangle;
        }
        if (isGameover)
        {
            Destroy(newTriangle);
            ui.gameOverPanel.SetActive(true);
            //DestroyImmediate(triangle.transform,true);
            
        }
    }
    public void replay()
    {
        foreach (Transform child in triangle.transform)
        {
            GameObject.DestroyImmediate(child.gameObject);
        }

        player.transform.position =new Vector3(-6.8f, -1f, 0);
        speedup = CSPEEDUP;
        speed = CSPEED;
        hsUp = 0.0002f;
        score = 0;
        ui.gameOverPanel.SetActive(false);
        isGameover = false;
    }
    public void changeAudio(AudioClip aud)
    {
        audio1.clip = aud;
        audio1.pitch = .8f;
        audio1.Play();
    }
}
