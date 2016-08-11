using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class controll : MonoBehaviour {

	private double ddY = 0; 
	private Vector3 middlePoint = new Vector3(50,50,50);
	private Vector3 movePoint = new Vector3(50,50,50);

	// Use this for initialization
	void Start () {

		StreamWriter sw = new StreamWriter("LogData.txt",false); //true=追記 false=上書き

		int i=0,j=0;
		for (i = -15; i <= 15; i++) {
			for (j = -15; j <= 15; j++) {
				Vector3 vec3 = new Vector3 (i, j, 0);
				Quaternion degree = Quaternion.Euler (vec3);
				Vector3 ans = controlAngle (degree);
				Debug.Log (ans);
				string text = i.ToString() + "," + j.ToString() + "," + ans.x.ToString() + "," + ans.y.ToString() + "," + ans.z.ToString();
				sw.WriteLine(text);
			}
		}

		sw.Flush();
		sw.Close();

	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 ans = controlAngle (transform.rotataion);
//		Debug.Log (ans);
	}

//	void Control()
//	{
//
//	}

	//回転する角度x,y,zを受け取って，目標値を返す関数
	Vector3 controlAngle(Quaternion degree)
	{
		float r = 355.0f;

		Vector4 scale = new Vector3 (1, 1, 1);
		Vector4 pos = new Vector3 (0, 0, 0);
		//Quaternion.Euler degree = Quaternion.Euler(vec3);

		//上の台の3点
		Vector4 A = new Vector4(0,244.96f,0,1);
		Vector4 B = new Vector4(212.15f,-122.43f,0,1);
		Vector4 C = new Vector4(-212.15f,-122.43f,0,1);

		//下の台の3点
		Vector4 a = new Vector4(0,152.01f,-342.61f,1);
		Vector4 b = new Vector4(131.61f,-76,-342.61f,1);
		Vector4 c = new Vector4(-131.61f,-76,-342.61f,1);

		//回転行列を生成
		Matrix4x4 matrixA = Matrix4x4.identity;
		matrixA.SetTRS(pos, degree, scale);
		Matrix4x4 matrixB = Matrix4x4.identity;
		matrixB.SetTRS (pos, degree, scale);
		Matrix4x4 matrixC = Matrix4x4.identity;
		matrixC.SetTRS (pos, degree, scale);
		//回転行列をかける
		Vector4 rotatedA = matrixA*A;
		Vector4 rotatedB = matrixB*B;
		Vector4 rotatedC = matrixC*C;
//		Debug.Log (rotatedA);
//		Debug.Log (rotatedB);
//		Debug.Log (rotatedC);
		//目標を算出
		float resultA = rotatedA.z - Mathf.Sqrt (r * r - (a.x - rotatedA.x) * (a.x - rotatedA.x) - (a.y - rotatedA.y) * (a.y - rotatedA.y));
		float resultB = rotatedB.z - Mathf.Sqrt (r * r - (b.x - rotatedB.x) * (b.x - rotatedB.x) - (b.y - rotatedB.y) * (b.y - rotatedB.y));
		float resultC = rotatedC.z - Mathf.Sqrt (r * r - (c.x - rotatedC.x) * (c.x - rotatedC.x) - (c.y - rotatedC.y) * (c.y - rotatedC.y));

//		if (type == 'A') {
//			Matrix4x4 matrix = Matrix4x4.TRS (A, degree, Vector3 (1, 1, 1));
//			Vector3 q = Vector3.Dot (matrix, A);
//			result = q.z - Mathf.Sqrt (r * r - (a.x - q.x) * (a.x - q.x) - (a.y - q.y) * (a.y - q.y));
//		} else if (type == 'B') {
//			Matrix4x4 matrix = Matrix4x4.TRS (B, degree, Vector3 (1, 1, 1));
//			Vector3 q = Vector3.Dot (matrix, B);
//			result = q.z - Mathf.Sqrt (r * r - (b.x - q.x) * (b.x - q.x) - (b.y - q.y) * (b.y - q.y));
//		} else if (type == 'C') {
//			Matrix4x4 matrix = Matrix4x4.TRS (C, degree, Vector3 (1, 1, 1));
//			Vector3 q = Vector3.Dot (matrix, C);
//			result = q.z - Mathf.Sqrt (r * r - (c.x - q.x) * (c.x - q.x) - (c.y - q.y) * (c.y - q.y));
//		} else {
//			print ("error");
//		}
		Vector3 result = new Vector3(resultA+342.61f,resultB+342.61f,resultC+342.61f);
		return result;
	}

}
