using UnityEngine;
using System.Collections;

public class ItemDestroyer : MonoBehaviour {

    private GameObject unityChan;


	// Use this for initialization
	void Start () {
        unityChan = GameObject.Find("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < unityChan.transform.position.z-10)
        {
            Destroy(gameObject);
        }
	}
}
