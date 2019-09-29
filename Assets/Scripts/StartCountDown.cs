using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountDown : MonoBehaviour {
    int count = 3;
    TextMesh textMesh;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();
        StartCoroutine(CountDown());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountDown(){
        while(count > 0){
            textMesh.text = count.ToString();
            count--;
            yield return new WaitForSeconds(1f);
        }
        textMesh.gameObject.SetActive(false);
        GameManager.Instance.GameStart();
    }

}
