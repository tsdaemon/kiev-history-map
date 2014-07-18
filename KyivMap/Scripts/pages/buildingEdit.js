$(document).ready(function() {
	$('#EndBuildingYear').change(function() {
		$('#StartUseYear').val($(this).val());
	});

	$("#wikisearch").select2({
		placeholder: "Искать в Wikipedia",
		minimumInputLength: 5,
		ajax: { 
			url: "http://ru.wikipedia.org/w/api.php",
			dataType: 'jsonp',
			data: function (term, page) {
				return {
					action: 'query',
					list:'search',
					srsearch: term,
					format:'json'
				};
			},
			results: function (data, page) { 
				return {
					results: $.map(data.query.search, function (val, i) {
						return { id: val.title, text: val.title };
					 })
				};
			}
		}
	}).on("change", function (e) {
		var title = e.val;
		var url = "http://ru.wikipedia.org/wiki/" + title;
		var name = title.replace(' (Киев)', '');
		var key = toTitleCase(name.replace(/[^А-Яа-я ]/g, '').translit()).split(' ').join('');
		
		$("#Name").val(name);
		$("#Key").val(key);
		$("#Url").val(url);
		
		$.get("/Image/GetFromWiki", { url: url }, function (data) {
			$("#Image").val(data.image);
			$("#upload-image").attr("src", data.image);
		});
		
		//$.ajax({
		//	url: "http://ru.wikipedia.org/w/api.php",
		//	dataType: 'jsonp',
		//	data: {
		//		action: 'query',
		//		titles: title,
		//		prop: 'images',
		//		format: 'json',
		//	},
		//	success: function(data) {
		//		var images = data.query.pages[Object.keys(data.query.pages)[0]].images;
		//		var image = images[0].title;
		//		for (var i = 0; i < images.length; i++) {
		//			var im = images[i].title;
		//			if (im.contains(name) || im.contains(key)) {
		//				image = im;
		//			}
		//		}
		//		if (image != null) {
		//			$.ajax({
		//				url: "http://ru.wikipedia.org/w/api.php",
		//				dataType: 'jsonp',
		//				data: {
		//					action: 'query',
		//					titles: image,
		//					prop: 'imageinfo',
		//					iiurlwidth: 300,
		//					iiprop: "url",
		//					format: 'json',
		//				},
		//				success: function(data) {
		//					var url = data.query.pages['-1'].imageinfo[0].url;
		//					$.get("/Image/UploadRemote", { url: url }, function (data) {
		//						$("#Image").val(data.image);
		//						$("#upload-image").attr("src", data.image);
		//					});
		//				}
		//			});
		//		}
		//	}
		//});
	});

	$("#Name").change(function() {
		var key = toTitleCase($(this).val().replace(/[^А-Яа-я ]/g, '').translit()).split(' ').join('');
		$("#Key").val(key);
	});

	$("#url-go").click(function() {
		var url = $("#Url").val();
		var html = '<a href = "' + url + '" target="_blank"></a>';
		$(html).appendTo('body').get(0).click();
	});

	$("#Image").change(function() {
		$("#upload-image").attr("src", $(this).val());
	});
});