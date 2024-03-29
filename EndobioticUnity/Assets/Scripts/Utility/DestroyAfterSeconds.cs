/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 16, 2023
 * Last Updated: April 2, 2023
 * Description: This utility class is for destroy any game object after couple of seconds.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    #region Class Variables
    [Header("Duration Data")]
    [SerializeField] private float m_duration;
    #endregion

    #region Unity Methods
    void Start()
    {
        StartCoroutine(destroyAfter(m_duration));
    }
    #endregion

    #region Destroy After Methods
    private IEnumerator destroyAfter(float a_duration)
    {
        yield return new WaitForSeconds(a_duration);

        Destroy(this.gameObject);
    }
    #endregion
}
