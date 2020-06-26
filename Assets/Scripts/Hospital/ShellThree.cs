using UnityEngine;

public class ShellThree : MonoBehaviour
{

    public GameObject []shellExplosionPrefab;
    public AudioClip shellExplosionAudio;
    int a = 0;


    void Update()
    {
        if(ItemButton.spriteIndex != -1&& ItemButton.spriteIndex!=3)
        {
            OptionShell(ItemButton.spriteIndex);
        }
    }

    public void OnTriggerEnter( Collider collider ) {
        AudioSource.PlayClipAtPoint(shellExplosionAudio,transform.position);
        GameObject.Instantiate(shellExplosionPrefab[a], transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
 
        if (collider.tag == "virus") {
            collider.SendMessage("VariusDamage");
        }
    }

   public void OptionShell(int n)
   {
        a=n;
   }
}
