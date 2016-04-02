using UnityEngine;

namespace Hackathon
{
    public class Cone : MonoBehaviour
    {
        public void Place(Vector3 start, Vector3 end, float size)
        {
            transform.position = start;
            Vector3 toEnd = end - start;
            float z = toEnd.magnitude;
            transform.localScale = new Vector3(size, size, z);
            transform.rotation = Quaternion.LookRotation(-toEnd);
        }
    }
}