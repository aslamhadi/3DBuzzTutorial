using UnityEngine;

public class Player : MonoBehaviour
{

    public float PlayerSpeed;
    public GameObject ProjectilePrefab;
    public static int Score = 0;
    public static int Lives = 3;
	
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
        BuildUI();
    }

    void BuildUI()
    {
        GUI.Label(new Rect(10, 10, 60, 20), "Score: " + Score);
        GUI.Label(new Rect(10, 30, 60, 20), "Lives: " + Lives);
    }
}
