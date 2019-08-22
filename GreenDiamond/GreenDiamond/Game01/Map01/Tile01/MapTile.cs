﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Charlotte.Common;

namespace Charlotte.Game01.Map01.Tile01
{
	public class MapTile
	{
		public string Name;
		public DDPicture Picture;

		public MapTile(string file)
		{
			this.Name = Path.GetFileNameWithoutExtension(file);
			this.Picture = DDPictureLoaders.Standard(file);

			MapTileUtils.Add(this);
		}
	}
}