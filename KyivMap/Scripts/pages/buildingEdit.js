$(document).ready(function() {
	$('#EndBuildingYear').change(function() {
		$('#StartUseYear').val($(this).val());
	});

	$("#wikisearch").select2({
		placeholder: "Искать в Wikipedia",
		minimumInputLength: 3,
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
		$("#Name").val(title);
		$("#Url").val(url);
		onNameChanged();

		$.get("/Image/GetFromWiki", { url: url }, function (data) {
			$("#Image").val(data.image);
			$("#upload-image").attr("src", data.image);
		});

		//$.get("/Wiki/GetBuildingInfo", { title: title }, function(data) {

		//});
	});

	$("#Name").change(onNameChanged);

	$("#url-go").click(function() {
		var url = $("#Url").val();
		var html = '<a href = "' + url + '" target="_blank"></a>';
		$(html).appendTo('body').get(0).click();
	});

	$("#Image").change(function() {
		$("#upload-image").attr("src", $(this).val());
	});
});

function onNameChanged() {
	var name = $("#Name").val();
	name = name.replace(' (Киев)', '').replace(' (станция метро)', ' (метро)').replace(' (станция метро, Киев)', ' (метро)');
	$("#Name").val(name);
	
	var key = toTitleCase(name.replace(/[^А-Яа-я ]/g, '').translit()).split(' ').join('');
	$("#Key").val(key);
	
	if (name.contains('метро')) {
		$('#Type').val(6) //Subway
	}
	
	if (name.contains('ЖК')) {
		$('#Type').val(1) //ЖК
	}
}