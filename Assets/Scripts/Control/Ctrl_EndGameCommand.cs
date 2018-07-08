/***
 * 标题：
 * 控制层，命令：结束游戏
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
using PureMVC.Patterns.Facade;
using PureMVC.Patterns.Command;
using PureMVCDemo.Model;
using PureMVCDemo.View;
using SUIFW;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {

	/// <summary>
	/// 控制层，命令：结束游戏
	/// </summary>
	public class Ctrl_EndGameCommand : SimpleCommand {

		//模型代理字段
		private Mod_GameDataProxy _proxyObj;

		//得到层级试视图的根对象
		private GameObject goRoot = GameObject.Find(ProConsts.NAME_Environment);

		/// <summary>
		/// 要执行的对应命令
		/// </summary>
		/// <param name="notification"></param>
		public override void Execute(INotification notification) {
			GlobalParams.IsStartGame = false;

			//停止脚本运行。
			StopScriptRunning();
			

			//保存当前最高分数
			//???为什么这里使用了一种面向接口的方法，就不需要调用GetInstance方法了???
			_proxyObj =  Facade.RetrieveProxy(Mod_GameDataProxy.NAME) as Mod_GameDataProxy;
			_proxyObj?.SaveHighestScore();

			//关闭当前UI窗体，回到引导窗体
			CloseCurrentUIForm();

		}

		private void StopScriptRunning(){
			
			//小鸟脚本的停止运行
			GameObject.FindGameObjectWithTag("Player").GetComponent<Ctrl_BirdControl>().StopGame();
			//管道组脚本的停止运行
			UnityHelper.FindChildNode(goRoot, ProConsts.NAME_Pipes).GetComponent<Ctrl_PipeMoving>().StopGame();
			//地面脚本的停止运行
			//UnityHelper.FindChildNode(goRoot, ProConsts.NAME_Lands).GetComponent<Ctrl_LandMoving>().StopGame();
			//获取时间脚本的停止运行
			goRoot.GetComponent<Ctrl_GetTime>().StopGame();

			//管道碰撞检测脚本的停止执行（不需要）

			//触发检测脚本的停止执行（不需要）

		}

		/// <summary>
		/// 关闭当前窗体，回到引导窗体
		/// </summary>
		private void  CloseCurrentUIForm(){
			//TODO：如何实现时间的延迟？
			//如何才能正确地打开？
			UIManager.GetInstance().CloseUIForm(ProConsts.NAME_PlayingUIForm);
			UIManager.GetInstance().OpenUIForm(ProConsts.NAME_GuideUIForm);
			
		}



	}
}