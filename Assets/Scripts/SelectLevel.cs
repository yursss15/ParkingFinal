using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public Text CountMoves;

    [Serializable]
    public struct Levels
    {
        public GameObject level;
        public int moves;
    }

    public Levels[] levels;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Game Level")) PlayerPrefs.SetInt("Game Level", 1);

        int gameLevel = PlayerPrefs.GetInt("Game Level");
        if (gameLevel > levels.Length) gameLevel = gameLevel % levels.Length;
        Levels now = levels[gameLevel - 1];
        now.level.SetActive(true);
        CountMoves.text = now.moves.ToString();
    }
}