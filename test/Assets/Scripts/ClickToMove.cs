using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator m_Anim;

    private bool m_Running = false;

    private NavMeshAgent m_Agent;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                m_Agent.destination = hit.point;
            }
        }
        if(m_Agent.remainingDistance <= m_Agent.stoppingDistance)
        {
            m_Running = false;
        }
        else
        {
            m_Running = true;
        }

        m_Anim.SetBool("running", m_Running);


      /*{
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                m_Agent.destination = m_HitInfo.point;
        }*/
    }
}
