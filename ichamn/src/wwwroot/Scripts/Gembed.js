
	var regUrl = /( www.[-a-zA-Z0-9@:%_\+.~#?&//=]+)|(http:[/][/][www.]?[-a-zA-Z0-9@:%_\+.~#?&;//=]+)|(https:[/][/][www.]?[-a-zA-Z0-9@:%_\+.~#?&;//=]+)/g;
	var providers;
	
	function initialize()
	{

	/*	$.get(pathname + "/Templates/Select/1", null, function (data) {
            $("#templateDiv").append(data);
        });*/
	}
	
	function getOEmbedProvider(url) {
        for (var i = 0; i < providers.length; i++) {
            if (providers[i].matches(url))
                return providers[i];
        }
        return null;
    }
		
	function OEmbedProvider(name, matchedFn, getEmbedFn,p_provider) {
        this.name = name;
        this.matchedFn = matchedFn;
        this.getEmbedFn = getEmbedFn;
		this.provider = p_provider;
		
        this.matches = function(urlPattern) 
		{
            return this.matchedFn(urlPattern);
        };
		
		this.embedCode = function(urlPattern)
		{
			return this.getEmbedFn(urlPattern);
		};
    };
	
	function getAllProviders()
    {
	    var oProv = new Providers();
		var imageProvider = oProv.getImageProvider();
		var linkProvider = oProv.getLinkProvider();
		var youtubeProvider = oProv.getYoutubeProvider();
		var result = [
			imageProvider,
			youtubeProvider,
			linkProvider			
		];
		return result;
	};
	
	function getUrlList(text)
	{
	    var newText = " " + text + " ";
		return newText.match(regUrl);
	};
	
	function getTransformation(url)
	{
		if (!providers)
		{
			providers = getAllProviders();
		}
		var i=0;
		for (i=0;i<providers.length;i++)
		{
			if (providers[i].matches(url))
			{
				return providers[i].embedCode(url);
			}
		}
		return '';
	}
	
	function getEmbedText(text)
	{
		var result = text;
		urlList = getUrlList(text);
	    if (urlList) {
	        var count;
	        for (count = 0; count < urlList.length; count++) {
	            var url = urlList[count];
	            url = url.trim(" ");
	            var transformedUrl = getTransformation(url);
	            result = result.replace(url, transformedUrl);
	        }
	    }
	    return result;
	};
	
	function getQueryParams(qs)
	{
		var ini = qs.indexOf("?");
		qs = qs.substring(ini+1,qs.length);
		qs = qs.split("+").join(" ");

		var params = {}, tokens,
			re = /[?&]?([^=]+)=([^&]*)/g;

		while (tokens = re.exec(qs)) {
			params[decodeURIComponent(tokens[1]).replace("&","").replace("amp;","")]
				= decodeURIComponent(tokens[2]);
		}

		return params;
	};
