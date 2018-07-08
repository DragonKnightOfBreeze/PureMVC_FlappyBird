/***
 * 标题：
 * 游戏开始窗体
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
using PureMVCDemo;
using SUIFW;
using UnityEngine;
using UnityEngine.UI;

//using Kernel;
//using Global;

namespace PureMVCDemo.View {

	/// <summary>
	/// 视图层：游戏开始窗体
	/// </summary>
	public class StartUIForm : BaseUIForm {

	

		void Awake() {
			//按钮注册
			RigisterButtonObjectEvent(ProConsts.NAME_Btn_Play, p => {
				OpenUIForm(ProConsts.NAME_GuideUIForm);
			});
		}


	}
}