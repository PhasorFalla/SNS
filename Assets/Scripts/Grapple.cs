using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject bubble;
    public LineRenderer line;
    SpringJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public bool tethered;
    public AudioClip tetherSFX;
    public AudioClip bubblePopSFX;
    
    Movement playerMovement;

    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<Movement>();
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
        line.enabled = false;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    // Update is called once per frame
    void Update()
    {
       
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


                tethered = true;

                if(bubble != null) { bubble.SetActive(false); }

                if (tetherSFX != null) { AudioManager.audioManager.PlaySound(tetherSFX); }
                if(bubblePopSFX != null) { AudioManager.audioManager.PlaySound(bubblePopSFX); }

                playerMovement.timesJumped = 0;
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

    public void Detatch()
    {
        joint.enabled = false;
        line.enabled = false;
        tethered = false;
        bubble.SetActive(true);
    }
}
