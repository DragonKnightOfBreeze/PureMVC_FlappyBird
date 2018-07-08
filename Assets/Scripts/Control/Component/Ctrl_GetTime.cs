/***
 * 标题：
 * 控制层：得到时间
 * 
 * 功能：
 * 每隔1s，取得一次时间
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
using PureMVC.Patterns.Facade;
using PureMVCDemo.Model;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层，得到时间
	/// </summary>
	public class Ctrl_GetTime : MonoBehaviour {
		//模型代理
		public Mod_GameDataProxy dataProxy = null;

		public void StartGame(){
			//得到模型层类的对象实例
			
			dataProxy =
				Facade.GetInstance(() => new AppFacade()).RetrieveProxy(Mod_GameDataProxy.NAME) as Mod_GameDataProxy;

			StartCoroutine(GetTime());
		}

		public void StopGame(){

			StopCoroutine(GetTime());
		}


		//void Start(){

		//	//启动协程，每隔1s，向PureMVC模型发送一次消息
		//	StartCoroutine(GetTime());
		//}



		IEnumerator GetTime(){
			yield return new WaitForEndOfFrame();
			while (true) {
				yield return new WaitForSeconds(1f);
				//调用模型层中的方法，同时更新显示的数值
				dataProxy?.AddTime();
				
			}
		}

	}

}

