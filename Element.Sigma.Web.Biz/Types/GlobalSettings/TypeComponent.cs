using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Element.Sigma.Web.Biz.Types.GlobalSettings
{
    [DataContract]
	[Serializable]
    public class TypeComponent
    {
	    [DataMember]
		public string SigmaOperation; // CRUD
		[DataMember]
		public int ComponentId;
		[DataMember]
		public int MaterialId;
		[DataMember]
		public int CwpId;
		[DataMember]
		public int DrawingId;
		[DataMember]
		public int ScheduledWorkItemId;
		[DataMember]
		public string TagNumber;
		[DataMember]
		public int ComponentProgressRatio;
		[DataMember]
		public int CompletedPercent;
		[DataMember]
		public decimal Qty;
        [DataMember]
        public decimal EstimatedManhour; // Qty * manhours
		[DataMember]
		public string Description;
		[DataMember]
		public int IsoLineNo;
		[DataMember]
		public string EngTagNumber;
		[DataMember]
        public int ImportHistoryId;
		[DataMember]
		public string CreatedBy;
		[DataMember]
		public string UpdatedBy;

        [DataMember]
        public List<TypeComponentCustomField> ComCustomField;
    }
}
