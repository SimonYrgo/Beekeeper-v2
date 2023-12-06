using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public TMP_Text healthText;

    private int score = 0;

    private int health = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        healthText.text = health.ToString();
    }

    public void AddCoins(int coinValue)
    {
        score = score + coinValue;
    }

    public void playerDamage(int damageTaken)
    {
        health = health - damageTaken;

        if (health ==  0) 
        {
            SceneManager.LoadScene(3);
                
        }
    }

    public void playerHeal(int healTaken)
    {
        health = health + healTaken;

    }



}