/***
 * 标题：
 * 游戏引导窗体
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
using SUIFW;
using UnityEngine;

//using Kernel;
//using Global;

namespace PureMVCDemo.View {
	/// <summary>
	/// 视图层：游戏引导窗体
	/// </summary>
	public class GuideUIForm : BaseUIForm {

		void Awake(){
			//本窗体类型
			CurrentUIType.UIForms_ShowType = UIFormShowType.HideOther;

			//注册按钮事件
			RigisterButtonObjectEvent(ProConsts.NAME_Btn_OK, p => {
				OpenUIForm(ProConsts.NAME_PlayingUIForm);
				//MVC启动命令
				Facade.GetInstance(()=>new AppFacade()).SendNotification(ProConsts.CMD_Reg_StartGame);
				//+++对视图层字段初始化+++
				Facade.GetInstance(()=>new AppFacade()).SendNotification(ProConsts.CMD_Msg_InitMediatorFields);

			});

		}


	}
}