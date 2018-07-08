/***
 * 标题：
 * 控制层，命令：注册模型层与视图层
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
using PureMVC.Patterns;
using PureMVCDemo.Model;
using PureMVCDemo.View;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层，命令：注册模型层与视图层
	/// </summary>
	public class Ctrl_RigisterCommand : SimpleCommand {
		
		public override void Execute(INotification notification){
			Facade.RegisterProxy(new Mod_GameDataProxy());
			Facade.RegisterMediator(new View_GamePlayingMediator());
		}
	}



}
