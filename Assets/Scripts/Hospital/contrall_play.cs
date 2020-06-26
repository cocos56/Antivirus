using UnityEngine;

public class contrall_play : MonoBehaviour {
    public float speed;
    public float Gravity;
    public float JumpHeight;

    Transform transform_play;
    Rigidbody rigidbody_play;

    bool isGround;
	// Use this for initialization
	void Start () {
        transform_play = transform;
        rigidbody_play = transform.GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 CurrentDirection = new Vector3(x, 0, y);
            //自身转为世界坐标
            CurrentDirection = transform_play.TransformDirection(CurrentDirection);
            CurrentDirection *= speed;

            //当前的刚体速度
            Vector3 currentVelocity = rigidbody_play.velocity;
            Vector3 velocityChange = CurrentDirection - currentVelocity;
            velocityChange.y = 0;

            rigidbody_play.AddForce(velocityChange, ForceMode.VelocityChange);

            if(Input.GetButtonDown("Jump"))
            {
                rigidbody_play.velocity = new Vector3(currentVelocity.x, CalculateJumpHeightSpeed(), currentVelocity.z);
            }
        }
        rigidbody_play.AddForce(new Vector3(0, -Gravity * rigidbody_play.mass, 0));
    }

     private float CalculateJumpHeightSpeed()
    {
        return Mathf.Sqrt(2 * Gravity * JumpHeight);
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
