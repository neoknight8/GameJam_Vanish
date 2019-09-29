using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour {
    TextMesh textMesh;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();
        Timer.Instance.SetTimerChangedHandler(ChangeText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ChangeText(int seconds){
        textMesh.text = seconds.ToString();
    }
}
