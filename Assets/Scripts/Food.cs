using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "SnakeHard")
        {
            if (this.transform.position == GameObject.Find("WoodBox").transform.position)
            {
                RandomizePosition();
            }
            if (this.transform.position == GameObject.Find("WoodBox1").transform.position)
            {
                RandomizePosition();
            }
            if (this.transform.position == GameObject.Find("WoodBox2").transform.position)
            {
                RandomizePosition();
            }
            if (this.transform.position == GameObject.Find("WoodBox3").transform.position)
            {
                RandomizePosition();
            }
            if (this.transform.position == GameObject.Find("WoodBox4").transform.position)
            {
                RandomizePosition();
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            RandomizePosition();
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
