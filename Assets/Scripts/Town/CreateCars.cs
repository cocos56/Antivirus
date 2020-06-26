using UnityEngine;

namespace town
{
	public class TestRandom : MonoBehaviour {
		GameObject pointParent;
		Vector3[]points;
		GameObject cloneobj;
		public GameObject player;
		public GameObject[]players;
		float time;
		float timerate=2f;
		// Use this for initialization
		void Start () {
			pointParent = GameObject.Find ("PointParent");
			//points.Length = pointParent.transform.childCount;//属性是只读的
			points = new Vector3[pointParent.transform.childCount];
			for (int i = 0; i < points.Length; i++) {//初始化数组
				points[i]=pointParent.transform.GetChild(i).transform.position;
			}
			time = Time.time;
		}
	
		// Update is called once per frame
		void Update () {
			if (Time.time>time) 
			{
				int random_point_index=Random.Range(0,points.Length);
				Vector3 clonePos=points[random_point_index];
				
				time=Time.time+timerate;
				int random_player_index=Random.Range(0,players.Length);
				GameObject clone_prefab=players[random_player_index];
				cloneobj=GameObject.Instantiate(clone_prefab,clonePos,clone_prefab.transform.rotation) as GameObject;
			}
			if (Input.GetKeyDown(KeyCode.A)) {
				if (cloneobj!=null) {
					cloneobj.transform.Translate(Vector3.left*0.1f,Space.Self);			
				}
			}
		}
	}
}
