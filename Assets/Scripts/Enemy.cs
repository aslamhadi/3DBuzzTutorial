using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MinSpeed;
    public float MaxSpeed;

    private float _currentSpeed;
    private float _x, _y, _z;

    // Use this for initialization
    void Start()
    {        
        _y = 7.0f;
        _z = 0.0f;
        SetSpeedAndPositionX();        
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = _currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * amountToMove);

        if (transform.position.y <= -5)
        {
            SetSpeedAndPositionX();            
        }
    }

    void SetSpeedAndPositionX()
    {
        _currentSpeed = Random.Range(MinSpeed, MaxSpeed);
        _x = Random.Range(-6f, 6f);
        transform.position = new Vector3(_x, _y, _z);
    }
}
