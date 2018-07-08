/***
 * 标题：
 * 控制层，管道的移动
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
using Object = System.Object;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control{
	/// <summary>
	/// 控制层：管道的移动
	/// </summary>
	public class Ctrl_PipeMoving : MonoBehaviour {

		public float floMovingSpeed = 3f;
		private Vector2 _OriginalPosition;

		private const float _DeltaDistance = 24f;

		void Start() {
			//保存原始位置
			_OriginalPosition = gameObject.transform.position;
		}

		void Update(){
			PipeMovingLoop();
		}

		public void StartGame(){
			//StartCoroutine(PipeMovingLoop());
		}

		public void StopGame(){
			//StopCoroutine("PipeMovingLoop");
			ResetPipesPosition();
		}

		private void PipeMovingLoop(){
			if (GlobalParams.IsStartGame) {
			    //到了“临界值”，就恢复原始方位
				if (gameObject.transform.position.x < _OriginalPosition.x - _DeltaDistance) {
					gameObject.transform.position = _OriginalPosition;
				}
				//移动
				gameObject.transform.Translate(Vector3.left * Time.deltaTime * floMovingSpeed);
			}
		}


			///// <summary>
			///// 管道的循环移动
			///// </summary>
			// IEnumerator PipeMovingLoop(){
			//	yield return new WaitForEndOfFrame();
			//	while (true) {
			//		if (GlobalParams.IsStartGame) {
			//			//到了“临界值”，就恢复原始方位
			//			if (gameObject.transform.position.x < _OriginalPosition.x - _DeltaDistance) {
			//				gameObject.transform.position = _OriginalPosition;
			//			}
			//			//移动
			//			gameObject.transform.Translate(Vector3.left * Time.deltaTime * floMovingSpeed);
			//		}
			//		yield return new WaitForSeconds(ProConsts.TIME_WaitTime);

			//	}
			//}

			/// <summary>
			/// 游戏结束时的管道复位
			/// </summary>
			private void ResetPipesPosition(){
			this.gameObject.transform.position = _OriginalPosition;
		}


	}
}