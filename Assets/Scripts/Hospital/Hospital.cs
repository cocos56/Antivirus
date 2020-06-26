using UnityEngine;
using UnityEngine.SceneManagement;

public class Hospital : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        End.buildIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
