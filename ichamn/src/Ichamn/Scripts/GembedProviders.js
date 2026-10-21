
function Providers()
{
/************** Image provider ****************/
	this.isImageFn = function(url)
	{
		if (url.length > 3)
		{
			 var extension = url.substr(url.length-4,4);
			 if ((extension == ".jpg")|(extension == ".png")|(extension == ".gif")|(extension == ".bmp")|(extension == "jpeg"))
			 {
				return true;
			 }
		}
		return false;	
	};
	
	this.getEmbedImageFn = function(url)
	{
		var data = { "url" : url};
		return $( "#imageTemplate" ).tmpl( data )[0].outerHTML;
	};
	
	this.getImageProvider = function()
	{
	    return new OEmbedProvider('ImageProvider',this.isImageFn,this.getEmbedImageFn);
	};
	
/************** Link provider ****************/

	this.isLinkFn = function(url)
	{
		return true;	
	};

	this.getEmbedLinkFn = function (urlname) {
	    var url;
	    if (urlname.indexOf("www") == 1) {
	        url = "http://" + urlname;
	    } else {
	        url = urlname;
	    }
	    var data = { "url": url, "urlname": urlname };
	    return $("#linkTemplate").tmpl(data)[0].outerHTML;
	};
	
	this.getLinkProvider = function()
	{
	    return new OEmbedProvider('LinkProvider',this.isLinkFn,this.getEmbedLinkFn);
	};
	
/************** Youtube provider ****************/	
/*	http://www.youtube  or www.youtube  */
	this.isYoutubekFn = function (url) {
	    if (getQueryParams(url).v) {
	        if (url.indexOf("http://www.youtube") != -1) {
	            return true;
	        }

	        if (url.indexOf("www.youtube") != -1) {
	            return true;
	        }
	    }
	    return false;
	};
			
	this.extractYoutubeData = function(url)
	{
		return getQueryParams(url);
	};
	
	this.getEmbedYoutubeFn = function(url)
	{
		var data = this.provider.extractYoutubeData(url);
		return $( "#youtubeTemplate" ).tmpl( data )[0].outerHTML;
	};
	
	this.getYoutubeProvider = function()
	{
	    return new OEmbedProvider('YoutubeProvider',this.isYoutubekFn,this.getEmbedYoutubeFn,this);
	};
	


}