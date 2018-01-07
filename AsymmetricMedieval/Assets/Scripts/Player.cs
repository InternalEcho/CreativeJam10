using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float playerSpeed, playerRotateSpeed, maxHp, hp;
    public AudioClip WalkingClip, DeathClip;
    private float TimeBetweenAudio;
    public AudioClip[] RandomAudio;

    private AudioSource walkAudio;
    private AudioSource deathAudio;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        hp = maxHp;
        walkAudio = (gameObject.AddComponent<AudioSource>() as AudioSource);
        walkAudio.clip = WalkingClip;
        deathAudio = (gameObject.AddComponent<AudioSource>() as AudioSource);
        deathAudio.clip = DeathClip;

        TimeBetweenAudio = Random.Range(15, 40);
        this.audioSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
        CheckHp();
        PlayRandomAudio();
	}

    void PlayRandomAudio()
    {
        // Generate a sound every random time
        TimeBetweenAudio -= Time.deltaTime;
        // Debug.Log(TimeBetweenAudio);
        if (TimeBetweenAudio <= 0)
        {
            TimeBetweenAudio = Random.Range(15, 40);
            audioSource.clip = RandomAudio[Random.Range(0, RandomAudio.Length - 1)];

            audioSource.Play();
        }
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

    void PlayRandomCreepySound()
    {

    }

    void CheckHp()
    {
        if (hp <= 0)
        {
            deathAudio.Play();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Trap")
        {
            Debug.Log("goblin collision");
            LoseHp();
        }
    }
}