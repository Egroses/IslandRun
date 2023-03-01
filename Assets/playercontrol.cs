using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playercontrol : MonoBehaviour
{
    private CharacterController player;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
	public int gold=0;
	public int limit=6;

    private void Start()
    {
        player = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        player.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			groundedPlayer=false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);
    }

	void OnTriggerStay(Collider other) {
		groundedPlayer=false;
		if(other.gameObject.tag=="toprak"){
			groundedPlayer=true;
			playerVelocity.y = 0f;
		}
		if(other.gameObject.tag=="coin"){
			Destroy(other.gameObject);
			gold++;
		}
	}

	public int getGold(){
		return gold;
	}
}