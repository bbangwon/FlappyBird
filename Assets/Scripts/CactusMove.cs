using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMove : MonoBehaviour {

    public float cactusSpeed;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * cactusSpeed * Time.deltaTime);		

        if(this.transform.position.x < -6f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnEnable()
    {
        this.transform.position = new Vector3(6f, Random.Range(-1f, 1.5f), 0);
    }
}
