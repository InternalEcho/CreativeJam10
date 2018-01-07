using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float playerSpeed, playerRotateSpeed, maxHp, hp;
    public AudioClip WalkingClip;

    private AudioSource walkAudio;

    // Use this for initialization
    void Start () {
        hp = maxHp;
        walkAudio = (gameObject.AddComponent<AudioSource>() as AudioSource);
        walkAudio.clip = WalkingClip;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
        CheckHp();
	}

    void Move()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z);

        this.transform.Translate(direction * playerSpeed);

        if (x == 0.0 && z == 0.0)
        {
            walkAudio.Stop();
        }
        else
        {
            // Play audio for walking if you're moving
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
            }
        }
    }

    void Rotate()
    {
        var rotate = Input.GetAxis("RotateHorizontal");

        transform.Rotate(0, rotate * playerRotateSpeed, 0);
    }

    void CheckHp()
    {
        if (hp <= 0)
        {
            GameManager.Instance.GoToPostGame();
        }
    }

    public void LoseHp()
    {
        if (hp >= 1)
        {
            hp--;
        }
    }
}