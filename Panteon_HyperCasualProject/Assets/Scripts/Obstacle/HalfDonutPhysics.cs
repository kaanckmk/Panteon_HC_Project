
using UnityEngine;

public class HalfDonutPhysics : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("here");
            other.transform.position = new Vector3(transform.position.x + 0.2f, other.transform.position.y, other.transform.position.z); 
        }
    }
}
