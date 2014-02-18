using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float PlayerSpeed;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;

    public static int Score = 0;
    public static int Lives = 3;
    public static int Missed = 0;
	
	// Update is called once per frame
	void Update ()
	{        
	    float amountToMove = Input.GetAxisRaw("Horizontal") * PlayerSpeed * Time.deltaTime;

        //move the player
        transform.Translate(Vector3.right * amountToMove);

        //wrap
        if(transform.position.x <= -7.5f) 
            transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
        else if (transform.position.x >= 7.5f)
            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);

	    if (Input.GetKeyDown("space"))
	    {
            //Fire projectile
            Vector3 position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y/2));
            Instantiate(ProjectilePrefab, position, Quaternion.identity);
	    }
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 120, 20), "Score: " + Score);
        GUI.Label(new Rect(10, 30, 80, 20), "Lives: " + Lives);
        GUI.Label(new Rect(10, 50, 120, 20), "Missed: " + Missed);
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "enemy")
        {
            Player.Lives--;

            var enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");            
            enemy.SetSpeedAndPosition();

            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        gameObject.renderer.enabled = false;
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(1.5f);
        gameObject.renderer.enabled = true;
    }
}
