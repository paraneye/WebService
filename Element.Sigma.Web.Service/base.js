/*
Written by hitapia(sbang)
Role : base model, collection, view
*/
var app = app || {};
Backbone.Model.prototype.setByName = function(key, value, options) { 
    var setter = {}; 
    setter[key] = value; 
    this.set(setter, options); 
};
Element.View = Backbone.View.extend({
    page : {
        title : "" 
    },
    url : "",
    dev : false,
	render : function(){ }
});
Element.Model = Backbone.Model.extend({
	idAttribute : "",
	test : "",
	apply : function(dom, type, options){
		app.component.LoadingData(true);
		$.ajax({ 
			url : this.urlRoot,
			data : JSON.stringify({ paramObj : this.toJSON() }),
			dataType : "json",
			contentType : 'application/json',
			type : type,
			success : function(response){
				app.component.LoadingData(false);
				if(response.IsSuccessful) {
					options.s(null, response);
				}else{
					Element.Tools.Error(response.ErrorMessage);
					options.e(null, response.ErrorMessage);
				}
			},
			error : function(xhr, errorText, errorCode){
				app.component.LoadingData(false);
				Element.Tools.Error(errorText);
				options.e(xhr, errorText);
			}	
		});
	},
	parse : function(data){
		if(app.config.debug)
			app.Debug("Model Parse", JSON.stringify(data));

		if(data.IsSuccessful){
			return JSON.parse(data.JsonDataSet)[0];
		}else{
			Element.Tools.Error(data.ErrorMessage);
			return null;
		}
	},
	render : function(){ }
});
Element.Collection = Backbone.Collection.extend({
	parse : function(data){
		if(app.config.debug)
			app.Debug("Collection Fetch & Parse ( " +this.url+ " ) ", JSON.stringify(data));

		if(data.IsSuccessful){
			return JSON.parse(data.JsonDataSet);
		}else{
			return null;
		}
	},
	render : function(){ }
});
var ThisViewPage = null;
var ThisPopViewPage = null;
Element.Router = Backbone.Router.extend({
	header : null,
	unsignedheader : null,
	subheader : null,
	contenttop : null,
	dir : "",
	initialize : function(){
		app.GetLoginInfo();
	},
	setbase : function(){
		var self = this;
		if(Element.Tools.GetCookie("logininfo")){
			//signed page
			self.header = self.header || new app.header();
			self.subheader = self.subheader || new app.subheader();
			self.contenttop = self.contenttop || new app.content_top();
		
			$("#header").html(self.header.render().el);
			$("#contenttop").html(self.contenttop.render().el);
			if(app.loggeduser.ProjectList.length > 0){
				$("#subheader").html(self.subheader.render().el);
			}else{
				$("#subheader").hide();
			}
		}else{
			//un-signed page
			self.unsignedheader = self.unsignedheader || new app.unsignedheader();
			$(".sga_header").html(self.unsignedheader.render().el);
			$("body").css("background", "#093a60");
		}

		app.Nav();
	},
	switchview : function(view){
		app.caller = 0;
		if(!view.options.anony){
			if(!app.CheckLogged()){
				app.Logout();
			}
		}

		if(ThisViewPage){
			ThisViewPage.remove();
		}
	
		ThisViewPage = view;
		this.setbase();
		this.baserender();
		$("#container").html(view.render().el);
	
		if(app.loggeduser.Id != ""){
			app.GetLoginInfo();
		}
	},
	options : function(params){
		var value = { page : 1, s_opt : "", s_val : "", o_opt : "", o_val : "" };
		if(params == null)
			return value;
		var conditions = params.split('&');
		_(conditions).each(function(condition) {
			condition = condition.split('=');
			switch(condition[0]){
				case "page" : 
					value.page = condition[1];
					break;
				case "s_opt" :
				   	value.s_opt = condition[1];
					break;
				case "s_val" :
				   	value.s_val = condition[1];
					break;
				case "o_opt" :
				   	value.o_opt = condition[1];
					break;
				case "o_val" :
				   	value.o_val = condition[1];
				   	break;
                default:
                    value[condition[0]] = condition[1];
                    break;
			}
		});
		return value;
	}
});

Element.Tools = {
	Paging : function(key){
		ThisViewPage.paging(key);
	},
	LinkClick: function (key) {
	    // ThisViewPage.link(key);
	    ThisViewPage.link.apply(this, arguments); // modified by bk to accept multiple keys from LinkClick.
	},
	GetPageName : function(){
		var tmp = location.href.split("#");
		var linknameinfo = ("#" + tmp[1]).split("?");
		var linkname = linknameinfo[0];
		return linkname;
	},
	MakeNav : function(obj, el){
		var per = (obj.length == 5) ? "20" : "32";
		$(el).find("li").remove();
		_.each(obj, function(menu){
			var m = $("<li>").css("width", per+"%");
			if(menu.Link){
				m.append("<a href=\"javascript:Element.Tools.GoLink('"+menu.Name+"', '"+menu.Link+"');\">"+menu.Name+"</a></i>");
			}else{
				m.append("<a href\"javascript:Element.Tools.GoLink('', 'NOLINK');\">"+menu.Name+"</a>");
			}
			if(menu.menus.length > 0){
				m.append("<i class='fa fa-plus'>");
				m.append("<ul>");
				_.each(menu.menus, function(submenu){
					m.find("ul").append("<li><a href=\"javascript:Element.Tools.GoLink('"+submenu.Name+"', '"+submenu.Link+"');\">"+submenu.Name+"</a></li>");
				});
			}
			el.append(m);
		});
	},
	GoLink : function(name, link){
		switch(link){
			case "UNDER" :
				Element.Tools.Error("This page is under construction", "info");
				break;
			case "NOLINK" :
				break;
			default : 
				Element.Tools.SetCookie("pagename", name);
				window.location.href = link;
		}
	},
	QueryGens : function(query, opt1 , val1, opt2, val2){
		var v = [];
		if(query.page) v.push("page="+query.page);
		switch(opt1){
			case "page" : query.page = val1; break;
			case "s_opt" : query.s_opt = val1; break;
			case "s_val" : query.s_val = val1; break;
			case "o_opt" : query.o_opt = val1; break;
			case "o_val" : query.o_val = val1; break;
		}
		switch(opt2){
			case "page" : query.page = val2; break;
			case "s_opt" : query.s_opt = val2; break;
			case "s_val" : query.s_val = val2; break;
			case "o_opt" : query.o_opt = val2; break;
			case "o_val" : query.o_val = val2; break;
		}
		if(query.s_val){ v.push("s_opt="+query.s_opt); v.push("s_val="+query.s_val); }
		if(query.o_val){ v.push("o_opt="+query.o_opt); v.push("o_val="+query.o_val); }
		for (k in query) {
			if(k != "page" && k != "s_opt" && k != "s_val" && k != "o_opt" && k != "o_val" && k != "offset" && k != "max"){
				v.push(k+"="+query[k]);
			}
		}
		L(v);
		return (v.length > 0) ? "?" + v.join("&") : "";
	},
	QueryGen : function(query, opt , val){
		var v = [];
		for (k in query) {
			if(k != "page" && k != "s_opt" && k != "s_val" && k != "o_opt" && k != "o_val" && k != "offset" && k != "max"){
				v.push(k+"="+query[k]);
			}
		}
		switch(opt){
			case "page" : query.page = val; break;
			case "s_opt" : query.s_opt = val; break;
			case "s_val" : query.s_val = val; break;
			case "o_opt" : query.o_opt = val; break;
			case "o_val" : query.o_val = val; break;
		}
		if(query.page) v.push("page="+query.page);
		if(query.s_val){
			v.push("s_opt="+query.s_opt);
			v.push("s_val="+query.s_val);
		}
		if(query.o_val){
			v.push("o_opt="+query.o_opt);
			v.push("o_val="+query.o_val);
		}
		return (v.length > 0) ? "?" + v.join("&") : "";
	},
	Validate : function(form){
		var s = true;
		_.each($(form).find(".required"), function(item){
			$(item).parent().parent().removeClass("has-error");
		});
		_.each($(form).find(".required"), function(item){
			if($(item).val() == "" && s){
				$(item).parent().parent().addClass("has-error");
				$(item).focus();
				s = false;
			}
		});
		_.each($(form).find(".d_number"), function(item){			
			if($(item).val().match(/^[-]?\d+(?:[.]\d+)?$/)==null){
				$(item).parent().parent().addClass("has-error");
				$(item).focus();
				s = false;
			}
		});
		_.each($(form).find(".d_email"), function(item){			
			if($(item).val().match(/^[\w]{4,}@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/)==null){
				$(item).parent().parent().addClass("has-error");
				$(item).focus();
				s = false;
			}
		});
		_.each($(form).find(".d_phone"), function(item){			
			if($(item).val().match(/[0-9|-]$/g)==null){
				$(item).parent().parent().addClass("has-error");
				$(item).focus();
				s = false;
			}
		});
		return s;
	},
	ValidateCheck : function(form, msg){
	    var sel = $(form).find("input[type='checkbox']:checked").length;
		if(sel == 0)
			Element.Tools.Error(msg || "Please select at least one item to delete", "info");
		return (sel > 0) ? true : false;
	},
	Error : function(msg){
		if($("#errormsg").length > 0){
			$("#errormsg").text(msg);
			return;
		}
		var cl = (arguments[1]) ? arguments[1] : "danger";
		var cn = (cl == "danger") ? "Error" : "";
		var error = $("<div/>").
			addClass("alert-dismissable").addClass("alert-"+cl).addClass("alert").
			css("width", "600px").
			css("left", "0").
			css("right", "0").
			css("margin-left", "auto").
			css("margin-right", "auto").
			css("position", "absolute");
		var msg = "<strong>"+cn+"</strong>&nbsp;&nbsp;"+msg;

		error.append(msg);
		error.css('top', '90px');
		$("body").append(error);
		if($("body").find(".layer_area").length > 0){
			$('.layer').fadeOut();
			$('.layer').remove();
		}
		error.delay(5000).fadeOut();
	},
	RESTGet : function(query){
		var v = "?";
		if(!query.hasOwnProperty("max")){
			if(app.config.paging.itemperpage == 1000000){
				v += "max="+app.config.paging.itemperpage+"&offset=0";
			}else{
				v += "max="+app.config.paging.itemperpage+"&offset="+(query.page-1)*app.config.paging.itemperpage;
			}
		}
		if(!query.hasOwnProperty(query.s_opt)){
			if(query.s_val)
				v += "&"+query.s_opt+"="+query.s_val;
		}
		if(!query.hasOwnProperty(query.o_val)){
			if(query.o_val)
				v += "&o_option="+query.o_opt+"&o_desc="+query.o_val;
		}

		for (k in query) {
			if(k != "page" && k != "s_opt" && k != "s_val" && k != "o_opt" && k != "o_val" && query[k] != ""){
				v += "&"+k+"="+query[k];
			}
		}

		
		return v;
	},
	SetCookie : function(cname, cvalue){
		var d = new Date();
		d.setTime(d.getTime()+(app.config.cookieexpirehour * 60 * 60 * 1000));
		var expires = "expires="+d.toGMTString();
		document.cookie = cname + "=" + cvalue + "; " + expires + ";path=/";
	},
	GetCookie : function(cname){
		var name = cname + "=";
		var ca = document.cookie.split(';');
		for(var i=0; i<ca.length; i++){
			var c = ca[i].trim();
			if (c.indexOf(name)==0) return c.substring(name.length,c.length);
		}
		return "";
	},
	DeleteCookie : function(cname){
		var expireDate = new Date();
		expireDate.setDate(expireDate.getDate() - 1);
		document.cookie = cname + "= " + "; expires=" + expireDate.toGMTString() + "; path=/";
	},
	Multi : function(url, data, dom, options){
		dom.find("button").attr("disabled", "disabled");
		if(app.config.debug)
			app.Debug("Model Request ( "+ url + ") ", JSON.stringify(data));

		app.component.LoadingData(true);
		$.ajax({ 
			url : url,
			data : JSON.stringify({ listObj : data }),
			dataType : "json",
			cache: false,
			contentType : 'application/json',
			type : "PUT",
			success : function(response){
				app.component.LoadingData(false);
				if(!response.IsSuccessful){
					Element.Tools.Error(response.ErrorMessage);
				}

				return (response.IsSuccessful) ? 
					options.s(null, response) : 
					options.e(null, response.ErrorMessage);
			},
			error : function(xhr, errorText, errorCode){
				app.component.LoadingData(false);
				options.e(xhr, errorText);
			}	
		});
	}
}
