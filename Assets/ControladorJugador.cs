using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float velocidad = 8.0f;
    public float velocidadRotacion = 120.0f;

    [Header("Ajustes de Salto y Gravedad")]
    public float fuerzaSalto = 12.0f;
    public float gravedad = 20.0f;

    private CharacterController controller;
    private Vector3 velocidadVertical = Vector3.zero;

    void Start()
    {
        // Obtiene el componente CharacterController asignado al jugador
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Rotación del jugador (Teclas A/D o Flechas Izquierda/Derecha)
        float giro = Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime;
        transform.Rotate(0, giro, 0);

        // 2. Movimiento hacia adelante y atrás (Teclas W/S o Flechas Arriba/Abajo)
        float avance = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        Vector3 movimiento = transform.forward * avance;

        // 3. Control de Gravedad y Salto (Tecla Espacio)
        if (controller.isGrounded)
        {
            // Resetear la velocidad de caída cuando toca el suelo
            if (velocidadVertical.y < 0)
            {
                velocidadVertical.y = -2f;
            }

            // Detectar si el jugador presiona Espacio para saltar
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
            {
                velocidadVertical.y = fuerzaSalto;
            }
        }

        // Aplicar la gravedad continuamente
        velocidadVertical.y -= gravedad * Time.deltaTime;

        // Mover el personaje combinando el avance horizontal y el movimiento vertical (salto/caída)
        controller.Move(movimiento + velocidadVertical * Time.deltaTime);
    }
}