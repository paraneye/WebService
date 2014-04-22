using Element.Shared.Common;

using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Bus;
using OptimaJet.Workflow.Core.Parser;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;
using OptimaJet.Workflow.DbPersistence;

using System;
using System.Xml.Linq;
using WorkflowRuntime = OptimaJet.Workflow.Core.Runtime.WorkflowRuntime;

namespace Element.Sigma.Web.Biz.Workflow
{
    public class WorkflowInitMgr
    {
        public static string _ProcessName;
        public static object _GeneratorSource;

        private static volatile WorkflowRuntime _runtime;

        private static readonly object _sync = new object();

        /// <summary>
        /// WorkflowRuntime
        /// </summary>
        public static WorkflowRuntime Runtime
        {
            get
            {
                if (_runtime == null)
                {
                    lock (_sync)
                    {
                        if (_runtime == null)
                        {
                            var connectionString = ConnStrHelper.getDbConnString(); ;
                            var builder = GetDefaultBuilder(_ProcessName, _GeneratorSource);

                            _runtime = new WorkflowRuntime(new Guid("{8D38DB8F-F3D5-4F26-A989-4FDD40F32D9D}"))
                                .WithBuilder(builder)
                                .WithBus(new NullBus())
                                .WithRoleProvider(new WorkflowRoleMgr())
                                .WithRuleProvider(new WorkflowRuleMgr())
                                .WithRuntimePersistance(new RuntimePersistence(connectionString))
                                .WithPersistenceProvider(new DbPersistenceProvider(connectionString))
                                .SwitchAutoUpdateSchemeBeforeGetAvailableCommandsOn()
                                .Start();

                            _runtime.ProcessStatusChanged += new EventHandler<ProcessStatusChangedEventArgs>(_runtime_ProcessStatusChanged);
                        }
                    }
                }

                return _runtime;
            }
        }

        #region _runtime_ProcessStatusChanged : WorkflowRuntime 객채의 상태값변경 발생시 이벤트 처리

        /**********************************************************************************************
         * Mehtod   명 : _runtime_ProcessStatusChanged
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : WorkflowRuntime 객채의 상태값변경 발생시 이벤트 처리
         * Input    값 : 
         * Ouput    값 : 
         **********************************************************************************************/
        /// <summary>
        /// WorkflowRuntime 객채의 상태값변경 발생시 이벤트 처리
        /// 실질적인 데이터의 Update 처리를 이곳에서 함.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void _runtime_ProcessStatusChanged(object sender, ProcessStatusChangedEventArgs e)
        {
            // 1. 리스트 로딩시
            // WorkflowProcessInstance에 현상태값 등록
            // WorkflowProcessInstanceStatus에 현상태값(1) 등록

            if (e.NewStatus != ProcessStatus.Idled && e.NewStatus != ProcessStatus.Finalized)
                return;

            if (string.IsNullOrEmpty(e.ProcessName))
                return;

            // 1. 리스트 로딩시
            // WorkflowProcessTransitionHistory에 정보 등록
            // WorkflowProcessInstance의 데이터 수정
            // WorkflowProcessInstanceStatus에 현상태값(2) 수정
            WorkflowActionsMgr.DeleteEmptyPreHistory(e.ProcessId);
            _runtime.PreExecuteFromCurrentActivity(e.ProcessId);
        }

        #endregion

        #region GetDefaultBuilder : 사용할 Process를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetDefaultBuilder
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 사용할 Process를 가져온다.
         * Input    값 : GetDefaultBuilder(Process명, Generator명)
         *               ProcessName        - dbo.WorkflowScheme의 Code
         *               GeneratorSource    - dbo.WorkflowProcessScheme의 ProcessName
         * Ouput    값 : IWorkflowBuilder
         **********************************************************************************************/
        /// <summary>
        /// GetDefaultBuilder : 사용할 Process를 가져온다
        /// </summary>
        /// <param name="ProcessName">dbo.WorkflowScheme.Code</param>
        /// <param name="GeneratorSource">dbo.WorkflowProcessScheme.ProcessName</param>
        /// <returns>IWorkflowBuilder</returns>
        public static IWorkflowBuilder GetDefaultBuilder(string ProcessName, object GeneratorSource)
        {
            _ProcessName = ProcessName;
            _GeneratorSource = GeneratorSource;

            var connectionString = ConnStrHelper.getDbConnString();
            var generator = new DbXmlWorkflowGenerator(connectionString).WithMapping(ProcessName, GeneratorSource);
            var builder = new WorkflowBuilder<XElement>(generator, new XmlWorkflowParser(), new DbSchemePersistenceProvider(connectionString)).WithDefaultCache();

            return builder;
        }

        #endregion

        #region GetWorkflowBuilderXElement : 사용할 Process를 가져온다.

        /**********************************************************************************************
         * Mehtod   명 : GetWorkflowBuilderXElement
         * 개   발  자 : 양영석
         * 생   성  일 : 2014-02-18
         * 용       도 : 사용할 Process를 가져온다.
         * Input    값 : GetWorkflowBuilderXElement(Process명, Generator명)
         *               ProcessName        - dbo.WorkflowScheme의 Code
         *               GeneratorSource    - dbo.WorkflowProcessScheme의 ProcessName
         * Ouput    값 : WorkflowBuilder<XElement>
         **********************************************************************************************/
        /// <summary>
        /// GetWorkflowBuilderXElement : 사용할 Process를 가져온다
        /// </summary>
        /// <param name="ProcessName">dbo.WorkflowScheme.Code</param>
        /// <param name="GeneratorSource">dbo.WorkflowProcessScheme.ProcessName</param>
        /// <param name="ProcessName"></param>
        /// <param name="GeneratorSource"></param>
        /// <returns>WorkflowBuilder<XElement></returns>
        public WorkflowBuilder<XElement> GetWorkflowBuilderXElement(string ProcessName, object GeneratorSource)
        {
            return GetDefaultBuilder(ProcessName, GeneratorSource) as WorkflowBuilder<XElement>;
        }

        #endregion
    }
}
