using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{



    //public float timer;
    //public int newtarget;
    //public float speed;
    //public NavMeshAgent nav;
    //public Vector3 target;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    nav = gameObject.GetCompoment<NavMeshAgent>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += timer.deltaTime;
    //    if(timer >= newtarget)
    //    {
    //        newtarget();
    //        timer = 0;

    //    }

    //}
    //void newTarget()
    //{
    //    float myX = gameObject.transform.position.x;
    //    float myZ = gameObject.transform.position.z;

    //    float xPos = myX + Random.Range(myX - 100, myX + 100);
    //    float ZPos = myZ + Random.Range(myZ - 100, myZ + 100);

    //    Target = new Vector3(xPos, gameObject.transform.position.y, ZPos);
    //    nav.SetDestination(Target);
    //}
    //------------------------------------------------------------------------
    //public Transform[] movePoints;
    //public float speed;
    //private int amount;
    //private Transform currentTarget;
    //private float timer = 0f;




    //void Start()
    //{
    //    transform.Translate(0, 0, 2);
    //    //    randoming();
    //}

    //void Update()
    //{
    //    Movement();
    //    timer += Time.deltaTime;
    //    if (timer > 5.05f)
    //    {
    //        randoming();
    //        timer = 0f;
    //    }
    //}

    //void randoming()
    //{
    //    amount = Random.Range(0, movePoints.Length);
    //    currentTarget = movePoints[amount];
    //}

    //void Movement()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

    //transform.position = new Vector3(3, 0, 1);

    //    transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
    //}
    [SerializeField] private List<Vector3> waypoints = new List<Vector3>();  // Hom many items you want, will show in Inspector
    public float speed;

    private int current = 0;
    private float WPradius = 1;

    private void Start()
    {
        GetRandom();
    }

    private void Update()
    {
        MoveBetweenWaypoints();
    }

    private void GetRandom()
    {
        for (int i = 0; i < 30; i++)
        {
            waypoints.Add(new Vector3(Random.Range(transform.position.x, transform.position.x + 3f),
                Random.Range(transform.position.y, transform.position.y + 3f),
                transform.position.z));
        }
    }

    private void MoveBetweenWaypoints()
    {
        if (Vector3.Distance(waypoints[current], transform.position) < WPradius)

        {
            transform.Rotate(0.0f, 90.0f, .0f, Space.Self);
            current = Random.Range(0, waypoints.Count);
            if (current >= waypoints.Count)
            {
                
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current], Time.deltaTime * speed);
       
    }

}

