using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.TryGetComponent(out ITriggerEnterAction _triggerEnter))
            {
                _triggerEnter.Enter();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.TryGetComponent(out ITriggerExitAction _triggerActions))
            {
                _triggerActions.Exit();
            }
        }
    }
}
