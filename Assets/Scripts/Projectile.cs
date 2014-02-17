using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;    

    private Transform _projectileTransform;

	// Use this for initialization
    void Start()
    {
        _projectileTransform = transform;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    float amountToMove = ProjectileSpeed * Time.deltaTime;

        //move the projectile
        _projectileTransform.Translate(Vector3.up * amountToMove);

        //destroy the object
        if(_projectileTransform.position.y >= 6.4f)
            Destroy(gameObject);
	}
}
