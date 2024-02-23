using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject Ferana; // Asigna la referencia del jugador en el inspector
    public float pushSpeed = 5f; // Velocidad a la que el objeto se moverá
    public float pushDistance = 10f; // Distancia que el objeto se moverá
    private Vector3 targetPosition; // La posición objetivo hacia donde se moverá el objeto
    private bool isMoving = false; // Controla si el objeto está en movimiento
    private float interactionDistance = 4f;
    private Vector3 initialPosition; // Almacena la posición inicial del objeto
    public float maxMovementDistance = 20f; // La distancia máxima que el objeto puede moverse

    void Start()
    {
        initialPosition = transform.position; // Almacena la posición inicial del objeto
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isMoving && IsPlayerClose() && Ferana.activeInHierarchy && CanMoveFurther()) // Verifica si Ferana está activo y si el objeto puede moverse más lejos
        {
            Vector3 directionToPlayer = transform.position - Ferana.transform.position; // Calcula la dirección correcta desde el objeto al jugador
            Vector3 moveDirection = GetOppositeDirection(directionToPlayer); // Obtiene la dirección opuesta en términos cardinales

            targetPosition = transform.position + (moveDirection * pushDistance);
            isMoving = true; // Comienza el movimiento
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            MoveObjectTowards(targetPosition);
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false; // Detiene el movimiento
            }
        }
    }

    Vector3 GetOppositeDirection(Vector3 direction)
    {
        direction = direction.normalized;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return direction.x > 0 ? Vector3.right : Vector3.left;
        }
        else
        {
            return direction.y > 0 ? Vector3.up : Vector3.down;
        }
    }

    void MoveObjectTowards(Vector3 targetPos)
    {
        float step = pushSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }

    bool IsPlayerClose()
    {
        return Vector3.Distance(transform.position, Ferana.transform.position) <= interactionDistance;
    }

    bool CanMoveFurther()
    {
        // Verifica si el objeto ya ha recorrido la distancia máxima permitida desde su posición inicial
        return Vector3.Distance(transform.position, initialPosition) < maxMovementDistance;
    }
}
