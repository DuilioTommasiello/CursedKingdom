using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler_Follow : StateMachineBehaviour
{
    [SerializeField] private float velocityMovment;
    [SerializeField] private float baseTempo;

    private float followTime;

    private Transform player;
    private AiFollow crawler;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        crawler = animator.gameObject.GetComponent<AiFollow>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, velocityMovment * Time.deltaTime);
        crawler.Turnx(player.position);
        crawler.TurnY(player.position);
        followTime -= Time.deltaTime;
        if (followTime <= 0)
        {
            animator.SetTrigger("Volver");
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
