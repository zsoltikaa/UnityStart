using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    // ez az osztaly egy pontszamkezelo singleton, ami a jatekos aktualis es legmagasabb pontszamat kezeli
    public static Score _instance; // statikus peldany az osztalybol, singleton mintazat hasznalatahoz

    [SerializeField]
    private TextMeshProUGUI _currentScoreText; // a felulethez tartozo szoveg objektum, ami az aktualis pontszamot jeleniti meg

    [SerializeField]
    private TextMeshProUGUI _highScoreText; // a felulethez tartozo szoveg objektum, ami a legmagasabb pontszamot jeleniti meg

    private int _score; // belso valtozo az aktualis pontszam tarolasara

    // az Awake metodus akkor fut le, amikor az objektum letrejon a jatek inditasakor
    private void Awake()
    {
        // ha meg nincs beallitva az _instance, akkor beallitjuk a jelenlegi objektumot annak
        if (_instance == null)
        {
            _instance = this;
        }
        // ha mar van beallitva, nem csinal semmit – lehetne bovitve singleton logikaval, hogy torolje a duplikatokat
    }

    // a Start metodus akkor fut le, amikor az objektum aktivva valik a jatek elejen
    private void Start()
    {
        // megjelenitjuk az aktualis pontszamot a feluleten, kezdetben ez 0
        _currentScoreText.text = $"{_score}";

        // beolvassuk es megjelenitjuk a legmagasabb pontszamot a PlayerPrefs-bol (ha nincs, akkor 0-t ad vissza)
        _highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }

    // ez a metodus frissiti a legmagasabb pontszamot, ha az aktualis pontszam nagyobb
    private void UpdateHighScore()
    {
        // osszehasonlitjuk az aktualis pontszamot a mentett legmagasabbal
        if (_score > PlayerPrefs.GetInt("HighScore"))
        {
            // ha nagyobb, elmentjuk az ujat
            PlayerPrefs.SetInt("HighScore", _score);

            // frissitjuk a feluleten is a szoveget
            _highScoreText.text = $"{_score}";
        }
    }

    // ez a metodus novel egyet az aktualis pontszamon es frissiti a megjelenitest es a rekordot
    public void UpdateScore()
    {
        _score++; // noveljuk az aktualis pontszamot eggyel

        // frissitjuk a feluleten az aktualis pontszamot
        _currentScoreText.text = $"{_score}";

        // megnezzuk, kell-e frissiteni a legmagasabb pontszamot
        UpdateHighScore();
    }

}
