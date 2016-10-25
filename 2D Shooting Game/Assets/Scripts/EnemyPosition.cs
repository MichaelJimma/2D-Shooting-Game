/*
 EnemyPosition.cs
 Author:Michael Jimma
 Last Modified by: Michael Jimma
 Date last Modified 206-10-24
 Program description: This is a utility to draw the rectangle boundary in design mode
 */

using UnityEngine;
using System.Collections;

public class EnemyPosition : MonoBehaviour
{

	void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
