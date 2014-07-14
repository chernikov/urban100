/**
 * @author Chernikov
 */

function Index() {
	var _this = this;
	
	this.num = 1;
	this.maxNum = 3;
	this.animate = false;
    this.inProcess = false;
	this.init = function ()
	{
	    _this.initSnapscroll();

	    $(".slider-menu .dots .dot").click(function () {
			var id = $(this).data("id");
			_this.movePage($("#slide" +id));
		});
		
		_this.setSlider(1);
		
		$(".switcher .item").click(function() {
			var dataNum = $(this).data("num");
			_this.changeImage(dataNum);
		});
		$("#gotoUp").click(function() {
			_this.movePage($("#slide1"));
		});
		
		$(".cell.active").click(function ()
		{
		    $(".tooltip").hide();
		    $(".tooltip", $(this)).show();
		});

		$(".tooltip .close").click(function(e)
		{
		    $(".tooltip").hide();
		    e.stopPropagation();
		});
		$(".tooltip").hide();


		$(document).on("click", ".add-popup .close, .add-popup .close-btn", function () {
		    $("#PopupWrapper").empty();
		});

		$(document).on("change", "input[name=Ask]", function () {

		    var value = $(this).val();
		    $(".text-notes").hide();
		    $(".text-notes[data-type="+value+"]").show();
		});

		$("#ShowAddPopup").click(function () {
		    $.ajax({
		        type: "GET",
		        url: "/Home/AddPopup",
		        success: function (data) {
		            $("#PopupWrapper").html(data);
		        }
		    });
		});

		$(document).on("focus", "#Name", function () {
		    $("#Name").attr("placeholder", "Імя, Прізвище");
		    $("#Name").removeClass("error");
		    $("#Name").removeClass("input-validation-error");
		});

		$(document).on("focus", "#Phone", function () {
		    $("#Phone").attr("placeholder", "Телефон");
		    $("#Phone").removeClass("error");
		});
		$(document).on("focus", "#Email", function () {
		    $("#Email").attr("placeholder", "Електропошта");
		    $("#Email").removeClass("error");
		});
		$(document).on("click", "#AddPopupBtn", function () {
		    $.ajax({
		        type: "POST",
		        url: "/Home/AddPopup",
		        data: $("#AddForm").serialize(),
		        success: function (data) {
		            $("#PopupWrapper").html(data);
		        }
		    });
		    return false;
		});
	};

    this.initSnapscroll = function() {
        $('ul.content').snapscroll({
            callback: function (el) {
                console.log(el.attr("id"));
                var $slider = $("#" + el.attr("id"));
                _this.setPage($slider);
            },
            before : function() {
                return _this.inProcess;
            }
        });
    }
	
    this.movePage = function (indexSlide) {
        _this.inProcess = true;
	    $('html, body').animate({ scrollTop: indexSlide.offset().top }, { duration: 400, queue: false });
	    _this.setPage(indexSlide);
	    _this.inProcess = false;
	};
	
	this.setPage = function(indexSlide) 
	{
      	var id = indexSlide.data("id");
      	_this.setSlider(id);
	};
	
	this.setSlider = function(id) 
	{
	    $(".tooltip").hide();
	    $("#PopupWrapper").empty();
		if (id == 1) {
			$("#rightMenu").hide();	
			$("#gotoUp").hide();
		} else {
			$("#rightMenu").show();
			$("#gotoUp").show();
			var top =  (32 * id-46);
			$("#rightMenu .square").css({top : top +"px"});
		}
		if (id == 8) {
			$("#scrollDownHint").hide();
		} else {
			$("#scrollDownHint").show();
		}
		if (id == 3) {
			_this.startChangeImage();
		} else {
			_this.stopChangeImage();
		}
	};
	
	this.changeImage = function(num) {
		_this.num = num;
		var css= "url('/Content/images/images/"+num+".jpg')";
		$("#slide3").css("background-image", css);
		$(".switcher .item").removeClass("active");
		$(".switcher .item[data-num='"+num+"']").addClass("active");
	};
	
	this.startChangeImage = function() {
		
		$("#slide3 .progressed").css({width :  "0px"});
		_this.animate = true;
		$("#slide3 .progressed").animate({width :  "700px"}, 3000, function() {
			_this.num = _this.num+1;
			if (_this.num > _this.maxNum) {
				_this.num = 1;
			}
			_this.changeImage(_this.num);
			_this.startChangeImage();
		});
		
	};
	
	this.stopChangeImage = function() {
		_this.animate = false;
	};
}


var index = null;
$(function() {
	index = new Index();
	index.init();
});

