/***
 * 标题：
 * 控制层，命令：开始游戏
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

//TODO：定义要执行的命令

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PureMVC.Patterns.Command;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Control {
	/// <summary>
	/// 控制层，命令：开始游戏
	/// 宏命令：可以添加多个子命令
	/// </summary>
	public class Ctrl_StartGameCommand : MacroCommand {

		/// <summary>
		/// 实例化宏命令
		/// </summary>
		protected override void InitializeMacroCommand(){
			//注册模型与视图Command
			AddSubCommand(()=>new Ctrl_RigisterCommand());
			//注册重新开始Command
			AddSubCommand(()=>new Ctrl_RestartGameCommand());
		}
	}
}