using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    private Transform currentTarget; // El objetivo actual al que se mueve el NPC
    [SerializeField] private NavMeshAgent agent; // Referencia al NavMeshAgent

    private void Start()
    {
        if (agent == null)
        {
            Debug.LogError("No se encontró un componente NavMeshAgent en el NPC.");
            return;
        }

        // Establece el primer objetivo
        currentTarget = target1;
        agent.SetDestination(currentTarget.position);
    }

    private void Update()
    {
        // Verifica si el NPC ha llegado al objetivo actual
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // Cambia el objetivo al otro target
            currentTarget = currentTarget == target1 ? target2 : target1;
            agent.SetDestination(currentTarget.position);
        }
    }
}
