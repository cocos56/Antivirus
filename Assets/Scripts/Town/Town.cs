using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace town
{
    public class Town : MonoBehaviour {
        public Text hpText;
        public GameObject defeat; 
        public static int hp=100;

        void Start()
        {
            End.buildIndex = SceneManager.GetActiveScene().buildIndex;
        }
        
        // Update is called once per frame
        void Update () {
            hpText.text = hp.ToString();
            if (hp<=0)
            {
                // defeat.SetActive(true);
                End.win = false;
                SceneManager.LoadScene("End");
            }
        }
    }
}
