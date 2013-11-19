LiveTileLab
===========

윈도우폰 8이 발표되면서 라이브 타일의 사이즈 small, medium, wide 형태의 세가지의 라이브타일 사이즈와 flip, cycle, iconic 등의 세가지 형태의 라이브타일이 생겨나게 되었다.
1. FlipTileData 
2. CycleTileData 
3. IconicTileData 

라이브타일의 이미지 사이즈
아래는 각 형태에 따른 타일 사이즈 이다.
Name of Tiles 	Small (Pixels) 	Medium (Pixels) 	Wide (Pixels) 
Flip 	159 x 159 	336 x 336 	691 x 336 
Cycle 	159 x 159 	336 x 336 	691 x 336 
Iconic 	110 x 110 	202 x 202 	N/A 

Full HD 975 x 474 
Full HD Page 1920x1080
1280x768

Flip Tile Templates
Flip liveTile은 기존의 윈도우폰7에서 흔히 볼 수 있었던 타일 모습이다. 다만 윈도우폰8에 맞춰서 Wide타일이 생겼다.
       

Cycle Tile Templates
Cycle liveTile은 이번 윈도우폰8에서 추가된 타일으로 최대 9개까지의 이미지를 움직이는 형식으로 보여준다. 윈도우폰의 Picture Hub에 있는 라이브타일 형태를 생각해보면 된다.


Iconic Tile Templates
Iconic liveTile은 이번 윈도우폰8에서 추가된 타일으로 간단한 아이콘과 숫자로 라이브타일을 표시한다. 이 라이브타일에는 110x110 size(small)과 202x202(medium) 사이즈의 라이브타일을 필요로한다. 그리고 뒷배경 색깔은 일반적으로 폰의 Accenct Color를 따르지만 따로 설정할 수 있다.


참고
기본 라이브타일은 업데이트가 가능한데             
ShellTile Tile = ShellTile.ActiveTiles.First(); 여기에서 Tile은 Primary Tile을 나타낸다.
그리고 Tile.Update(CycleTile);의 메서드를 사용하여 타일을 업데이트 하는데
중요한 점은 WMAppMenifest.xaml에서 지정한 타입 Flip, Iconic, Cycle 중에 선택한 종류의 타일을 업데이트 해야지 다른 종류의 타일을 업데이트하면 오류가 발생하게 된다.

