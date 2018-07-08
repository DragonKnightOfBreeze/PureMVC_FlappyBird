/***
 * 标题：
 * 全局管理类
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
using PureMVCDemo.Control;
using SUIFW;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo {
	/// <summary>
	/// 类：全局管理类
	/// </summary>
	public class AppFacade : Facade {

		//得到层级试视图的根对象
		private GameObject goRoot = GameObject.Find(ProConsts.NAME_Environment);

		public AppFacade(){
			//注册核心的“命令”（第二个参数：使用空参数的表达式Lambda写法）
			RegisterCommand(ProConsts.CMD_Reg_StartGame, () => new Ctrl_StartGameCommand());
			RegisterCommand(ProConsts.CMD_Reg_EndGame, () => new Ctrl_EndGameCommand());


			//添加游戏对象脚本
			AddGameObjectScript();
			
		}


		/// <summary>
		/// 添加游戏对象脚本
		/// </summary>
		private void AddGameObjectScript(){
			
			//添加主角控制脚本
			GameObject.FindGameObjectWithTag("Player").AddComponent<Ctrl_BirdControl>();
			//动态挂载陆地移动脚本
			UnityHelper.AddComponentToChildNode<Ctrl_LandMoving>(goRoot,ProConsts.NAME_Lands);
			//动态挂载管道移动脚本
			UnityHelper.AddComponentToChildNode<Ctrl_PipeMoving>(goRoot, ProConsts.NAME_Pipes);
			//动态挂载“得到时间”脚本
			goRoot.AddComponent<Ctrl_GetTime>();

			//动态挂载地面碰撞检测脚本
			UnityHelper.AddComponentToChildNode<Ctrl_DeathCollision>(goRoot, ProConsts.NAME_LandCollider);
			//动态挂载管道碰撞检测脚本
			//TODO：重构，随机性
			for (int i = 1; i <=4; i++) {
				UnityHelper.AddComponentToChildNode<Ctrl_DeathCollision>(goRoot, "Pipe" + "_UP_" + i);
				UnityHelper.AddComponentToChildNode<Ctrl_DeathCollision>(goRoot, "Pipe" + "_Down_" + i);
			}

			//TODO：重构，随机性
			//动态挂载管道通过触发检测脚本
			for (int i = 1; i <=4; i++) {
				UnityHelper.AddComponentToChildNode<Ctrl_PipeTrigger>(goRoot, "PipeTrigger_" + i);
			}
		}

	}
}