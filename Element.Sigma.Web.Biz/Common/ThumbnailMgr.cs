using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.Common
{
    public class ThumbnailMgr
    {
        public bool GenerateThumbnail(string targetPath, string filename, string fileExtension)
        {
            bool isSuccess = true;
            try
            {
                string orgFilePath = Path.Combine(targetPath, filename + "." + fileExtension);
                string thumbnailFilePath = Path.Combine(targetPath, filename + ".thumbnail." + fileExtension);

                // Thumbnail 비율 적용 - 원본 이미지의  가로:세율 비율 확인 - 축소 길이 - 가로 고정 - 200)
                System.IO.Stream imgstream = File.Open(orgFilePath, FileMode.Open);
                System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(imgstream);

                float orgheight = sourceImage.PhysicalDimension.Height;
                float orgwidth = sourceImage.PhysicalDimension.Width;
                int newwidth = 200;

                float newheight = orgheight / orgwidth * newwidth;

                System.Drawing.Image thumbnailImage = sourceImage.GetThumbnailImage(newwidth, (int)newheight, null, IntPtr.Zero);
                thumbnailImage.Save(thumbnailFilePath);

                imgstream.Dispose();
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
    }
}
