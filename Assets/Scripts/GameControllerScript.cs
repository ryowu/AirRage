using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class GameControllerScript : MonoBehaviour
{
	private int score;
	public Text scoreText;
	public Text replayText;

	public GameObject SmallCurveEnemy;
	public GameObject SmallDirectEnemy;
	public GameObject MediumEnemyB17Type2;
	public GameObject MediumEnemyBF109EType1;
	public GameObject MediumEnemyBF109EType2;

	private bool isGameOver;


	private List<EnemySpawnTask> enemyList;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = false;

		enemyList = new List<EnemySpawnTask>();
		InitLevel1();

		StartCoroutine("SpawnEnemyEngine");

		score = 0;
		UpdateScoreText();
		replayText.text = "";
		isGameOver = false;
	}

	private void InitLevel1()
	{
		//StoryBoard
		//AddEnemyTask

		float topY = transform.position.y;
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.None, DelayTime = 3f });

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType2, Position = new Vector3(-2, topY), DelayTime = 2f });

		InitSmallPlaneEnemyTeam(2f);
		InitSmallPlaneEnemyTeam(-2f);

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType2, Position = new Vector3(-2, topY), DelayTime = 2f });

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType1, Position = new Vector3(-1, topY), DelayTime = 0 });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType1, Position = new Vector3(1, topY), DelayTime = 2f });

		InitSmallPlaneEnemyTeam(-2.5f);
		InitSmallPlaneEnemyTeam(2.5f);

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType1, Position = new Vector3(-1, topY), DelayTime = 0 });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType1, Position = new Vector3(1, topY), DelayTime = 2f });

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.BF109EType2, Position = new Vector3(-2, topY), DelayTime = 2f });

		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.B17Type2, Position = new Vector3(3, topY), DelayTime = 3f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.B17Type2, Position = new Vector3(0, topY), DelayTime = 3f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.B17Type2, Position = new Vector3(-3, topY), DelayTime = 2f });
	}

	private void InitSmallPlaneEnemyTeam(float x)
	{
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.SmallPlane, Position = new Vector3(x, transform.position.y), DelayTime = 0.5f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.SmallPlane, Position = new Vector3(x, transform.position.y), DelayTime = 0.5f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.SmallPlane, Position = new Vector3(x, transform.position.y), DelayTime = 0.5f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.SmallPlane, Position = new Vector3(x, transform.position.y), DelayTime = 0.5f });
		enemyList.Add(new EnemySpawnTask() { EnemyPlaneType = EnemyType.SmallPlane, Position = new Vector3(x, transform.position.y), DelayTime = 1f });
	}

	private IEnumerator SpawnEnemyEngine()
	{
		for (int i = 0; i < enemyList.Count; i++)
		{
			switch (enemyList[i].EnemyPlaneType)
			{
				case EnemyType.None:
					{
						break;
					}
				case EnemyType.SmallPlane:
					{
						Instantiate(SmallDirectEnemy, enemyList[i].Position, transform.rotation);
						//Random.Range(-6f, 6f), transform.position.y
						break;
					}
				case EnemyType.B17Type2:
					{
						Instantiate(MediumEnemyB17Type2, enemyList[i].Position, transform.rotation);
						break;
					}
				case EnemyType.BF109EType1:
					{
						Instantiate(MediumEnemyBF109EType1, enemyList[i].Position, transform.rotation);
						break;
					}
				case EnemyType.BF109EType2:
					{
						Instantiate(MediumEnemyBF109EType2, enemyList[i].Position, transform.rotation);
						break;
					}
				default:
					{
						break;
					}
			}
			yield return new WaitForSeconds(enemyList[i].DelayTime);
		}
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
