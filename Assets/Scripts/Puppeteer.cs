using Chronos;
using UnityEngine;

namespace Hackathon
{
    public class Puppeteer : MonoBehaviour
    {
        [SerializeField]
        private float lifetime = 10;

        private const float minMovMagnitudeMouse = 25.0f;
        private const float rewindSpeed = 1f;

        private Clock clock;
        private Vector3 mousePosition;

        private bool beforeZero { get { return clock.time <= 0; } }
        private bool afterLifetime { get { return clock.time >= lifetime; } }

        private void Start()
        {
            clock = Timekeeper.instance.Clock("Root");
        }

        private void Update()
        {
            if (Application.isEditor)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Rewind();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Play();
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    Pause();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mousePosition = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    mousePosition -= Input.mousePosition;
                    HandleInput(ref mousePosition);
                }
            }

            if (beforeZero)
            {
                Play();
            }
            else if (afterLifetime)
            {
                Rewind();
            }
        }

        private void Rewind()
        {
            if (beforeZero) return;

            clock.localTimeScale = -rewindSpeed;
        }

        private void Play()
        {
            clock.localTimeScale = 1f;
        }

        private void Pause()
        {
            clock.localTimeScale = 0;
        }

        private void OnTap()
        {
            if (clock.localTimeScale == 0)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }

        private void OnSwipeLeft()
        {
            Rewind();
        }

        private void OnSwipeRight()
        {
            Play();
        }

        private void OnSwipeDown()
        {
        }

        private void OnSwipeUp()
        {
        }

        private void HandleInput(ref Vector3 move)
        {
            if (move.magnitude < minMovMagnitudeMouse)
            {
                OnTap();
            }
            else
            {
                move.Normalize();

                if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
                {
                    if (move.x > 0.0f)
                    {
                        OnSwipeRight();
                    }
                    else
                    {
                        OnSwipeLeft();
                    }
                }
                else
                {
                    if (move.y > 0.0f)
                    {
                        OnSwipeUp();
                    }
                    else
                    {
                        OnSwipeDown();
                    }
                }
            }
        }
    }
}