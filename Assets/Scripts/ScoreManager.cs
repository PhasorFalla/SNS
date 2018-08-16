using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int coinCount;
    public Text coinCountText;
    public Text coinCountResult;

    public int deathCount;
    public Text deathCountText;
    public Text deathCountResult;


    public static ScoreManager scoreManager;

    public void Start()
    {
        scoreManager = this;

        if(scoreManager != this) { Destroy(this); }

        deathCountText.text = "0";
        coinCountText.text = "0 /50";
        coinCountResult.text = coinCount.ToString();
        deathCountResult.text = deathCount.ToString();
    }

    public void CollectCoin()
    {
        coinCount++;
        coinCountText.text = coinCount.ToString() + " /50";
        coinCountResult.text = coinCount.ToString();

    }

    public void UseCoin(int cost)
    {
        coinCount -= cost;
    }

    public void DeathCount()
    {
        deathCount++;
        deathCountText.text = deathCount.ToString();
        deathCountResult.text = deathCount.ToString();
    }

}
