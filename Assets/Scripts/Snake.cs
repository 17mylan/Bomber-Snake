using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
public class Snake : MonoBehaviour
{
    ScoreManager scoreManager;
    ScoreManagerHard scoreManagerHard;
    public int Score = 0;
    public int BestScore;
    public int ScoreHard = 0;
    public int BestScoreHard;
    public Vector2 _direction = Vector2.right;
    public List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    private float shakeTimeRemaining, shakePower;
    public void Start()
    {
        ResetState();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Snake")
        {
            scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.Score = PlayerPrefs.GetInt("Score", 0);
            scoreManager.BestScore = PlayerPrefs.GetInt("BestScore", scoreManager.BestScore);
        }
        else
        {
            scoreManagerHard = FindObjectOfType<ScoreManagerHard>();
            scoreManagerHard.ScoreHard = PlayerPrefs.GetInt("ScoreHard", 0);
            scoreManagerHard.BestScoreHard = PlayerPrefs.GetInt("BestScoreHard", scoreManagerHard.BestScoreHard);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }
    public void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    public void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);
        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }
        this.transform.position = Vector3.zero;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Snake")
            {
                scoreManager.Score++;
                PlayerPrefs.SetInt("Score", Score);
                if (scoreManager.Score > scoreManager.BestScore)
                {
                    scoreManager.BestScore = scoreManager.Score;
                    scoreManager = FindObjectOfType<ScoreManager>();
                    PlayerPrefs.SetInt("BestScore", scoreManager.BestScore);
                    audioSource.PlayOneShot(clip, volume);
                }
            }
            else
            {
                scoreManagerHard.ScoreHard++;
                PlayerPrefs.SetInt("ScoreHard", ScoreHard);
                if (scoreManagerHard.ScoreHard > scoreManagerHard.BestScoreHard)
                {
                    scoreManagerHard.BestScoreHard = scoreManagerHard.ScoreHard;
                    scoreManagerHard = FindObjectOfType<ScoreManagerHard>();
                    PlayerPrefs.SetInt("BestScoreHard", scoreManagerHard.BestScoreHard);
                    audioSource.PlayOneShot(clip, volume);
                }
            }
        }
        else if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}