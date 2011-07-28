using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using C1.Win.C1FlexGrid;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.FileManager.Controller
{
    public class FileManager
    {
        Document loDocument;
        DocAuthor loDocAuthor;
        DocEditor loDocEditor;
        DocTag loDocTag;

        ImageBO loImage;
        ImageTag loImageTag;

        MySqlTransaction loMySqlTransaction;

        Microsoft.Office.Interop.Word.Application _oApplication;
        Microsoft.Office.Interop.Word.Document _oDocument;


        public object FileUpload
        {
            get;
            set;
        }

        public object ImageUpload
        {
            get;
            set;
        }


        public FileManager()
        {
            loDocument = new Document();
            loDocAuthor = new DocAuthor();
            loDocEditor = new DocEditor();
            loDocTag = new DocTag();
            loImage = new ImageBO();
            loImageTag = new ImageTag();
        }

        public void uploadFiles(C1FlexGrid poGrid)
        {
            for (int i = 1; i < poGrid.Rows.Count; i++)
            {
                try
                {
                    object[] _progressCount = new object[2];
                    _progressCount[0] = poGrid.GetDataDisplay(i, "Title");

                    //update database
                    loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();

                    //para ni sa loading text -- file to db
                    _progressCount[1] = 1;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    loDocument.Title = poGrid.GetDataDisplay(i, "Title");
                    loDocument.Path = GlobalVariables.goFileServer;
                    loDocument.Newspaper = poGrid.GetDataDisplay(i, "Newspaper");
                    loDocument.Doctype = poGrid.GetDataDisplay(i, "Doc Type");
                    loDocument.Section = poGrid.GetDataDisplay(i, "Section");
                    loDocument.PublishedDate = poGrid.GetDataDisplay(i, "Published Date");

                    //generate preview
                    string _preview = "";
                    switch (loDocument.Doctype)
                    {
                        case ".rtf":
                        case ".doc":
                            //add preview
                            try
                            {
                                object readOnly = false;
                                object isVisible = false;
                                object _missing = System.Reflection.Missing.Value;
                                _oApplication = new Microsoft.Office.Interop.Word.Application();
                                //_oDocument = _oApplication.Documents.Open(poGrid.GetDataDisplay(i, "Local Path"));
                                object _path = @"" + poGrid.GetDataDisplay(i, "Local Path").ToString();
                                _oDocument = _oApplication.Documents.Open(ref _path, ref _missing,
                                ref readOnly, ref _missing, ref _missing, ref _missing,
                                ref _missing, ref _missing, ref _missing, ref _missing,
                                ref _missing, ref isVisible, ref _missing, ref _missing,
                                ref _missing, ref _missing);
                                _preview = GlobalFunctions.addSlashes(_oDocument.Content.Text);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                _oDocument.Close();
                                _oApplication.Quit();
                            }
                            break;

                        case ".txt":
                            //add preview
                            string _textPreview = File.ReadAllText(poGrid.GetDataDisplay(i, "Local Path"));
                            _preview = GlobalFunctions.addSlashes(_textPreview);
                            break;
                    }

                    loDocument.Preview = _preview;

                    string _docId = loDocument.insert(ref loMySqlTransaction);

                    char[] _separator = { ',' };

                    //para ni sa loading text -- authors
                    _progressCount[1] = 2;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    //add authors
                    string[] _authors = poGrid.GetDataDisplay(i, "Authors").Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string _str in _authors)
                    {
                        loDocAuthor.AuthorId = _str;
                        loDocAuthor.DocumentId = _docId;
                        loDocAuthor.insert(ref loMySqlTransaction);
                    }

                    //para ni sa loading text -- editors
                    _progressCount[1] = 3;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    //add editors
                    string[] _editors = poGrid.GetDataDisplay(i, "Editors").Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string _str in _editors)
                    {
                        loDocEditor.EditorId = _str;
                        loDocEditor.DocumentId = _docId;
                        loDocEditor.insert(ref loMySqlTransaction);
                    }

                    //para ni sa loading text -- tags
                    _progressCount[1] = 4;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    //add tags
                    string[] _tags = poGrid.GetDataDisplay(i, "Tags").Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                    IList<string> _tagList = GlobalFunctions.removeRedundancy(_tags);

                    foreach (string _str in _tagList)
                    {
                        loDocTag.Tag = _str.ToLower().Trim();
                        loDocTag.DocumentId = _docId;
                        try
                        {
                            loDocTag.insert(ref loMySqlTransaction);
                        }
                        catch { }
                    }

                    //para ni sa loading text -- hidden tags
                    _progressCount[1] = 5;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    //add hidden tags
                    IList<string> _hiddenTagList = new List<string>();
                    //start with the dates
                    DateTime _publishedDate = DateTime.Parse(poGrid.GetDataDisplay(i, "Published Date"));
                    _hiddenTagList.Add(_publishedDate.ToString("yyyy")); //year
                    _hiddenTagList.Add(_publishedDate.ToString("MMM")); //short month name
                    _hiddenTagList.Add(_publishedDate.ToString("MMMM")); //month name
                    _hiddenTagList.Add(_publishedDate.ToShortDateString());
                    _hiddenTagList.Add(_publishedDate.ToLongDateString());
                    _hiddenTagList.Add(_publishedDate.ToString("yyyy-MM-dd"));
                    _hiddenTagList.Add(_publishedDate.ToString("dd-MM-yy"));

                    //title
                    char[] _whiteSpaceSeparator = { ' ' };
                    string[] _splitTitle = loDocument.Title.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string _str in _splitTitle)
                    {
                        _hiddenTagList.Add(_str);
                    }

                    //authors
                    string[] _authorNames = poGrid.GetDataDisplay(i, "Names").Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string _str in _authorNames)
                    {
                        string[] _nameSplit = _str.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string _str2 in _nameSplit)
                        {
                            _hiddenTagList.Add(_str2);
                        }
                    }

                    //editors
                    string[] _editorInitials = poGrid.GetDataDisplay(i, "Initials").Split(_separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string _str in _editorInitials)
                    {
                        string[] _initialSplit = _str.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string _str2 in _initialSplit)
                        {
                            _hiddenTagList.Add(_str2);
                        }
                    }

                    //also add the newspaper and section as tags
                    _hiddenTagList.Add(loDocument.Newspaper);
                    _hiddenTagList.Add(poGrid.GetDataDisplay(i, "Section Name"));

                    //remove repetitive entries
                    IList<string> _noRepeatHiddenTags = GlobalFunctions.removeRedundancy(_hiddenTagList.ToArray<string>());

                    //save to database like a baws
                    foreach (string _str in _noRepeatHiddenTags)
                    {
                        if (_str != "" || _str != null)
                        {
                            loDocTag.Tag = _str.ToLower().Trim();
                            loDocTag.DocumentId = _docId;
                            try
                            {
                                loDocTag.insert(ref loMySqlTransaction);
                            }
                            catch { }
                        }
                    }

                    //para ni sa loading text -- first 100 words
                    _progressCount[1] = 6;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text

                    //get the document contents, but check for it's doctype first though!
                    switch (loDocument.Doctype)
                    {
                        case ".rtf":
                        case ".doc":
                            string _docContents = "";
                            _oApplication = new Microsoft.Office.Interop.Word.Application();
                            _oDocument = _oApplication.Documents.Open(poGrid.GetDataDisplay(i, "Local Path"));

                            //loop throught the first 100 words

                            int _numberOfWords = 0;

                            if (_oDocument.Words.Count >= 100)
                            {
                                _numberOfWords = 100;
                            }
                            else
                            {
                                _numberOfWords = _oDocument.Words.Count;
                            }

                            for (int _wordCount = 1; _wordCount <= _numberOfWords; _wordCount++)
                            {
                                _docContents += _oDocument.Words[_wordCount].Text;
                            }

                            string[] _docContentsArr = _docContents.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);

                            IList<string> _docContentsList = GlobalFunctions.removeRedundancy(_docContentsArr);

                            foreach (string _str in _docContentsList)
                            {
                                if (_str.Length > 1)
                                {
                                    loDocTag.Tag = _str.ToLower().Trim();
                                    loDocTag.DocumentId = _docId;
                                    try
                                    {
                                        loDocTag.insert(ref loMySqlTransaction);
                                    }
                                    catch { }
                                }
                            }
                            break;
                        case ".txt":
                            string _textContents = File.ReadAllText(poGrid.GetDataDisplay(i, "Local Path"));
                            string[] _textContentsArr = _textContents.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);

                            IList<string> _textContentsList = GlobalFunctions.removeRedundancy(_textContentsArr);
                            foreach (string _str in _textContentsList)
                            {
                                if (_str.Length > 1)
                                {
                                    loDocTag.Tag = _str.ToLower().Trim();
                                    loDocTag.DocumentId = _docId;
                                    try
                                    {
                                        loDocTag.insert(ref loMySqlTransaction);
                                    }
                                    catch { }
                                }
                            }
                            break;
                    }

                    //maypa ang mysqltransaction, mu commit!
                    loMySqlTransaction.Commit();

                    //copy file to server
                    File.Copy(@"" + poGrid.GetDataDisplay(i, "Local Path"), @"" + GlobalVariables.goFileServer + @"\" + _docId + loDocument.Doctype);

                    //para ni sa loading text -- first 100 words
                    _progressCount[1] = 7;
                    FileUpload.GetType().GetMethod("reportProgress").Invoke(FileUpload, _progressCount);
                    //^para sa loading text
                }
                catch (Exception)
                {
                    loMySqlTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (_oDocument != null)
                    {
                        _oDocument.Close();
                        _oApplication.Quit();
                    }

                    GC.Collect();
                }
            }
        }

        public void uploadImages(C1FlexGrid poGrid)
        {
            for (int i = 1; i < poGrid.Rows.Count; i++)
            {
                try
                {
                    object[] _progressCount = new object[2];
                    char[] _separator = { ',' };
                    char[] _whiteSpaceSeparator = { ' ' };

                    //begin
                    loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();

                    string _imageId = "";

                    //para ni sa loading text -- saving image to db
                    _progressCount[0] = poGrid.GetDataDisplay(i, "Title");
                    _progressCount[1] = 1;
                    ImageUpload.GetType().GetMethod("reportProgress").Invoke(ImageUpload, _progressCount);
                    //^para sa loading text

                    loImage.Title = poGrid.GetDataDisplay(i, "Title");
                    loImage.Path = poGrid.GetDataDisplay(i, "Local Path");
                    loImage.PhotographerId = poGrid.GetDataDisplay(i, "Photographer ID");
                    loImage.Caption = poGrid.GetDataDisplay(i, "Caption");
                    loImage.Location = poGrid.GetDataDisplay(i, "Location");
                    loImage.DateTaken = DateTime.Parse(poGrid.GetDataDisplay(i, "Date Taken"));
                    loImage.Type = poGrid.GetDataDisplay(i, "Type");

                    _imageId = loImage.insert(ref loMySqlTransaction);

                    //para ni sa loading text -- saving tags to db
                    _progressCount[1] = 2;
                    ImageUpload.GetType().GetMethod("reportProgress").Invoke(ImageUpload, _progressCount);
                    //^para sa loading text

                    IList<string> _tagList = poGrid.GetDataDisplay(i, "Tags").Split(_separator, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string _str in _tagList)
                    {
                        loImageTag.ImageId = _imageId;
                        loImageTag.Tag = _str.ToLower().Trim();
                        try
                        {
                            loImageTag.insert(ref loMySqlTransaction);
                        }
                        catch { }
                    }

                    //para ni sa loading text -- saving hidden tags to db
                    _progressCount[1] = 3;
                    ImageUpload.GetType().GetMethod("reportProgress").Invoke(ImageUpload, _progressCount);
                    //^para sa loading text

                    IList<string> _hiddenTagList = new List<string>();
                    //start with the dates
                    DateTime _dateTaken = DateTime.Parse(poGrid.GetDataDisplay(i, "Date Taken"));
                    _hiddenTagList.Add(_dateTaken.ToString("yyyy")); //year
                    _hiddenTagList.Add(_dateTaken.ToString("MMM")); //short month name
                    _hiddenTagList.Add(_dateTaken.ToString("MMMM")); //month name
                    _hiddenTagList.Add(_dateTaken.ToShortDateString());
                    _hiddenTagList.Add(_dateTaken.ToLongDateString());
                    _hiddenTagList.Add(_dateTaken.ToString("yyyy-MM-dd"));
                    _hiddenTagList.Add(_dateTaken.ToString("dd-MM-yy"));

                    //title
                    string[] _titleArr = loImage.Title.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                    IList<string> _titleList = GlobalFunctions.removeRedundancy(_titleArr);

                    foreach (string _str in _titleList)
                    {
                        _hiddenTagList.Add(_str);
                    }

                    //photographer
                    string[] _photographerArr = poGrid.GetDataDisplay(i, "Photographer").Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                    IList<string> _photographerList = GlobalFunctions.removeRedundancy(_photographerArr);

                    foreach (string _str in _photographerList)
                    {
                        _hiddenTagList.Add(_str);
                    }

                    //caption
                    string[] _captionArr = loImage.Caption.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                    IList<string> _captionList = GlobalFunctions.removeRedundancy(_captionArr);

                    foreach (string _str in _captionList)
                    {
                        _hiddenTagList.Add(_str);
                    }

                    //location
                    string[] _locationArr = loImage.Location.Split(_whiteSpaceSeparator, StringSplitOptions.RemoveEmptyEntries);
                    IList<string> _locationList = GlobalFunctions.removeRedundancy(_locationArr);

                    foreach (string _str in _captionList)
                    {
                        _hiddenTagList.Add(_str);
                    }

                    //remove repetitive entries
                    IList<string> _noRepeatHiddenTags = GlobalFunctions.removeRedundancy(_hiddenTagList.ToArray<string>());

                    //save to database like a baws
                    foreach (string _str in _noRepeatHiddenTags)
                    {
                        if (_str != "" || _str != null)
                        {
                            loImageTag.Tag = _str.ToLower().Trim();
                            loImageTag.ImageId = _imageId;
                            try
                            {
                                loImageTag.insert(ref loMySqlTransaction);
                            }
                            catch { }
                        }
                    }

                    loMySqlTransaction.Commit();

                    //File.Copy(@"" + poGrid.GetDataDisplay(i, "Local Path"), @"" + GlobalVariables.goImageServer + @"\" + _imageId + loImage.Type);

                    //para ni sa loading text -- copying image to server
                    _progressCount[1] = 4;
                    ImageUpload.GetType().GetMethod("reportProgress").Invoke(ImageUpload, _progressCount);
                    //^para sa loading text

                    Stream buffer;
                    StreamReader srImage = new StreamReader(poGrid.GetDataDisplay(i, "Local Path"));
                    buffer = srImage.BaseStream;
                    Bitmap bmImage = new Bitmap(buffer);
                    bmImage.Save(GlobalVariables.goImageServer + @"\" + _imageId + loImage.Type);

                    //para ni sa loading text -- done
                    _progressCount[1] = 5;
                    ImageUpload.GetType().GetMethod("reportProgress").Invoke(ImageUpload, _progressCount);
                    //^para sa loading text
                }
                catch (Exception ex)
                {
                    loMySqlTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
