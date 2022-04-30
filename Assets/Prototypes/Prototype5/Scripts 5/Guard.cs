using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Proto5
{

    public class Guard : GameBehaviour
    {
        public static event System.Action OnGuardHasSpottedPlayer;

        //public float speed = 5f;
        //public float waitTime = .3f;
        //public float turnSpeed = 90;
        float timeToSpotPlayer = 1f;

        public Light spotlight;
        public float viewDistance;
        public LayerMask viewMask;

        float viewAngle;
        float playerVisibleTimer;

        public Transform pathHolder;
        Transform player;
        Color originalSpotlightColor;

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;


        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            viewAngle = spotlight.spotAngle;
            originalSpotlightColor = spotlight.color;


            //Vector3[] waypoints = new Vector3[pathHolder.childCount];
            //for (int i = 0; i < waypoints.Length; i++)
            //{
            //    waypoints[i] = pathHolder.GetChild(i).position;
            //    waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
            //}

            //StartCoroutine(FollowPath(waypoints));

            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            //agent.autoBraking = false;

            GotoNextPoint();
        }

        private void Update()
        {
            if (CanSeePlayer())
            {
                playerVisibleTimer += Time.deltaTime;
            }
            else
            {
                playerVisibleTimer -= Time.deltaTime;
            }
            playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
            spotlight.color = Color.Lerp(originalSpotlightColor, Color.red, playerVisibleTimer / timeToSpotPlayer);

            if (playerVisibleTimer >= timeToSpotPlayer)
            {
                if (OnGuardHasSpottedPlayer != null)
                {
                    OnGuardHasSpottedPlayer();
                }
            }

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        bool CanSeePlayer()
        {
            if (Vector3.Distance(transform.position, player.position) < viewDistance)
            {
                Vector3 dirToPlayer = (player.position - transform.position).normalized;
                float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
                if (angleBetweenGuardAndPlayer < viewAngle / 2f)
                {
                    if (!Physics.Linecast(transform.position, player.position, viewMask))
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        //IEnumerator FollowPath(Vector3[] waypoints)
        //{
        //    transform.position = waypoints[0];

        //    int targetWaypointIndex = 1;
        //    Vector3 targetWayPoint = waypoints[targetWaypointIndex];
        //    transform.LookAt(targetWayPoint);

        //    while (true)
        //    {
        //        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
        //        if(transform.position == targetWayPoint)
        //        {
        //            targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
        //            targetWayPoint = waypoints[targetWaypointIndex];
        //            yield return new WaitForSeconds(waitTime);
        //            yield return StartCoroutine(TurnToFace(targetWayPoint));
        //        }
        //        yield return null;
        //    }
        //}

        //IEnumerator TurnToFace(Vector3 lookTarget)
        //{
        //    Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        //    float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        //    while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05)
        //    {
        //        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
        //        transform.eulerAngles = Vector3.up * angle;
        //        yield return null;
        //    }
        //}

        private void OnDrawGizmos()
        {
            //Vector3 startPosition = pathHolder.GetChild(0).position;
            //Vector3 previousPosition = startPosition;

            //foreach (Transform waypoint in pathHolder)
            //{
            //    Gizmos.DrawSphere(waypoint.position, .3f);
            //    Gizmos.DrawLine(previousPosition, waypoint.position);
            //    previousPosition = waypoint.position;
            //}
            //Gizmos.DrawLine(previousPosition, startPosition);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
        }
    }
}