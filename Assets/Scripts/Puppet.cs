using UnityEngine;

namespace Hackathon
{
    public class Puppet : TimeBehaviour
    {
        [SerializeField]
        private Transform[] wayPoints;

        private new Animation animation;

        protected virtual void Awake()
        {
            animation = GetComponent<Animation>();
        }

        protected virtual void Start()
        {
            timeline.Do(true,
                forward: () => { animation.Play(); },
                backward: () => { });
        }

        public void Position(float normalizedPos)
        {
            if(wayPoints.Length == 0)
                return;
            Transform secondClosestPoint = wayPoints[0];
            Transform closestPoint = wayPoints[0];

            for (int i = 1; i < wayPoints.Length; i++)
            {
                if ((wayPoints[i].position - transform.position).magnitude < (closestPoint.position - transform.position).magnitude)
                {
                    secondClosestPoint = closestPoint;
                    closestPoint = wayPoints[i];
                }
            }

            
        }
    }
}