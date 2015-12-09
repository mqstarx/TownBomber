using UnityEngine;
using System.Collections;

public class SpecialEffectHelper : MonoBehaviour {



    public static SpecialEffectHelper Instance;

    public ParticleSystem FireEffect;
    public ParticleSystem SmokeEffect;
    // Use this for initialization

    void Awake()
    {
        if(Instance!=null)
        {
            Debug.LogError("too many fire");
        }
        Instance = this;
    }


    public void Explosion(Vector3 position)
    {
        instantiate(FireEffect, position);
    }

    public void Smoke(Vector3 position)
    {
        instantiate(SmokeEffect, position);
    }
    private ParticleSystem instantiate(ParticleSystem prefub,Vector3 pos)
    {
        ParticleSystem exp = Instantiate(prefub, pos, Quaternion.identity) as ParticleSystem;
        Destroy(exp.gameObject, exp.startLifetime);
        return exp;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
