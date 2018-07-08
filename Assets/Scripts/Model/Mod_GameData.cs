/***
 * 标题：
 * 游戏数据实体类
 *
 * 功能：
 * 定义小鸟的相关数据（时间，分数，最高分）
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

//using Kernel;
//using Global;

namespace PureMVCDemo.Model {
	/// <summary>
	/// 类：游戏数据实体类
	/// </summary>
	public class Mod_GameData {

		public int Time { set; get; } = 0;
		public int Score { set; get; } = 0;
		public int HighestScore { set; get; } = 0;



	}
}