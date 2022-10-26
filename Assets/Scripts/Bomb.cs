using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    public AudioSource audioSource;
    public CameraShake cameraShake;
    public BombShakeEnable bombShakeEnable;
    public AudioClip clip;
    public float volume = 0.3f;
    public BoxCollider2D gridAreaBomb;
    public LayerMask mask;
    public GameObject explosionPrefab;
    public bool BombStatus = false;
    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        RandomizePosition();
    }
    float timePassed = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite nativeSprite;
    public Sprite newSprite;
    public Sprite oldSprite;
    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    void ChangeSprite2(Sprite oldSprite)
    {
        spriteRenderer.sprite = oldSprite;
    }
    void ChangeSprite3(Sprite nativeSprite)
    {
        spriteRenderer.sprite = nativeSprite;
    }
    public void Explode(int x, int y)
    {
        Instantiate(explosionPrefab, this.transform.position + new Vector3Int(x, y, 0), Quaternion.identity);
    }
    public bool BombShakeStatus = true;
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 4.3f)
        {
            ChangeSprite(newSprite);
        }
        if (timePassed > 4.4f)
        {
            ChangeSprite(oldSprite);
        }
        if (timePassed > 4.5f)
        {
            ChangeSprite(newSprite);
        }
        if (timePassed > 4.6f)
        {
            ChangeSprite(oldSprite);
        }
        if (timePassed > 4.7f)
        {
            ChangeSprite(newSprite);
        }
        if (timePassed > 4.8f)
        {
            ChangeSprite(oldSprite);
        }
        if (timePassed > 4.9f)
        {
            ChangeSprite(newSprite);
        }
        if (timePassed > 5f)
        {
            if (BombStatus == false)
            {
                ChangeSprite(newSprite);
                BombStatus = true;
                if (PlayerPrefs.GetInt("BombStatus") == 0)
                {
                    StartCoroutine(cameraShake.Shake(.15f, .4f));
                }
                audioSource.PlayOneShot(clip, volume);
                for (int i = -3; i < 4; i++)
                {
                    Explode(i, 0);
                }
                for (int i = -3; i < 0; i++)
                {
                    Explode(0, i);
                }
                for (int i = 1; i < 4; i++)
                {
                    Explode(0, i);
                }
            }
        }
        if (timePassed > 5.5f)
        {
            ChangeSprite3(nativeSprite);
            RandomizePosition();
            timePassed = 0f;
            BombStatus = false;
            for (int i = 0; i < 13; i++)
            {
                DestroyImmediate(GameObject.Find("Explosion(Clone)"), true);
            }
        }
    }
    public void RandomizePosition()
    {
        Bounds bounds = this.gridAreaBomb.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Explosion" || other.tag == "Obstacle") 
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}