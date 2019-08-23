﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common;
using Charlotte.Map01.Tile01;

namespace Charlotte.Map01
{
	public class Map
	{
		public MapCell DefaultCell = new MapCell();
		public AutoTable<MapCell> Table;

		public Map(int w, int h)
		{
			if (
				w < 1 || IntTools.IMAX < w ||
				h < 1 || IntTools.IMAX < h
				)
				throw new DDError();

			this.Table = new AutoTable<MapCell>(w, h);

			for (int x = 0; x < w; x++)
			{
				for (int y = 0; y < h; y++)
				{
					this.Table[x, y] = new MapCell();
				}
			}
		}

		public int W
		{
			get { return this.Table.W; }
		}

		public int H
		{
			get { return this.Table.H; }
		}

		public MapCell GetCell(I2Point pt)
		{
			return this.GetCell(pt, this.DefaultCell);
		}

		public MapCell GetCell(I2Point pt, MapCell defCell)
		{
			return this.GetCell(pt.X, pt.Y, defCell);
		}

		public MapCell GetCell(int x, int y)
		{
			return this.GetCell(x, y, this.DefaultCell);
		}

		public MapCell GetCell(int x, int y, MapCell defCell)
		{
			if (
				x < 0 || this.Table.W <= x ||
				y < 0 || this.Table.H <= y
				)
				return defCell;

			return Table[x, y];
		}

		// TablePoint ... I2Point Table用の座標
		// Point      ... D2Point 座標(ピクセル単位)

		public static I2Point ToTablePoint(D2Point pt)
		{
			return ToTablePoint(pt.X, pt.Y);
		}

		public static I2Point ToTablePoint(double x, double y)
		{
			int mapTileX = (int)Math.Floor(x / MapTile.WH);
			int mapTileY = (int)Math.Floor(y / MapTile.WH);

			return new I2Point(mapTileX, mapTileY);
		}
	}
}