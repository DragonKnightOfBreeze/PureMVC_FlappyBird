/***
 * 标题：
 * 项目常量类
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
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo {
	/// <summary>
	/// 类：项目常量类
	/// </summary>
	public class ProConsts {

		/* 游戏对象的名称常量 */

		public const string NAME_Environment = "Environment";
		public const string NAME_Lands = "Landings";
		public const string NAME_Pipes = "Pipes";
		public const string NAME_LandCollider = "LandCollider";

		/* 窗体名称常量 */

		public const string NAME_StartUIForm = "StartUIForm";
		public const string NAME_GuideUIForm = "GuideUIForm";
		public const string NAME_PlayingUIForm = "PlayingUIForm";

		/* 在StartUIForm中的名称常量 */

		public const string NAME_Btn_Play = "Btn_Play";
		public const string NAME_Btn_RankingList = "Btn_RankingList";
		public const string NAME_Btn_Rate = "Btn_Rate";

		/* 在GuideUIForm中的名称常量 */

		public const string NAME_Btn_OK = "Btn_OK";

		
		/* 注册命令常量 */

		public const string CMD_Reg_StartGame = "Reg_StartGame";
		public const string CMD_Reg_EndGame = "Reg_EndGame";
		public const string CMD_Reg_RestartGame = "Reg_RestartGame";

		/* 消息命令常量 */

		public const string CMD_Msg_DisplayGameInfo = "Msg_DisplayGameInfo";


		/* 数值型常量 */
		/// <summary>
		/// 死亡延迟时间（如何应用在PureMVC中？）
		/// </summary>
		public const float TIME_DeathDelay = 2.5f;
		/// <summary>
		/// 协程的无限循环间隔时间
		/// </summary>
		public const float TIME_WaitTime = 0.1f;

	}
}