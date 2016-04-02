using Chronos;
using UnityEngine;

namespace Hackathon
{
    public class Puppeteer : MonoBehaviour
    {
        [SerializeField]
        private float lifetime = 10;

        private const float rewindSpeed = 1f;
        private Clock clock;

        private void Start()
        {
            clock = Timekeeper.instance.Clock("Root");
        }

        private void Update()
        {
            bool beforeZero = clock.time < 0;
            bool afterEnd = clock.time > lifetime;

            if (!afterEnd && !RewindIsPressed())
            {
                clock.localTimeScale = 1f;
            }
            else if (!beforeZero && RewindIsPressed())
            {
                clock.localTimeScale = -rewindSpeed;
            }
            else if (beforeZero || afterEnd)
            {
                clock.localTimeScale = 0;
            }
        }

        private bool RewindIsPressed()
        {
            return Input.GetMouseButton(1) || Input.GetKey(KeyCode.Space);
        }
    }
}