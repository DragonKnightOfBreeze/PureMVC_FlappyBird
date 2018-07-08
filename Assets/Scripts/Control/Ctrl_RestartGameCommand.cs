/***
 * 标题：
 * 控制层，命令：重新开始游戏
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
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using SUIFW;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层，命令：重新开始游戏
	/// </summary>
	public class Ctrl_RestartGameCommand : SimpleCommand {

		//得到层级试视图的根对象
		private GameObject goRoot = GameObject.Find(ProConsts.NAME_Environment);


		/// <summary>
		/// 要执行的对应命令
		/// </summary>
		/// <param name="notification"></param>
		public override void Execute(INotification notification){
			GlobalParams.IsStartGame = true;

			//脚本重新运行
			StartScriptRunning();

			
		}


		/// <summary>
		/// 脚本重新运行
		/// </summary>
		private void StartScriptRunning(){

			//小鸟脚本的重新运行
			GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_BirdControl>().StartGame();
			//地面脚本的重新运行
			//UnityHelper.FindChildNode(goRoot, ProConsts.NAME_Lands).GetComponent<Ctrl_LandMoving>().StartGame();
			//管道组脚本的重新运行
			UnityHelper.FindChildNode(goRoot, ProConsts.NAME_Pipes).GetComponent<Ctrl_PipeMoving>().StartGame();
			//时间脚本的重新运行
			goRoot.GetComponent<Ctrl_GetTime>().StartGame();
			
			//管道碰撞检测脚本的停止执行（不需要）

			//触发检测脚本的停止执行
		
		}

	}
}