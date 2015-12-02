using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       /* if (otherCollider.gameObject.name.Contains("Bomb"))
        {
            
            SpecialEffectHelper.Instance.Explosion(otherCollider.transform.position);
            Destroy(otherCollider.gameObject);
           // Destroy(gameObject, 0.1f);

        }*/


    }
}
