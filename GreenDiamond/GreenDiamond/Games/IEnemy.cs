﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common.Options;

namespace Charlotte.Games
{
	//	インスタンスの生成には IEnemies.Load を使用する？
	//
	public interface IEnemy
	{
		void Loaded(D2Point pt);
		bool EachFrame(); // ? 生存
		DDCrash GetCrash();
		bool Crashed(IWeapon weapon); // ? 生存
		bool CrashedToPlayer(); // ? 生存
		int GetAttackPoint();
		void Draw();
	}
}
