using UnityEngine;

namespace Hackathon
{
    public class Enabler : TimeBehaviour
    {
        public float time;
        public GameObject target;

        private void Start()
        {
            target.SetActive(false);
            timeline.Plan(time, false, () => { target.SetActive(true); }, () => { });
        }
    }
}