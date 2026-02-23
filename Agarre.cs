using JetBrains.Annotations;
using UnityEngine;

public class Agarre : MonoBehaviour
{
   
    public bool esAgarrable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
            AudioManager.Instance.Play2D("detectarobj");
        }
    }

    private void OntriggerExit(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
