using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO.IsolatedStorage;

namespace LiveTileLab
{
    public partial class MakeImage : PhoneApplicationPage
    {
        public MakeImage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WriteableBitmap wbmp = new WriteableBitmap(336, 336);
            wbmp.Render(FirstRow, new TranslateTransform() {X = FirstRow.Margin.Left, Y = FirstRow.Margin.Top});
            wbmp.Render(SecondRow, new TranslateTransform() { X = SecondRow.Margin.Left, Y = SecondRow.Margin.Top });
            wbmp.Render(ImageInput, new TranslateTransform() { X = ImageInput.Margin.Left, Y = ImageInput.Margin.Top });
            wbmp.Invalidate();

            // save image to isolated storage
            BitmapImage bmp = new BitmapImage();
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // use of "/Shared/ShellContent/" folder is mandatory!
                using (IsolatedStorageFileStream imageStream = new IsolatedStorageFileStream("/Shared/ShellContent/MyImage.jpg", System.IO.FileMode.Create, isf))
                {
                    wbmp.SaveJpeg(imageStream, wbmp.PixelWidth, wbmp.PixelHeight, 0, 100);
                    bmp.SetSource(imageStream);
                }
            }

            OutputImage.Source = bmp;


            ShellTile Tile = ShellTile.ActiveTiles.First();//Primary Tile
            if (null != Tile)
            {
                CycleTileData CycleTile = new CycleTileData();
                CycleTile.Title = "Primary Tile Update!";
                CycleTile.Count = 9;

                CycleTile.SmallBackgroundImage = new Uri("isostore:/Shared/ShellContent/MyImage.jpg", UriKind.Absolute);//isolated Storage에 저장 후 

                CycleTile.CycleImages = new Uri[]//이미지 배열 생성. 9개까지만 생성 가능
                {
                    new Uri("isostore:/Shared/ShellContent/MyImage.jpg", UriKind.Absolute),
                };

                Tile.Update(CycleTile);
                MessageBox.Show("Primary 타일이 업데이트 되었습니다.");
            }

        }
    }
}