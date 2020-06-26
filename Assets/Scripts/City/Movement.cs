using UnityEngine;

namespace City
{
    public class Movement : MonoBehaviour
    {
        /*
         * 处理消毒车移动
         */
        public float speed = 5;
        public float angularSpeed = 30;
        private Rigidbody rigidbody;
        // Start is called before the first frame update
        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float v = Input.GetAxis("Vertical");
            rigidbody.velocity = transform.forward * v * speed;
            float h = Input.GetAxis("Horizontal");
            rigidbody.angularVelocity = transform.up * h * angularSpeed;
        }
    }
}