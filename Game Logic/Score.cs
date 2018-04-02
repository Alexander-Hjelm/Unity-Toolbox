using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The CreditCounter component maintains the player's current amount of credits
/// </summary>
public class Score : MonoBehaviour
{
	[SerializeField] private Text scoreText;	// Credits display text, set in ispector
	private int score = 0;					// Current credits

	void Update ()
	{
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int score)
	{
		this.score += score;
	}

}
