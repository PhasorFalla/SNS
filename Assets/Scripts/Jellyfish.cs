using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    public float timer;

    public Transform[] path;
    public float speed = 5.0f;
    public float reachDist = 1.0f;
    public int targetIndex = 0;
    bool arrived;

    private Transform target;
    private int ArrayDirection = 1;

    public AudioClip deathSFX;
    public ParticleSystem deathVFX;
    bool move;
    Animator anim;

    private void Start()
    {
        target = path[0];
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Direction", true);
        StartCoroutine(MoveTimer());

    }

    private void Update()
    {
        for (int i = 1; i < path.Length; i++)
        {
            Debug.DrawLine(path[i].position, path[i - 1].position, Color.yellow);
        }
    }

    public void SetNextPoint()
    {
        if (targetIndex >= path.Length - 1)
        {
            ArrayDirection = -1;
        }

        else if (targetIndex <= 0)
        {
            ArrayDirection = 1;
        }

        

        targetIndex += ArrayDirection;
        
        target = path[targetIndex];
        arrived = false;
        if (targetIndex == 0)
        {
            anim.SetBool("Direction", true);
            StartCoroutine(MoveTimer());
        }
        else
        {
            anim.SetBool("Direction", false);
            StopAllCoroutines();
            StartCoroutine(MoveToPoint(target));
        }
        //StartCoroutine(MoveToPoint(target));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Grapple>().Detatch();
            FanReset.deathzone.ResetEntity(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.GetComponent<Grapple>().tethered)
            {
                other.gameObject.GetComponent<Grapple>().Detatch();
                FanReset.deathzone.ResetEntity(other.gameObject);

            }
            else
            {

                EnemyDeath();
            }




        }
    }

    public void EnemyDeath()
    {
        if (deathSFX != null)
        {
            AudioManager.audioManager.PlaySound(deathSFX);
        }
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    public IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(MoveToPoint(target));
        anim.enabled = true;
        yield return new WaitForSeconds(timer);
        StopAllCoroutines();
        StartCoroutine(MoveTimer());

    }

    IEnumerator MoveToPoint(Transform point)
    {
        while (!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed / 100f);
            if (Vector3.Distance(transform.position, point.position) < 0.1)
            {
                arrived = true;
                SetNextPoint();
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }



}
