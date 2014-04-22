using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.IO;
using System.Collections.Generic;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;


namespace Element.Sigma.Web.Biz.ProjectData
{
    public class ImportMgr
    {
        TypeUserInfo userinfo = AuthMgr.GetUserInfo();

        #region Convert Excel To DataTable
        /// <summary>
        /// Convert Excel To DataTable
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <param name="workSheet">workSheet</param>
        /// <returns></returns>
        public SigmaResultType ImportMTOFromExcel(string filePath, string exportfilepath)
        {
            DataTable dt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);

            int moduleId = Modules.Civil; // 임시

            if (dt.Rows.Count < 1)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = "no record from file.";
            }

            switch (moduleId)
            {
                case Modules.Piping:
                    break;
                case Modules.Electrical:
                    break;
                case Modules.Instrumentation:
                    break;
                case Modules.Scaffold:
                    break;
                case Modules.Insulation:
                    break;
                case Modules.Steel:
                    break;
                case Modules.Mechanical:
                    break;
                case Modules.Civil:
                    result = ImportCivilMto(dt, filePath, exportfilepath);
                    break;
                case Modules.MAGS:
                    break;
            }

            return result;
        }

        #endregion 

        #region MTO : Edit Material Information
        public SigmaResultType UpdateMTO(TypeComponent objComponent, TypeMaterial objMaterial)
        {
            SigmaResultType sResult = new SigmaResultType();
            CommonCodeMgr common = new CommonCodeMgr();
            ComponentMgr comMgr = new ComponentMgr();
            ComponentProgressMgr comproMgr = new ComponentProgressMgr();
            CommonCodeMgr commonMgr = new CommonCodeMgr();
            DataRow[] StepRow = null;

            decimal ComQty = objComponent.Qty; string MultiQty = "N"; decimal EstimatedManhour = 0;

            List<TypeComponentProgress> listComponentProgress = new List<TypeComponentProgress>();

            //Get Material Table
            string MtrWhere = "where DisciplineCode = 'DISCIPLINE_CIVIL'";
            DataTable MtrDt = common.GetCommonCode("*", "Material", MtrWhere);

            //Check Exist material name 
            DataRow[] MtrRow = MtrDt.Select("TaskCategoryId = '" + objMaterial.TaskCategoryId + "' " +
                            "AND TaskTypeId = '" + objMaterial.TaskTypeId + "' " + " AND Description = '" + objMaterial.Description + "'");

            //StepRow의 Data 없는 경우 [progressStep Table 에서 ProgressStepId = 13|| Name = default progress의  Weight 값으로 처리]
            DataRow[] defaultStepRow = new DataTable().Select();//common.GetCommonCode("*", "ProgressStep", " Where Name = 'Default work'").Select();

            //Check Material
            if (MtrRow.Length > 0)
            {
                objComponent.MaterialId = int.Parse(MtrRow[0][0].ToString());

                StepRow = commonMgr.GetProgressStepByTaskCategoryTaskType(objMaterial.TaskCategoryId, objMaterial.TaskTypeId).Select();

                if (StepRow.Length > 0)
                {
                    foreach (DataRow Step in StepRow)
                    {
                        TypeComponentProgress obj = new TypeComponentProgress();
                        MultiQty = Step["IsMultipliable"].ToString();

                        if (MultiQty == "Y") // ProgressStep > IsMultipliable(MultipliedByQty) = "Y" 
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        else
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty 2014.3.31  임시 IsMultipliable 구분 없도록
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                        listComponentProgress.Add(obj);
                    }
                }
                else
                {
                    TypeComponentProgress obj = new TypeComponentProgress();
                    obj.EstimatedManhours = (defaultStepRow.Length > 0 ? Convert.ToDecimal(defaultStepRow[0]["weight"]) : 100) * ComQty;
                    obj.ProgressStepId = defaultStepRow.Length > 0 ? int.Parse(defaultStepRow[0]["ProgressStepId"].ToString()) : 0;
                    EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                    listComponentProgress.Add(obj);
                }

                objComponent.EstimatedManhour = EstimatedManhour;

                sResult = comMgr.AddComponetInfo(objComponent);

            }

            if (sResult.IsSuccessful)
            {
                if (MtrRow.Length > 0)
                {
                    listComponentProgress.ForEach(x => x.ComponentId = objComponent.ComponentId);
                    listComponentProgress.ForEach(x => x.IsCompleted = "N");
                    listComponentProgress.ForEach(x => x.AmountInstalled = 0);
                    listComponentProgress.ForEach(x => x.SigmaOperation = "C");
                    sResult = comproMgr.MultiComponentProgress(listComponentProgress);
                }
                else
                {
                    sResult.IsSuccessful = false;
                    sResult.StringValue = "The Data of Material do not Exist!!";
                }

            }
            else
            {
                sResult.IsSuccessful = false;
                sResult.StringValue = "Add ComponetInfo Failed!!";
            }

            return sResult;
        }
        #endregion
        public SigmaResultType SaveMTO(TypeComponent objComponent, TypeMaterial objMaterial)
        {
            SigmaResultType sResult = new SigmaResultType();
            CommonCodeMgr common = new CommonCodeMgr();
            ComponentMgr comMgr = new ComponentMgr();
            ComponentProgressMgr comproMgr = new ComponentProgressMgr();
            CommonCodeMgr commonMgr = new CommonCodeMgr();
            DataRow[] StepRow = null;

            decimal ComQty = objComponent.Qty; string MultiQty = "N"; decimal EstimatedManhour = 0;

            List<TypeComponentProgress> listComponentProgress = new List<TypeComponentProgress>();

            //Get Material Table
            string MtrWhere = "where DisciplineCode = 'DISCIPLINE_CIVIL'";
            DataTable MtrDt = common.GetCommonCode("*", "Material", MtrWhere);

            //Check Exist material name 
            DataRow[] MtrRow = MtrDt.Select("TaskCategoryId = '" + objMaterial.TaskCategoryId + "' " +
                            "AND TaskTypeId = '" + objMaterial.TaskTypeId + "' " + " AND Description = '" + objMaterial.Description + "'");

            //StepRow의 Data 없는 경우 [progressStep Table 에서 ProgressStepId = 13|| Name = default progress의  Weight 값으로 처리]
            DataRow[] defaultStepRow = new DataTable().Select(); //common.GetCommonCode("*", "ProgressStep", " Where Name = 'Default work'").Select();

            //Check Material
            if (MtrRow.Length > 0)
            {
                objComponent.MaterialId = int.Parse(MtrRow[0][0].ToString());

                StepRow = commonMgr.GetProgressStepByTaskCategoryTaskType(objMaterial.TaskCategoryId, objMaterial.TaskTypeId).Select();

                if (StepRow.Length > 0)
                {
                    foreach (DataRow Step in StepRow)
                    {
                        TypeComponentProgress obj = new TypeComponentProgress();
                        MultiQty = Step["IsMultipliable"].ToString();

                        if (MultiQty == "Y") // ProgressStep > IsMultipliable(MultipliedByQty) = "Y" 
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        else
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty 2014.3.31  임시 IsMultipliable 구분 없도록
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                        listComponentProgress.Add(obj);
                    }
                }
                else
                {
                    TypeComponentProgress obj = new TypeComponentProgress();
                    obj.EstimatedManhours = (defaultStepRow.Length > 0 ? Convert.ToDecimal(defaultStepRow[0]["weight"]) : 100) * ComQty;
                    obj.ProgressStepId = defaultStepRow.Length > 0 ? int.Parse(defaultStepRow[0]["ProgressStepId"].ToString()) : 0;
                    EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                    listComponentProgress.Add(obj);
                }

                objComponent.EstimatedManhour = EstimatedManhour;

                sResult = comMgr.AddComponetInfo(objComponent);

            }

            if (sResult.IsSuccessful)
            {
                if (MtrRow.Length > 0)
                {
                    listComponentProgress.ForEach(x => x.ComponentId = Convert.ToInt32(sResult.ScalarValue));
                    listComponentProgress.ForEach(x => x.IsCompleted = "N");
                    listComponentProgress.ForEach(x => x.AmountInstalled = 0);
                    listComponentProgress.ForEach(x => x.SigmaOperation = "C");
                    sResult = comproMgr.MultiComponentProgress(listComponentProgress);
                }
                else
                {
                    sResult.IsSuccessful = false;
                    sResult.StringValue = "The Data of Material do not Exist!!";
                }

            }
            else
            {
                sResult.IsSuccessful = false;
                sResult.StringValue = "Add ComponetInfo Failed!!";
            }

            return sResult;
        }


        public SigmaResultType ImportCivilMto(DataTable Exceldt, string filePath, string exportfilepath)
        {
            #region Set  Basic

            CommonCodeMgr common = new CommonCodeMgr();
            SigmaResultType SigmaResult = new SigmaResultType();
            DataLoaderCivil loader = new DataLoaderCivil();
            Export2Excel ExportExcel = new Export2Excel();
            TypeComponent cmpt = new TypeComponent();
            TypeMaterial mtr = new TypeMaterial();
            TypeComponentCustomField ccf = new TypeComponentCustomField();
            TypeMaterialCustomField mcf = new TypeMaterialCustomField();
            TypeImportHistory ImportHistory = new TypeImportHistory();
            TypeComponentReferenceDrawing crd = new TypeComponentReferenceDrawing();
            ComponentMgr comMgr = new ComponentMgr();
            MaterialMgr mtrMgr = new MaterialMgr();
            ImportHistoryMgr HistoryMgr = new ImportHistoryMgr();
            ComponentCustomFieldMgr CCFMgr = new ComponentCustomFieldMgr();
            MaterialCustomFieldMgr MCFMgr = new MaterialCustomFieldMgr();
            TypeComponentProgress cmptPro = new TypeComponentProgress();
            ComponentProgressMgr cmpProMgr = new ComponentProgressMgr();
            CommonCodeMgr ComCodeMgr = new CommonCodeMgr();
            ComponentReferenceDrawingMgr crdMgr = new ComponentReferenceDrawingMgr();

            int Failcnt = 0;
            int ImportHistoryId = -1;
            int HisCnt = 0;
            int ComponentID = -1;

            if (Exceldt.Rows.Count > 0)
            {
                loader = MTOImportHelper.GetDataLoaderCivilOrdinal(Exceldt);
            }
            else
            {
                SigmaResult.IsSuccessful = false;
                SigmaResult.ErrorMessage = "no record from file.";
            }

            //Set TagNumber Name 
            DataTable TmGroupDt = SetTagNumber(Exceldt);
            //Make Err Table
            DataTable ErrDataTable =  SetErrTable(Exceldt);
            #endregion

            #region Get Common Data From DB
            string FileName  = Path.GetFileName(filePath).ToString();

            //Get CWP Table 
            //DataTable CwpdDt = common.GetCommonCode("*", "cwp", "");
            DataTable CwpdDt = common.GetCWP();
            SigmaResult = SetErrMassage(CwpdDt, "CWP"); //Err?

            //Get UOM Table 
            string UOMWhere = "Where CodeCategory = 'UOM' ";
            DataTable UOMDt = common.GetCommonCode("*", "SigmaCode", UOMWhere);
            SigmaResult = SetErrMassage(UOMDt, "SigmaCode Table UOM");

            //Get Material Table
            string MtrWhere = "where DisciplineCode = 'DISCIPLINE_CIVIL'";
            DataTable MtrDt = common.GetCommonCode("*", "Material", MtrWhere);
            SigmaResult = SetErrMassage(MtrDt, "Material");

            //Get CostCode Table
            DataTable CostCodeDt = common.GetCommonCode("CostCodeId, CostCode", "CostCode", "");
            SigmaResult = SetErrMassage(CostCodeDt, "CostCode");

            //Get Discipline(SigmaCode Table)
            string DisciplineWhere = "where CodeCategory = 'DISCIPLINE' AND CodeName = 'Civil'";
            DataTable DisciplineDt = common.GetCommonCode("code", "SigmaCode", DisciplineWhere);
            SigmaResult = SetErrMassage(DisciplineDt, "SigmaCode Table DISCIPLINE");

            //Get TaskCatogory
            DataTable TaskCategoryDt = common.GetCommonCode("*", "TaskCategory", "where DisciplineCode = 'DISCIPLINE_CIVIL'");
            SigmaResult = SetErrMassage(TaskCategoryDt, "TaskCategory");
            int taskCategoryCnt = TaskCategoryDt.Rows.Count;
            int cnt1 = int.Parse(TaskCategoryDt.Rows[0][0].ToString());
            int cnt2 = int.Parse(TaskCategoryDt.Rows[taskCategoryCnt - 1][0].ToString());
            string where = "WHERE TaskCategoryId between " + cnt1 + " AND  " + cnt2;

            //Get TaskType
            DataTable TaskTypeDt = common.GetCommonCode("*", "TaskType", where);
            SigmaResult = SetErrMassage(TaskTypeDt, "TaskCategory");

            //StepRow의 Data 없는 경우 [progressStep Table 에서 ProgressStepId = 13|| Name = default progress의  Weight 값으로 처리]
            DataRow[] defaultStepRow = new DataTable().Select();// common.GetCommonCode("*", "ProgressStep", " Where Name = 'default progress'").Select();

            #endregion

            //Set Composite Data 
            DataTable CompoDt = CheckCompositeData(Exceldt);

            foreach (DataRow r in Exceldt.Rows)
            {
                #region  Validation Data
                DataRow[] CwpRow = null; DataRow[] TaskCategoryRow = null; DataRow[] TaskTypeRow = null; DataRow[] CostCodeRow = null;
                DataRow[] StepRow = null; DataRow[] UOMRow = null; DataRow[] MtrRow = null; DataRow[] comMaterRow = null;
                string MtrName = string.Empty;   int TaskCategoryId = 0;  int TaskTyeId = 0;    int CostCodeid = 0; 
                decimal ComQty = 0; string MultiQty = "N"; string TagNumber = string.Empty;
                string compositeMateral = string.Empty; decimal EstimatedManhour = 0; string EngTagNumber = string.Empty;

                List<TypeComponentProgress> listComponentProgress = new List<TypeComponentProgress>();

                //get Drawing Info
                DataTable DrawDt = common.GetCwpDrawing(r[loader.Ord_Drawing].ToString(), (r[loader.Ord_Revision].ToString()));
                SigmaResult = SetErrMassage(DrawDt, r[loader.Ord_Drawing].ToString());
                //get Choice UOM info
                string SelectUOMWhere = "CodeName = '" + r[loader.Ord_UOM] + "' OR CodeShortName = '" + r[loader.Ord_UOM] + "'";

                //Get CostCode Info
                if (!string.IsNullOrEmpty(r[loader.Ord_CostCode].ToString().Trim())) CostCodeRow = CostCodeDt.Select("CostCode = '" + r[loader.Ord_CostCode].ToString() + "'");
                if (CostCodeRow != null && CostCodeRow.Length > 0) CostCodeid = Convert.ToInt32(CostCodeRow[0][0].ToString());
                if (!string.IsNullOrEmpty(r[loader.Ord_CWP].ToString().Trim()))CwpRow = CwpdDt.Select("CwpName = '" + r[loader.Ord_CWP].ToString() + "'");
                if (!string.IsNullOrEmpty(r[loader.Ord_TaskCategory].ToString().Trim())) TaskCategoryRow = TaskCategoryDt.Select("TaskCategoryName = '" + r[loader.Ord_TaskCategory] + "'");
                if (!string.IsNullOrEmpty(r[loader.Ord_TaskType].ToString().Trim())) TaskTypeRow = TaskTypeDt.Select("TaskTypeName = '" + r[loader.Ord_TaskType] + "'");
                if (!string.IsNullOrEmpty(r[loader.Ord_MaterialDescription].ToString().Trim()))MtrName = r[loader.Ord_MaterialDescription].ToString();
                if (!string.IsNullOrEmpty(r[loader.Ord_EngTagNumber].ToString().Trim())) EngTagNumber = r[loader.Ord_EngTagNumber].ToString();
                if (!string.IsNullOrEmpty(r[loader.Ord_UOM].ToString().Trim())) UOMRow = UOMDt.Select(SelectUOMWhere);
                if(TaskCategoryRow != null && TaskCategoryRow.Length > 0 )TaskCategoryId = int.Parse(TaskCategoryRow[0][0].ToString());
                if(TaskTypeRow != null && TaskTypeRow.Length > 0 )TaskTyeId = int.Parse(TaskTypeRow[0][0].ToString());
                if (!string.IsNullOrEmpty(r[loader.Ord_AssoCompoMaterial].ToString().Trim())) compositeMateral = r[loader.Ord_AssoCompoMaterial].ToString();

                string MtrNameWhere = " AND Description = '" + MtrName + "'";

                //Check Exist material name 
                if (TaskCategoryRow.Length > 0 && TaskTypeRow.Length > 0)
                {
                    MtrRow = MtrDt.Select("TaskCategoryId = '" + TaskCategoryRow[0][0] + "' " +
                                    "AND TaskTypeId = '" + TaskTypeRow[0][0] + "' " + MtrNameWhere);
                }

                if(UOMRow.Length > 0)
                {
                    UOMRow = MtrDt.Select("TaskCategoryId = '" + TaskCategoryRow[0][0] + "' " +
                                    "AND TaskTypeId = '" + TaskTypeRow[0][0] + "' AND UomCode = '" +UOMRow[0][0] + "'");
                }

                //MaterialDescription & AssociatedComposite Material Description
                if (compositeMateral != string.Empty)
                {
                    comMaterRow = CompoDt.Select("MaterialDescription ='" + compositeMateral + "'");
                }

                #endregion 
  
                #region Set ProgressStep
                //Check ProgressStep Table
                StepRow = common.GetProgressStepByTaskCategoryTaskType(TaskCategoryId, TaskTyeId).Select();
                ComQty = Convert.ToDecimal(r[loader.Ord_Qty]);

                if (StepRow.Length != 0)
                {
                    foreach (DataRow Step in StepRow)
                    {
                        TypeComponentProgress obj = new TypeComponentProgress();
                        MultiQty = Step["IsMultipliable"].ToString();

                        if (MultiQty == "Y") // ProgressStep > IsMultipliable(MultipliedByQty) = "Y" 
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        else
                        {
                            obj.EstimatedManhours = (Convert.ToDecimal(Step["Weight"]) / 100) * Convert.ToDecimal(MtrRow.Length > 0 ? MtrRow[0]["Manhours"] : 0) * ComQty;//Manhours*weight*Qty 2014.3.31  임시 IsMultipliable 구분 없도록
                            obj.ProgressStepId = int.Parse(Step["ProgressStepId"].ToString());
                        }
                        EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                        listComponentProgress.Add(obj);
                    }
                }
                else
                {
                    TypeComponentProgress obj = new TypeComponentProgress();
                    obj.EstimatedManhours = (defaultStepRow.Length > 0 ? Convert.ToDecimal(defaultStepRow[0]["weight"]) : 100) * ComQty;
                    obj.ProgressStepId = defaultStepRow.Length > 0 ? int.Parse(defaultStepRow[0]["ProgressStepId"].ToString()) : 0;
                    EstimatedManhour = EstimatedManhour + obj.EstimatedManhours;
                    listComponentProgress.Add(obj);
                }
                

                #endregion 

                #region 1. Set ImportHistory(SuccessCount/FailCount)
                //ImportHistoryId 값 구하기 위해
                if (HisCnt == 0)
                {
                    SigmaResultType AddResult = AddImportHistory(0, 0, FileName, "MTO");
                    ImportHistoryId = Convert.ToInt32(AddResult.ScalarValue);
                    HisCnt = 1;// ImportHistory Table 한번만 입력
                }
                #endregion

                #region 2.  Set ErrDataTable
              
            if (CwpRow.Length == 0 || CwpRow == null)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The drawing type of [CWP] doesn’t exist. ";
                Failcnt = Failcnt + 1;
            }
            else if (DrawDt.Rows.Count == 0)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The drawing type of [Drawing Number] doesn’t exist. ";
                Failcnt = Failcnt + 1;
            }
            else if (TaskCategoryDt.Rows.Count == 0 || TaskCategoryRow.Length == 0)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + r[loader.Ord_TaskCategory].ToString() + "]";
                Failcnt = Failcnt + 1;
            }
            else if (TaskTypeDt.Rows.Count == 0 || TaskTypeRow.Length == 0)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + r[loader.Ord_TaskType].ToString() + "]";
                Failcnt = Failcnt + 1;
            }
            else if (MtrRow == null || MtrRow.Length == 0)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + r[loader.Ord_MaterialDescription].ToString() + "]";
                Failcnt = Failcnt + 1;
            }
            else if (UOMRow == null || UOMRow.Length == 0)
            {
                ErrDataTable.Rows.Add(r.ItemArray);
                ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + r[loader.Ord_UOM].ToString() + "]";
                Failcnt = Failcnt + 1;
            }
            //else if (CostCodeRow == null || CostCodeRow.Length == 0)
            //{
            //    ErrDataTable.Rows.Add(r.ItemArray);
            //    ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + r[loader.Ord_CostCode].ToString() + "]";
            //    Failcnt = Failcnt + 1;
            //}
            //else if (comMaterRow != null && comMaterRow.Length == 0)
            //{
            //    ErrDataTable.Rows.Add(r.ItemArray);
            //    ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + compositeMateral + "]";
            //    Failcnt = Failcnt + 1;
            //}
            else
            {
                #endregion

                #region 3. Set & Save Component

                    #region 3.1 Set Tag Number

                if (!string.IsNullOrEmpty(r[loader.Ord_TagNumber].ToString().Trim()))
                    TagNumber = r[loader.Ord_TagNumber].ToString().Trim();
                else
                {
                    string name = string.Empty;

                    if (MtrName.Length > 3)
                    {
                        name = MtrName.Substring(0, MtrName.Length);
                    }

                    if ((comMaterRow != null && comMaterRow.Length > 0) || MtrName.Contains("Composite")) //Composite data가 있으면 TagNumber : CO-drawing number-sequence number
                    {
                        TagNumber = MTOImportHelper.GetCreateTagNumber(TmGroupDt, r[loader.Ord_Drawing].ToString().Trim(), "CO");
                    }
                    else
                    {
                        TagNumber = MTOImportHelper.GetCreateTagNumber(TmGroupDt, r[loader.Ord_Drawing].ToString().Trim(), string.Empty);//drawing number-sequence number
                    }
                }

                #endregion 
                cmpt.CwpId = int.Parse(CwpRow[0][0].ToString());
                cmpt.DrawingId = Convert.ToInt32(DrawDt.Rows[DrawDt.Rows.Count - 1]["DrawingId"]);
                cmpt.MaterialId = Convert.ToInt32(MtrRow[0][0]);//metarial table data 있어야 함
                cmpt.TagNumber = TagNumber;
                cmpt.Qty = ComQty;
                cmpt.ScheduledWorkItemId = 0;
                cmpt.IsoLineNo = 0;
                cmpt.EstimatedManhour = EstimatedManhour;// Material의 manhours * Qty
                cmpt.ImportHistoryId = ImportHistoryId;
                cmpt.Description = MtrName;//Material Name
                cmpt.EngTagNumber = EngTagNumber;
                cmpt.CreatedBy = userinfo.SigmaUserId;
                SigmaResult = comMgr.AddComponent(cmpt);
                ComponentID = SigmaResult.ScalarValue;//for ComponentCustomField insert
                #endregion

                #region 4.Set & Save ComponentReferenceDrawing
                crd.ComponentId = ComponentID;
                crd.DrawingId = int.Parse(DrawDt.Rows[0]["DrawingId"].ToString());
                crd.CreatedBy = userinfo.SigmaUserId;
                SigmaResult = crdMgr.AddComponentReferenceDrawing(crd);
                #endregion 

                #region 5. Set & Save ComponetCustomField[StructureNumber]

                if (r[loader.Ord_StructureNumber].ToString() != null)
                {
                    string FieldName = "Structure Number";
                    string ColumnValue = r[loader.Ord_StructureNumber].ToString();
                    string FieldWhere = "WHERE FieldName = '" + FieldName.Replace(" ","") + "'";
                    int customFieldId = 0;
                    DataRow[] customFieldRow = common.GetCommonCode("*", "CustomField", FieldWhere).Select();

                    if (customFieldRow.Count() > 0)
                    {
                        customFieldId = int.Parse(customFieldRow[0]["CustomFieldId"].ToString());
                    }
                    else
                    {
                        TypeCustomField rtn = new TypeCustomField();
                        rtn.FieldName = FieldName;
                        rtn.IsDisplayable = "Y";
                        CustomFieldMgr customFieldMtr = new CustomFieldMgr();
                        rtn = customFieldMtr.GetCustomField(rtn);
                        customFieldId = rtn.CustomFieldId;
                    }

                    ccf.CustomFieldId = customFieldId;
                    ccf.ComponentId = ComponentID;
                    ccf.Value = r[loader.Ord_StructureNumber].ToString();
                    ccf.CreatedBy = userinfo.SigmaUserId;
                    SigmaResult = CCFMgr.AddComponentCustomField(ccf);
                }

                #endregion

                #region 6. Set & Save ComponentProgress
                listComponentProgress.ForEach(x => x.ComponentId = ComponentID);
                listComponentProgress.ForEach(x => x.IsCompleted = "N");
                listComponentProgress.ForEach(x => x.AmountInstalled = 0);
                listComponentProgress.ForEach(x => x.SigmaOperation = "C");
                SigmaResult = cmpProMgr.MultiComponentProgress(listComponentProgress);
                #endregion

                #region 7. CustomField = "UD_" 인 경우[ComponentCustomField Table]
                //Excel 항목중에 "UD-"로 시작하는 것에 대해서 Validation 처리
                for (int i = 0; i < Exceldt.Columns.Count; i++)
                {
                    if (Exceldt.Columns[i].ToString().Substring(0, 3).ToUpper() == "UD_")
                    {
                        string RowValue = r.ItemArray.GetValue(i).ToString();
                        SigmaResult.IsSuccessful = CheckCustomField(Exceldt, Exceldt.Columns[i].ToString().Trim(), ComponentID, RowValue);
                    }
                }
                #endregion
            }
        }
 
        #region 8. Update Fail Count/Success Count(ImportHistory Table)
            Failcnt = Failcnt++;
            int iTotalCnt = Exceldt.Rows.Count;
            int iSuccessCnt = iTotalCnt - Failcnt;
            ImportHistory.ImportCategory = "MTO";
            ImportHistory.ImportedFileName = FileName;
            ImportHistory.ImportedDate = DateTime.Now.ToString();
            ImportHistory.TotalCount = iTotalCnt;
            ImportHistory.SuccessCount = iSuccessCnt;
            ImportHistory.FailCount = Failcnt;
            ImportHistory.UpdatedBy = userinfo.SigmaUserId;
            ImportHistory.ImportHistoryId = ImportHistoryId;
            SigmaResult = HistoryMgr.UpdateImportHistory(ImportHistory);

        #endregion 

            //ConvertExcel file && CSV file
            Export2Excel.ConvertExcelfromData(ErrDataTable, ImportHistoryId.ToString()+".xlsx", exportfilepath);
            Export2Excel.ConvertCSVFile(ErrDataTable, ImportHistoryId.ToString()+".csv", exportfilepath);

            return SigmaResult;
        }

        #region ImportMeterialLib (from Excel file)


        public SigmaResultType ImportMeterialLib(string filePath, string exportfilepath)
        {
            MaterialMgr materialMgr = new MaterialMgr();
            CostCodeMgr costCodeMgr = new CostCodeMgr();
            SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
            TaskCategoryMgr taskCategoryMgr = new TaskCategoryMgr();
            SigmaResultType sigmaResult = new SigmaResultType();
            TypeMaterial typeMaterial = new TypeMaterial();

            DataLoaderMaterialLib loader = new DataLoaderMaterialLib();

            DataTable Exceldt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);
            DataTable ErrDataTable = SetErrTable(Exceldt);

            int failCount = 0;
            int rowCount = Exceldt.Rows.Count;
            int columnCount = Exceldt.Columns.Count;

            if (rowCount > 0)
            {
                loader = MTOImportHelper.GetDataLoaderMaterialLib(Exceldt);

                string codeName = "ALL";
                string codeCategoryUOM = "UOM";
                string codeCategoryDiscipline = "DISCIPLINE";

                DataSet CostCodeDS = costCodeMgr.ListCostCodeForMaterial();
                DataSet SigmaCodeDisciplineDS = sigmaCodeMgr.ListSigmaCodeByCodeCategory(codeName, codeCategoryDiscipline);
                DataSet SigmaCodeUOMDS = sigmaCodeMgr.ListSigmaCodeByCodeCategory(codeName, codeCategoryUOM);
                DataRow DisciplineCode = SigmaCodeDisciplineDS.Tables[0].Select("CodeName = '" + Exceldt.Rows[0][loader.Ord_Disicipline] + "'").FirstOrDefault();
                DataSet TaskCategoryDS = taskCategoryMgr.ListTaskCategoryByDisciplineCode(DisciplineCode[0].ToString());
                DataSet TaskTypeDS = taskCategoryMgr.ListTaskTypeByDisciplineCode(DisciplineCode[0].ToString());

                foreach (DataRow row in Exceldt.Rows)
                {
                    bool isValidation = true;

                    #region Mandatory Check (*)

                    for (int i = 0; i < columnCount; i++)
                    {
                        if (Exceldt.Columns[i].ToString().Substring(0, 1).ToUpper() == "*" && string.IsNullOrEmpty(row.ItemArray.GetValue(i).ToString()))
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The value of [" + Exceldt.Columns[i].ToString() + "] is required.";
                            failCount = failCount + 1;
                            isValidation = false;
                            break;
                        }
                    }

                    #endregion Mandatory Check

                    #region Reference Check (SigmaCode Table)

                    DataRow Discipline = null;
                    if (isValidation)
                    {
                        Discipline = SigmaCodeDisciplineDS.Tables[0].Select("CodeName = '" + row[loader.Ord_Disicipline] + "'").FirstOrDefault();
                        if (Discipline == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_Disicipline].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    DataRow TaskCategory = null;
                    if (isValidation)
                    {
                        TaskCategory = TaskCategoryDS.Tables[0].Select("TaskCategoryName = '" + row[loader.Ord_TaskCategory] + "'").FirstOrDefault();
                        if (TaskCategory == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_TaskCategory].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    DataRow TaskType = null;
                    if (isValidation)
                    {
                        TaskType = TaskTypeDS.Tables[0].Select("TaskTypeName = '" + row[loader.Ord_TaskType] + "'").FirstOrDefault();
                        if (TaskType == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_TaskType].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    DataRow UOM = null;
                    if (isValidation)
                    {
                        UOM = SigmaCodeUOMDS.Tables[0].Select("CodeShortName = '" + row[loader.Ord_UOM] + "' OR CodeName = '" + row[loader.Ord_UOM] + "'").FirstOrDefault();
                        if (UOM == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_UOM].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    DataRow CostCode = null;
                    if (isValidation && !string.IsNullOrEmpty(row[loader.Ord_CostCode].ToString()))
                    {
                        CostCode = CostCodeDS.Tables[0].Select("CostCode = '" + row[loader.Ord_CostCode] + "'").FirstOrDefault();
                        if (CostCode == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_CostCode].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Reference Check

                    #region Duplication Check

                    if (isValidation)
                    {
                        string disciplineCode = Discipline["Code"].ToString().Trim();
                        string taskCategoryId = TaskCategory["TaskCategoryId"].ToString();
                        string taskTypeId = TaskType["TaskTypeId"].ToString();
                        string uomCode = UOM["Code"].ToString().Trim();
                        string description = row[loader.Ord_MaterialDescription] == null ? "" : row[loader.Ord_MaterialDescription].ToString();

                        DataSet MaterialDS = materialMgr.ListMaterialByDisciplineTaskCategory(disciplineCode, taskCategoryId, taskTypeId, description, uomCode);

                        if (MaterialDS.Tables[0].Rows.Count > 0)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "This data[Materail] is duplicated.";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Duplication Check

                    #region AddMaterial

                    if (isValidation)
                    {
                        typeMaterial.DisciplineCode = Discipline["Code"].ToString().Trim();
                        typeMaterial.TaskCategoryId = Utilities.ToInt32(TaskCategory["TaskCategoryId"].ToString().Trim());
                        typeMaterial.TaskTypeId = Utilities.ToInt32(TaskType["TaskTypeId"].ToString().Trim());
                        typeMaterial.Manhours = Utilities.ToDecimal(row[loader.Ord_ManHour].ToString().Trim());
                        typeMaterial.UomCode = UOM["Code"].ToString().Trim();
                        typeMaterial.Vendor = row[loader.Ord_Vendor].ToString();
                        typeMaterial.Description = row[loader.Ord_MaterialDescription].ToString().Trim();
                        typeMaterial.PartNumber = row[loader.Ord_PartNumber].ToString().Trim();
                        typeMaterial.CostCodeId = (CostCode == null) ? 0 : Utilities.ToInt32(CostCode["CostCodeId"].ToString().Trim());
                        typeMaterial.CreatedBy = userinfo.SigmaUserId;
                        
                        sigmaResult = materialMgr.AddMaterial(typeMaterial);

                        if (sigmaResult.IsSuccessful)
                        {
                            // CustomField
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (Exceldt.Columns[i].ToString().Substring(0, 3).ToUpper() == "UD_")
                                {
                                    string RowValue = row.ItemArray.GetValue(i).ToString();
                                    if (!string.IsNullOrEmpty(RowValue))
                                    {
                                        sigmaResult.IsSuccessful = CheckMaterialCustomField(Exceldt, Exceldt.Columns[i].ToString().Trim(), sigmaResult.ScalarValue, RowValue);
                                    }
                                }
                            }
                        }
                    }

                    #endregion AddMaterial

                }

                // Set ImportHistory(SuccessCount/FailCount)
                sigmaResult = AddImportHistory(Exceldt.Rows.Count, failCount, Path.GetFileName(filePath).ToString(), "MaterialLibrary");

                // ConvertExcel file && CSV file
                Export2Excel.ConvertExcelfromData(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".xlsx", exportfilepath);
                Export2Excel.ConvertCSVFile(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".csv", exportfilepath);

                sigmaResult.IsSuccessful = true;
            }
            else
            {
                sigmaResult.IsSuccessful = false;
                sigmaResult.ErrorMessage = "no record from file.";
            }

            return sigmaResult;
        }

        #endregion ImportMeterialLib

        #region ImportEquipmentLib (from Excel File)

        public SigmaResultType ImportEquipmentLib(string filePath, string exportfilepath)
        {
            EquipmentMgr equipmentMgr = new EquipmentMgr();
            SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
            SigmaResultType sigmaResult = new SigmaResultType();
            TypeEquipment typeEquipment = new TypeEquipment();
            DataLoaderEquipmentLib loader = new DataLoaderEquipmentLib();

            DataTable Exceldt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);
            DataTable ErrDataTable = SetErrTable(Exceldt);

            int failCount = 0;
            int rowCount = Exceldt.Rows.Count;
            int columnCount = Exceldt.Columns.Count;

            if (rowCount > 0)
            {
                loader = MTOImportHelper.GetDataLoaderEquipmentLib(Exceldt);

                string parentCodeCategory = "EQUIP%";
                string categoryName = "ALL";
                string codeCategory = "EQUIP_%";

                DataSet SigmaCodeCategoryDS = sigmaCodeMgr.ListSigmaCodeCategoryByParentCodeCategory(parentCodeCategory, categoryName);
                DataSet SigmaCodeDS = sigmaCodeMgr.ListSigmaCodeForEquipment(codeCategory);

                foreach (DataRow row in Exceldt.Rows)
                {
                    bool isValidation = true;

                    #region Mandatory Check (*)

                    for (int i = 0; i < columnCount; i++)
                    {
                        if (Exceldt.Columns[i].ToString().Substring(0, 1).ToUpper() == "*" && string.IsNullOrEmpty(row.ItemArray.GetValue(i).ToString()))
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The value of [" + Exceldt.Columns[i].ToString() + "] is required.";
                            failCount = failCount + 1;
                            isValidation = false;
                            break;
                        }
                    }

                    #endregion Mandatory Check

                    #region Reference Check (SigmaCodeCategory Table)

                    DataRow EquipmentCodeMain = null;
                    DataRow EquipmentCodeSub = null;
                    DataRow ThirdLevel = null;
                    if (isValidation)
                    {
                        EquipmentCodeMain = SigmaCodeCategoryDS.Tables[0].Select("CategoryName = '" + row[loader.Ord_EquipCodeMain] + "'").FirstOrDefault();
                        if (EquipmentCodeMain == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_EquipCodeMain].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }
                    if (isValidation)
                    {
                        EquipmentCodeSub = SigmaCodeCategoryDS.Tables[0].Select("ParentCodeCategory = '" + EquipmentCodeMain["CodeCategory"] + "' AND CategoryName = '" + row[loader.Ord_EquipCodeSub] + "'").FirstOrDefault();
                        if (EquipmentCodeSub == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_EquipCodeSub].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }
                    if (isValidation && !string.IsNullOrEmpty(row[loader.Ord_ThirdLevel].ToString()))
                    {
                        ThirdLevel = SigmaCodeDS.Tables[0].Select("CodeCategory = '" + EquipmentCodeSub["CodeCategory"] + "' AND CodeName = '" + row[loader.Ord_ThirdLevel] + "'").FirstOrDefault();
                        if (ThirdLevel == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_ThirdLevel].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Reference Check

                    #region Duplication Check

                    if (isValidation)
                    {
                        string equipmentCodeMain = row[loader.Ord_EquipCodeMain].ToString();
                        string equipmentCodeSub = row[loader.Ord_EquipCodeSub].ToString();
                        string thirdLevel = row[loader.Ord_ThirdLevel].ToString();
                        string spec = row[loader.Ord_Spec].ToString().Replace("'", "’");
                        string equipmentType = row[loader.Ord_EquipmentType].ToString();

                        DataSet EquipmentDS = equipmentMgr.ListMaterialByEquipmentCodeMain(equipmentCodeMain, equipmentCodeSub, thirdLevel, spec, equipmentType);

                        if (EquipmentDS.Tables[0].Rows.Count > 0)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "This data[Equipment] is duplicated.";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Duplication Check

                    #region AddEquipment

                    if (isValidation)
                    {
                        typeEquipment.EquipmentCodeMain = EquipmentCodeMain["CodeCategory"].ToString();
                        typeEquipment.EquipmentCodeSub = EquipmentCodeSub["CodeCategory"].ToString();
                        typeEquipment.ThirdLevel = (ThirdLevel == null) ? "" :ThirdLevel["Code"].ToString().Trim() ;
                        typeEquipment.Spec = row[loader.Ord_Spec].ToString().Replace("'", "’");
                        typeEquipment.EquipmentType = row[loader.Ord_EquipmentType].ToString();
                        typeEquipment.ModelNumber = row[loader.Ord_ModelNumber].ToString();
                        typeEquipment.Description = row[loader.Ord_Description].ToString();
                        typeEquipment.CreatedBy = userinfo.SigmaUserId;
                        
                        sigmaResult = equipmentMgr.AddEquipment(typeEquipment);

                        if (sigmaResult.IsSuccessful)
                        {
                            // CustomField
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (Exceldt.Columns[i].ToString().Substring(0, 3).ToUpper() == "UD_")
                                {
                                    string RowValue = row.ItemArray.GetValue(i).ToString();
                                    sigmaResult.IsSuccessful = CheckEquipmentCustomField(Exceldt, Exceldt.Columns[i].ToString().Trim(), sigmaResult.ScalarValue, RowValue);
                                }
                            }
                        }
                    }

                    #endregion AddEquipment

                }

                // Set ImportHistory(SuccessCount/FailCount)
                sigmaResult = AddImportHistory(Exceldt.Rows.Count, failCount, Path.GetFileName(filePath).ToString(), "EquipmentLibrary");

                // ConvertExcel file && CSV file
                Export2Excel.ConvertExcelfromData(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".xlsx", exportfilepath);
                Export2Excel.ConvertCSVFile(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".csv", exportfilepath);

                sigmaResult.IsSuccessful = true;
            }
            else
            {
                sigmaResult.IsSuccessful = false;
                sigmaResult.ErrorMessage = "no record from file.";
            }

            return sigmaResult;
        }

        #endregion ImportEquipmentLib

        #region ImportConsumableLib (from Excel file)

        public SigmaResultType ImportConsumableLib(string filePath, string exportfilepath)
        {
            MaterialMgr materialMgr = new MaterialMgr();
            SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
            CommonCodeMgr commonCodeMgr = new CommonCodeMgr();
            SigmaResultType sigmaResult = new SigmaResultType();
            TypeMaterial typeMaterial = new TypeMaterial();

            DataLoaderConsumableLib loader = new DataLoaderConsumableLib();

            DataTable Exceldt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);
            DataTable ErrDataTable = SetErrTable(Exceldt);

            int failCount = 0;
            int rowCount = Exceldt.Rows.Count;
            int columnCount = Exceldt.Columns.Count;

            string codeName = "ALL";
            string codeCategory = "UOM";

            if (rowCount > 0)
            {
                loader = MTOImportHelper.GetDataLoaderConsumableLib(Exceldt);

                DataSet SigmaCodeDS = sigmaCodeMgr.ListSigmaCodeByCodeCategory(codeName, codeCategory);

                foreach (DataRow row in Exceldt.Rows)
                {
                    bool isValidation = true;

                    #region Mandatory Check (*)

                    for (int i = 0; i < columnCount; i++)
                    {
                        if (Exceldt.Columns[i].ToString().Substring(0, 1).ToUpper() == "*" && string.IsNullOrEmpty(row.ItemArray.GetValue(i).ToString()))
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The value of [" + Exceldt.Columns[i].ToString() + "] is required.";
                            failCount = failCount + 1;
                            isValidation = false;
                            break;
                        }
                    }

                    #endregion Mandatory Check

                    #region Reference Check (SigmaCode Table)

                    DataRow UOM = null;
                    if (isValidation)
                    {
                        UOM = SigmaCodeDS.Tables[0].Select("CodeName = '" + row[loader.Ord_UOM] + "'").FirstOrDefault();
                        if (UOM == null)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_UOM].ToString() + "]";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Reference Check

                    #region Duplication Check

                    if (isValidation)
                    {
                        string vendor = row[loader.Ord_Vendor].ToString().Trim();
                        string description = row[loader.Ord_Description].ToString().Trim();
                        string partNumber = row[loader.Ord_PartNumber].ToString().Trim();
                        string uomCode = UOM["Code"].ToString().Trim();

                        DataSet ConsumableDS = materialMgr.ListMaterialByVendorPartNumber(vendor, description, partNumber, uomCode);
                        
                        if (ConsumableDS.Tables[0].Rows.Count > 0)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "This data[Consumable] is duplicated.";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Duplication Check

                    #region AddMaterial
                    
                    if (isValidation)
                    {
                        typeMaterial.DisciplineCode = "";           
                        typeMaterial.TaskCategoryId = 0;
                        typeMaterial.TaskTypeId = 0;
                        typeMaterial.Manhours = 0;
                        typeMaterial.UomCode = UOM["Code"].ToString().Trim();                  
                        typeMaterial.Vendor = row[loader.Ord_Vendor].ToString().Trim();
                        typeMaterial.Description = row[loader.Ord_Description].ToString().Trim();      
                        typeMaterial.PartNumber = row[loader.Ord_PartNumber].ToString().Trim();
                        typeMaterial.CostCodeId = 0;
                        typeMaterial.CreatedBy = userinfo.SigmaUserId;
                        
                        sigmaResult = materialMgr.AddMaterial(typeMaterial);

                        if (sigmaResult.IsSuccessful)
                        {
                            // CustomField
                            for (int i = 0; i < columnCount; i++)
                            {
                                if (Exceldt.Columns[i].ToString().Substring(0, 3).ToUpper() == "UD_")
                                {
                                    string RowValue = row.ItemArray.GetValue(i).ToString();
                                    sigmaResult.IsSuccessful = CheckMaterialCustomField(Exceldt, Exceldt.Columns[i].ToString().Trim(), sigmaResult.ScalarValue, RowValue);
                                }
                            }
                        }
                    }

                    #endregion AddMaterial
                }

                // Set ImportHistory(SuccessCount/FailCount)
                sigmaResult = AddImportHistory(Exceldt.Rows.Count, failCount, Path.GetFileName(filePath).ToString(), "ConsumableLibrary");

                // ConvertExcel file && CSV file
                Export2Excel.ConvertExcelfromData(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".xlsx", exportfilepath);
                Export2Excel.ConvertCSVFile(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".csv", exportfilepath);

                sigmaResult.IsSuccessful = true;
            }
            else
            {
                sigmaResult.IsSuccessful = false;
                sigmaResult.ErrorMessage = "no record from file.";
            }

            return sigmaResult;
        }

        #endregion ImportConsumableLib

        #region ImportDrawingTypeLib (from Excel file)

        public SigmaResultType ImportDrawingTypeLib(string filePath, string exportfilepath)
        {
            SigmaCodeMgr sigmaCodeMgr = new SigmaCodeMgr();
            CommonCodeMgr commonCodeMgr = new CommonCodeMgr();
            SigmaResultType sigmaResult = new SigmaResultType();
            TypeSigmaCode typeSigmaCode = new TypeSigmaCode();

            DataLoaderDrawingType loader = new DataLoaderDrawingType();

            DataTable Exceldt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);
            DataTable ErrDataTable = SetErrTable(Exceldt);

            int failCount = 0;
            int rowCount = Exceldt.Rows.Count;
            int columnCount = Exceldt.Columns.Count;

            if (rowCount > 0)
            {
                loader = MTOImportHelper.GetDataLoaderDrawingType(Exceldt);

                string codeCategory = "DRAWING_TYPE";

                foreach (DataRow row in Exceldt.Rows)
                {
                    bool isValidation = true;

                    #region Mandatory Check (*)

                    for (int i = 0; i < columnCount; i++)
                    {
                        if (Exceldt.Columns[i].ToString().Substring(0, 1).ToUpper() == "*" && string.IsNullOrEmpty(row.ItemArray.GetValue(i).ToString()))
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "The value of [" + Exceldt.Columns[i].ToString() + "] is required.";
                            failCount = failCount + 1;
                            isValidation = false;
                            break;
                        }
                    }

                    #endregion Mandatory Check

                    #region Reference Check (SigmaCode Table)

                    //DataRow DrawingType = null;
                    //if (isValidation)
                    //{
                    //    DrawingType = SigmaCodeDT.Select("CodeName = '" + row[loader.Ord_DrawingType] + "'").FirstOrDefault();
                    //    if (DrawingType == null)
                    //    {
                    //        ErrDataTable.Rows.Add(row.ItemArray);
                    //        ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "There is no item in the library to match up with the value of [" + row[loader.Ord_DrawingType].ToString() + "]";
                    //        failCount = failCount + 1;
                    //        isValidation = false;
                    //    }
                    //}

                    #endregion Reference Check

                    #region Duplication Check

                    if (isValidation)
                    {
                        string codeName = row[loader.Ord_DrawingType].ToString();

                        DataSet SigmaCodeDS = sigmaCodeMgr.ListSigmaCodeByCodeCategory(codeName, codeCategory);
                        
                        if (SigmaCodeDS.Tables[0].Rows.Count > 0)
                        {
                            ErrDataTable.Rows.Add(row.ItemArray);
                            ErrDataTable.Rows[ErrDataTable.Rows.Count - 1]["Fail Reason"] = "This data[Drawing Type] is duplicated.";
                            failCount = failCount + 1;
                            isValidation = false;
                        }
                    }

                    #endregion Duplication Check

                    #region AddSigmaCode

                    if (isValidation)
                    {
                        typeSigmaCode.Code = "";
                        typeSigmaCode.CodeCategory = codeCategory;
                        typeSigmaCode.CodeName = row[loader.Ord_DrawingType].ToString().Trim();
                        typeSigmaCode.CodeShortName = row[loader.Ord_DrawingType].ToString().Trim();
                        typeSigmaCode.RefChar = "";
                        typeSigmaCode.RefNo = "";
                        typeSigmaCode.Description = row[loader.Ord_Description].ToString();
                        typeSigmaCode.IsActive = "Y";
                        typeSigmaCode.SortOrder = "";
                        typeSigmaCode.SigmaOperation = "C";
                        typeSigmaCode.CreatedBy = userinfo.SigmaUserId;

                        sigmaResult = sigmaCodeMgr.AddSigmaCode(typeSigmaCode);
                    }

                    #endregion AddSigmaCode

                }

                // Set ImportHistory(SuccessCount/FailCount)
                sigmaResult = AddImportHistory(Exceldt.Rows.Count, failCount, Path.GetFileName(filePath).ToString(), "DrawingType");

                // ConvertExcel file && CSV file
                Export2Excel.ConvertExcelfromData(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".xlsx", exportfilepath);
                Export2Excel.ConvertCSVFile(ErrDataTable, sigmaResult.ScalarValue.ToString() + ".csv", exportfilepath);

                sigmaResult.IsSuccessful = true;
            }
            else
            {
                sigmaResult.IsSuccessful = false;
                sigmaResult.ErrorMessage = "no record from file.";
            }

            return sigmaResult;
        }

        #endregion ImportDrawingTypeLib

        #region Common  Method

        /// <summary>
        /// 2014-03-15 
        /// Set Err Massage 
        /// </summary>
        /// <returns></returns>
        private SigmaResultType SetErrMassage(DataTable dt, string name)
        {
            SigmaResultType Result = new SigmaResultType();
            Result.JsonDataSet = JsonHelper.convertDataTableToJson(dt);

            if (!Result.IsSuccessful)
            {
                Result.IsSuccessful = false;
                Result.StringValue = name + "  better check!!!";
            }

            return Result;
        }

        /// <summary>
        /// 2014-03-10
        /// Get AssociatedTagNumberCombo
        /// Data > MTO > Assocated Tag Number Combo Box
        /// </summary>
        /// <param name="DrawingId"></param>
        /// <param name="Gubun">1</param> 1:Associated Tag Num 
        /// <returns></returns>
        public SigmaResultType GetTagNumberCombo(int DrawingId, int Gubun)
        {
            SigmaResultType Result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DrawingId", DrawingId),
                new SqlParameter("@Gubun", Gubun)
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTagNumberComboByDrawingId", parameters);
            Result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            Result.IsSuccessful = true;
            return Result;

          }

        /// <summary>
        /// Make Composite Data Table
        /// </summary>
        /// <param name="Exceldt"></param>
        /// <returns></returns>
        private DataTable CheckCompositeData(DataTable Exceldt)
        {
            Exceldt.Columns["*Task Category"].ColumnName = "TaskCategory";
            Exceldt.Columns["*Material Description"].ColumnName = "MaterialDescription";

            string composite = "Composite";
            DataRow[] comRow = Exceldt.Select("TaskCategory = '" + composite + "'" +
                                                " AND MaterialDescription LIKE '" + composite + "%'");

            DataTable compositeDT = new DataTable();
            compositeDT = Exceldt.Copy();
            compositeDT.Rows.Clear();

            for (int i = 0; i < comRow.Length; i++)
            {
                compositeDT.Rows.Add(comRow[i].ItemArray);
            }

            return compositeDT;
        }

        /// <summary>
        /// Excel File 항목중에서 "UD-" 시작하는 이름은 CustomField Table 에서 유무확인후 ComponentCustomField Table에 입력
        /// </summary>
        /// <returns></returns>
        private bool  CheckCustomField(DataTable Exceldt, string ColName, int ComponentId, string CustomFieldValue)
        {
            bool bResult = false;
            CommonCodeMgr common = new CommonCodeMgr();
            TypeCustomField Typecf = new TypeCustomField();
            CustomFieldMgr CustFieldMgr = new CustomFieldMgr();
            TypeComponentCustomField Typeccf = new TypeComponentCustomField();
            ComponentCustomFieldMgr ccfMgr = new ComponentCustomFieldMgr();

            string CustomFieldWhere = string.Empty;
            DataRow[] cfRow = null;

            CustomFieldWhere = "WHERE FieldName like '" + ColName + "'";
            cfRow = common.GetCommonCode("CustomFieldId, FieldName", "CustomField", CustomFieldWhere).Select();

            if (cfRow.Length > 0)//CustomField Table에 있으면 ComponentCustomField Table에만 입력
            {
                Typeccf.ComponentId = ComponentId;
                Typeccf.CustomFieldId = Convert.ToInt32(cfRow[0][0]);
                Typeccf.Value = CustomFieldValue;
                Typeccf.CreatedBy = userinfo.SigmaUserId;
                bResult = ccfMgr.AddComponentCustomField(Typeccf).IsSuccessful;

            }
            else //CustomField Table & ComponentCustomField Table 에 입력
            {
                Typecf.FieldType = "STRING";
                Typecf.FieldName = ColName;
                Typecf.IsDisplayable = "Y";
                Typecf.CreatedBy = userinfo.SigmaUserId;

                bResult = CustFieldMgr.AddCustomField(Typecf).IsSuccessful;

                if (bResult == true)
                {
                    int CustomFieldId = Convert.ToInt32(CustFieldMgr.AddCustomField(Typecf).ScalarValue.ToString());

                    Typeccf.ComponentId = ComponentId;
                    Typeccf.CustomFieldId = CustomFieldId;
                    Typeccf.Value = CustomFieldValue;
                    Typeccf.CreatedBy = userinfo.SigmaUserId;
                    bResult = ccfMgr.AddComponentCustomField(Typeccf).IsSuccessful;
                }

            }

            return bResult;
        }

        private bool CheckMaterialCustomField(DataTable Exceldt, string ColName, int MaterialId, string CustomFieldValue)
        {
            CommonCodeMgr common = new CommonCodeMgr();
            CustomFieldMgr customFieldMgr = new CustomFieldMgr();
            MaterialMgr materialMgr = new MaterialMgr();
            MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();

            TypeCustomField customField = new TypeCustomField();
            TypeMaterialCustomField materialCustomField = new TypeMaterialCustomField();

            SigmaResultType mResult = new SigmaResultType();
            SigmaResultType cResult = new SigmaResultType();

            DataSet CustomFiledSD = materialCustomFieldMgr.ListMaterialCustomFieldByFieldName(ColName);

            if (CustomFiledSD.Tables[0].Rows.Count > 0)  // CustomField Table 동일 FieldName이 있으면 MaterialCustomField Table 입력
            {
                DataRow CustomFiledSR = CustomFiledSD.Tables[0].Rows[0];
                materialCustomField.MaterialId = MaterialId;
                materialCustomField.CustomFieldId = Convert.ToInt32(CustomFiledSR["CustomFieldId"].ToString());
                materialCustomField.Value = CustomFieldValue;
                materialCustomField.CreatedBy = userinfo.SigmaUserId;

                mResult = materialMgr.AddMaterialCustomField(materialCustomField);
            }
            else // CustomField Table & MaterialCustomField Table 에 입력
            {
                customField.FieldName = ColName;
                customField.IsDisplayable = "Y";
                customField.CreatedBy = userinfo.SigmaUserId;

                cResult = customFieldMgr.AddCustomField(customField);

                if (cResult.IsSuccessful)
                {
                    materialCustomField.MaterialId = MaterialId;
                    materialCustomField.CustomFieldId = cResult.ScalarValue;
                    materialCustomField.Value = CustomFieldValue;
                    materialCustomField.CreatedBy = userinfo.SigmaUserId;

                    mResult = materialMgr.AddMaterialCustomField(materialCustomField);
                }
            }

            return mResult.IsSuccessful;
        }

        private bool CheckEquipmentCustomField(DataTable Exceldt, string ColName, int EquipmentId, string CustomFieldValue)
        {
            CommonCodeMgr common = new CommonCodeMgr();
            CustomFieldMgr customFieldMgr = new CustomFieldMgr();
            EquipmentMgr equipmentMgr = new EquipmentMgr();
            MaterialCustomFieldMgr materialCustomFieldMgr = new MaterialCustomFieldMgr();

            TypeCustomField customField = new TypeCustomField();
            TypeEquipmentCustomField equipmentCustomField = new TypeEquipmentCustomField();
            
            SigmaResultType mResult = new SigmaResultType();
            SigmaResultType cResult = new SigmaResultType();

            DataSet CustomFiledSD = materialCustomFieldMgr.ListMaterialCustomFieldByFieldName(ColName);
            DataRow CustomFiledSR = CustomFiledSD.Tables[0].Rows[0];

            if (CustomFiledSD.Tables[0].Rows.Count > 0)
            {
                equipmentCustomField.EquipmentId = EquipmentId;
                equipmentCustomField.CustomFieldId = Convert.ToInt32(CustomFiledSR["CustomFieldId"].ToString());
                equipmentCustomField.Value = CustomFieldValue;
                equipmentCustomField.CreatedBy = userinfo.SigmaUserId;

                mResult = equipmentMgr.AddEquipmentCustomField(equipmentCustomField);
            }
            else
            {
                customField.FieldName = ColName;
                customField.IsDisplayable = "Y";
                customField.CreatedBy = userinfo.SigmaUserId;

                cResult = customFieldMgr.AddCustomField(customField);

                if (cResult.IsSuccessful)
                {
                    equipmentCustomField.EquipmentId = EquipmentId;
                    equipmentCustomField.CustomFieldId = cResult.ScalarValue;
                    equipmentCustomField.Value = CustomFieldValue;
                    equipmentCustomField.CreatedBy = userinfo.SigmaUserId;

                    mResult = equipmentMgr.AddEquipmentCustomField(equipmentCustomField);
                }
            }

            return mResult.IsSuccessful;
        }

        #region Set Add ImportHistory Info
        /// <summary>
        /// Set Add ImportHistory Info
        /// </summary>
        /// <param name="iTotalCnt"></param>
        /// <param name="FailCnt"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private SigmaResultType AddImportHistory(int iTotalCnt, int FailCnt, string FileName, string ImportCategory)
        {
            SigmaResultType HistoryResult = new SigmaResultType();
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistoryMgr HistoryMgr = new ImportHistoryMgr();

            //DB Date로 하기 말고.
            DateTime convertedDate = DateTime.Parse(DateTime.Now.ToString());
            DateTime localDate = convertedDate.ToLocalTime();

            int Failcnt = FailCnt++;
            int iSuccessCnt = iTotalCnt - Failcnt;
            ImportHistory.ImportCategory = ImportCategory;
            ImportHistory.ImportedFileName = FileName;
            ImportHistory.ImportedDate = localDate.ToString();
            ImportHistory.TotalCount = iTotalCnt;
            ImportHistory.SuccessCount = iSuccessCnt;
            ImportHistory.FailCount = Failcnt;
            ImportHistory.CreatedBy = userinfo.SigmaUserId;//임시
            return HistoryResult = HistoryMgr.AddImportHistory(ImportHistory);
        }
        #endregion 

        #region Make ErrTable
        /// <summary>
        /// Make ErrTable
        /// </summary>
        /// <param name="Exceldt"></param>
        /// <returns></returns>
        private DataTable SetErrTable(DataTable Exceldt)
        {
            DataTable ErrDataTable = new DataTable("ErrDataTable");
            ErrDataTable = Exceldt.Copy();
            ErrDataTable.Rows.Clear();
            ErrDataTable.Columns.Add("Fail Reason");
            return ErrDataTable;
        }
        #endregion 

        #region Make TagNumber(drawing number-sequence number)
        /// <summary>
        /// Make TagNumber(drawing number-sequence number)
        /// </summary>
        /// <param name="Exceldt"></param>
        /// <returns></returns>
        private DataTable SetTagNumber(DataTable Exceldt)
        {
            DataTable TmGroupDt = new DataTable();

            //Drawing Number
            var groupedData = from b in Exceldt.AsEnumerable()
                              group b by b.Field<string>("*Drawing Number").Trim() into g
                              where g.Count() > 1
                              select g.Key;

            
            DataColumn TmpCol1 = TmGroupDt.Columns.Add("Tag_Number", typeof(string));
            DataColumn TmpCol2 = TmGroupDt.Columns.Add("no", typeof(int));

            DataRow workRow2;

            for (int i = 0; i < groupedData.ToList().Count; i++)
            {
                workRow2 = TmGroupDt.NewRow();
                workRow2[0] = groupedData.ToList()[i].ToString().Trim();
                workRow2[1] = 0;
                TmGroupDt.Rows.Add(workRow2);
            }
            return TmGroupDt;
        }

        #endregion 

        /// <summary>
        /// Get Discipline Info[MTO]
        /// </summary>
        /// <param name="CwpName">CwpName</param>
        /// <param name="CwpId">CwpId</param>
        /// <returns></returns>
        public SigmaResultType GetDiscipline(string CwpName, string CwpId)
        {
            SigmaResultType Result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpName", CwpName),
                new SqlParameter("@CwpId", int.Parse(CwpId))
            };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDiscipline", parameters);
            Result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            Result.IsSuccessful = true;

            return Result;
        }

        #endregion 

        #region MULTI MTO DELETE[Component/ComponentCustomField/ComponentProgress]
        /// <summary>
        /// MULTI MTO DELETE[Component/ComponentCustomField/ComponentProgress]
        /// </summary>
        /// <param name="listCom">TypeComponent</param>
        /// <returns></returns>
        public SigmaResultType DeleteMTO(List<TypeComponent> listCom)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            ComponentMgr comMgr = new  ComponentMgr();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

               foreach (TypeComponent anObj in listCom)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "D":
                            comMgr.DeleteMTO(anObj);
                            break;
                    }
                }
 
                scope.Complete();

            return result;
        }
        #endregion 

    }
}
