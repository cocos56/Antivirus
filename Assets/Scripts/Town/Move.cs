using UnityEngine;

namespace town
{
    public class Move : MonoBehaviour
    {
        public float movespeed = 0.05f;

        public GameObject go;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.S))
            {
                go.transform.Translate(-Vector3.forward*movespeed, Space.Self);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                go.transform.Translate(Vector3.forward* movespeed, Space.Self);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                go.transform.Rotate(-Vector3.up * Time.deltaTime*60,Space.Self);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                go.transform.Rotate(Vector3.up * Time.deltaTime * 60, Space.Self);
            }
        }
    }
}