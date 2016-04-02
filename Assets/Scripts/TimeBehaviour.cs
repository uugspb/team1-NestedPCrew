using UnityEngine;
using Chronos;

namespace Hackathon
{
    [RequireComponent(typeof (Timeline))]
    public class TimeBehaviour : MonoBehaviour
    {
        private Timeline cachedTimeline;

        public Timeline timeline { get { return cachedTimeline ?? (cachedTimeline = GetComponent<Timeline>()); } }
    }
}