/***
 * 标题：
 * 控制层：管道控制脚本
 * 
 * 功能：
 * 做当个管道的碰撞检测
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
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层：即死碰撞检测
	/// </summary>
	[RequireComponent(typeof(BoxCollider2D))]
	public class Ctrl_DeathCollision : MonoBehaviour {

		/// <summary>
		/// 2D碰撞检测
		/// （可延迟的方法）
		/// </summary>
		/// <param name="collision"></param>
		void OnCollisionEnter2D(Collision2D collision) {
			if (GlobalParams.IsStartGame && collision.gameObject.tag == "Player") {
				//通过PureMVC的通知，实现游戏结束
				//TODO：延迟进入引导窗体
				Facade.GetInstance(()=>new AppFacade()).SendNotification(ProConsts.CMD_Reg_EndGame);
			}
		}



	}
}