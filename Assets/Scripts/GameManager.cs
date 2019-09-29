using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {
    [SerializeField]
    GameObject ballPrehab;
    [SerializeField]
    Score score;
    [SerializeField]
    TextMesh[] resultTexts;
    bool isInPlay;

	// Use this for initialization
	void Start () {
        isInPlay = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R) && !isInPlay){
            SceneManager.LoadScene("SampleScene");
        }
	}

    public void GameStart(){
        isInPlay = true;
        GenerateBall();
        // Timerの設定
        Timer.Instance.SetTime(120);
        Timer.Instance.SetTimerStoppedHandler(GameEnd);
        Timer.Instance.StartCount();
    }

    public void GenerateBall(){
        Instantiate(ballPrehab, new Vector3(Random.Range(-1.5f, 1.5f), 0.5f, Random.Range(-1.5f, 1.5f)), Quaternion.Euler(Vector3.zero));
    }

    public void Goal(int playerId){
        score.AddScore(playerId);
        GenerateBall();
    }

    private void GameEnd(){
        isInPlay = false;
        int[] result = score.GetScore();
        if(result[0] > result[1]){
            resultTexts[0].gameObject.SetActive(true);
        }else if(result[0] < result[1]){
            resultTexts[1].gameObject.SetActive(true);
        }else{
            resultTexts[2].gameObject.SetActive(true);
        }
    }

    public bool IsInPlay(){
        return isInPlay;
    }
}
