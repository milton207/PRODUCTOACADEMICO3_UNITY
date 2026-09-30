using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    [Header("Ajustes del Objeto")]
    public float velocidadRotacion = 100.0f;

    void Update()
    {
        // El objeto gira continuamente para llamar la atención del jugador
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el objeto que lo toca es el Jugador o una de sus partes
        if (other.CompareTag("Player") || other.GetComponentInParent<ControladorJugador>() != null)
        {
            Debug.Log("¡Objeto recolectado con éxito!");

            // Destruye el objeto interactivo de la escena
            Destroy(gameObject);
        }
    }
}