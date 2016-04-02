using UnityEngine;

namespace Hackathon
{
    public class Puppet : TimeBehaviour
    {
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
    }
}