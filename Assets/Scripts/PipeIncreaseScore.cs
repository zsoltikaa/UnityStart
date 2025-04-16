using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ez a metodus akkor hivodik meg, amikor egy masik 2d-s collider belelep ennek az objektumnak a trigger zonajaba

        // ellenorizzuk, hogy az osszeutkozo objektum cimkeje "Flappy"-e
        if (collision.gameObject.CompareTag("Flappy"))
        {
            // ha a cimke "Flappy", akkor meghivjuk a Score singleton peldanyan az UpdateScore metodust
            // ez novelni fogja a jatekban a jatekos pontszamat
            Score._instance.UpdateScore();
        }
    }

}
