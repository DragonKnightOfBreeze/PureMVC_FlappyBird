/***
 * 标题：
 * 控制层，陆地的移动
 * 
 * 功能：
 * 
 * 
 * 用法：
 * 
 * 
 * 思路：
 * 
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control{
	/// <summary>
	/// 控制层：陆地移动
	/// </summary>
	public class Ctrl_LandMoving : MonoBehaviour {

		public float floMovingSpeed = 3f;
		private Vector2 _OriginalPosition;

		private const float _DeltaDistance = 5f;

		void Start() {
			//保存陆地原始位置
			_OriginalPosition = gameObject.transform.position;
		}

		void Update(){
			LandMovingLoop();
		}


		public void StartGame(){
			//StartCoroutine(LandMovingLoop());
		}

		public void StopGame() {
			//StopCoroutine("LandMovingLoop");
		}

		private void LandMovingLoop(){
			while (true) {
				if (GlobalParams.IsStartGame) {
					//到了“临界值”，就恢复原始方位
					if (gameObject.transform.position.x < _OriginalPosition.x - _DeltaDistance) {
						gameObject.transform.position = _OriginalPosition;
					}
					//移动
					gameObject.transform.Translate(Vector3.left * Time.deltaTime * floMovingSpeed);
				}
			}
		}


		///// <summary>
		///// 陆地的循环移动
		///// </summary>
		//IEnumerator LandMovingLoop(){
		//	yield return new WaitForEndOfFrame();
		//	while (true) {
		//		//到了“临界值”，就恢复原始方位
		//		if (gameObject.transform.position.x < _OriginalPosition.x - _DeltaDistance) {
		//			gameObject.transform.position = _OriginalPosition;
		//		}
		//		//移动
		//		gameObject.transform.Translate(Vector3.left * Time.deltaTime * floMovingSpeed);
		//		yield return new WaitForSeconds(ProConsts.TIME_WaitTime);
		//	}
		//}


	}
}