/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 15, 2023
 * Last Updated: April 2, 2023
 * Description: This class is push any game object.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PushableObject : MonoBehaviour
{
    [Header("Form")]
    [SerializeField] private Form m_requiredForm;

    [Header("Intractable")]
    [SerializeField] private InteractableOjbects m_objectType;

    [Header("Pit Trap Data")]
    [SerializeField] private bool m_destroyOnceUsed;

    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;

    //Components
    private Rigidbody2D m_rigidBody2D;

    #region Unity Methods
    private void Awake()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D a_collision)
    {
        //Pit Trap
        if (a_collision.collider.gameObject.TryGetComponent(out TrapObject a_trapObject))
        {
            if (a_trapObject.GetObjectType() == m_objectType)
            {
                a_trapObject.Interact();

                if (m_destroyOnceUsed)
                {
                    Destroy(gameObject);
                }
            }
        }

        //Movement the block
        else if (a_collision.gameObject.TryGetComponent(out CharacterFormsController a_formController))
        {
            if (a_formController.currForm == m_requiredForm)
            {
                m_rigidBody2D.mass = 10;

                m_soundEffectUnityEvent?.Invoke();
            }
            else
            {
                m_rigidBody2D.mass = float.MaxValue;
            }
        }
    }
    #endregion
}
