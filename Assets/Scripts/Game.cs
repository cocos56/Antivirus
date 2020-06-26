using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public float timeLeft = 1f;
    public Text timeLeftText;

    // Start is called before the first frame update
    void Start()
    {
        End.buildIndex = SceneManager.GetActiveScene().buildIndex;
        End.win = !End.win;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftText.text = timeLeft.ToString("f2");
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }
}
