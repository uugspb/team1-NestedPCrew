using UnityEngine;

namespace Hackathon
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer crosshair;
        [SerializeField]
        private SpriteRenderer dot;
        [SerializeField]
        private LayerMask geometryMask;

        private const float offset = 0.01f;
        private const int raycastDistance = 100;
        private const float minDistance = 1;
        private const float defaultDistance = 20;
        private const float maxDistance = 50;

        private Transform tr;
        private Transform cameraTransform;

        private void Start()
        {
            tr = transform;
            cameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            tr.position = cameraTransform.position;
            tr.rotation = cameraTransform.rotation;

            RaycastHit hit;
            if (RaycastGeometry(tr.position, tr.forward, out hit))
            {
                UpdateCrosshair(hit.point, hit.normal);
                SetCrosshairActive(true);
            }
            else
            {
                SetCrosshairActive(false);
            }
        }

        private void UpdateCrosshair(Vector3 point, Vector3 normal)
        {
            var position = point + normal*offset;
            var rotation = Quaternion.LookRotation(normal);
            SetPositionAndRotation(position, rotation);
        }

        private void SetCrosshairActive(bool active)
        {
            crosshair.enabled = active;
            dot.enabled = !active;
            if (!active)
            {
                SetPositionAndRotation(crosshair.transform.position, Quaternion.LookRotation(-tr.forward));
            }
        }

        private void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            var toPosition = position - tr.position;
            if (toPosition.magnitude < minDistance || toPosition.magnitude > maxDistance)
            {
                position = tr.position + toPosition.normalized*defaultDistance;
            }
            crosshair.transform.position = position;
            crosshair.transform.rotation = rotation;
            dot.transform.position = position;
            dot.transform.rotation = rotation;
        }

        private bool RaycastGeometry(Vector3 position, Vector3 forward, out RaycastHit raycastHit)
        {
            return Physics.Raycast(position, forward, out raycastHit, raycastDistance, geometryMask,
                QueryTriggerInteraction.Collide);
        }
    }
}