using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float jumpPower = 5f;
    public GameObject imageBird;
    public Vector3 lookDirection;
    public static Bird bird;

    private void Awake()
    {
        bird = this;
    }

	// Update is called once per frame
	void Update () {
        if(GameManager.manager.end == false)
        {
            if (Input.GetMouseButtonDown(0) && this.transform.position.y < 5f)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                this.GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
            }

            if(GameManager.manager.ready == false)
            {
                lookDirection.z = this.GetComponent<Rigidbody>().velocity.y * 10f + 20f;
            }
        }        
        
        Quaternion R = Quaternion.Euler(lookDirection);
        imageBird.transform.rotation = Quaternion.RotateTowards(imageBird.transform.rotation, R, 5f);
	}

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Cactus")
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, -3, 0);
            lookDirection = new Vector3(0, 0, -90f);
            GameManager.manager.GameOver();
        }
        else if(target.tag == "Goal")
        {

        }
    }
}
