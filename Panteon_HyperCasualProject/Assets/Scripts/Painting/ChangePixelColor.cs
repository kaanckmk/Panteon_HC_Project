using System;
using UnityEngine;



[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]
public class ChangePixelColor : MonoBehaviour
{
    private Collider _collider;
    private Renderer _renderer;
    
    void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();
    }
    private void OnGUI()
    {
        Event evt = Event.current;
        if (evt.isMouse && Input.GetMouseButton (0))
        {
            // Send a ray to collide with the plane
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (_collider.Raycast (ray, out hit, Mathf.Infinity))
            {
                // Find the u,v coordinate of the Texture
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                // Paint it red
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<Renderer>().sharedMaterial.mainTexture;
                
                tex.SetPixel ((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.red);
                tex.Apply ();
            }
        }
    }
}