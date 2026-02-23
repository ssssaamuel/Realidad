using Unity.VisualScripting;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float Gravedad = -10f;
    public float FuerzaSalto = 3f;
    

    public Transform EnElPiso;
    public float Distanciadelpiso;
    public LayerMask Piso;

    Vector3 VelocidadCaida;
    bool EstaenelPiso;

    public Camera mainCamara;
    public Vector3 camForward;
    public Vector3 camRight;
    public Vector3 moveJugador;
    public Vector3 mover;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EstaenelPiso = Physics.CheckSphere(EnElPiso.position, Distanciadelpiso, Piso);
        if (EstaenelPiso && VelocidadCaida.y < 0)
        { 
        VelocidadCaida.y = 2; 
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mover = new Vector3(x, 0, z);
        moveJugador = Vector3.ClampMagnitude(moveJugador, 1);
        moveJugador = mover.x * camRight + mover.z * camForward;
        Controlador.Move(mover*Velocidad * Time.deltaTime);
        Controlador.transform.LookAt(Controlador.transform.position + moveJugador);

        if (Input.GetButtonDown("Jump")&&EstaenelPiso)
        {
            VelocidadCaida.y = Mathf.Sqrt(FuerzaSalto * -2f * Gravedad);
        }
        VelocidadCaida.y += Gravedad * Time.deltaTime;
        Controlador.Move(VelocidadCaida * Time.deltaTime);
        DireccionCamara();

    }
    void DireccionCamara()
    {
        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
