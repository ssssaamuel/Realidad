using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public float Empuje = 5.0f;
    private float obtenerMasa;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody objeto = hit.collider.attachedRigidbody;

        if (objeto == null || objeto.isKinematic) {
        
            return;
        }
        if (hit.moveDirection.y < -0.3)
        {
        return;    
         }
        obtenerMasa = objeto.mass;
        Vector3 empujerDir = new Vector3(hit.moveDirection.x,0,hit.moveDirection.z);

        objeto.linearVelocity = empujerDir * Empuje / obtenerMasa;
    }
}
