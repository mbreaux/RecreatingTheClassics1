using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour {

    public float StartSpeed = 1.0f;
    public float MaxSpeed = 50.0f;
    public float Speed;
    public float SpeedIncrement;
    Rigidbody2D rigidbody;
    GameController gamecontroller;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        gamecontroller = transform.Find("/GameController").GetComponent<GameController>();
        StartCoroutine(ResetBall());
	}
	
	// Update is called once per frame
	void Update () {
        Speed = Mathf.Clamp(Speed, 0.0f, MaxSpeed);	
	}

    void FixedUpdate()
    {
        SetVelocity();
    }

    IEnumerator ResetBall()
    {
        transform.position = Vector2.zero;
        Speed = 0.0f;
        yield return new WaitForSeconds(3.0f);
        Speed = StartSpeed;
        rigidbody.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }
    void SetVelocity()
    {
        rigidbody.velocity = (rigidbody.velocity.normalized * Speed);
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        Speed += SpeedIncrement;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "RedGoal")
        {
            gamecontroller.BlueScore += 1;
        }
        if (other.gameObject.name == "BlueGoal")
        {
            gamecontroller.RedScore += 1;
        }
        StartCoroutine(ResetBall());
    }
}
