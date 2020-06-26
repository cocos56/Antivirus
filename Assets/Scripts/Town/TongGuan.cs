using UnityEngine;
using UnityEngine.SceneManagement;

namespace town
{
    public class TongGuan : MonoBehaviour
    {
        public GameObject cv;
        void OnCollisionEnter(Collision collision)
        {
            // Debug.Log(0);
            if (collision.gameObject.name == "car")
            {
                // cv.SetActive(true);
                End.win = true;
                SceneManager.LoadScene("End");
            }
        }
    }
}
