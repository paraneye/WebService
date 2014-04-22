using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Leadtools;
using Leadtools.Codecs;

namespace Element.Shared.LeadTools
{
    public static class DrawingHelper
    {
        public static bool ConvertDrawingImage(string strBasePath, string strSavePath)
        {
            try
            {
                RasterCodecs codecs = new RasterCodecs();
                RasterImage image = codecs.Load(strBasePath, 0, Leadtools.Codecs.CodecsLoadByteOrder.BgrOrGray, 1, 1);

                return SaveDrawingImage(image, strSavePath);
            }
            catch(Exception ex)
            {
                throw new Exception("WCF : Failed ConvertDrawingImage('" + ex.Message + "')");
            }
        }

        public static bool SaveDrawingImage(RasterImage image, string fileName)
        {
            try
            {
                Leadtools.Codecs.RasterCodecs codecs = new Leadtools.Codecs.RasterCodecs();
                codecs.Options.Jpeg.Save.QualityFactor = 255;
                codecs.Save(image, fileName, RasterImageFormat.Jpeg411, 24, 1, 1, 1, CodecsSavePageMode.Overwrite);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return true;
        }

    }
}
