$(function(){
	
	(function($)
	{
         $.fn.menuSlide = function() {
           var left = $(this).position().left;
		   console.log("Left: "+ left);
           $("#menuSlider").animate({ left : left }, { duration: 400, queue: false });
           return this;
         }; 
      })(jQuery);
      
	 $("ul.menu li a").click(function(e) {
      	e.preventDefault();
      	index.movePage($(this.hash));
    });
    
    // Scroll Spy
    $(window).scroll(function() 
    {
      	var top = $(window).scrollTop() + 60; // Take into account height of fixed menu
      	$(".slide").each(function()
      	{
        	var c_top = $(this).offset().top;
        	var c_bot = c_top + $(this).height();
        	var id = $(this).attr("id");
        	var li_tag = $('a[href$="' + id + '"]').parent();
        	if ((top > c_top) && (top < c_bot))
        	{
        		li_tag.menuSlide();
        	}
      });
    });
}); // end of document ready
