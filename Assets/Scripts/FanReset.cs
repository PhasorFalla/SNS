using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FanReset : MonoBehaviour
{

    public Transform spawnpoint;
    public static FanReset deathzone;
    public AudioClip playerDeathSFX;
    private GameObject entityToReset;
    public GameController GC;
    public GameObject player;
    public bool finished;

    [HideInInspector]
    public bool dead;
    public GameObject hurtPanel;
    public GameObject deathPanel;
    public float speed = 7f;


    private void Awake()
    {
        if(deathzone == null)
        {
            deathzone = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entityToReset = collision.gameObject;
            ResetEntity(entityToReset);
        }
    }

    public void ResetEntity(GameObject entity)
    {
        GC.ResetScene();
        if(playerDeathSFX != null)
        {
            AudioManager.audioManager.PlaySound(playerDeathSFX);
        }

        if(entity.GetComponent<Rigidbody2D>() != null)
        {
            entity.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        dead = true;
        deathPanel.SetActive(true);
        hurtPanel.GetComponent<CanvasGroup>().alpha = 0;
        StartCoroutine(FadeHurt());
        ScoreManager.scoreManager.DeathCount();
        entity.transform.position = spawnpoint.position;
        entity.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    IEnumerator FadeHurt()
    {
        var fade = hurtPanel.GetComponent<CanvasGroup>();
        
        while(fade.alpha < 1)
        {
            fade.alpha += Time.deltaTime * speed;

            if (fade.alpha >= 1)
            {
                StartCoroutine(FadeOut());
                yield break;

            }
            yield return null;
        }
        
        
    }

    IEnumerator FadeOut()
    {
        var fade = hurtPanel.GetComponent<CanvasGroup>();

        while (fade.alpha > 0)
        {
            fade.alpha -= Time.deltaTime * speed;

            if (fade.alpha <= 0)
            {
                fade.alpha = 0;
                deathPanel.SetActive(false);
                yield break;

            }
            yield return null;
        }


    }

}
