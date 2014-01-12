using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{
		public GameObject m_explosion;
		public GameObject m_playerExplosion;
		void OnTriggerEnter (Collider other)
		{
				Instantiate (m_explosion, transform.position, transform.rotation);
				if (other.tag == "Player") {
						Instantiate (m_playerExplosion, other.transform.position, other.transform.rotation);
				}
				DestroyObject (other.gameObject);
				Destroy (gameObject);
		}
}
