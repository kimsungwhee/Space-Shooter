using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
		public float m_xMin;
		public float m_xMax;
		public float m_zMin;
		public float m_zMax;
}

public class PlayerController : MonoBehaviour
{
		protected Rigidbody m_rigidbody;
		protected AudioSource m_audio;
		public float m_speed;
		public Boundary m_boundary;
		public float m_tilt;
		public float m_fireRate;
		protected float m_nextFire;
		public GameObject m_shot;
		public Transform m_shotSpawn;
		// Use this for initialization
		void Start ()
		{
				m_rigidbody = this.rigidbody;		
				m_audio = audio;	
		}

		void FixedUpdate ()
		{
				float moveH = Input.GetAxis ("Horizontal");//获取水平移动量
				float moveV = Input.GetAxis ("Vertical");//后去垂直移动量

				Vector3 movement = new Vector3 (moveH, 0.0f, moveV);

				m_rigidbody.velocity = movement * m_speed;

				m_rigidbody.position = new Vector3 (
						Mathf.Clamp (m_rigidbody.position.x, m_boundary.m_xMin, m_boundary.m_xMax),
						0.0f,
						Mathf.Clamp (m_rigidbody.position.z, m_boundary.m_zMin, m_boundary.m_zMax)
				);

				m_rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, m_rigidbody.velocity.x * m_tilt);
		}

		void Update ()
		{
				if (Time.time > m_nextFire) {
						m_nextFire = Time.time + m_fireRate;
						GameObject blot = Instantiate (m_shot, m_shotSpawn.position, m_shotSpawn.rotation) as GameObject;
						DestroyObject (blot, 2.0f);
						m_audio.Play ();
				}
		}
}
