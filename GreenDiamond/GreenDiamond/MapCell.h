typedef struct MapCell_st
{
	int Wall; // 壁フラグ
	int PicId; // -1 == 画像無し

	// <---- access free
}
MapCell_t;

MapCell_t *CreateMapCell(void);
void ReleaseMapCell(MapCell_t *i);

// <-- cdtor

// <-- accessor
