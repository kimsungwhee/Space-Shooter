using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public GameObject m_hazard;
		public Vector3 m_spawnValues;
		public int m_hazardCount;
		public float m_hazardWait;
		public float m_starWait;
		public float m_waveWait;
		// Use this for initialization
		void Start ()
		{
				StartCoroutine ("SpawnWaves");
		}

		IEnumerator SpawnWaves(){
				yield return new	WaitForSeconds (m_starWait);
				while (true) {
						for (int i = 0; i < m_hazardCount; ++i) {
								Vector3 spawnPosition = new Vector3 (Random.Range (-m_spawnValues.x, m_spawnValues.x), m_spawnValues.y, m_spawnValues.z);
								Quaternion spawnRotation = Quaternion.identity;
								Instantiate (m_hazard, spawnPosition, spawnRotation);
								yield return new	WaitForSeconds (m_hazardWait);
						}
						yield return new WaitForSeconds (m_waveWait);
				}
		}
}
