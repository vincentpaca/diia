using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
namespace EchoSystems.DIIA.FileSearch.Models
{
    public class Converter
    {
        public bool convertDocToTxt(string pSourcePath, string pDestinationPath)
        {
            object _missing = System.Reflection.Missing.Value;
            Word.Application wordApp = new Word.Application();
            Word.Document aDoc = null;
            try
            {
                if (File.Exists(@"" + pSourcePath))
                {


                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;

                    object path = @"" + pSourcePath;

                    aDoc = wordApp.Documents.Open(ref path, ref _missing,
                            ref readOnly, ref _missing, ref _missing, ref _missing,
                            ref _missing, ref _missing, ref _missing, ref _missing,
                            ref _missing, ref isVisible, ref _missing, ref _missing,
                            ref _missing, ref _missing);
                    string _content = aDoc.Content.Text;
                    _content = _content.Replace("/n", "/r/n");
                    _content = _content.Trim();
                    File.WriteAllText(@"" + pDestinationPath, _content);
                    return true;
                }
                else
                {
                    MessageBox.Show("File does not exist!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                aDoc.Close();
                wordApp.Quit();
                GC.Collect();
            }
        }

        public bool convertTxtToDoc(string pSourcePath, string pDestinationPath)
        {
            object missing = System.Reflection.Missing.Value;
            object Visible = true;
            object start1 = 0;
            object end1 = 0;
            Word.Application WordApp = new Word.Application();
            Word.Document adoc = null;
            try
            {
                if (File.Exists(@"" + pSourcePath))
                {


                    string _content = File.ReadAllText(pSourcePath);
                    adoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                    Word.Range rng = adoc.Range(ref start1, ref missing);
                    rng.Font.Name = "Georgia";
                    rng.InsertAfter(_content);
                    object filename = @"" + pDestinationPath;
                    adoc.SaveAs(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                    return true;

                }
                else
                {
                    MessageBox.Show("File does not exist!", "DIIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                adoc.Close();
                WordApp.Quit();
                GC.Collect();
            }
        }
    }
}
