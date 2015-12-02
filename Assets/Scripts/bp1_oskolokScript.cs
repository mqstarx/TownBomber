using UnityEngine;
using System.Collections;

public class bp1_oskolokScript : MonoBehaviour {

    // Use this for initialization

    public float LiveTime;
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        LiveTime -= Time.deltaTime;
        if (LiveTime <= 0)
        {
            SpecialEffectHelper.Instance.Smoke(transform.position);
            Destroy(gameObject, 0.1f);
        }
	}
}
