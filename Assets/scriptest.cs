
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.InputSystem;

public class scriptest : MonoBehaviour
{
    private float movementX;
    private float movementY;

    [SerializeField] private float speed = 5f;
    //OnMove to match 
    void OnMove(InputValue value)
    {
        //Vector2 is a data type (shoudl match)
        Vector2 v = value.Get<Vector2>();
        //print to terminal
        Debug.Log(v);
        //grabbing the x component
        movementX = v.x;
        //grabbing the y component
        movementY = v.y;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
