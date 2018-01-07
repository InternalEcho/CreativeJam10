using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    private bool canAttack;
    public GameObject displaySword;

    public AudioClip slashingSound;
    public AudioClip stabbingSound;
    private AudioSource slashingSource;
    private AudioSource stabbingSource;

    // Use this for initialization
    void Start () {
        canAttack = true;
        displaySword.transform.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Renderer>().enabled = false;
        slashingSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        slashingSource.clip = slashingSound;
        stabbingSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        stabbingSource.clip = stabbingSound;
    }
	
	// Update is called once per frame
	void Update () {
        Attack();
	}
    
    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            canAttack = false;
            int randomAttack = Random.Range(0, 3);
            StartCoroutine(AttackAnimation(randomAttack));
        }
    }
    
    private IEnumerator AttackAnimation(int randomAttack)
    {
        displaySword.transform.GetComponent<Renderer>().enabled = false;
        this.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Renderer>().enabled = true;

        switch (randomAttack)   // 0 = stab, 1 = horizontal swing, 2 = diagonal swing
        {
            case 0:
                this.GetComponent<Animator>().SetTrigger("Stab");
                yield return new WaitForSeconds(0.5f);
                stabbingSource.Play();
                break;
            case 1:
                this.GetComponent<Animator>().SetTrigger("HorizontalSwing");
                yield return new WaitForSeconds(0.5f);
                slashingSource.Play();
                break;
            case 2:
                this.GetComponent<Animator>().SetTrigger("DiagonalSwing");
                yield return new WaitForSeconds(0.5f);
                slashingSource.Play();
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1.5f);
        displaySword.transform.GetComponent<Renderer>().enabled = true;
        this.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Renderer>().enabled = false;
        canAttack = true;
    }

    /*void Stab()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Stabbed");   //Debug
            this.GetComponent<Animator>().SetTrigger("Stab");
        }
    }

    void VerticalSwing()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Vertical Swing");   //Debug
            this.GetComponent<Animator>().SetTrigger("VerticalSwing");
        }
    }

    void HorizontalSwing()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Horizontal Swing");   //Debug
            this.GetComponent<Animator>().SetTrigger("HorizontalSwing");
        }
    }*/
}
