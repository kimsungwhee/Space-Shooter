using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour
{
		public float m_lifeTime;
		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, m_lifeTime);
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
}
