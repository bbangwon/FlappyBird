using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float waitingTime = 1.5f;
    public static GameManager manager;
    public bool ready = true;
    public bool end = false;
    public GameObject cactus;

    // Use this for initialization
    void Start() {
        manager = this;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && ready == true)
        {
            ready = false;
            InvokeRepeating("MakeCactus", 1f, waitingTime);
            Bird.bird.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void MakeCactus()
    {
        Instantiate(cactus);
    }

    public void GameOver()
    {
        end = true;
        CancelInvoke("MakeCactus");
        iTween.ShakePosition(Camera.main.gameObject, iTween.Hash("x", 0.2, "y", 0.2, "time", 0.5f));
    }
}
