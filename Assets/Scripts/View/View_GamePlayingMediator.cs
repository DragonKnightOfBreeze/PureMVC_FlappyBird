/***
 * 标题：
 * 视图层：显示游戏进行时的UI控制
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
using PureMVC.Patterns.Mediator;
using PureMVCDemo.Model;
using SUIFW;
using UnityEngine;
using UnityEngine.UI;

//using Kernel;
//using Global;

namespace PureMVCDemo.View {
	/// <summary>
	/// 
	/// </summary>
	public class View_GamePlayingMediator : Mediator {

		public new const string NAME = "View_GamePlayingMediator";

		//控件定义（文字）
		private Text Txt_Time_Pre;
		private Text Txt_Score_Pre;
		private Text Txt_HighestScore_Pre;

		//控件定义（显示数值）
		private Text Txt_Time;
		private Text Txt_Score;
		private Text Txt_HighestScore;


		/// <summary>
		/// 构造函数
		/// </summary>
		public View_GamePlayingMediator() : base(NAME){
			////得到层级视图的根节点
			//GameObject goCanvas = GameObject.Find("Canvas(Clone)");

			////得到控件
			////过多使用nameof关键字是否会影响性能？
			//Txt_Time_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Time_Pre));
			//Txt_Score_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Score_Pre));
			//Txt_HighestScore_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_HighestScore_Pre));

			//Txt_Time = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Time));
			//Txt_Score = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Score));
			//Txt_HighestScore = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_HighestScore));

			////确定控件显示的文字
			////TODO语言国际化
			//Txt_Time_Pre.text = "时间：";
			//Txt_Score_Pre.text = "分数：";
			//Txt_HighestScore_Pre.text = "最高分：";


		}

		/// <summary>
		/// 允许接受的消息列表
		/// </summary>
		/// <returns></returns>
		public override string[] ListNotificationInterests(){
			string[] strList = new string[] {
				ProConsts.CMD_Msg_DisplayGameInfo,
				ProConsts.CMD_Msg_InitMediatorFields
			};

			return strList;
		}

		/// <summary>
		/// 处理接受到的消息列表
		/// </summary>
		/// <param name="notification"></param>
		public override void HandleNotification(INotification notification){
			
			switch (notification.Name) {
				case ProConsts.CMD_Msg_DisplayGameInfo:
					DisplayGameInfo(notification);
					break;
				case ProConsts.CMD_Msg_InitMediatorFields:
					InitMediatorFields();
					break;
				default:
					break;
			}
		}

		#region 【私有方法】

		/// <summary>
		/// 初始化字段
		/// </summary>
		private void InitMediatorFields(){
			//得到层级视图的根节点
			GameObject goCanvas = GameObject.Find("Canvas(Clone)");

			//得到控件
			//过多使用nameof关键字是否会影响性能？
			Txt_Time_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Time_Pre));
			Txt_Score_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Score_Pre));
			Txt_HighestScore_Pre = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_HighestScore_Pre));

			Txt_Time = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Time));
			Txt_Score = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_Score));
			Txt_HighestScore = UnityHelper.GetComponentInChildNode<Text>(goCanvas, nameof(Txt_HighestScore));

			//确定控件显示的文字
			//TODO语言国际化
			Txt_Time_Pre.text = "时间：";
			Txt_Score_Pre.text = "分数：";
			Txt_HighestScore_Pre.text = "最高分：";
		}

		/// <summary>
		/// 显示游戏信息
		/// </summary>
		/// <param name="notification"></param>
		private void DisplayGameInfo(INotification notification ){
			Mod_GameData gameData = notification.Body as Mod_GameData;
			//显示控件的数值
			if (gameData != null) {
				if (Txt_Time && Txt_Score && Txt_HighestScore) {
					Txt_Time.text = gameData.Time.ToString();
					Txt_Score.text = gameData.Score.ToString();
					Txt_HighestScore.text = gameData.HighestScore.ToString();
				}
			}
		}

		#endregion
	}
}