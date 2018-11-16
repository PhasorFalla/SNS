using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject bubble;
    public GameObject straps;
    public ParticleSystem gutParticle;
    public LineRenderer aimSight;
    public LineRenderer line;
    SpringJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public bool tethered;
    public AudioClip[] tetherSFX;
    public AudioClip bubblePopSFX;
    public bool aimAssist;
    private int lastSFX;
    Movement playerMovement;

    // Use this for initialization
    void Start()
    {
        aimSight.enabled = aimAssist;
        playerMovement = GetComponent<Movement>();
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
        line.enabled = false;
        straps.SetActive(true);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    public void LineAim()
    {
        if (!aimAssist) { return; }
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        aimSight.SetPosition(0, transform.position);
        aimSight.SetPosition(1, pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameController != null)
        {
            if (GameController.gameController.isPaused == true) { return; }

        }

        LineAim();
        straps.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if(hit.collider!=null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null && hit.collider.gameObject.tag != "Enemies")
            {
                joint.enabled = true;
                joint.connectedAnchor = hit.point;
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                playerMovement.timesJumped = 0;

                TetherShot();

                
            }
        }

        

        line.SetPosition(0, transform.position);

        if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            Detatch();
        }
        if (gameObject.transform.position.y > hit.point.y)
        {
            Detatch();
        }
    }

    public void TetherShot()
    {
        if (aimAssist) { aimSight.enabled = false; }
        if (bubblePopSFX != null) { AudioManager.audioManager.PlaySound(bubblePopSFX); }
        if (gutParticle != null) { gutParticle.Play(); }
        if (bubble != null) { bubble.SetActive(false); }
        tethered = true;

        int r = Random.Range(0, tetherSFX.Length);
        if(r == lastSFX)
        {
            r = Random.Range(0, tetherSFX.Length);
        }

        lastSFX = r;
        AudioManager.audioManager.PlaySound(tetherSFX[lastSFX]);
    }

    public void PlayerDeath()
    {
        Detatch();
        playerMovement.timesJumped = 1;
    }

    public void Detatch()
    {
        joint.enabled = false;
        line.enabled = false;
        if (aimAssist) { aimSight.enabled = true; }
        tethered = false;
        bubble.SetActive(true);
    }
}
