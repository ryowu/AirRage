using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	private int score;
	public Text scoreText;
	public Text replayText;

	public GameObject SmallCurveEnemy;
	public GameObject SmallDirectEnemy;
	public GameObject MediumEnemyB17Type2;
	public GameObject MediumEnemyBF109E;
	public GameObject Cloud_0;

	private bool isGameOver;



	IEnumerator SpawnEnemy()
	{
		while (true)
		{
			Instantiate(
				SmallDirectEnemy,
				new Vector3(Random.Range(-6f, 6f), transform.position.y, 0f),
				transform.rotation
			);

			yield return new WaitForSeconds(1f);
		}
	}

	IEnumerator SpawnMediumEnemy()
	{
		while (true)
		{
			Instantiate(
							MediumEnemyB17Type2,
							new Vector3(Random.Range(-5f, 5f), transform.position.y, 0f),
							transform.rotation
						);

			yield return new WaitForSeconds(6f);
		}
	}


	IEnumerator SpawnBF109E()
	{
		while (true)
		{
			Instantiate(
							MediumEnemyBF109E,
							new Vector3(0, transform.position.y, 0f),
							transform.rotation
						);

			yield return new WaitForSeconds(3f);
		}
	}

	IEnumerator BuildCloud()
	{
		while (true)
		{
			Instantiate(
			Cloud_0,
			new Vector3(Random.Range(-6f, 6f), transform.position.y, 0f),
			transform.rotation
			);
			yield return new WaitForSeconds(4f);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine("SpawnEnemy");
		StartCoroutine("BuildCloud");
		StartCoroutine("SpawnMediumEnemy");

		StartCoroutine("SpawnBF109E");

		score = 0;
		UpdateScoreText();
		replayText.text = "";
		isGameOver = false;


	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space) && isGameOver)
		{
			SceneManager.LoadScene("MainScene");
		}
	}

	public void AddScore(int scoreToAdd)
	{
		score += scoreToAdd;
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		replayText.text = "Hit SPACE to replay!";
		isGameOver = true;
	}
}
