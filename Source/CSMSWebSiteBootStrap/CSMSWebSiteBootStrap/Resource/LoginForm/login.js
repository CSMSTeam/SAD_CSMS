$(function() {
	$(document).tooltip({
		position : {
			my : "left top",
			at : "right+5 top-5"
		}
	});
});

function checkLogin(formName){
	//Check if username is null
	var username = document.forms[formName]["txtUsername"].value;
	if (username == "" || username == null){
		$("#txtUsername").attr("title", "Username is required!");
		$("#txtUsername").tooltip({
			position : {
				my : "left top",
				at : "right+5 top-5"
			},
			open : function(event, ui) {
				ui.tooltip.css('background', 'white');
				ui.tooltip.css('border', '1 solid black');
			}
		});
		$("#txtUsername").focus();
		return false;
	}
	//Check if password is null
	var password = document.forms[formName]["txtPassword"].value;
	if (password == ""|| password == null){
		$("#txtPassword").attr("title", "Password is required!");
		$("#txtPassword").tooltip({
			position : {
				my : "left top",
				at : "right+5 top-5"
			},
			open : function(event, ui) {
				ui.tooltip.css('background', 'white');
				ui.tooltip.css('border', '1 solid black');
			}
		});
		$("#txtPassword").focus();
		return false;
	}
	return true;
}