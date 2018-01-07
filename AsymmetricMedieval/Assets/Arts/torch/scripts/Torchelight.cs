using UnityEngine;
using System.Collections;

public class Torchelight : MonoBehaviour {
	
	public GameObject TorchLight;
	public GameObject MainFlame;
	public GameObject BaseFlame;
	public GameObject Etincelles;
	public GameObject Fumee;
	public float MaxLightIntensity;
	public float IntensityLight;
    public AudioClip FireCrack;

    private GameObject Player;
    private bool lightUp;
    private AudioSource audioSource;

    void Start ()
    {
        IntensityLight = 0;
        lightUp = false;
        audioSource = (gameObject.AddComponent<AudioSource>() as AudioSource);
        audioSource.clip = FireCrack;
        Player = GameObject.FindGameObjectWithTag("Player");

        TorchLight.GetComponent<Light>().intensity=IntensityLight;
		MainFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*20f;
		BaseFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*15f;	
		Etincelles.GetComponent<ParticleSystem>().emissionRate=IntensityLight*7f;
		Fumee.GetComponent<ParticleSystem>().emissionRate=IntensityLight*12f;
	}
	

	void Update ()
    {
        if (!lightUp){ lightUp = verifyPlayerIsClose(); }

		TorchLight.GetComponent<Light>().intensity=IntensityLight/2f+Mathf.Lerp(IntensityLight-0.1f,IntensityLight+0.1f,Mathf.Cos(Time.time*30));

		TorchLight.GetComponent<Light>().color=new Color(Mathf.Min(IntensityLight/1.5f,1f),Mathf.Min(IntensityLight/2f,1f),0f);
		MainFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*20f;
		BaseFlame.GetComponent<ParticleSystem>().emissionRate=IntensityLight*15f;
		Etincelles.GetComponent<ParticleSystem>().emissionRate=IntensityLight*7f;
		Fumee.GetComponent<ParticleSystem>().emissionRate=IntensityLight*12f;
    }

    private bool verifyPlayerIsClose()
    {
        if ((Player.transform.position - this.transform.position).sqrMagnitude < 10 * 3)
        {
            Debug.Log((Player.transform.position - this.transform.position).sqrMagnitude);
            Debug.Log((Player.transform.position - this.transform.position).sqrMagnitude < 15);
            Debug.Log("is near!");
            // Set the torch to on
            IntensityLight = MaxLightIntensity;
            // Play fire cracking sound
            audioSource.Play();

            return true;
        }
        else
        {
            //Debug.Log((Player.transform.position - this.transform.position).sqrMagnitude);
            //Debug.Log((Player.transform.position - this.transform.position).sqrMagnitude < 15);

            return false;
        }
    }
}
