using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
		public float m_speed;
		// Use this for initialization
		void Start ()
		{
				rigidbody.velocity = transform.forward * m_speed;
		}
}
