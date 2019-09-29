using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    [SerializeField]
    private int playerId;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("Soccer Ball(Clone)")){
            Destroy(other.gameObject);
            GameManager.Instance.Goal(playerId);
        }
    }
}
