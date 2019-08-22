﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxLibDLL;
using Charlotte.Tools;
using Charlotte.Common;
using Charlotte.Game01;
using Charlotte.Game01.Map01;

namespace Charlotte.Main01
{
	public class TitleMenu
	{
		private DDSimpleMenu SmplMenu;

		public void Perform()
		{
			DDCurtain.SetCurtain();
			DDEngine.FreezeInput();

			//Ground.I.Music.Title.Play();

			string[] items = new string[]
			{
				"ゲームスタート",
				"コンテニュー？",
				"設定",
				"終了",
			};

			int selectIndex = 0;

			this.SmplMenu = new DDSimpleMenu();

			this.SmplMenu.WallColor = new I3Color(16, 64, 32);
			//this.SmplMenu.WallPicture = Ground.I.Picture.TitleWall;

			for (; ; )
			{
				selectIndex = this.SmplMenu.Perform("Donut2", items, selectIndex);

				switch (selectIndex)
				{
					case 0:
						{
							this.LeaveTitleMenu();

							using (Game game = new Game())
							{
								game.Map = MapLoader.Load(@"Map\t0001.txt");
								game.Perform();
							}
							this.ReturnTitleMenu();
						}
						break;

					case 1:
						// TODO
						break;

					case 2:
						this.Setting();
						break;

					case 3:
						goto endMenu;

					default:
						throw new DDError();
				}
			}
		endMenu:
			DDEngine.FreezeInput();
			DDMusicUtils.Fade();
			DDCurtain.SetCurtain(30, -1.0);

			foreach (DDScene scene in DDSceneUtils.Create(40))
			{
				this.DrawWall();
				DDEngine.EachFrame();
			}
		}

		private void Setting()
		{
			DDCurtain.SetCurtain();
			DDEngine.FreezeInput();

			string[] items = new string[] 
			{
				"パッドのボタン設定",
				"ウィンドウサイズ変更",
				"ＢＧＭ音量",
				"ＳＥ音量",
				"戻る",
			};

			int selectIndex = 0;

			for (; ; )
			{
				selectIndex = this.SmplMenu.Perform("設定", items, selectIndex);

				switch (selectIndex)
				{
					case 0:
						this.SmplMenu.PadConfig();
						break;

					case 1:
						this.SmplMenu.WindowSizeConfig();
						break;

					case 2:
						this.SmplMenu.VolumeConfig("ＢＧＭ音量", DDGround.MusicVolume, 0, 100, 1, 10, volume =>
						{
							DDGround.MusicVolume = volume;
							DDMusicUtils.UpdateVolume();
						},
						() => { }
						);
						break;

					case 3:
						this.SmplMenu.VolumeConfig("ＳＥ音量", DDGround.SEVolume, 0, 100, 1, 10, volume =>
						{
							DDGround.SEVolume = volume;
							DDSEUtils.UpdateVolume();
						},
						() =>
						{
							//Ground.I.SE.PauseIn.Play();
						}
						);
						break;

					case 4:
						goto endMenu;

					default:
						throw new DDError();
				}
			}
		endMenu:
			DDEngine.FreezeInput();
		}

		private void DrawWall()
		{
			DX.DrawBox(0, 0, DDConsts.Screen_W, DDConsts.Screen_H, DX.GetColor(16, 64, 32), 1);
			//DDDraw.DrawRect(Ground.I.Picture.TitleWall, 0, 0, DDConsts.Screen_W, DDConsts.Screen_H);
		}

		private void LeaveTitleMenu()
		{
			DDMusicUtils.Fade();
			DDCurtain.SetCurtain(30, -1.0);

			GC.Collect();
		}

		private void ReturnTitleMenu()
		{
			//Ground.I.Music.Title.Play();

			GC.Collect();
		}
	}
}