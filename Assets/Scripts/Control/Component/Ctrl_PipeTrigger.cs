/***
 * 标题：
 * 控制层，分数控制
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
using PureMVC.Patterns.Facade;
using PureMVCDemo.Model;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层，通过管道的触发检测
	/// </summary>
	public class Ctrl_PipeTrigger : MonoBehaviour {

		//模型代理字段
		private Mod_GameDataProxy _proxyObj;

		////void StartGame() {
		////	??? 需要开始游戏后才处理 ???
		////	需要延迟的方法
		////	至少每次重新开始游戏，都要进行一次
		////	_proxyObj = Facade.GetInstance(() => new AppFacade()).RetrieveProxy(Mod_GameDataProxy.NAME) as Mod_GameDataProxy;
		////}

		void OnTriggerEnter2D(Collider2D collision) {
			//至少每次重新开始游戏，都要进行一次
			_proxyObj = Facade.GetInstance(() => new AppFacade()).RetrieveProxy(Mod_GameDataProxy.NAME) as Mod_GameDataProxy;

			if (GlobalParams.IsStartGame && collision.gameObject.tag == "Player") {
				_proxyObj?.AddScore();
			}
		}

	}
}