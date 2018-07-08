/***
 * 标题：
 * 游戏开始脚本
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
using PureMVCDemo;
using SUIFW;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo {
	/// <summary>
	/// 脚本：游戏开始
	/// </summary>
	public class GameStart : MonoBehaviour {
		private int count = 0;

		void Start() {
			//打开开始窗体
			UIManager.GetInstance().OpenUIForm(ProConsts.NAME_StartUIForm);

			//启动MVC框架
			//TODO
			new AppFacade();
		}

		void Update(){
			if (count == 3)
				count = 0;
			++count;

			if (count == 3) {
				Debug.Log("IsStartGame："+GlobalParams.IsStartGame);
				
			}
		}

	}
}
