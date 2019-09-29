using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    int[] score = new int[2]{0,0};
    [SerializeField]
    TextMesh[] textMesh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int playerId)
    {
        score[playerId - 1]++;
        textMesh[playerId - 1].text = score[playerId - 1].ToString();
    }

    public int[] GetScore(){
        return score;
    }
}
