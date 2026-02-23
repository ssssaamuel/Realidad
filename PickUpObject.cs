using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform ZonadeInteraccion;
    void Update()
    {
        if(ObjectToPickUp != null & ObjectToPickUp.GetComponent<Agarre>().esAgarrable == true && PickedObject == null)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<Agarre>().esAgarrable = false;
                PickedObject.transform.SetParent(ZonadeInteraccion);
                PickedObject.transform.position = ZonadeInteraccion.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        } else if (PickedObject)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PickedObject.GetComponent<Agarre>().esAgarrable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}
