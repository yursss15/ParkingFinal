using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.Instance.PlayGame();
    }

    public void WinGame()
    {
        GameManager.Instance.WinGame();
    }

    public void LoseGame()
    {
        GameManager.Instance.LoseGame();
    }
}
