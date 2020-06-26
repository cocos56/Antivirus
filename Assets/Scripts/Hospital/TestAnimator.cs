using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    public  float speed = 80.0f;   //移动速度
    public float rotationSpeed = 80.0f;  //旋转速度
    public Rigidbody rig;
    Animator ani;

    // Use this for initialization
    void Start()
    {
        ani = transform.GetComponent<Animator>();
        rig= transform.GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            ani.Play("run(2D)");
            ani.SetFloat("x", Input.GetAxis("Horizontal"));
            ani.SetFloat("y", Input.GetAxis("Vertical"));

            // 使用上下方向键或者W、S键来控制前进后退
            float translation = Input.GetAxis("Vertical") * speed;
            //使用左右方向键或者A、D键来控制左右旋转
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            rig.velocity = translation* transform.forward;
            rig.angularVelocity = rotation * transform.up;

            //transform.Translate(0, 0, translation); //沿着Z轴移动
            //transform.Rotate(0, rotation, 0); //绕Y轴旋转
        }
        else if (Input.GetAxis("Vertical") == 0
                && Input.GetAxis("Horizontal") == 0
                && stateInfo.IsName("Base Layer.run(2D)"))
        {
            ani.Play("stand");
        }
    }
}
