using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // statikus peldany a GameManager osztalybol, hogy mas scriptbol is konnyen elerheto legyen

    [SerializeField]
    private GameObject _gameOverCanves; // hivatkozas a "game over" canvas objektumra, amely a jatek vege kepernyot jeleniti meg

    private void Awake()
    {
        // ha meg nincs beallitva az instance (azaz ez az elso letrehozott GameManager), akkor beallitjuk erre az objektumra
        if (instance == null)
        {
            instance = this;
        }

        // biztositsuk, hogy a jatek normalis idoben fusson (ne legyen leallitva)
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        // megjelenitjuk a "game over" kepernyot
        _gameOverCanves.SetActive(true);

        // leallitjuk az ido mulasat a jatekban, igy minden animacio es mozgas megall
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // ujratoltjuk a jelenlegi jelenetet, ez gyakorlatilag ujrainditja a jatekot
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
