$(document).ready(function () {
	$("#search-text").change(function () {
		var text = $(this).val().toLowerCase();
		$("tr.building").each(function () {
			var name = $(this).find("td.name").html().toLowerCase();
			if (name.indexOf(text) >= 0) {
				$(this).show();
			}
			else {
				$(this).hide();
			}
		});
	});
	$("#search-clear").click(function () {
		$("tr.building").show();
		$("#search-text").val('');
	});
})