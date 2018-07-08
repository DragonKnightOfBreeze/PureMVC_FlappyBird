/***
 * 标题：
 * 游戏数据实体类
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
using PureMVC.Patterns.Proxy;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.Model {
	/// <summary>
	/// 类：游戏数据实体类
	/// </summary>
	public class Mod_GameDataProxy :Proxy {

		private const string NAME_HighestScore ="HighestScore";


		//类的名称
		public new const string NAME = "Mod_GameDataProy";
		//public new const string NAME = this.GetType().ToString();

		private Mod_GameData _GameData;

		public Mod_GameDataProxy():base(NAME){
			_GameData = new Mod_GameData();
			//得到最高分数（得到持久化的数据）
			_GameData.HighestScore = PlayerPrefs.GetInt(NAME_HighestScore);
		}

		/// <summary>
		/// 每1s调用一次
		/// </summary>
		public void AddTime(){
			++_GameData.Time;
			//数据发送到视图层
			SendNotification(ProConsts.CMD_Msg_DisplayGameInfo,_GameData,null);
		}

		public void AddScore(){
			++_GameData.Score;
			//更新最高分数
			AddHighestScore();
			//SendNotification(ProConsts.CMD_Msg_DisplayGameInfo, _GameData, null);
		}

		public void AddHighestScore(){
			if (_GameData.Score > _GameData.HighestScore) {
				_GameData.HighestScore = _GameData.Score;
			}
		}




		/// <summary>
		/// 保存最高分数
		/// （由命令层来调用）
		/// </summary>
		public void SaveHighestScore(){
			if (_GameData.HighestScore > PlayerPrefs.GetInt(NAME_HighestScore))
			{
				PlayerPrefs.SetInt(NAME_HighestScore,_GameData.HighestScore);
			}
		}

		/// <summary>
		/// 重置游戏数据
		/// </summary>
		public void ResetData(){
			_GameData.Score = 0;
			_GameData.Time = 0;
		}
	}
}