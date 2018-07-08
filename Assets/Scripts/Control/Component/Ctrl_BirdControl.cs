/***
 * 标题：
 * 控制层：小鸟的控制脚本
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
using SUIFW;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层：小鸟的控制脚本
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public class Ctrl_BirdControl : MonoBehaviour {
		//升力
		public float FloUPPower = 3f;
		//2D刚体
		private Rigidbody2D rb2D;
		//小鸟的原始位置
		private Vector2 _BirdOriginalPosition;



		void Start() {
			//保存原始方位
			_BirdOriginalPosition = gameObject.transform.position;
			//获取2D刚体
			rb2D = this.gameObject.GetComponent<Rigidbody2D>();

			//gameObject.SetActive(false);

			//禁用2D刚体
			DisableRigidbody2D();
		}

		void Update(){

			if (GlobalParams.IsStartGame) {
				//接受玩家输入
				if (Input.GetButton("Fire1")) {
					rb2D.velocity = Vector2.up * FloUPPower;
				}

				//接受玩家鼠标点击
				else if (Input.GetMouseButton(1)) {
					rb2D.velocity = Vector2.up * FloUPPower;
				}

				////接受玩家触屏点击
				//EventTriggerListener.GetListener(gameObject).onClick += p => {
				//	rb2D.velocity = Vector2.up * FloUPPower;
				//};


			}
		}

		/// <summary>
		/// 公共方法：游戏开始
		/// </summary>
		public void StartGame(){
			//gameObject.SetActive(true);
			//启用2D刚体
			EnableRigidbody2D();
			////恢复小鸟的原始位置
			//gameObject.transform.position = _BirdOriginalPosition;
		}


		/// <summary>
		/// 公共方法：游戏结束
		/// </summary>
		public void StopGame(){
			//gameObject.SetActive(false);
			//禁用2D刚体
			DisableRigidbody2D();
			//恢复小鸟的原始位置
			gameObject.transform.position = _BirdOriginalPosition;
		}







		/// <summary>
		/// 禁用2D刚体
		/// </summary>
		private void EnableRigidbody2D() {
			//控制2D刚体是否不受物理引擎控制
			//只写这一句仍然会缓慢下降，除非切换到静态一次
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
		}

		/// <summary>
		/// 禁用2D刚体
		/// </summary>
		private void DisableRigidbody2D(){
			//控制2D刚体是否不受物理引擎控制
			//只写这一句仍然会缓慢下降，除非切换到静态一次
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true; 
			this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
		}


	}
}