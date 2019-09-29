using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    private const int power = 60;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int playerId;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.Instance.IsInPlay()){
            Move();
        }
	}

    void Move(){
        Vector2 axis = GamepadInput.GamePad.GetAxis(GamepadInput.GamePad.Axis.LeftStick,(GamepadInput.GamePad.Index)playerId);
        if(axis.magnitude > 0.1f){
            transform.forward = new Vector3(axis.normalized.x, 0, axis.normalized.y);
            transform.Translate(new Vector3(0,0,axis.magnitude * speed));
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }
    }

    void Kick(GameObject _gameObject){
        if (GamepadInput.GamePad.GetButtonDown(GamepadInput.GamePad.Button.X, (GamepadInput.GamePad.Index)playerId))
        {
            if (GameManager.Instance.IsInPlay())
            {
                _gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * power);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ball"){
            Kick(collision.gameObject);
        }
    }
}
