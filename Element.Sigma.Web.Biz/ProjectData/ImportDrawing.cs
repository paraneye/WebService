using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using Element.Shared.Common;
using System.Web;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class ImportDrawing
    {
        /// <summary>
        /// List Drawing Info After ImportDrawing
        /// </summary>
        /// <param name="fileName"></param>
        public SigmaResultType ListDrawingByImportHistoryId(int ImportHistoryId, string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ImportHistoryId", ImportHistoryId));
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListDrawingByImportHistoryId", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }


        public SigmaResultType AddDrawing(string fileUrl, string exportfilepath)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable drawingdata = null; 
            

            // Get connection string 123
            string connStr = ConnStrHelper.getDbConnString();

            // * [1] excel file upload - only one file
            string Importedfilename = Path.GetFileNameWithoutExtension(fileUrl);
            //FileInfo fileinfo = new FileInfo(Importedfilename);
            FileInfo fileinfo = new FileInfo(fileUrl);
            long fileSize = fileinfo.Length; // byte
            //long fileSize = 10;
            string fileExtention = Path.GetExtension(fileUrl);
            string fileType = "FILE_TYPE_DRAWING";
            string CreateBy = userinfo.SigmaUserId;

            int fileStroeId;
            int fileId;
            int AffectedRow;

            string fileCategory = "FILE_CATEGORY_DRAWING";

            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistoryMgr HistoryMgr = new ImportHistoryMgr();

            
                // * [2] Save Drawing Info
                drawingdata = ImportHelper.ImportWorkSheet(fileUrl, true, false, "");

                
                #region Make ERR Data Table
                DataTable ErrDataTable = new DataTable("ErrDataTable");
                ErrDataTable = drawingdata.Copy();
                ErrDataTable.Rows.Clear();
                ErrDataTable.Columns.Add("Reason");//Desciption Of Err
                #endregion 
                                               

                #region Get Common Data From DB
                //Get CWP Table
                CommonCodeMgr common = new CommonCodeMgr();
                DataTable CwpdDt = common.GetCommonCode("*", "cwp", "");

                //Get Drawing Type(SigmaCode Table)
                string DrawingTypeWhere = "where CodeCategory = 'DRAWING_TYPE'";
                DataTable DrawingTypeDt = common.GetCommonCode("CodeName", "SigmaCode", DrawingTypeWhere);
                #endregion

                int importid = 0;
                int Failcnt = 0;
                int HisCnt = 0;
                string Failreason = string.Empty;
                

                foreach (DataRow drow in drawingdata.Rows)
                {
                    int failrow = 0;

                    string xlsCwpName = drow["*CWP"].ToString();
                    string xlsDrawingno = drow["*Drawing Number"].ToString();
                    string xlsFileName = drow["*File Name"].ToString();
                    string xlsRevision = drow["*Revision"].ToString();
                    string xlsTitle = drow["*Drawing Title"].ToString();
                    string xlsDesc = drow["*Drawing Description"].ToString();
                    string xlsDrawingType = drow["*Drawing Type"].ToString();
                    string xlsRefDrawingno = drow["Reference Drawings"].ToString();
                    string xlsDetDrawingno = drow["Detailed Drawings"].ToString();

                    
                    DataRow[] CwpRow = CwpdDt.Select("CwpName = '" + xlsCwpName + "'");
                    DataRow[] DrawingTypeRow = DrawingTypeDt.Select("CodeName = '" + xlsDrawingType + "'");

                    #region 1.  Set ErrDataTable

                    Failreason = GetFailreasonForRequired(drow);

                    if (string.IsNullOrEmpty(Failreason))
                    {
                        if (CwpRow.Length == 0)
                        {
                            ErrDataTable.Rows.Add(drow.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = " InCorrect CWP!!";
                            Failcnt = Failcnt + 1;
                            failrow = 1;
                        }
                        //else if (string.IsNullOrEmpty(xlsDrawingno.Trim()))
                        //{
                        //    ErrDataTable.Rows.Add(drow.ItemArray);
                        //    ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = " Drawing Number is required for Import";
                        //    Failcnt = Failcnt + 1;
                        //    failrow = 1;
                        //}
                        else if (DrawingTypeRow.Length == 0)
                        {
                            ErrDataTable.Rows.Add(drow.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = " InCorrect DrawingType!!";
                            Failcnt = Failcnt + 1;
                            failrow = 1;
                        }
                    }
                    else
                    {
                        ErrDataTable.Rows.Add(drow.ItemArray);
                        ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = Failreason;
                        Failcnt = Failcnt + 1;
                        failrow = 1;
                    }

                    #endregion

                    if (failrow == 1)
                        continue;


                    //ImportHistoryId 값 구하기 위해
                    if (HisCnt == 0)
                    {
                        SigmaResultType AddResult = AddImportHistory(0, 0, fileUrl, "DRAWING");
                        importid = Convert.ToInt32(AddResult.ScalarValue);
                        HisCnt = 1;// ImportHistory Table 한번만 입력
                    }

                    SqlParameter[] drawingParm = new SqlParameter[] {
                                //new SqlParameter("@ImportedSourceFileInfoID", fileId), 
                                new SqlParameter("@ImportedSourceFileInfoID", importid), 
                                new SqlParameter("@CwpName", xlsCwpName),
                                new SqlParameter("@Name", xlsDrawingno), 
                                new SqlParameter("@FileName", xlsFileName), 
                                new SqlParameter("@Title", xlsTitle),
                                new SqlParameter("@Description", xlsDesc),
                                new SqlParameter("@Revision", xlsRevision),
                                new SqlParameter("@DrawingType", xlsDrawingType),
                                new SqlParameter("@CreatedBy", CreateBy),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100), // sp에서 output 설정했을 경우
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

                    drawingParm[9].Direction = ParameterDirection.Output;
                    drawingParm[10].Direction = ParameterDirection.ReturnValue;
                                        
                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDrawing", drawingParm);
                    string resultMsg = (string)drawingParm[9].Value;
                    AffectedRow = (int)drawingParm[10].Value;

                    
                }
                           

                //#region 7. Update Fail Count/Success Count(ImportHistory Table)
                //Failcnt = Failcnt++;
                //SigmaResultType UpdateImportHistory = new SigmaResultType();
                //int iTotalCnt = drawingdata.Rows.Count;
                //int iSuccessCnt = iTotalCnt - Failcnt;
                //ImportHistory.ImportCategory = "DRAWING";
                //ImportHistory.ImportedFileName = Path.GetFileName(fileUrl).ToString();
                //ImportHistory.ImportedDate = DateTime.Now.ToString();
                //ImportHistory.TotalCount = iTotalCnt;
                //ImportHistory.SuccessCount = iSuccessCnt;
                //ImportHistory.FailCount = Failcnt;
                //ImportHistory.UpdatedBy = "ADMIN";
                //ImportHistory.ImportHistoryId = importid;
                //UpdateImportHistory = HistoryMgr.UpdateImportHistory(ImportHistory);
                //#endregion 



                ////ConvertExcel file && CSV file
                //Export2Excel.ConvertExcelfromData(ErrDataTable, importid.ToString());
                //Export2Excel.ConvertCSVFile(ErrDataTable, importid.ToString());
                



            // Import 후에 Reference Drawing 처리 한다. Transaction 독립 --> 변경 할 것.. Import 진행 중 모든 Reference Data 성립하는지 검증해 Miss Match 처리
            // [3] Save ReferenceDrawing Info
            drawingdata = ImportHelper.ImportWorkSheet(fileUrl, true, false, "");

            DrawingMgr drawingmgr = new DrawingMgr();
            SigmaResultType refresult = new SigmaResultType();

            foreach (DataRow drow in drawingdata.Rows)
            {
                //string xlsDrawingno = drow["Drawing Number"].ToString();
                //string xlsRevision = drow["Revision"].ToString();
                //string xlsRefDrawingno = drow["Reference Drawings"].ToString();
                //string xlsDetailDrawingno = drow["Detailed Drawings"].ToString();

                string xlsDrawingno = drow["*Drawing Number"].ToString();
                string xlsRevision = drow["*Revision"].ToString();
                string xlsRefDrawingno = drow["Reference Drawings"].ToString();
                string xlsDetailDrawingno = drow["Detailed Drawings"].ToString();

                // * RefDrawingNo는 하나의 컬럼에 ,로 구분지어 여러건 입력 될 수 있다. --> DetailDrawingNo 도 추가 할 것. leebw 02.17

                if (string.IsNullOrEmpty(xlsRefDrawingno))
                    continue;

                string[] arrRefDrawingno = xlsRefDrawingno.Split(',');

                foreach (string refdrawno in arrRefDrawingno)
                {
                    int failrow = 0;

                    refresult = drawingmgr.GetDrawingByNumber(refdrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        //result.IsSuccessful = false;
                        //result.ErrorMessage = "Incorrect Reference Drawing";
                        //return result;
                        ErrDataTable.Rows.Add(drow.ItemArray);
                        ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = " InCorrect Reference Drawing(not found)";
                        Failcnt = Failcnt + 1;
                        failrow = 1;
                    }

                    if (failrow == 1)
                        continue;



                    SqlParameter[] drawingParm = new SqlParameter[] {
                        new SqlParameter("@RefDrawingNo", refdrawno.Trim()), 
                        new SqlParameter("@DrawingNo", xlsDrawingno), 
                        new SqlParameter("@DetailDrawingNo", xlsDetailDrawingno), 
                        new SqlParameter("@Revision", xlsRevision),
                        new SqlParameter("@CreatedBy", CreateBy),
                        new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

                    drawingParm[5].Direction = ParameterDirection.ReturnValue;

                    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddReferenceDrawing", drawingParm);
                        //int AffectedRow = (int)drawingParm[5].Value;
                        AffectedRow = (int)drawingParm[5].Value;

                        scope.Complete();
                    }
                }


                // * DetailDrawingNo는 하나의 컬럼에 ,로 구분지어 여러건 입력 될 수 있다.
                if (string.IsNullOrEmpty(xlsDetailDrawingno))
                    continue;

                string[] arrDetailDrawingno = xlsDetailDrawingno.Split(',');

                foreach (string detaildrawno in arrDetailDrawingno)
                {
                    int failrow = 0;

                    refresult = drawingmgr.GetDrawingByNumber(detaildrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        ErrDataTable.Rows.Add(drow.ItemArray);
                        ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Reason"] = " InCorrect Detail Drawing(not found)";
                        Failcnt = Failcnt + 1;
                        failrow = 1;
                    }

                    if (failrow == 1)
                        continue;
                    
                    SqlParameter[] detaildrawingParm = new SqlParameter[] {
                        new SqlParameter("@DetailDrawingNo", detaildrawno.Trim()), 
                        new SqlParameter("@DrawingNo", xlsDrawingno), 
                        new SqlParameter("@Revision", xlsRevision),
                        new SqlParameter("@CreatedBy", CreateBy),
                        new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

                    detaildrawingParm[4].Direction = ParameterDirection.ReturnValue;

                    using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDetailDrawing", detaildrawingParm);
                        AffectedRow = (int)detaildrawingParm[4].Value;

                        scope.Complete();
                    }
                }
            }

            #region 7. Update Fail Count/Success Count(ImportHistory Table)
            Failcnt = Failcnt++;
            SigmaResultType UpdateImportHistory = new SigmaResultType();
            int iTotalCnt = drawingdata.Rows.Count;
            int iSuccessCnt = iTotalCnt - Failcnt;
            ImportHistory.ImportCategory = "DRAWING";
            ImportHistory.ImportedFileName = Path.GetFileName(fileUrl).ToString();
            ImportHistory.ImportedDate = DateTime.Now.ToString();
            ImportHistory.TotalCount = iTotalCnt;
            ImportHistory.SuccessCount = iSuccessCnt;
            ImportHistory.FailCount = Failcnt;
            ImportHistory.UpdatedBy = "ADMIN";
            ImportHistory.ImportHistoryId = importid;
            UpdateImportHistory = HistoryMgr.UpdateImportHistory(ImportHistory);
            #endregion
            
            ////ConvertExcel file && CSV file
            //Export2Excel.ConvertExcelfromData(ErrDataTable, importid.ToString());
            //Export2Excel.ConvertCSVFile(ErrDataTable, importid.ToString());
            

            //excel file generate for direct call 'export' link
            Export2Excel.ConvertExcelfromData(ErrDataTable, importid.ToString() + fileExtention, exportfilepath);

            //csv file generate for import error list view
            Export2Excel.ConvertCSVFile(ErrDataTable, importid.ToString() + ".csv", exportfilepath);


            DataSet ds = new DataSet();
                        
            ds.Tables.Add("ImportHistory");
            ds.Tables["ImportHistory"].Columns.Add("Id");
            ds.Tables["ImportHistory"].Columns.Add("Total");
            ds.Tables["ImportHistory"].Columns.Add("Success");
            ds.Tables["ImportHistory"].Columns.Add("Fail");

            string[] str = new string[4];

            str[0] = importid.ToString();
            str[1] = iTotalCnt.ToString();
            str[2] = iSuccessCnt.ToString();
            str[3] = Failcnt.ToString();

            ds.Tables["ImportHistory"].Rows.Add(str);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            //result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;




            // 엑셀 파일 삭제
            System.IO.File.Delete(fileUrl);


            return result;
        }

        private string GetFailreasonForRequired(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "CWP,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "Drawing Number,";
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "File Name,";
            if (string.IsNullOrEmpty(r[3].ToString()))
                rslt += "Revision,";
            if (string.IsNullOrEmpty(r[4].ToString()))
                rslt += "Drawing Title,";
            if (string.IsNullOrEmpty(r[5].ToString()))
                rslt += "Drawing Description,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }

        public SigmaResultType AddDrawingImage(string sourcePath, string targetPath)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            //PDFLibNet.PDFWrapper pdfDoc;

            PDFLibNet.PDFWrapper pdfDoc = new PDFLibNet.PDFWrapper();


            ////       target directory 는 쿠키 값 확인하여 추가 경로를 생성해야 된다. 
            ////       추가 경로 --> [company]/[project id]/[document type]/[document name(id)]/[document revision]
            //string targetChildPath = "Company\\" + "Project\\" + "Drawing\\";

            string targetChildPath = userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "Drawing\\";

            targetPath = targetPath + targetChildPath;

            // Source Path에서 읽고 확인 후 정상이면 Target Path로 이동
            string[] filePaths = Directory.GetFiles(sourcePath);
            
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();


            // * [1] Image file upload - multiple files
            foreach (string path in filePaths)
            {


                string convertfilepath = string.Empty;
                string Importedfilename = Path.GetFileNameWithoutExtension(path);
                FileInfo fileinfo = new FileInfo(path);
                long fileSize = fileinfo.Length; // byte
                string fileExtention = Path.GetExtension(path);
                string fileType = "FILE_TYPE_DRAWING";
                string CreateBy = userinfo.SigmaUserId;

                int fileStroeId;
                int fileId;

                string fileCategory = "FILE_CATEGORY_DRAWING";

                if (fileExtention == ".pdf" || fileExtention == ".PDF")
                {
                    // pdf --> jpg 로 변경해서 등록
                    pdfDoc.LoadPDF(path);
                    //pdfDoc.RenderPage();
                    convertfilepath = targetPath + Importedfilename + ".jpg";
                    //pdfDoc.ExportJpg(@"c:\temp\page_pdf%d.jpg", 1, 1, 150, 90);
                    //*** waitpoc  --> 동기화, 비동기화 --> 기다릴 거냐?
                    pdfDoc.ExportJpg(convertfilepath, 1, 1, 150, 90, 1);

                    //** Dispose 시점을 늦춰 본다.. 아래 foreach end 시점  -- Object X  foreach 밖으로 사용 후에 처리 할 것
                    //pdfDoc.Dispose()

                }
                else if (fileExtention == ".xls" || fileExtention == ".xlsx")
                    continue;

                //---------------------------------------------------------------------------

                
                SqlParameter[] fileStoreParm = new SqlParameter[] {
                    new SqlParameter("@FileStoreID", SqlDbType.Int, 10), // sp에서 output 설정했을 경우
                    new SqlParameter("@Title", Importedfilename), 
                    new SqlParameter("@Description", Importedfilename),
                    new SqlParameter("@Category", fileCategory),
                    new SqlParameter("@TypeCode", fileType),
                    new SqlParameter("@CreatedBy", CreateBy),
                    new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                };

                fileStoreParm[0].Direction = ParameterDirection.Output;
                fileStoreParm[6].Direction = ParameterDirection.ReturnValue;

                // 하나의 TransctionScope으로..
                using (scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddFileStoreDrawing", fileStoreParm);

                    fileStroeId = (int)fileStoreParm[0].Value;
                    int AffectedRow = (int)fileStoreParm[6].Value;

                    string targetFilePath = targetChildPath + Importedfilename + ".jpg";
                                       

                    // Compose parameters
                    SqlParameter[] uploadfileParm = new SqlParameter[] {
                        new SqlParameter("@UploadedFileInfoId", SqlDbType.Int, 10), // sp에서 output 설정했을 경우
                        new SqlParameter("@FileStoreID", fileStroeId),
                        new SqlParameter("@Name", Importedfilename), 
                        new SqlParameter("@Size", fileSize),
                        //new SqlParameter("@Path", path),
                        new SqlParameter("@Path", targetFilePath),
                        new SqlParameter("@FileExtension", fileExtention),
                        new SqlParameter("@Revision", "None"),
                        new SqlParameter("@FileType", fileType),
                        new SqlParameter("@CreatedBy", CreateBy),
                        new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

                    uploadfileParm[0].Direction = ParameterDirection.Output;
                    uploadfileParm[9].Direction = ParameterDirection.ReturnValue;


                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddUploadedFileInfoDrawing", uploadfileParm);

                    fileId = (int)uploadfileParm[0].Value;
                    int uploadAffectedRow = (int)uploadfileParm[9].Value;

                    scope.Complete();
                }
                
            }
                        
            pdfDoc.Dispose();
            pdfDoc = null;

            // * [2] To Copy all the files (in source directory -> to target directory)

            //MemoryStream destination = new MemoryStream();

            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] sourcefilePaths = Directory.GetFiles(sourcePath);
                foreach (string sourceFile in sourcefilePaths)
                {
                    string sourcefilename = Path.GetFileNameWithoutExtension(sourceFile);
                    string fileExtention = Path.GetExtension(sourceFile);
                    //string sourceFile = System.IO.Path.Combine(sourcePath, sourcefilename);

                    string destFile = System.IO.Path.Combine(targetPath, sourcefilename + fileExtention);
                    try
                    {
                            
                        // *** converted jpg File
                        string strSavePath = targetPath + sourcefilename + ".jpg";

                        // Thumbnail 비율 적용 - 원본 이미지의  가로:세율 비율 확인 - 축소 길이 - 가로 고정 - 200)
                        System.IO.Stream imgstream = File.Open(strSavePath, FileMode.Open);
                        System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(imgstream);
                        
                        float orgheight = sourceImage.PhysicalDimension.Height;
                        float orgwidth = sourceImage.PhysicalDimension.Width;
                        int newwidth = 200;

                        float newheight = orgheight / orgwidth * newwidth;

                        System.Drawing.Image thumbnailImage = sourceImage.GetThumbnailImage(newwidth, (int)newheight, null, IntPtr.Zero);
                        thumbnailImage.Save(targetPath + sourcefilename + ".thumbnail" + ".jpg");

                        imgstream.Dispose();

                        //  pdf file copy to DocumentFolderRoot
                        System.IO.File.Copy(sourceFile, destFile, true);

                    }
                    catch (System.IO.IOException copye)
                    {
                        //Console.WriteLine(copye.Message);
                        result.ErrorMessage = copye.Message + " copy error";
                        result.IsSuccessful = false;
                        return result;
                    }
                }
            }
            else
            {
                //Console.WriteLine("Source path does not exist!");
                result.ErrorMessage = "Source path : " + sourcePath + " does not exist!";
                result.IsSuccessful = false;
                return result;
            }
            
            // * [3] Delete source files - optional
            try
            {
                string[] sourcefilePaths = Directory.GetFiles(sourcePath);
                foreach (string sourceFile in sourcefilePaths)
                {
                    System.IO.File.Delete(sourceFile);
                }
            }
            catch (System.IO.IOException dele)
            {
                //Console.WriteLine(dele.Message);
                result.ErrorMessage = dele.Message + " delete error";
                result.IsSuccessful = false;
                return result;
            }


            result.IsSuccessful = true;
            return result;
        }


        private SigmaResultType AddImportHistory(int iTotalCnt, int FailCnt, string filePath, string ImportCategory)
        {
            SigmaResultType HistoryResult = new SigmaResultType();
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistoryMgr HistoryMgr = new ImportHistoryMgr();

            int Failcnt = FailCnt++;
            int iSuccessCnt = iTotalCnt - Failcnt;
            ImportHistory.ImportCategory = ImportCategory;
            ImportHistory.ImportedFileName = Path.GetFileName(filePath).ToString();
            ImportHistory.ImportedDate = DateTime.Now.ToString();
            ImportHistory.TotalCount = iTotalCnt;
            ImportHistory.SuccessCount = iSuccessCnt;
            ImportHistory.FailCount = Failcnt;
            ImportHistory.CreatedBy = "ADMIN";
            return HistoryResult = HistoryMgr.AddImportHistory(ImportHistory);
        }
    }
}

