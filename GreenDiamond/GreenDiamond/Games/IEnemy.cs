﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;

namespace Charlotte.Games
{
	public interface IEnemy
	{
		void Loaded(D2Point pt);
		bool EachFrame(); // ? 生存
		Crash GetCrash();
		bool Crashed(IWeapon weapon); // ? 生存
		bool CrashedToPlayer(); // ? 生存
		int GetAttackPoint();
		void Draw();
	}
}