using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour {

    public float Speed = 4.0f;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public float movedir;
    Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        // Check for input
        if (Input.GetKey(UpKey))
        {
            movedir = 1.0f;
        }
        else if (Input.GetKey(DownKey))
        {
            movedir = -1.0f;
        }
        else
        {
            movedir = 0.0f;
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(0.0f, movedir * Speed);
    }
}
