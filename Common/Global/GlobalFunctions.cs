using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using C1.Win.C1FlexGrid;

namespace EchoSystems.Common.Global
{
    public class GlobalFunctions
    {
        public static string addSlashes(string pStr)
        {
            pStr = pStr.Trim();
            pStr = pStr.Replace("\'", "\\\'");
            pStr = pStr.Replace("\"", "\\\"");
            pStr = pStr.Replace(";" , "\\;");
            return pStr;
        }

        public static string removeQuotes(string pStr)
        {
            try
            {
                return pStr.Replace('\'', '`');
            }
            catch
            {
                return "";
            }
        } 

        public static IList<string> removeRedundancy(string[] pStr)
        {
            IList<string> _strCollection = new List<string>();
            foreach(string _str in pStr)
            {
                if(!_strCollection.Contains(_str))
                {
                    _strCollection.Add(_str);
                }
            }
            return _strCollection;
        }

        public static string parseTitleFromFile(string pInput)
        {
            string _ret = "";
            Regex _reg = new Regex(@"(?<=\\)(.*?)(?=\.)");

            if (_reg.Match(pInput).Success)
            {
                string _match = _reg.Match(pInput).ToString();
                char[] _charArray = new char[] { '\\' };
                string[] _tokens = _match.Split(_charArray);

                foreach (string _str in _tokens)
                {
                    _ret = _str;
                }
            }

            return _ret;
        }

        public static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
                                            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public static void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam =
                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        /// <summary>
        /// Binds a datatable into the component1 flex grid.
        /// ***flexgrid columns should have a name
        /// </summary>
        /// <param name="pGrid">component1 flex grid</param>
        /// <param name="pDt">datatable containing data to be binded</param>
        public static void bindDataTableToFlexGrid(ref C1FlexGrid pGrid, DataTable pDt)
        {
            try
            {
                if (pDt.Rows.Count > 0)
                {
                    int _row = 1;
                    pGrid.Rows.Count = 1;
                    foreach (DataRow _dRow in pDt.Rows)
                    {
                        pGrid.Rows.Count++;
                        for (int _col = 0; _col < pGrid.Cols.Count; _col++)
                        {
                            try
                            {
                                string _str = _dRow[pGrid.Cols[_col].Name.ToString()].ToString();
                                pGrid.SetData(_row, _col, _str);
                            }
                            catch { }
                        }
                        _row++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : Global Functions." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        /// <summary>
        /// binds datatable columns into object attributes
        /// </summary>
        /// <param name="pObj">object</param>
        /// <param name="pDt">datatable</param>
        public static void BindAttribute(ref object pObj, DataTable pDt)
        {
            try
            {
                if (pDt.Rows.Count > 0)
                {
                    foreach (DataColumn _dCol in pDt.Columns)
                    {
                        try
                        {
                            if (typeof(string) == pObj.GetType().GetProperty(_dCol.ColumnName).PropertyType)
                            {
                                pObj.GetType().GetProperty(_dCol.ColumnName).SetValue(pObj, pDt.Rows[0][_dCol.ColumnName].ToString(), null);
                            }
                            else if (typeof(int) == pObj.GetType().GetProperty(_dCol.ColumnName).PropertyType)
                            {
                                pObj.GetType().GetProperty(_dCol.ColumnName).SetValue(pObj, int.Parse(pDt.Rows[0][_dCol.ColumnName].ToString()), null);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : Global Functions." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }

        /// <summary>
        /// converts a c1 flex grid into a datatable
        /// </summary>
        /// <param name="pGrid"></param>
        /// <returns></returns>
        public static DataTable convertFlexGridToDataTable(C1FlexGrid pGrid)
        {
            try
            {
                DataTable _dt = new DataTable();
                if (pGrid.Rows.Count > 0)
                {

                    for (int _col = 0; _col < pGrid.Cols.Count; _col++)
                    {
                        _dt.Columns.Add(pGrid.Cols[_col].Name);
                    }
                    DataRow _dRow;
                    for (int _row = 1; _row < pGrid.Rows.Count; _row++)
                    {
                        _dRow = _dt.NewRow();
                        for (int _col = 0; _col < pGrid.Cols.Count; _col++)
                        {
                            _dRow[pGrid.Cols[_col].Name] = pGrid.GetDataDisplay(_row, _col);
                        }
                        _dt.Rows.Add(_dRow);
                    }
                }
                return _dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Message!\r\n" + ex.Message + "\r\nError in : Utilities." + ex.TargetSite + " - " + ex.StackTrace.Substring(ex.StackTrace.IndexOf("line")) + ".");
            }
        }
    }
}
