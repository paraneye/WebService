/*
 * Wirtten by hitapia(sban)
 * Role : Starter & Common Value Setup
 * 현재 이 폴더 앱에서 사용할 부분에 대한 정의를 한다.
 */

var app = app || {};
app = {
	config : {
		title : "Element Sigma",
		debug : false,
		jsonp : false,
		cookieexpirehour : 1,
		project : null,
		plink : [],
        path : "/ui",
		domain : "",
		uploadpath : "/Common/FileHandler.ashx",
		docPath : {
			docs :  "/SigmaStorage/SigmaDoc/",
			template :  "/SigmaStorage/Template/",
			temp :  "/SigmaStorage/Temporary/",
			images : "/SigmaStorage/UploadedImage/"
		},
		filebase : "/SigmaStorage/",
		paging : {
			itemperpage : 10
		},
		downloads : {
		    costcodetemplate: "costcode/costcode_template.xlsx",
		    projectcostcodetemplate: "projectcostcode/projectcostcode_template.xlsx",
		    clientcostcodetemplate: "clientcostcode/clientcostcode_template.xlsx",
		    personnelstemplate: "personnel/personnels_template.xlsx",
		    userstemplate: "users/users_template.xlsx",
			drawingtemplate: "drawing/Import-DrawingList-Template.xlsx",
			meteriallibrarytemplate: "meteriallibrary/Import-MaterialLibrary-Template.xlsx",
			equipmentlibrarytemplate: "equipmentlibrary/Import-EquipmentLibrary-Template.xlsx",
			consumablelibrarytemplate: "consumablelibrary/Import-ConsumableLibrary-Template.xlsx",
			mtotemplate: "mto/Import-MTO-Template.xlsx"
		},
		tpl : {
			header : "/ui/common/tpl/tpl_header.html",
			subheader : "/ui/common/tpl/tpl_subheader.html",
			contenttop : "/ui/common/tpl/tpl_content_top.html",
			unsignedheader : "/ui/common/tpl/tpl_unsigned.html",
			footer : "/ui/common/tpl/tpl_footer.html"
		}
	},
	userprojectlist : null,
	caller : 0,
	loggeduser : {
		Id : "",
		Name : "",
		ProjectId: "",
		CompanyId: "",
        CompanyName: "",
		ModuleId : "",
		LoginDate : null,
        Perms : null
	},
	TemplateManager : {
		templates: {},
		getnocache: function(id, callback){
			$.get(id, function(template){ callback(template); });
		},
		get: function(id, callback){
			var self = this;
			var template = self.templates[id];
			if (template){
				callback(template);
			}else{
				$.get(id, function(template){
					self.templates[id] = template;
					callback(template);
				});
			}
		}
	},
	SetTitle : function(pages){
	},
	Logout : function(){
		app.userprojectlist = null;
		Element.Tools.DeleteCookie("logininfo");
		window.location = "/ui/#login";
	},
	Login : function(){
		Element.Tools.SetCookie("logininfo", JSON.stringify(app.loggeduser));
		//TODO : login 처리 이후 window.location 변경 
		window.location = "/ui/";
	},
	CheckLogged : function(){
		var logged = Element.Tools.GetCookie("logininfo");
		return (logged != undefined && logged != "") ? true : false;
	},
	GetLoginInfo : function(){
		var logged = Element.Tools.GetCookie("logininfo");
		if(logged != undefined && logged != ""){
			app.loggeduser = JSON.parse(logged);
			if(app.loggeduser.IsActivated == "N"){
				window.location = "/ui/#updatepassword";
				return;
			}
			Element.Tools.SetCookie("logininfo", JSON.stringify(app.loggeduser));
		}
	},
	Start : function(){ 		//Start App
	},
	Nav : function(){
		Element.Tools.MakeNav(ElementMenu.Project, $("#subheader ul"));
	},
	Debug : function(l, s){
		if($("#debug_log").length == 0){
			$("#debugger").html("<textarea id='debug_log' class='form-control' style='width:100%;height:100%'></textarea>");
		}
		
		$("#debug_log").val($("#debug_log").val() + l + " :\n\t" + s + "\n");
	}
};

//For Develop or Debugger - Start
function L(msg){
	console.log(msg);
}
//For Develop or Debugger - End
app.GetLoginInfo();

//basic model
(function($){
	app.page = Element.Model.extend({ defaults : { Id : "", Title : "" } });
	app.keyvalue = Element.Model.extend({ defaults : { Id : "", Name : "", Value : "" } });
	app.exception = Element.Model.extend({ defaults : { Id : "", Code : "", Message : "" } });

	app.pages = Element.Collection.extend({ model : app.page });
	app.keyvalues = Element.Collection.extend({ model : app.keyvalue });
	app.exceptions = Element.Collection.extend({ model : app.exception });
})(jQuery);

//for dev. and test
app.config.debug = true;
app.Start();
